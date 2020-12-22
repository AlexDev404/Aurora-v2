// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Endpoints
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using System.Runtime.InteropServices;

namespace Aurora.Launcher
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct Endpoints
  {
    public const string WebsiteBase = "https://aurorafn.dev/";
    public const string ApiBase = "https://api.aurorafn.dev/";
    public const string Version = "https://aurorafn.dev/api/version";
    public const string OAuth = "https://api.aurorafn.dev/account/api/oauth/token";
    public const string Exchange = "https://api.aurorafn.dev/account/api/oauth/exchange";

    public static string DeviceAuth(string accountId) => "https://api.aurorafn.dev/account/api/public/account/" + accountId + "/deviceAuth";
  }
}
