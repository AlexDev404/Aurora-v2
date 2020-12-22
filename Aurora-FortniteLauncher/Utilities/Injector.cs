// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Utilities.Injector
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Aurora.Launcher.Utilities
{
  internal class Injector
  {
    public static void Inject(int processId, string path)
    {
      IntPtr hProcess = Win32.OpenProcess(1082, false, processId);
      IntPtr procAddress = Win32.GetProcAddress(Win32.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
      uint num1 = (uint) ((path.Length + 1) * Marshal.SizeOf(typeof (char)));
      IntPtr num2 = Win32.VirtualAllocEx(hProcess, IntPtr.Zero, num1, 12288U, 4U);
      Win32.WriteProcessMemory(hProcess, num2, Encoding.Default.GetBytes(path), num1, out UIntPtr _);
      Win32.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, num2, 0U, IntPtr.Zero);
    }
  }
}
