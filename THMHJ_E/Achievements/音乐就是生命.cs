﻿// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.音乐就是生命
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 音乐就是生命 : AchievementBase
  {
    private int time;

    public override bool Check(Hashtable data)
    {
      ++this.time;
      if (this.time / 60 >= 30)
      {
        this.finished = true;
        this.get = true;
      }
      return this.get;
    }
  }
}
