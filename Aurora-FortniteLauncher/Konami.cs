// Decompiled with JetBrains decompiler
// Type: Aurora.Launcher.Konami
// Assembly: FortniteLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01525776-EED9-4366-9F14-D304150BDE9C
// Assembly location: C:\Data\copy\Aurora\FortniteLauncher.exe

using System.Collections.Generic;
using System.Windows.Input;

namespace Aurora.Launcher
{
  public class Konami
  {
    private readonly List<Key> _keys = new List<Key>()
    {
      Key.Up,
      Key.Up,
      Key.Down,
      Key.Down,
      Key.Left,
      Key.Right,
      Key.Left,
      Key.Right,
      Key.B,
      Key.A
    };

    public int Position { get; private set; }

    public bool IsCompleted(Key key)
    {
      if (this._keys[this.Position + 1] == key)
        ++this.Position;
      else if (this.Position != 1 || key != Key.Up)
        this.Position = this._keys[0] != key ? -1 : 0;
      if (this.Position != this._keys.Count - 1)
        return false;
      this.Position = -1;
      return true;
    }
  }
}
