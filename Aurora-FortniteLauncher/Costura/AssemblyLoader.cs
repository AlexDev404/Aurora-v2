// Decompiled with JetBrains decompiler
// Type: Costura.AssemblyLoader
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
  [CompilerGenerated]
  internal static class AssemblyLoader
  {
    private static object nullCacheLock = new object();
    private static Dictionary<string, bool> nullCache = new Dictionary<string, bool>();
    private static Dictionary<string, string> assemblyNames = new Dictionary<string, string>();
    private static Dictionary<string, string> symbolNames = new Dictionary<string, string>();
    private static int isAttached;

    private static string CultureToString(CultureInfo culture) => culture == null ? "" : culture.Name;

    private static Assembly ReadExistingAssembly(AssemblyName name)
    {
      foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        AssemblyName name1 = assembly.GetName();
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        if (string.Equals(name1.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name1.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
          return assembly;
      }
      return (Assembly) null;
    }

    private static void CopyTo(Stream source, Stream destination)
    {
      byte[] buffer = new byte[81920];
      int count;
      while ((count = source.Read(buffer, 0, buffer.Length)) != 0)
        destination.Write(buffer, 0, count);
    }

    private static Stream LoadStream(string fullName)
    {
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      if (!fullName.EndsWith(".compressed"))
        return executingAssembly.GetManifestResourceStream(fullName);
      using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
      {
        using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
        {
          MemoryStream memoryStream = new MemoryStream();
          // ISSUE: reference to a compiler-generated method
          AssemblyLoader.CopyTo((Stream) deflateStream, (Stream) memoryStream);
          memoryStream.Position = 0L;
          return (Stream) memoryStream;
        }
      }
    }

    private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
    {
      string fullName;
      // ISSUE: reference to a compiler-generated method
      return resourceNames.TryGetValue(name, out fullName) ? AssemblyLoader.LoadStream(fullName) : (Stream) null;
    }

    private static byte[] ReadStream(Stream stream)
    {
      byte[] buffer = new byte[stream.Length];
      stream.Read(buffer, 0, buffer.Length);
      return buffer;
    }

    private static Assembly ReadFromEmbeddedResources(
      Dictionary<string, string> assemblyNames,
      Dictionary<string, string> symbolNames,
      AssemblyName requestedAssemblyName)
    {
      string name = requestedAssemblyName.Name.ToLowerInvariant();
      if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
        name = requestedAssemblyName.CultureInfo.Name + "." + name;
      byte[] rawAssembly;
      // ISSUE: reference to a compiler-generated method
      using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, name))
      {
        if (stream == null)
          return (Assembly) null;
        // ISSUE: reference to a compiler-generated method
        rawAssembly = AssemblyLoader.ReadStream(stream);
      }
      // ISSUE: reference to a compiler-generated method
      using (Stream stream = AssemblyLoader.LoadStream(symbolNames, name))
      {
        if (stream != null)
        {
          // ISSUE: reference to a compiler-generated method
          byte[] rawSymbolStore = AssemblyLoader.ReadStream(stream);
          return Assembly.Load(rawAssembly, rawSymbolStore);
        }
      }
      return Assembly.Load(rawAssembly);
    }

    public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      lock (AssemblyLoader.nullCacheLock)
      {
        // ISSUE: reference to a compiler-generated field
        if (AssemblyLoader.nullCache.ContainsKey(e.Name))
          return (Assembly) null;
      }
      AssemblyName assemblyName = new AssemblyName(e.Name);
      // ISSUE: reference to a compiler-generated method
      Assembly assembly1 = AssemblyLoader.ReadExistingAssembly(assemblyName);
      if (assembly1 != (Assembly) null)
        return assembly1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      Assembly assembly2 = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
      if (assembly2 == (Assembly) null)
      {
        // ISSUE: reference to a compiler-generated field
        lock (AssemblyLoader.nullCacheLock)
        {
          // ISSUE: reference to a compiler-generated field
          AssemblyLoader.nullCache[e.Name] = true;
        }
        if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
          assembly2 = Assembly.Load(assemblyName);
      }
      return assembly2;
    }

    static AssemblyLoader()
    {
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("costura", "costura.costura.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("cs.modernwpf.resources", "costura.cs.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("de.modernwpf.resources", "costura.de.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("es.modernwpf.resources", "costura.es.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("fa.modernwpf.resources", "costura.fa.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("fr.modernwpf.resources", "costura.fr.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("it.modernwpf.resources", "costura.it.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("ja.modernwpf.resources", "costura.ja.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("ko.modernwpf.resources", "costura.ko.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.windowsapicodepack", "costura.microsoft.windowsapicodepack.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.symbolNames.Add("microsoft.windowsapicodepack", "costura.microsoft.windowsapicodepack.pdb.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.windowsapicodepack.shell", "costura.microsoft.windowsapicodepack.shell.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.symbolNames.Add("microsoft.windowsapicodepack.shell", "costura.microsoft.windowsapicodepack.shell.pdb.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.windowsapicodepack.shellextensions", "costura.microsoft.windowsapicodepack.shellextensions.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.symbolNames.Add("microsoft.windowsapicodepack.shellextensions", "costura.microsoft.windowsapicodepack.shellextensions.pdb.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("modernwpf.controls", "costura.modernwpf.controls.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("modernwpf", "costura.modernwpf.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("pl.modernwpf.resources", "costura.pl.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("pt-BR.modernwpf.resources", "costura.pt-BR.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("ru.modernwpf.resources", "costura.ru.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("system.valuetuple", "costura.system.valuetuple.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("tr.modernwpf.resources", "costura.tr.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("zh-Hans.modernwpf.resources", "costura.zh-Hans.modernwpf.resources.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("zh-Hant.modernwpf.resources", "costura.zh-Hant.modernwpf.resources.dll.compressed");
    }

    public static void Attach()
    {
      // ISSUE: reference to a compiler-generated field
      if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
        return;
      AppDomain.CurrentDomain.AssemblyResolve += (ResolveEventHandler) ((sender, e) =>
      {
        // ISSUE: reference to a compiler-generated field
        lock (AssemblyLoader.nullCacheLock)
        {
          // ISSUE: reference to a compiler-generated field
          if (AssemblyLoader.nullCache.ContainsKey(e.Name))
            return (Assembly) null;
        }
        AssemblyName assemblyName = new AssemblyName(e.Name);
        // ISSUE: reference to a compiler-generated method
        Assembly assembly1 = AssemblyLoader.ReadExistingAssembly(assemblyName);
        if (assembly1 != (Assembly) null)
          return assembly1;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        Assembly assembly2 = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
        if (assembly2 == (Assembly) null)
        {
          // ISSUE: reference to a compiler-generated field
          lock (AssemblyLoader.nullCacheLock)
          {
            // ISSUE: reference to a compiler-generated field
            AssemblyLoader.nullCache[e.Name] = true;
          }
          if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
            assembly2 = Assembly.Load(assemblyName);
        }
        return assembly2;
      });
    }
  }
}
