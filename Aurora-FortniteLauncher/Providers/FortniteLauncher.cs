// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Providers.FortniteLauncher
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Aurora.Launcher.Utilities;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Aurora.Launcher.Providers
{
  public class FortniteLauncher
  {
    private Process _clientProcess;
    private Process _antiCheatProcess;

    public async Task StartGame(
      string arguments,
      bool injectNative = true,
      string antiCheat = null,
      string path = null)
    {
      FortniteLauncher fortniteLauncher = this;
      string tempDirPath = Path.Combine(Path.GetTempPath(), "FortniteClient-Win64-Shipping_" + (antiCheat ?? "BE") + ".exe");
      Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aurora.Launcher.Resources.FortniteClient-Win64-Shipping_" + (antiCheat ?? "BE") + ".exe");
      FileStream file = new FileStream(tempDirPath, FileMode.Create, FileAccess.ReadWrite);
      FileStream fileStream = file;
      await manifestResourceStream.CopyToAsync((Stream) fileStream);
      file.Close();
      fortniteLauncher._antiCheatProcess = new Process()
      {
        StartInfo = new ProcessStartInfo(tempDirPath, arguments)
        {
          UseShellExecute = false,
          CreateNoWindow = true
        }
      };
      fortniteLauncher._antiCheatProcess.Start();
      fortniteLauncher._clientProcess = new Process()
      {
        StartInfo = new ProcessStartInfo(path ?? Path.Combine(AuroraConfig.Get()?.Path, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe"), arguments)
        {
          UseShellExecute = false,
          CreateNoWindow = true
        }
      };
      fortniteLauncher._clientProcess.Start();
      if (injectNative)
        Injector.Inject(fortniteLauncher._clientProcess.Id, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Aurora.Runtime.dll"));
      await fortniteLauncher._clientProcess.WaitForExitAsync();
      fortniteLauncher._antiCheatProcess.Kill();
      Thread.Sleep(200);
      File.Delete(tempDirPath);
      tempDirPath = (string) null;
      file = (FileStream) null;
    }
  }
}
