﻿ 
// Type: Shooting.Planes.Story.Story_SSS01_01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS01_01 : BaseStory_SSS
  {
    public Story_SSS01_01(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceAmi01");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceAya_no");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary["FaceAya_base"];
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.CharN = new CharacterName(StageData, "ename_Ami");
      StoryEmitterStar storyEmitterStar = new StoryEmitterStar(StageData, this.CharN.Position, 0.0f, 0.0);
      this.Conv.Add(new Conversation("。。。", false, true, "FaceAya_no", "FaceAmi01"));
      this.Conv.Add(new Conversation("。。。。。。", true, false, "FaceAya_no", (string) null));
      this.Conv.Add(new Conversation("从前有座山，", false, true, (string) null, "FaceAmi01"));
      this.Conv.Add(new Conversation("山上有座庙，", false, true, (string) null, "FaceAmi01"));
      this.Conv.Add(new Conversation("庙里有只文文在卖报，", false, true, (string) null, "FaceAmi01"));
      this.Conv.Add(new Conversation("。。。。。。", true, false, "FaceAya_sw", (string) null));
      this.Conv.Add(new Conversation("报上写着，", false, true, (string) null, "FaceAmi02"));
      this.Conv.Add(new Conversation("从前有座山，山上有座庙，庙里有只文文在卖报", false, true, (string) null, "FaceAmi03"));
      this.Conv.Add(new Conversation("报上写着，", false, true, (string) null, "FaceAmi04"));
      this.Conv.Add(new Conversation("从前有座山，山上有座庙，庙里有只文文在卖报", false, true, (string) null, "FaceAmi05"));
      this.Conv.Add(new Conversation("报上写着，", false, true, (string) null, "FaceAmi06"));
      this.Conv.Add(new Conversation("喂，有完没完了", true, false, "FaceAya_sw", (string) null));
      this.Conv.Add(new Conversation("好了，开打吧", false, true, (string) null, "FaceAmi07"));
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.Conv.Count)
        return;
      this.Boss.Enabled = true;
      this.StageData.ChangeBGM(".\\BGM\\Boss01.wav", 0, 0, (int) byte.MaxValue, 754110, 3294270);
      StageDataPackage stageData = this.StageData;
      Rectangle boundRect1 = this.BoundRect;
      int width1 = boundRect1.Width;
      boundRect1 = this.BoundRect;
      int y = boundRect1.Height - 16;
      Point DestPoint = new Point(width1, y);
      MusicTitle musicTitle1 = new MusicTitle(stageData, "喧闹吧！在这不眠之夜", DestPoint);
      MusicTitle musicTitle2 = musicTitle1;
      Rectangle boundRect2 = this.BoundRect;
      double width2 = (double) boundRect2.Width;
      boundRect2 = this.BoundRect;
      double num = (double) (boundRect2.Height + 100);
      PointF pointF = new PointF((float) width2, (float) num);
      musicTitle2.OriginalPosition = pointF;
      musicTitle1.Scale = 0.5f;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
      EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.FromArgb(40, (int) byte.MaxValue, 20));
      new MagicCircle(this.StageData, "MagicCircleSix").Scale = 1.5f;
      this.Background3D.WarpEnabled = true;
    }
  }
}
