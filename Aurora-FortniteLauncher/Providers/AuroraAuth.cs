// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Providers.AuroraAuth
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Aurora.Launcher.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Aurora.Launcher.Providers
{
  public class AuroraAuth
  {
    public static async Task Login(string email, string password)
    {
      WebClient webClient = new WebClient();
      webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
      webClient.Headers.Add("Authorization", "basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("ea2c2ef1b13c4158f987900918521d5d:a967ea60eefc1f8551a6034dc8e89000")));
      NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString.Add("username", email);
      queryString.Add(nameof (password), password);
      queryString.Add("grant_type", nameof (password));
      try
      {
        Globals.AuthData = (OAuthToken) JsonConvert.DeserializeObject<OAuthToken>(await webClient.UploadStringTaskAsync("https://api.aurorafn.dev/account/api/oauth/token", queryString.ToString()));
      }
      catch (WebException ex)
      {
        if (ex.Status != WebExceptionStatus.ProtocolError || ex.Response == null)
          throw new Exception("Unable to connect to Aurora servers.");
        HttpWebResponse response = (HttpWebResponse) ex.Response;
        if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.BadRequest)
          throw new Exception("Invalid credentials!");
        throw new Exception("Unknown exception occurred!");
      }
    }

    public static async Task RefreshToken()
    {
      WebClient webClient = new WebClient();
      webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
      webClient.Headers.Add("Authorization", "basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("ea2c2ef1b13c4158f987900918521d5d:a967ea60eefc1f8551a6034dc8e89000")));
      NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString.Add("refresh_token", Globals.AuthData.RefreshToken);
      queryString.Add("grant_type", "refresh_token");
      try
      {
        Globals.AuthData = (OAuthToken) JsonConvert.DeserializeObject<OAuthToken>(await webClient.UploadStringTaskAsync("https://api.aurorafn.dev/account/api/oauth/token", queryString.ToString()));
      }
      catch (WebException ex)
      {
        if (ex.Status != WebExceptionStatus.ProtocolError || ex.Response == null)
          throw new Exception("Unable to connect to Aurora servers.");
        HttpWebResponse response = (HttpWebResponse) ex.Response;
        if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.BadRequest)
          throw new Exception("Invalid credentials!");
        throw new Exception("Unknown exception occurred!");
      }
    }

    public static async Task DeviceAuthLogin(DeviceAuth deviceAuth)
    {
      WebClient webClient = new WebClient();
      webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
      webClient.Headers.Add("Authorization", "basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("ea2c2ef1b13c4158f987900918521d5d:a967ea60eefc1f8551a6034dc8e89000")));
      NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString.Add("account_id", deviceAuth.AccountId);
      queryString.Add("device_id", deviceAuth.DeviceId);
      queryString.Add("secret", deviceAuth.Secret);
      queryString.Add("grant_type", "device_auth");
      try
      {
        Globals.AuthData = (OAuthToken) JsonConvert.DeserializeObject<OAuthToken>(await webClient.UploadStringTaskAsync("https://api.aurorafn.dev/account/api/oauth/token", queryString.ToString()));
      }
      catch (WebException ex)
      {
        if (ex.Status != WebExceptionStatus.ProtocolError || ex.Response == null)
          throw new Exception("Unable to connect to Aurora servers.");
        HttpWebResponse response = (HttpWebResponse) ex.Response;
        if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.BadRequest)
          throw new Exception("Invalid credentials!");
        throw new Exception("Unknown exception occurred!");
      }
    }

    public static async Task CreateDeviceAuth()
    {
      WebClient webClient = new WebClient();
      webClient.Headers.Add("Authorization", "bearer " + Globals.AuthData.AccessToken);
      try
      {
        AuroraConfig.SaveDeviceAuth((DeviceAuth) JsonConvert.DeserializeObject<DeviceAuth>(await webClient.UploadStringTaskAsync(Endpoints.DeviceAuth(Globals.AuthData.AccountId), "")));
      }
      catch (Exception ex)
      {
      }
    }

    public static async Task<ExchangeCode> GetExchangeCode()
    {
      WebClient webClient = new WebClient();
      webClient.Headers.Add("Authorization", "bearer " + Globals.AuthData.AccessToken);
      ExchangeCode exchangeCode;
      try
      {
        exchangeCode = (ExchangeCode) JsonConvert.DeserializeObject<ExchangeCode>(await webClient.DownloadStringTaskAsync("https://api.aurorafn.dev/account/api/oauth/exchange"));
      }
      catch (WebException ex)
      {
        if (ex.Status != WebExceptionStatus.ProtocolError || ex.Response == null)
          throw new Exception("Unable to connect to Aurora servers.");
        HttpWebResponse response = (HttpWebResponse) ex.Response;
        if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.BadRequest)
          throw new Exception("Invalid credentials!");
        throw new Exception("Unknown exception occurred!");
      }
      return exchangeCode;
    }
  }
}
