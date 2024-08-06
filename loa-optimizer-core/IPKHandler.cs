using System.Text;

namespace loa_optimizer_core;
public class IPKHandler {
  Dictionary<string, string[]> nameEscapeDictionary;

  record UnescapeEntry(char character, int index);
  Dictionary<string, UnescapeEntry> nameUnescapeDictionary;


  private IPKHandler() { }


  public string ObfuscateFileName(string fileName) {
    var dotIndex = fileName.IndexOf('.');
    // SGINTRO_WARNING_USA
    string name = fileName.Substring(0, dotIndex == -1 ? fileName.Length : dotIndex).ToUpperInvariant();
    // .English.ipk
    string ext = "";
    if(dotIndex > -1) {
      ext = fileName.Substring(dotIndex).ToUpperInvariant();
    }

    string escapedName = EscapeString(name);

    var sb = new StringBuilder(fileName.Length);

    for(int i = 0; i < escapedName.Length; i++) {
      char c = escapedName[i];
      int temp = c;

      // Handle Numerals
      if(c >= '0' && c <= '9') {
        temp += 43;
      }

      int result = (escapedName.Length + 7 * (temp - 'A')) % 36 + 'A';

      if(result > 'Z') {
        result -= 43;
      }

      sb.Append((char)result);
    }

    // F3HGM8N1Q7X8GHG31BTFXEF.ENGLISH.IPK
    return $"{sb.ToString()}{ext}";
  }

  public string DeobfuscateFileName(string fileName) {
    var dotIndex = fileName.IndexOf('.');
    // F3HGM8N1Q7X8GHG31BTFXEF
    string name = fileName.Substring(0, dotIndex == -1 ? fileName.Length : dotIndex).ToUpperInvariant();
    // .English.ipk
    string ext = "";
    if(dotIndex > -1) {
      ext = fileName.Substring(dotIndex).ToUpperInvariant();
    }

    var sb = new StringBuilder(fileName.Length);

    for(int i = 0; i < name.Length; i++) {
      char c = name[i];
      int temp = c;

      // Handle Numerals
      if(c >= '0' && c <= '9') {
        temp += 43;
      }

      int result = (31 * (temp - name.Length - 'A') % 36 + 36) % 36 + 'A';

      if(result > 'Z') {
        result -= 43;
      }

      sb.Append((char)result);
    }

    // Unescape the name after Deobfuscation
    string unescapedName = UnescapeString(sb.ToString());

    // SGINTRO_WARNING_USA.ENGLISH.IPK
    return $"{unescapedName}{ext}";
  }

  private string EscapeString(string unescapedString) {
    var sb = new StringBuilder();

    for(int i = 0; i < unescapedString.Length; i++) {
      var c = unescapedString[i].ToString();
      if(!nameEscapeDictionary.ContainsKey(c)) {
        sb.Append(c);
        continue;
      }

      sb.Append(nameEscapeDictionary[c][sb.Length % nameEscapeDictionary[c].Length]);
    }

    for(int i = 0; i < 20 - unescapedString.Length; i++) {
      sb.Append(nameEscapeDictionary["!"][sb.Length % nameEscapeDictionary["!"].Length]);
    }


    return sb.ToString();
  }

  private string UnescapeString(string escapedString) {
    var output = new StringBuilder();
    int idx = 0;

    do {
      var cmp = escapedString.Substring(idx, 2);

      if(!nameUnescapeDictionary.ContainsKey(cmp)) {
        output.Append(escapedString[idx]);
        idx++;
        continue;
      }

      var pair = nameUnescapeDictionary[cmp];

      if(pair.index != idx % 4) {
        output.Append(escapedString[idx]);
        idx++;
        continue;
      }

      output.Append(pair.character);
      idx += 2;
    } while(idx < escapedString.Length - 1);

    if(idx == escapedString.Length - 1) {
      output.Append(escapedString[idx]);
    }

    output = output.Replace("!", null);

    return output.ToString();
  }

  public static IPKHandler New(Region region) {
    switch(region) {
      case Region.Korea:
        return new IPKHandlerKorea();
      case Region.Russia:
        return new IPKHandlerRussia();
      case Region.Global:
      default:
        return new IPKHandlerGlobal();
    }
  }
  private class IPKHandlerGlobal : IPKHandler {

    // Original reference:
    // https://www.gildor.org/smf/index.php/topic,3055.msg46444.html#msg46444
    // https://gist.github.com/molenzwiebel/284318d9e963672b239f9fca901be89a
    public IPKHandlerGlobal() {
      nameEscapeDictionary = new Dictionary<string, string[]>{
        {"Q", ["QP", "QD", "QW", "Q4"]},
        {"-", ["QL", "QB", "QO", "Q5"]},
        {"_", ["QC", "QN", "QT", "Q9"]},
        {"X", ["XU", "XN", "XH", "X3"]},
        {"!", ["XW", "XS", "XZ", "X0"]},
      };

      nameUnescapeDictionary = new Dictionary<string, UnescapeEntry> {
        {"QP", new('Q', 0) },
        {"QD", new('Q', 1) },
        {"QW", new('Q', 2) },
        {"Q4", new('Q', 3) },
        {"QL", new('-', 0) },
        {"QB", new('-', 1) },
        {"QO", new('-', 2) },
        {"Q5", new('-', 3) },
        {"QC", new('_', 0) },
        {"QN", new('_', 1) },
        {"QT", new('_', 2) },
        {"Q9", new('_', 3) },
        {"XU", new('X', 0) },
        {"XN", new('X', 1) },
        {"XH", new('X', 2) },
        {"X3", new('X', 3) },
        {"XW", new('!', 0) },
        {"XS", new('!', 1) },
        {"XZ", new('!', 2) },
        {"X0", new('!', 3) },
      };
    }
  }

  private class IPKHandlerKorea : IPKHandler {
    public IPKHandlerKorea() {
      throw new NotImplementedException();
    }
  }

  private class IPKHandlerRussia : IPKHandler {
    public IPKHandlerRussia() {
      throw new NotImplementedException();
    }
  }
}


public enum Region {
  Korea,
  Global,
  Russia
}