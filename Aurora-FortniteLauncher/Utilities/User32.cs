// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Utilities.User32
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using System;
using System.Runtime.InteropServices;

namespace Aurora.Launcher.Utilities
{
  public static class User32
  {
    [DllImport("user32.dll")]
    public static extern IntPtr SetWindowText(IntPtr hWnd, string windowName);

    [DllImport("user32.dll")]
    public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
  }
}
