﻿// Decompiled with JetBrains decompiler
// Type: Shooting.Boss_Koreirei01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class Boss_Koreirei01 : BaseBossTouhou
  {
    public Boss_Koreirei01(StageDataPackage StageData)
      : base(StageData)
    {
      this.TxtureObjects = new TextureObject[3, 4]
      {
        {
          this.TextureObjectDictionary["BossKoreirei-00"],
          this.TextureObjectDictionary["BossKoreirei-01"],
          this.TextureObjectDictionary["BossKoreirei-02"],
          this.TextureObjectDictionary["BossKoreirei-03"]
        },
        {
          this.TextureObjectDictionary["BossKoreirei-10"],
          this.TextureObjectDictionary["BossKoreirei-11"],
          this.TextureObjectDictionary["BossKoreirei-12"],
          this.TextureObjectDictionary["BossKoreirei-13"]
        },
        {
          this.TextureObjectDictionary["BossKoreirei-20"],
          this.TextureObjectDictionary["BossKoreirei-21"],
          this.TextureObjectDictionary["BossKoreirei-22"],
          this.TextureObjectDictionary["BossKoreirei-23"]
        }
      };
      this.TxtureObject = this.TxtureObjects[0, 0];
      this.OriginalPosition = new PointF(30f, -50f);
      this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
      this.MaxHP = 10000;
      this.HealthPoint = (float) this.MaxHP;
      this.Life = 2;
      this.Region = 20;
      this.Velocity = 6f;
      this.DirectionDegree = 90.0;
      this.SpellTime = 1200;
      this.LifeTime = 100000;
      this.OnSpell = false;
      this.SpellcardHP = 0;
      this.SetBossLifeLineTex();
      ItemGetter itemGetter = new ItemGetter(StageData);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (!this.OnSpell)
        this.Armon = 0.0f;
      switch (this.Life)
      {
        case 0:
          this.Velocity = 0.0f;
          this.DestPoint = (PointF) new Point(this.Ran.Next(100, this.BoundRect.Width - 100), this.Ran.Next(70, 200));
          break;
        case 1:
          this.Ctrl1();
          break;
        case 2:
          this.Ctrl2();
          break;
      }
      this.MoveToPoint(this.DestPoint);
      if (!this.OnSpell)
      {
        if ((double) this.HealthPoint >= (double) this.SpellcardHP && this.Time <= this.SpellTime)
          return;
        this.HealthPoint = (float) this.SpellcardHP;
        this.Time = 0;
        this.OnSpell = true;
        ShootingStarShard shootingStarShard = new ShootingStarShard(this.StageData, new PointF((float) (this.BoundRect.Width / 2), 0.0f));
      }
      else if ((double) this.HealthPoint <= 0.0 || this.Time > this.SpellTime)
      {
        --this.Life;
        this.OnAction = 0;
        Rectangle boundRect;
        if ((double) this.HealthPoint <= 0.0 && this.Life >= -1)
        {
          this.GiveItems();
          StageDataPackage stageData = this.StageData;
          boundRect = this.BoundRect;
          PointF OriginalPosition = new PointF((float) (boundRect.Width / 2), 0.0f);
          ShootingStarShard shootingStarShard = new ShootingStarShard(stageData, OriginalPosition);
        }
        if (this.Life <= 0)
        {
          if (this.Life == 0)
          {
            this.Velocity = 0.0f;
            BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
            this.HealthPoint = 0.0f;
            this.GiveEndEffect();
            this.Life = -1;
          }
          else if (this.Time == this.LifeTime - 100)
          {
            this.DestPoint = (PointF) new Point(this.Ran.Next((int) this.OriginalPosition.X - 30, (int) this.OriginalPosition.X + 30), -200);
            this.Velocity = 5f;
            this.Background3D.WarpEnabled = false;
          }
        }
        else
        {
          BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
          this.StageData.SoundPlay("se_tan00.wav");
          this.HealthPoint = (float) this.MaxHP;
          this.Time = 0;
          this.OnSpell = false;
          boundRect = this.BoundRect;
          this.DestPoint = (PointF) new Point(boundRect.Width / 2, 100);
          this.Velocity = 4f;
        }
      }
    }

    public override void GiveEndEffect()
    {
      EndBoss_Touhou_Small endBossTouhouSmall = new EndBoss_Touhou_Small(this.StageData, this.OriginalPosition, Color.Yellow, Color.OrangeRed);
      Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
      this.Background3D.WarpEnabled = false;
      LifeItem_Touhou lifeItemTouhou = new LifeItem_Touhou(this.StageData, this.OriginalPosition);
    }

    private void Ctrl2()
    {
      if (!this.OnSpell)
      {
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 140);
        }
        else
          this.RandomMove1(150, 4f);
        if (this.Time != 90)
          return;
        this.OnSpell = true;
      }
      else if (this.Time == 91)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        this.Armon = 0.4f;
        SpellCard_SSS03_01 spellCardSsS0301 = new SpellCard_SSS03_01(this.StageData);
      }
    }

    private void Ctrl1()
    {
      if (!this.OnSpell)
      {
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 180);
        }
        else
          this.RandomMove1(150, 4f);
        if (this.Time != 100)
          return;
        this.OnSpell = true;
        this.SpellTime = 2400;
      }
      else if (this.Time == 101)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        this.Armon = 0.4f;
        SpellCard_SSS03_02 spellCardSsS0302 = new SpellCard_SSS03_02(this.StageData);
      }
    }
  }
}
