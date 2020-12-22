// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Providers.LauncherInstalled
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aurora.Launcher.Providers
{
  public class LauncherInstalled
  {
    [JsonProperty("InstallationList")]
    public List<Installation> InstallationList { get; set; }
  }
}
