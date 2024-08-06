using Microsoft.Win32;
using ValveKeyValue;

namespace loa_optimizer_core;
public class SteamLocator {
  const string REG_STEAM_PATH_KEY = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam";
  const string REG_STEAM_INSTALL_PATH_VALUE = "InstallPath";

  internal class LibraryFolder {
    public string Path { get; set; }

    public Dictionary<string, string> Apps { get; set; }
  }

  static string GetSteamInstallPath() {
    var steamInstallPath = Registry.GetValue(REG_STEAM_PATH_KEY, REG_STEAM_INSTALL_PATH_VALUE, null);

    if(steamInstallPath == null) {
      return "";
    }

    return (string)steamInstallPath;
  }

  public static string FindGamePath(int gameId, string gameDirName) {
    var steamInstallPath = GetSteamInstallPath();

    if(steamInstallPath == "") {
      return "";
    }

    var stream = File.OpenRead($"{steamInstallPath}\\steamapps\\libraryfolders.vdf");

    var kv = KVSerializer.Create(KVSerializationFormat.KeyValues1Text);
    var libraryFolders = kv.Deserialize<Dictionary<string, LibraryFolder>>(stream);

    foreach(var libraryFolder in libraryFolders.Values) {
      if(!libraryFolder.Apps.ContainsKey(gameId.ToString())) {
        continue;
      }

      return Path.GetFullPath($"{libraryFolder.Path}\\steamapps\\common\\{gameDirName}");
    }
    return "";
  }
}
