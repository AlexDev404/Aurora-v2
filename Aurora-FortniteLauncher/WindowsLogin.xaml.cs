// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Windows.Login
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Aurora.Launcher.Models;
using Aurora.Launcher.Properties;
using Aurora.Launcher.Providers;
using ModernWpf.Controls;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Aurora.Launcher.Windows
{
  public partial class Login : Window, IComponentConnector
  {
    private readonly Konami _konami;
    private readonly string _nativePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Aurora.Runtime.dll");
    internal TextBox EmailField;
    internal PasswordBox PasswordField;
    internal Button LoginButton;
    internal Label LoginFailedLabel;
    internal Label LoggingInlabel;
    internal ProgressBar ProgressLogin;
    private bool _contentLoaded;

    public Login()
    {
      this._konami = new Konami();
      ((IEnumerable<string>) Environment.GetCommandLineArgs()).Select<string, string>((Func<string, string>) (x => x.ToUpper()));
      this.InitializeComponent();
      this.SetLoggingIn(true);
      this.HandleStartup().ConfigureAwait(false);
    }

    private async Task HandleStartup()
    {
      if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aurora")))
        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aurora"));
      if (!File.Exists(this._nativePath))
      {
        ContentDialog contentDialog = new ContentDialog();
        contentDialog.set_Title((object) Resources.ExceptionOccurredText);
        ((ContentControl) contentDialog).Content = (object) ("\"Aurora.Runtime.dll\"  " + Resources.FileMissingErrorText);
        contentDialog.set_CloseButtonText(Resources.ExitButtonText);
        ContentDialogResult contentDialogResult = await contentDialog.ShowAsync();
        Application.Current.Shutdown();
      }
      else
      {
        Config config = AuroraConfig.Get();
        if (config.DeviceAuth == null)
          this.SetLoggingIn();
        else
          await this.LoginWithDeviceAuth(config.DeviceAuth);
      }
    }

    private async Task LoginWithDeviceAuth(DeviceAuth auth)
    {
      Login login = this;
      try
      {
        await AuroraAuth.DeviceAuthLogin(auth);
        new Aurora.Launcher.Windows.Launcher().Show();
        login.Close();
      }
      catch (Exception ex)
      {
        login.SetLoggingIn();
      }
    }

    private void SetLoggingIn(bool isLoggingIn = false)
    {
      this.EmailField.Visibility = isLoggingIn ? Visibility.Hidden : Visibility.Visible;
      this.PasswordField.Visibility = isLoggingIn ? Visibility.Hidden : Visibility.Visible;
      this.LoginButton.Visibility = isLoggingIn ? Visibility.Hidden : Visibility.Visible;
      this.LoginFailedLabel.Visibility = isLoggingIn ? Visibility.Hidden : Visibility.Visible;
      this.LoggingInlabel.Visibility = isLoggingIn ? Visibility.Visible : Visibility.Hidden;
      ((UIElement) this.ProgressLogin).Visibility = isLoggingIn ? Visibility.Visible : Visibility.Hidden;
    }

    private void EmailField_KeyUp(object sender, KeyEventArgs e)
    {
      if (!this._konami.IsCompleted(e.Key))
        return;
      new TransRights().Show();
    }

    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
      Login login = this;
      login.SetLoggingIn(true);
      try
      {
        await AuroraAuth.Login(login.EmailField.Text, login.PasswordField.Password);
        await AuroraAuth.CreateDeviceAuth();
        new Aurora.Launcher.Windows.Launcher().Show();
        login.Close();
      }
      catch (Exception ex)
      {
        login.SetLoggingIn();
        login.LoginFailedLabel.Content = ex.Message == "Invalid credentials!" ? (object) Resources.InvalidCredentialsText : (ex.Message == "Unknown exception occurred!" ? (object) Resources.UnknownExceptionText : (object) Resources.FailedToConnectText);
        login.LoginFailedLabel.Visibility = Visibility.Visible;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/FortniteLauncher;component/windows/login.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.EmailField = (TextBox) target;
          this.EmailField.KeyUp += new KeyEventHandler(this.EmailField_KeyUp);
          break;
        case 2:
          this.PasswordField = (PasswordBox) target;
          break;
        case 3:
          this.LoginButton = (Button) target;
          this.LoginButton.Click += new RoutedEventHandler(this.LoginButton_Click);
          break;
        case 4:
          this.LoginFailedLabel = (Label) target;
          break;
        case 5:
          this.LoggingInlabel = (Label) target;
          break;
        case 6:
          this.ProgressLogin = (ProgressBar) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
