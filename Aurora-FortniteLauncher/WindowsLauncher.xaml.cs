// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Windows.Launcher
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Aurora.Launcher.Models;
using Aurora.Launcher.Properties;
using Aurora.Launcher.Providers;
using ModernWpf.Controls;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Aurora.Launcher.Windows
{
  public partial class Launcher : Window, IComponentConnector
  {
    private readonly FortniteLauncher _launcher;
    internal Label UsernameLabel;
    internal Button LoginButton;
    internal Label AuroraHeader;
    private bool _contentLoaded;

    public Launcher()
    {
      this.InitializeComponent();
      this.UsernameLabel.Content = (object) Globals.AuthData.DisplayName;
      this._launcher = new FortniteLauncher();
    }

    private void AboutLabel_MouseDown(object sender, MouseButtonEventArgs e) => new About().ShowAsync();

    private void WebsiteLabel_MouseDown(object sender, MouseButtonEventArgs e) => Process.Start("https://aurorafn.dev");

    private void DiscordLabel_MouseDown(object sender, MouseButtonEventArgs e) => Process.Start("https://discord.gg/EC9GQ9UPGQ");

    private void SettingsLabel_MouseDown(object sender, MouseButtonEventArgs e) => new Settings().ShowAsync();

    private async void LaunchButton_Click(object sender, RoutedEventArgs e)
    {
      Aurora.Launcher.Windows.Launcher launcher = this;
      string arguments = "-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -skippatchcheck -AUTH_TYPE=exchangecode -AUTH_LOGIN=unused ";
      int num = 0;
      object obj;
      try
      {
        arguments = arguments + "-AUTH_PASSWORD=" + (await AuroraAuth.GetExchangeCode()).Code + " ";
      }
      catch (Exception ex)
      {
        obj = (object) ex;
        num = 1;
      }
      if (num == 1)
      {
        Exception exception = (Exception) obj;
        ContentDialog contentDialog = new ContentDialog();
        contentDialog.set_Title((object) Resources.ExceptionOccurredText);
        ((ContentControl) contentDialog).Content = exception.Message == "Invalid credentials!" ? (object) Resources.InvalidCredentialsText : (exception.Message == "Unknown exception occurred!" ? (object) Resources.UnknownExceptionText : (object) Resources.FailedToConnectText);
        contentDialog.set_CloseButtonText(Resources.ExitButtonText);
        ContentDialogResult contentDialogResult = await contentDialog.ShowAsync();
        new Login().Show();
        launcher.Close();
        arguments = (string) null;
      }
      else
      {
        obj = (object) null;
        arguments += "-noeac -fromfl=be -fltoken=f7b9gah4h5380d10f721dd6a";
        if (!File.Exists(Path.Combine(AuroraConfig.Get()?.Path ?? "", "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe")))
        {
          ContentDialog contentDialog = new ContentDialog();
          contentDialog.set_Title((object) Resources.ExceptionOccurredText);
          ((ContentControl) contentDialog).Content = (object) ("\"FortniteClient-Win64-Shipping.exe\" " + Resources.InvalidPathErrorText);
          contentDialog.set_CloseButtonText(Resources.ExitButtonText);
          ContentDialogResult contentDialogResult = await contentDialog.ShowAsync();
          arguments = (string) null;
        }
        else
        {
          launcher.SetHide();
          await launcher._launcher.StartGame(arguments);
          try
          {
            await AuroraAuth.RefreshToken();
          }
          catch
          {
            AuroraConfig.SaveDeviceAuth((DeviceAuth) null);
            Globals.AuthData = (OAuthToken) null;
            new Login().Show();
            launcher.Close();
          }
          launcher.SetShow();
          arguments = (string) null;
        }
      }
    }

    private void SetShow()
    {
      if (!this.Dispatcher.CheckAccess())
        this.Dispatcher.Invoke((Delegate) new Aurora.Launcher.Windows.Launcher.SetShowDelegate(this.SetShow));
      else
        this.Show();
    }

    private void SetHide()
    {
      if (!this.Dispatcher.CheckAccess())
        this.Dispatcher.Invoke((Delegate) new Aurora.Launcher.Windows.Launcher.SetHideDelegate(this.SetHide));
      else
        this.Hide();
    }

    private async void SignOutLabel_MouseDown(object sender, MouseButtonEventArgs e)
    {
      Aurora.Launcher.Windows.Launcher launcher = this;
      ContentDialog contentDialog = new ContentDialog();
      contentDialog.set_Title((object) Resources.SignOutConfirmationDialogTitle);
      ((ContentControl) contentDialog).Content = (object) Resources.SignOutConfirmationDialogContent;
      contentDialog.set_PrimaryButtonText(Resources.Yes);
      contentDialog.set_CloseButtonText(Resources.No);
      if (await contentDialog.ShowAsync() != 1)
        return;
      AuroraConfig.SaveDeviceAuth((DeviceAuth) null);
      Globals.AuthData = (OAuthToken) null;
      new Login().Show();
      launcher.Close();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/FortniteLauncher;component/windows/launcher.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          ((UIElement) target).MouseDown += new MouseButtonEventHandler(this.AboutLabel_MouseDown);
          break;
        case 2:
          ((UIElement) target).MouseDown += new MouseButtonEventHandler(this.WebsiteLabel_MouseDown);
          break;
        case 3:
          ((UIElement) target).MouseDown += new MouseButtonEventHandler(this.DiscordLabel_MouseDown);
          break;
        case 4:
          ((UIElement) target).MouseDown += new MouseButtonEventHandler(this.SettingsLabel_MouseDown);
          break;
        case 5:
          ((UIElement) target).MouseDown += new MouseButtonEventHandler(this.SignOutLabel_MouseDown);
          break;
        case 6:
          this.UsernameLabel = (Label) target;
          break;
        case 7:
          this.LoginButton = (Button) target;
          this.LoginButton.Click += new RoutedEventHandler(this.LaunchButton_Click);
          break;
        case 8:
          this.AuroraHeader = (Label) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }

    private delegate void SetShowDelegate();

    private delegate void SetHideDelegate();
  }
}
