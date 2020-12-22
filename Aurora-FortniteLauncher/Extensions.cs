// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Extensions
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Aurora.Launcher
{
  public static class Extensions
  {
    public static Task WaitForExitAsync(
      this Process process,
      CancellationToken cancellationToken = default (CancellationToken))
    {
      if (process.HasExited)
        return (Task) Task.FromResult<int>(0);
      TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
      process.EnableRaisingEvents = true;
      process.Exited += (EventHandler) ((sender, args) => tcs.TrySetResult((object) null));
      if (cancellationToken != new CancellationToken())
        cancellationToken.Register((Action) (() => tcs.SetCanceled()));
      return !process.HasExited ? (Task) tcs.Task : (Task) Task.FromResult<object>(new object());
    }
  }
}
