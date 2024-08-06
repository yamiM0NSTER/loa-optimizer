using loa_optimizer_core;

namespace loa_optimizer;
internal class Optimizer {
  const string ORIGINAL_INTRO_FILE_NAME = "SGINTRO_WARNING_USA"; // obfuscated: F3HGM8N1Q7X8GHG31BTFXEF

  string _path;
  loa_optimizer_core.Region _region;
  public Optimizer(string path, loa_optimizer_core.Region region) {
    _path = path;
    _region = region;
  }

  public void Optimize(bool disableIntro) {
    OptimizeIntro(disableIntro);
  }

  void OptimizeIntro(bool disableIntro) {
    var moviesPath = Path.Combine(_path, "EFGame\\Movies");
    var handler = IPKHandler.New(loa_optimizer_core.Region.Global);
    var obfuscatedName = handler.ObfuscateFileName(ORIGINAL_INTRO_FILE_NAME);

    var translateDictionary = new Dictionary<string, string>() {
      { $"{obfuscatedName}.English.ipk", $"{obfuscatedName}.English.ipk.bak"},
      { $"{obfuscatedName}.French.ipk", $"{obfuscatedName}.French.ipk.bak"},
      { $"{obfuscatedName}.German.ipk", $"{obfuscatedName}.German.ipk.bak"},
      { $"{obfuscatedName}.Spanish.ipk", $"{obfuscatedName}.Spanish.ipk.bak"},
    };

    if(disableIntro) {
      foreach(var pair in translateDictionary) {
        try {
          var originalFilePath = Path.Combine(moviesPath, pair.Key);

          if(!File.Exists(originalFilePath)) {
            continue;
          }

          var backupFilePath = Path.Combine(moviesPath, pair.Value);

          File.Move(originalFilePath, backupFilePath);
        } catch { }
      }

      return;
    }

    foreach(var pair in translateDictionary) {
      try {
        var backupFilePath = Path.Combine(moviesPath, pair.Value);

        if(!File.Exists(backupFilePath)) {
          continue;
        }

        var originalFilePath = Path.Combine(moviesPath, pair.Key);

        File.Move(backupFilePath, originalFilePath);
      } catch { }
    }

  }
}
