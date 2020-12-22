// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.App
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Aurora.Launcher
{
  public partial class App : Application
  {
    private bool _contentLoaded;

    private App() => Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      this.StartupUri = new Uri("../Windows/Login.xaml", UriKind.Relative);
      Application.LoadComponent((object) this, new Uri("/FortniteLauncher;component/app.xaml", UriKind.Relative));
    }

    [STAThread]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public static void Main()
    {
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}
