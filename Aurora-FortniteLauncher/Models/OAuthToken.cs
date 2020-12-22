// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Models.OAuthToken
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Newtonsoft.Json;
using System;

namespace Aurora.Launcher.Models
{
  public class OAuthToken
  {
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("expires_at")]
    public DateTime ExpiresAt { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonProperty("refresh_expires")]
    public int RefreshExpires { get; set; }

    [JsonProperty("refresh_expires_at")]
    public DateTime RefreshExpiresAt { get; set; }

    [JsonProperty("account_id")]
    public string AccountId { get; set; }

    [JsonProperty("client_id")]
    public string ClientId { get; set; }

    [JsonProperty("internal_client")]
    public bool InternalClient { get; set; }

    [JsonProperty("client_service")]
    public string ClientService { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("in_app_id")]
    public string InAppId { get; set; }
  }
}
