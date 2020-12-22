// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Windows.Settings
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Aurora.Launcher.Properties;
using Aurora.Launcher.Providers;
using Microsoft.WindowsAPICodePack.Dialogs;
using ModernWpf;
using ModernWpf.Controls;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Aurora.Launcher.Windows
{
  public partial class Settings : ContentDialog, IComponentConnector
  {
    internal Settings dialog;
    internal TextBox PathField;
    internal Button BrowseButton;
    private bool _contentLoaded;

    public Settings()
    {
      base.\u002Ector();
      this.InitializeComponent();
      this.PathField.Text = AuroraConfig.Get()?.Path ?? "";
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
      CommonOpenFileDialog commonOpenFileDialog1 = new CommonOpenFileDialog();
      ((CommonFileDialog) commonOpenFileDialog1).set_Title(Resources.SelectPathFileDialogTitle);
      commonOpenFileDialog1.set_IsFolderPicker(true);
      ((CommonFileDialog) commonOpenFileDialog1).set_DefaultDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
      CommonOpenFileDialog commonOpenFileDialog2 = commonOpenFileDialog1;
      if (((CommonFileDialog) commonOpenFileDialog2).ShowDialog() != 1)
        return;
      this.PathField.Text = ((CommonFileDialog) commonOpenFileDialog2).get_FileName();
    }

    private async void PrimaryButton_Click(
      ContentDialog sender,
      ContentDialogButtonClickEventArgs args)
    {
      Settings settings = this;
      if (Directory.Exists(settings.PathField.Text))
      {
        AuroraConfig.SavePath(settings.PathField.Text);
      }
      else
      {
        settings.Hide();
        ContentDialog contentDialog = new ContentDialog();
        contentDialog.set_Title((object) Resources.ExceptionOccurredText);
        ((ContentControl) contentDialog).Content = (object) Resources.PathDoesntExistDialogContent;
        contentDialog.set_CloseButtonText(Resources.ExitButtonText);
        ContentDialogResult contentDialogResult = await contentDialog.ShowAsync();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/FortniteLauncher;component/windows/settings.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.dialog = (Settings) target;
          // ISSUE: method pointer
          this.dialog.add_PrimaryButtonClick(new TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs>((object) this, __methodptr(PrimaryButton_Click)));
          break;
        case 2:
          this.PathField = (TextBox) target;
          break;
        case 3:
          this.BrowseButton = (Button) target;
          this.BrowseButton.Click += new RoutedEventHandler(this.BrowseButton_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
