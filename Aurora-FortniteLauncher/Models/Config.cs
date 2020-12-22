// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Models.Config
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Newtonsoft.Json;

namespace Aurora.Launcher.Models
{
  public class Config
  {
    [JsonProperty("DeviceAuth")]
    public DeviceAuth DeviceAuth { get; set; }

    [JsonProperty("Path")]
    public string Path { get; set; }
  }
}
