// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Providers.Installation
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Newtonsoft.Json;

namespace Aurora.Launcher.Providers
{
  public class Installation
  {
    [JsonProperty("InstallLocation")]
    public string InstallLocation { get; set; }

    [JsonProperty("AppName")]
    public string AppName { get; set; }

    [JsonProperty("AppVersion")]
    public string AppVersion { get; set; }
  }
}
