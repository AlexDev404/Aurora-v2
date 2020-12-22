// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Providers.AuroraConfig
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using Aurora.Launcher.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Aurora.Launcher.Providers
{
  public class AuroraConfig
  {
    public static string _path => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aurora", "SAVE");

    public static Config Get()
    {
      if (File.Exists(AuroraConfig._path))
        return (Config) JsonConvert.DeserializeObject<Config>(AuroraConfig.Decompress(File.ReadAllBytes(AuroraConfig._path)));
      AuroraConfig.Create();
      return AuroraConfig.Get();
    }

    public static void Save(Config config) => File.WriteAllBytes(AuroraConfig._path, AuroraConfig.Compress(JsonConvert.SerializeObject((object) config)));

    public static void SaveDeviceAuth(DeviceAuth deviceAuth) => AuroraConfig.Save(new Config()
    {
      DeviceAuth = deviceAuth,
      Path = AuroraConfig.Get()?.Path
    });

    public static void SavePath(string path) => AuroraConfig.Save(new Config()
    {
      DeviceAuth = AuroraConfig.Get()?.DeviceAuth,
      Path = path
    });

    public static void Create() => AuroraConfig.Save(new Config()
    {
      DeviceAuth = (DeviceAuth) null,
      Path = EpicLauncher.GetInstallLocations().FirstOrDefault<Installation>((Func<Installation, bool>) (x => x.AppName == "Fortnite"))?.InstallLocation
    });

    private static byte[] Compress(string input)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (GZipStream gzipStream = new GZipStream((Stream) memoryStream, CompressionMode.Compress))
        {
          new MemoryStream(Encoding.UTF8.GetBytes(input)).CopyTo((Stream) gzipStream);
          gzipStream.Close();
          return memoryStream.ToArray();
        }
      }
    }

    public static string Decompress(byte[] data)
    {
      MemoryStream memoryStream1 = new MemoryStream();
      using (MemoryStream memoryStream2 = new MemoryStream(data))
      {
        using (GZipStream gzipStream = new GZipStream((Stream) memoryStream2, CompressionMode.Decompress))
        {
          gzipStream.CopyTo((Stream) memoryStream1);
          gzipStream.Close();
          memoryStream1.Position = 0L;
          return new StreamReader((Stream) memoryStream1).ReadToEnd();
        }
      }
    }
  }
}
