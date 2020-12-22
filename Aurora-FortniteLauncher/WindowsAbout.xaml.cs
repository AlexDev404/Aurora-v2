// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Windows.About
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using ModernWpf.Controls;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Aurora.Launcher.Windows
{
  public partial class About : ContentDialog, IComponentConnector
  {
    internal About dialog;
    internal Label InfoLabel;
    internal Label VersionHeaderLabel;
    internal Label VersionLabel;
    private bool _contentLoaded;

    public About()
    {
      base.\u002Ector();
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/FortniteLauncher;component/windows/about.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.dialog = (About) target;
          break;
        case 2:
          this.InfoLabel = (Label) target;
          break;
        case 3:
          this.VersionHeaderLabel = (Label) target;
          break;
        case 4:
          this.VersionLabel = (Label) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
