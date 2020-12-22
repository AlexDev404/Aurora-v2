// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Models.DeviceAuth
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Newtonsoft.Json;

namespace Aurora.Launcher.Models
{
  public class DeviceAuth
  {
    [JsonProperty("deviceId")]
    public string DeviceId { get; set; }

    [JsonProperty("accountId")]
    public string AccountId { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }
  }
}
