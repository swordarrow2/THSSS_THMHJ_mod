﻿// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundTransitionIn
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class BackgroundTransitionIn : BaseObject
  {
    public int Delay { get; set; }

    public BackgroundTransitionIn(StageDataPackage StageData)
      : base(StageData, "bullet21_7", new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.Background.BackgroundList.Add((BaseObject) this);
      this.Position = new PointF((float) (StageData.BoundRect.X + StageData.BoundRect.Width / 2), (float) (StageData.BoundRect.Y + StageData.BoundRect.Height / 2));
      this.Scale = 30f;
      this.LifeTime = 480;
      this.Delay = 400;
      this.TransparentValueF = (float) byte.MaxValue;
      this.ColorValue = Color.Black;
    }

    public override void Ctrl()
    {
      ++this.Time;
      if (this.Time <= this.Delay)
        return;
      this.TransparentValueF -= (float) ((int) byte.MaxValue / (this.LifeTime - this.Delay) + 1);
    }
  }
}
