// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Providers.EpicLauncher
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Aurora.Launcher.Providers
{
  public static class EpicLauncher
  {
    public static List<Installation> GetInstallLocations()
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat");
      if (!Directory.Exists(Path.GetDirectoryName(path)))
        return new List<Installation>();
      return !File.Exists(path) ? new List<Installation>() : ((LauncherInstalled) JsonConvert.DeserializeObject<LauncherInstalled>(File.ReadAllText(path))).InstallationList;
    }
  }
}
