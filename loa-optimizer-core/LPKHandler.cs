namespace loa_optimizer_core;
public class LPKHandler {
  public static LPKHandler New(Region region) {
    switch(region) {
      case Region.Korea:
        return new LPKHandlerKorea();
      case Region.Russia:
        return new LPKHandlerRussia();
      case Region.Global:
      default:
        return new LPKHandlerGlobal();
    }
  }
}

public class LPKHandlerGlobal : LPKHandler {

}

public class LPKHandlerKorea : LPKHandler {
  public LPKHandlerKorea() {
    throw new NotImplementedException();
  }
}

public class LPKHandlerRussia : LPKHandler {
  public LPKHandlerRussia() {
    throw new NotImplementedException();
  }
}

public enum Region {
  Korea,
  Global,
  Russia
}