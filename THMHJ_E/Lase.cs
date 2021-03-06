﻿// Decompiled with JetBrains decompiler
// Type: THMHJ.Lase
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  [Serializable]
  public class Lase
  {
    public int bindid = -1;
    private float[] conditions = new float[10];
    private float[] results = new float[24];
    public bool NeedDelete;
    public int id;
    public int parentid;
    public bool Binding;
    public bool bansound;
    public bool Bindwithspeedd;
    public bool Deepbind;
    public bool Deepbinded;
    public float x;
    public float y;
    public int time;
    public int begin;
    public int life;
    public float r;
    public float rdirection;
    public Vector2 rdirections;
    public int tiao;
    public int t;
    public float fdirection;
    public Vector2 fdirections;
    public int range;
    public float speed;
    public float speedd;
    public float speedx;
    public float speedy;
    public Vector2 speedds;
    public float aspeed;
    public float aspeedx;
    public float aspeedy;
    public float aspeedd;
    public Vector2 aspeedds;
    public int sonlife;
    public float type;
    public float longs;
    public float wscale;
    public float alpha;
    public bool Ray;
    public float sonspeed;
    public float sonspeedd;
    public Vector2 sonspeedds;
    public float sonaspeed;
    public float sonaspeedd;
    public Vector2 sonaspeedds;
    public float xscale;
    public float yscale;
    public bool Blend;
    public bool Outdispel;
    public bool Invincible;
    public Lase rand;
    public List<Event> Parentevents;
    public List<LExecution> Eventsexe;
    public List<Event> Sonevents;
    public Lase copys;

    public Lase()
    {
    }

    public Lase(float xs, float ys, LayerManager layerm)
    {
      this.rand = new Lase();
      this.Parentevents = new List<Event>();
      this.Sonevents = new List<Event>();
      this.Eventsexe = new List<LExecution>();
      this.x = xs;
      this.y = ys;
      this.begin = layerm.LayerArray[this.parentid].begin;
      this.life = layerm.LayerArray[this.parentid].end - layerm.LayerArray[this.parentid].begin + 1;
      this.r = 0.0f;
      this.rdirection = 0.0f;
      this.tiao = 1;
      this.t = 5;
      this.fdirection = 0.0f;
      this.range = 360;
      this.speed = 0.0f;
      this.speedd = 0.0f;
      this.aspeed = 0.0f;
      this.aspeedd = 0.0f;
      this.sonlife = 200;
      this.type = 0.0f;
      this.longs = 100f;
      this.wscale = 1f;
      this.alpha = 100f;
      this.Ray = false;
      this.sonspeed = 5f;
      this.sonspeedd = 0.0f;
      this.sonaspeed = 0.0f;
      this.sonaspeedd = 0.0f;
      this.xscale = 1f;
      this.yscale = 1f;
      this.Blend = false;
      this.Outdispel = true;
      this.Invincible = false;
    }

    public void Update(
      LayerManager layerm,
      CrazyStorm cs,
      Time Times,
      Center Centers,
      Vector2 Player)
    {
      if (this.bindid != -1 && this.bindid >= layerm.LayerArray[this.parentid].BatchArray.Count)
      {
        this.bindid = -1;
        this.Deepbind = false;
        this.Bindwithspeedd = false;
      }
      if (this.Deepbinded)
        ++this.time;
      if (!(!this.Deepbinded & Times.now >= this.begin & Times.now <= this.begin + this.life - 1) && !(this.Deepbinded & this.time >= this.begin & this.time <= this.begin + this.life - 1) && !this.Deepbind)
        return;
      if (!this.Deepbind & !this.Deepbinded)
        this.time = Times.now - this.begin + 1;
      if (!this.Deepbind)
      {
        this.speedx += this.aspeedx;
        this.speedy += this.aspeedy;
        this.x += this.speedx;
        this.y += this.speedy;
        this.conditions[0] = !this.Deepbinded ? (float) this.time : (float) (this.time - this.begin + 1);
        this.conditions[1] = this.r;
        this.conditions[2] = this.rdirection;
        this.conditions[3] = (float) this.tiao;
        this.conditions[4] = (float) this.t;
        this.conditions[5] = this.fdirection;
        this.conditions[6] = (float) this.range;
        this.conditions[7] = this.wscale;
        this.conditions[8] = this.longs;
        this.conditions[9] = this.alpha;
        this.results[0] = this.r;
        this.results[1] = this.rdirection;
        this.results[2] = (float) this.tiao;
        this.results[3] = (float) this.t;
        this.results[4] = this.fdirection;
        this.results[5] = (float) this.range;
        this.results[6] = this.speed;
        this.results[7] = this.speedd;
        this.results[8] = this.aspeed;
        this.results[9] = this.aspeedd;
        this.results[10] = (float) this.life;
        this.results[11] = this.type;
        this.results[12] = this.wscale;
        this.results[13] = this.longs;
        this.results[14] = this.alpha;
        this.results[15] = this.sonspeed;
        this.results[16] = this.sonspeedd;
        this.results[17] = this.sonaspeed;
        this.results[18] = this.sonaspeedd;
        this.results[19] = this.xscale;
        this.results[20] = this.yscale;
        this.results[21] = 0.0f;
        this.results[22] = 0.0f;
        this.results[23] = 0.0f;
        foreach (Event parentevent in this.Parentevents)
        {
          if (parentevent.t <= 0)
            parentevent.t = 1;
          if (this.time % parentevent.t == 0)
            ++parentevent.loop;
          foreach (EventRead result in parentevent.results)
          {
            if (result.special == 4)
            {
              if (result.changevalue == 1)
                result.res = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, this.x - 4f + Centers.ox - Centers.x, this.y + 16f + Centers.oy - Centers.y));
              if (result.changevalue == 4)
                result.res = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, this.x - 4f + Centers.ox - Centers.x, this.y + 16f + Centers.oy - Centers.y));
              if (result.changevalue == 18)
                result.res = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, this.x - 4f + Centers.ox - Centers.x, this.y + 16f + Centers.oy - Centers.y));
            }
            if (result.opreator == ">")
            {
              if (result.opreator2 == ">")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    LExecution lexecution = new LExecution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      lexecution.parentid = this.parentid;
                      lexecution.id = this.id;
                      lexecution.change = result.change;
                      lexecution.changetype = result.changetype;
                      lexecution.changevalue = result.changevalue;
                      lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      lexecution.region = this.results[result.changename].ToString();
                      lexecution.time = result.times;
                      lexecution.ctime = lexecution.time;
                      this.Eventsexe.Add(lexecution);
                    }
                    else
                      continue;
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  LExecution lexecution = new LExecution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    lexecution.parentid = this.parentid;
                    lexecution.id = this.id;
                    lexecution.change = result.change;
                    lexecution.changetype = result.changetype;
                    lexecution.changevalue = result.changevalue;
                    lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    lexecution.region = this.results[result.changename].ToString();
                    lexecution.time = result.times;
                    lexecution.ctime = lexecution.time;
                    this.Eventsexe.Add(lexecution);
                  }
                  else
                    continue;
                }
              }
              else if (result.opreator2 == "=")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    LExecution lexecution = new LExecution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      lexecution.parentid = this.parentid;
                      lexecution.id = this.id;
                      lexecution.change = result.change;
                      lexecution.changetype = result.changetype;
                      lexecution.changevalue = result.changevalue;
                      lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      lexecution.region = this.results[result.changename].ToString();
                      lexecution.time = result.times;
                      lexecution.ctime = lexecution.time;
                      this.Eventsexe.Add(lexecution);
                    }
                    else
                      continue;
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  LExecution lexecution = new LExecution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    lexecution.parentid = this.parentid;
                    lexecution.id = this.id;
                    lexecution.change = result.change;
                    lexecution.changetype = result.changetype;
                    lexecution.changevalue = result.changevalue;
                    lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    lexecution.region = this.results[result.changename].ToString();
                    lexecution.time = result.times;
                    lexecution.ctime = lexecution.time;
                    this.Eventsexe.Add(lexecution);
                  }
                  else
                    continue;
                }
              }
              else if (result.opreator2 == "<")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    LExecution lexecution = new LExecution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      lexecution.parentid = this.parentid;
                      lexecution.id = this.id;
                      lexecution.change = result.change;
                      lexecution.changetype = result.changetype;
                      lexecution.changevalue = result.changevalue;
                      lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      lexecution.region = this.results[result.changename].ToString();
                      lexecution.time = result.times;
                      lexecution.ctime = lexecution.time;
                      this.Eventsexe.Add(lexecution);
                    }
                    else
                      continue;
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  LExecution lexecution = new LExecution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    lexecution.parentid = this.parentid;
                    lexecution.id = this.id;
                    lexecution.change = result.change;
                    lexecution.changetype = result.changetype;
                    lexecution.changevalue = result.changevalue;
                    lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    lexecution.region = this.results[result.changename].ToString();
                    lexecution.time = result.times;
                    lexecution.ctime = lexecution.time;
                    this.Eventsexe.Add(lexecution);
                  }
                  else
                    continue;
                }
              }
              else if ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime))
              {
                LExecution lexecution = new LExecution();
                if (!result.noloop)
                {
                  if (result.time > 0)
                  {
                    --result.time;
                    if (result.time == 0)
                      result.noloop = true;
                  }
                  lexecution.parentid = this.parentid;
                  lexecution.id = this.id;
                  lexecution.change = result.change;
                  lexecution.changetype = result.changetype;
                  lexecution.changevalue = result.changevalue;
                  lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                  lexecution.region = this.results[result.changename].ToString();
                  lexecution.time = result.times;
                  lexecution.ctime = lexecution.time;
                  this.Eventsexe.Add(lexecution);
                }
                else
                  continue;
              }
            }
            if (result.opreator == "=")
            {
              if (result.opreator2 == ">")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    LExecution lexecution = new LExecution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      lexecution.parentid = this.parentid;
                      lexecution.id = this.id;
                      lexecution.change = result.change;
                      lexecution.changetype = result.changetype;
                      lexecution.changevalue = result.changevalue;
                      lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      lexecution.region = this.results[result.changename].ToString();
                      lexecution.time = result.times;
                      lexecution.ctime = lexecution.time;
                      this.Eventsexe.Add(lexecution);
                    }
                    else
                      continue;
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  LExecution lexecution = new LExecution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    lexecution.parentid = this.parentid;
                    lexecution.id = this.id;
                    lexecution.change = result.change;
                    lexecution.changetype = result.changetype;
                    lexecution.changevalue = result.changevalue;
                    lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    lexecution.region = this.results[result.changename].ToString();
                    lexecution.time = result.times;
                    lexecution.ctime = lexecution.time;
                    this.Eventsexe.Add(lexecution);
                  }
                  else
                    continue;
                }
              }
              else if (result.opreator2 == "=")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    LExecution lexecution = new LExecution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      lexecution.parentid = this.parentid;
                      lexecution.id = this.id;
                      lexecution.change = result.change;
                      lexecution.changetype = result.changetype;
                      lexecution.changevalue = result.changevalue;
                      lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      lexecution.region = this.results[result.changename].ToString();
                      lexecution.time = result.times;
                      lexecution.ctime = lexecution.time;
                      this.Eventsexe.Add(lexecution);
                    }
                    else
                      continue;
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  LExecution lexecution = new LExecution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    lexecution.parentid = this.parentid;
                    lexecution.id = this.id;
                    lexecution.change = result.change;
                    lexecution.changetype = result.changetype;
                    lexecution.changevalue = result.changevalue;
                    lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    lexecution.region = this.results[result.changename].ToString();
                    lexecution.time = result.times;
                    lexecution.ctime = lexecution.time;
                    this.Eventsexe.Add(lexecution);
                  }
                  else
                    continue;
                }
              }
              else if (result.opreator2 == "<")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    LExecution lexecution = new LExecution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      lexecution.parentid = this.parentid;
                      lexecution.id = this.id;
                      lexecution.change = result.change;
                      lexecution.changetype = result.changetype;
                      lexecution.changevalue = result.changevalue;
                      lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      lexecution.region = this.results[result.changename].ToString();
                      lexecution.time = result.times;
                      lexecution.ctime = lexecution.time;
                      this.Eventsexe.Add(lexecution);
                    }
                    else
                      continue;
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  LExecution lexecution = new LExecution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    lexecution.parentid = this.parentid;
                    lexecution.id = this.id;
                    lexecution.change = result.change;
                    lexecution.changetype = result.changetype;
                    lexecution.changevalue = result.changevalue;
                    lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    lexecution.region = this.results[result.changename].ToString();
                    lexecution.time = result.times;
                    lexecution.ctime = lexecution.time;
                    this.Eventsexe.Add(lexecution);
                  }
                  else
                    continue;
                }
              }
              else if ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime))
              {
                LExecution lexecution = new LExecution();
                if (!result.noloop)
                {
                  if (result.time > 0)
                  {
                    --result.time;
                    if (result.time == 0)
                      result.noloop = true;
                  }
                  lexecution.parentid = this.parentid;
                  lexecution.id = this.id;
                  lexecution.change = result.change;
                  lexecution.changetype = result.changetype;
                  lexecution.changevalue = result.changevalue;
                  lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                  lexecution.region = this.results[result.changename].ToString();
                  lexecution.time = result.times;
                  lexecution.ctime = lexecution.time;
                  this.Eventsexe.Add(lexecution);
                }
                else
                  continue;
              }
            }
            if (result.opreator == "<")
            {
              if (result.opreator2 == ">")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    LExecution lexecution = new LExecution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      lexecution.parentid = this.parentid;
                      lexecution.id = this.id;
                      lexecution.change = result.change;
                      lexecution.changetype = result.changetype;
                      lexecution.changevalue = result.changevalue;
                      lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      lexecution.region = this.results[result.changename].ToString();
                      lexecution.time = result.times;
                      lexecution.ctime = lexecution.time;
                      this.Eventsexe.Add(lexecution);
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  LExecution lexecution = new LExecution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    lexecution.parentid = this.parentid;
                    lexecution.id = this.id;
                    lexecution.change = result.change;
                    lexecution.changetype = result.changetype;
                    lexecution.changevalue = result.changevalue;
                    lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    lexecution.region = this.results[result.changename].ToString();
                    lexecution.time = result.times;
                    lexecution.ctime = lexecution.time;
                    this.Eventsexe.Add(lexecution);
                  }
                }
              }
              else if (result.opreator2 == "=")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    LExecution lexecution = new LExecution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      lexecution.parentid = this.parentid;
                      lexecution.id = this.id;
                      lexecution.change = result.change;
                      lexecution.changetype = result.changetype;
                      lexecution.changevalue = result.changevalue;
                      lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      lexecution.region = this.results[result.changename].ToString();
                      lexecution.time = result.times;
                      lexecution.ctime = lexecution.time;
                      this.Eventsexe.Add(lexecution);
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  LExecution lexecution = new LExecution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    lexecution.parentid = this.parentid;
                    lexecution.id = this.id;
                    lexecution.change = result.change;
                    lexecution.changetype = result.changetype;
                    lexecution.changevalue = result.changevalue;
                    lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    lexecution.region = this.results[result.changename].ToString();
                    lexecution.time = result.times;
                    lexecution.ctime = lexecution.time;
                    this.Eventsexe.Add(lexecution);
                  }
                }
              }
              else if (result.opreator2 == "<")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    LExecution lexecution = new LExecution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      lexecution.parentid = this.parentid;
                      lexecution.id = this.id;
                      lexecution.change = result.change;
                      lexecution.changetype = result.changetype;
                      lexecution.changevalue = result.changevalue;
                      lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      lexecution.region = this.results[result.changename].ToString();
                      lexecution.time = result.times;
                      lexecution.ctime = lexecution.time;
                      this.Eventsexe.Add(lexecution);
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  LExecution lexecution = new LExecution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    lexecution.parentid = this.parentid;
                    lexecution.id = this.id;
                    lexecution.change = result.change;
                    lexecution.changetype = result.changetype;
                    lexecution.changevalue = result.changevalue;
                    lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    lexecution.region = this.results[result.changename].ToString();
                    lexecution.time = result.times;
                    lexecution.ctime = lexecution.time;
                    this.Eventsexe.Add(lexecution);
                  }
                }
              }
              else if ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime))
              {
                LExecution lexecution = new LExecution();
                if (!result.noloop)
                {
                  if (result.time > 0)
                  {
                    --result.time;
                    if (result.time == 0)
                      result.noloop = true;
                  }
                  lexecution.parentid = this.parentid;
                  lexecution.id = this.id;
                  lexecution.change = result.change;
                  lexecution.changetype = result.changetype;
                  lexecution.changevalue = result.changevalue;
                  lexecution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                  lexecution.region = this.results[result.changename].ToString();
                  lexecution.time = result.times;
                  lexecution.ctime = lexecution.time;
                  this.Eventsexe.Add(lexecution);
                }
              }
            }
          }
        }
        for (int index = 0; index < this.Eventsexe.Count; ++index)
        {
          if (!this.Eventsexe[index].NeedDelete)
          {
            this.Eventsexe[index].Update(this);
          }
          else
          {
            this.Eventsexe.RemoveAt(index);
            --index;
          }
        }
      }
      int num = 0;
      if (this.rand.t != 0)
        num = (int) MathHelper.Lerp((float) -this.rand.t, (float) this.rand.t, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if (this.t <= 0)
        return;
      if (this.Deepbind)
      {
        this.Shoot(layerm, cs, Times, Centers, Player);
      }
      else
      {
        if (this.time % this.t + num != 0)
          return;
        this.Shoot(layerm, cs, Times, Centers, Player);
      }
    }

    private void Shoot(
      LayerManager layerm,
      CrazyStorm cs,
      Time Times,
      Center Centers,
      Vector2 Player)
    {
      int num1 = this.tiao;
      int num2 = 0;
      int num3 = 0;
      float num4 = 0.0f;
      float num5 = 0.0f;
      float num6 = 0.0f;
      float num7 = 0.0f;
      float num8 = 0.0f;
      if (this.rand.tiao != 0)
        num1 = this.tiao + (int) MathHelper.Lerp((float) -this.rand.tiao, (float) this.rand.tiao, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.r != 0.0)
        num2 = (int) MathHelper.Lerp(-this.rand.r, this.rand.r, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.rdirection != 0.0)
        num4 = MathHelper.Lerp(-this.rand.rdirection, this.rand.rdirection, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if (this.rand.range != 0)
        num3 = (int) MathHelper.Lerp((float) -this.rand.range, (float) this.rand.range, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.sonspeed != 0.0)
        num5 = MathHelper.Lerp(-this.rand.sonspeed, this.rand.sonspeed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.fdirection != 0.0)
        num6 = MathHelper.Lerp(-this.rand.fdirection, this.rand.fdirection, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.sonaspeed != 0.0)
        num7 = MathHelper.Lerp(-this.rand.sonaspeed, this.rand.sonaspeed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.sonaspeedd != 0.0)
        num8 = MathHelper.Lerp(-this.rand.sonaspeedd, this.rand.sonaspeedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if (this.bindid == -1)
      {
        for (int index1 = 0; index1 < num1; ++index1)
        {
          Barrage barrage = new Barrage();
          barrage.IsLase = true;
          if ((double) layerm.LayerArray[this.parentid].LaseArray[this.id].rdirection == -99999.0)
            this.rdirection = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, this.x - 4f, this.y + 16f));
          float degrees = this.rdirection + ((float) index1 - (float) (((double) num1 - 1.0) / 2.0)) * (float) (this.range + num3) / (float) num1 + num4;
          barrage.x = (float) ((double) this.x - 4.0 + ((double) this.r + (double) num2) * Math.Cos((double) MathHelper.ToRadians(degrees))) + Centers.ox - Centers.x;
          barrage.y = (float) ((double) this.y + 16.0 + ((double) this.r + (double) num2) * Math.Sin((double) MathHelper.ToRadians(degrees))) + Centers.oy - Centers.y;
          barrage.life = this.sonlife;
          barrage.type = (int) this.type;
          barrage.wscale = this.wscale;
          barrage.longs = this.longs;
          barrage.alpha = this.alpha;
          barrage.speed = this.sonspeed + num5;
          if ((double) layerm.LayerArray[this.parentid].LaseArray[this.id].fdirection == -99999.0)
            this.fdirection = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, barrage.x, barrage.y));
          else if ((double) layerm.LayerArray[this.parentid].LaseArray[this.id].fdirection == -100000.0)
            this.fdirection = MathHelper.ToDegrees(Main.Twopointangle(this.fdirections.X, this.fdirections.Y, barrage.x, barrage.y));
          barrage.speedd = (float) ((double) this.fdirection + (double) num6 + (double) ((float) index1 - (float) (((double) num1 - 1.0) / 2.0)) * (double) (this.range + num3) / (double) num1);
          barrage.aspeed = this.sonaspeed + num7;
          if ((double) layerm.LayerArray[this.parentid].LaseArray[this.id].sonaspeedd == -99999.0)
            layerm.LayerArray[this.parentid].LaseArray[this.id].copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, barrage.x, barrage.y));
          else if ((double) layerm.LayerArray[this.parentid].LaseArray[this.id].sonaspeedd == -100000.0)
            layerm.LayerArray[this.parentid].LaseArray[this.id].copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(this.sonaspeedds.X, this.sonaspeedds.Y, barrage.x, barrage.y));
          barrage.aspeedd = this.sonaspeedd + num8;
          barrage.speedx = this.xscale * barrage.speed * (float) Math.Cos((double) MathHelper.ToRadians(barrage.speedd));
          barrage.speedy = this.yscale * barrage.speed * (float) Math.Sin((double) MathHelper.ToRadians(barrage.speedd));
          barrage.aspeedx = this.xscale * barrage.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(barrage.aspeedd));
          barrage.aspeedy = this.yscale * barrage.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(barrage.aspeedd));
          barrage.IsRay = this.Ray;
          barrage.xscale = this.xscale;
          barrage.yscale = this.yscale;
          barrage.Blend = this.Blend;
          barrage.Outdispel = this.Outdispel;
          barrage.Invincible = this.Invincible;
          for (int idx = 0; idx < this.Sonevents.Count; ++idx)
          {
            Event @event = new Event(idx);
            @event.t = this.Sonevents[idx].t;
            @event.addtime = this.Sonevents[idx].addtime;
            @event.events = this.Sonevents[idx].events;
            for (int index2 = 0; index2 < this.Sonevents[idx].results.Count; ++index2)
              @event.results.Add((EventRead) this.Sonevents[idx].results[index2].Copy());
            @event.index = this.Sonevents[idx].index;
            barrage.Events.Add(@event);
          }
          barrage.parentid = this.id;
          layerm.LayerArray[this.parentid].Barrages.Add(barrage);
        }
      }
      else
      {
        for (int index1 = 0; index1 < layerm.LayerArray[this.parentid].Barrages.Count; ++index1)
        {
          if (((!layerm.LayerArray[this.parentid].Barrages[index1].IsLase & layerm.LayerArray[this.parentid].Barrages[index1].parentid == this.bindid ? 1 : 0) & (layerm.LayerArray[this.parentid].Barrages[index1].time > 15 ? 1 : (!layerm.LayerArray[this.parentid].Barrages[index1].Mist ? 1 : 0)) & (!layerm.LayerArray[this.parentid].Barrages[index1].NeedDelete ? 1 : 0)) != 0)
          {
            if (this.Deepbind)
            {
              if (layerm.LayerArray[this.parentid].Barrages[index1].lase != null)
              {
                layerm.LayerArray[this.parentid].Barrages[index1].lase.x = layerm.LayerArray[this.parentid].Barrages[index1].x - (Centers.ox - Centers.x);
                layerm.LayerArray[this.parentid].Barrages[index1].lase.y = layerm.LayerArray[this.parentid].Barrages[index1].y - (Centers.oy - Centers.y);
                layerm.LayerArray[this.parentid].Barrages[index1].lase.Update(layerm, cs, Times, Centers, Player);
              }
              else
              {
                layerm.LayerArray[this.parentid].Barrages[index1].lase = this.Clone();
                layerm.LayerArray[this.parentid].Barrages[index1].lase.Deepbind = false;
                layerm.LayerArray[this.parentid].Barrages[index1].lase.Deepbinded = true;
                layerm.LayerArray[this.parentid].Barrages[index1].lase.bindid = -1;
                layerm.LayerArray[this.parentid].Barrages[index1].lase.time = 0;
                if (this.Bindwithspeedd)
                  layerm.LayerArray[this.parentid].Barrages[index1].lase.fdirection += layerm.LayerArray[this.parentid].Barrages[index1].fdirection;
                layerm.LayerArray[this.parentid].Barrages[index1].lase.Bindwithspeedd = false;
              }
            }
            else
            {
              for (int index2 = 0; index2 < num1; ++index2)
              {
                Barrage barrage = new Barrage();
                barrage.IsLase = true;
                if ((double) layerm.LayerArray[this.parentid].LaseArray[this.id].rdirection == -99999.0)
                  this.rdirection = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, layerm.LayerArray[this.parentid].Barrages[index1].x, layerm.LayerArray[this.parentid].Barrages[index1].y));
                float degrees = this.rdirection + ((float) index2 - (float) (((double) num1 - 1.0) / 2.0)) * (float) (this.range + num3) / (float) num1 + num4;
                barrage.x = layerm.LayerArray[this.parentid].Barrages[index1].x + (this.r + (float) num2) * (float) Math.Cos((double) MathHelper.ToRadians(degrees));
                barrage.y = layerm.LayerArray[this.parentid].Barrages[index1].y + (this.r + (float) num2) * (float) Math.Sin((double) MathHelper.ToRadians(degrees));
                barrage.life = this.sonlife;
                barrage.type = (int) this.type;
                barrage.wscale = this.wscale;
                barrage.longs = this.longs;
                barrage.alpha = this.alpha;
                barrage.speed = this.sonspeed + num5;
                if ((double) layerm.LayerArray[this.parentid].LaseArray[this.id].fdirection == -99999.0)
                  this.fdirection = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, barrage.x, barrage.y));
                else if ((double) layerm.LayerArray[this.parentid].LaseArray[this.id].fdirection == -100000.0)
                  this.fdirection = MathHelper.ToDegrees(Main.Twopointangle(this.fdirections.X, this.fdirections.Y, barrage.x, barrage.y));
                barrage.speedd = !this.Bindwithspeedd ? (float) ((double) this.fdirection + (double) num6 + (double) ((float) index2 - (float) (((double) num1 - 1.0) / 2.0)) * (double) (this.range + num3) / (double) num1) : (float) ((double) this.fdirection + (double) num6 + (double) ((float) index2 - (float) (((double) num1 - 1.0) / 2.0)) * (double) (this.range + num3) / (double) num1) + layerm.LayerArray[this.parentid].Barrages[index1].speedd;
                barrage.aspeed = this.sonaspeed + num7;
                if ((double) layerm.LayerArray[this.parentid].LaseArray[this.id].sonaspeedd == -99999.0)
                  this.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, barrage.x, barrage.y));
                else if ((double) layerm.LayerArray[this.parentid].LaseArray[this.id].sonaspeedd == -100000.0)
                  this.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(this.sonaspeedds.X, this.sonaspeedds.Y, barrage.x, barrage.y));
                barrage.aspeedd = this.sonaspeedd + num8;
                barrage.speedx = this.xscale * barrage.speed * (float) Math.Cos((double) MathHelper.ToRadians(barrage.speedd));
                barrage.speedy = this.yscale * barrage.speed * (float) Math.Sin((double) MathHelper.ToRadians(barrage.speedd));
                barrage.aspeedx = this.xscale * barrage.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(barrage.aspeedd));
                barrage.aspeedy = this.yscale * barrage.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(barrage.aspeedd));
                barrage.IsRay = this.Ray;
                barrage.xscale = this.xscale;
                barrage.yscale = this.yscale;
                barrage.Blend = this.Blend;
                barrage.Outdispel = this.Outdispel;
                barrage.Invincible = this.Invincible;
                for (int idx = 0; idx < this.Sonevents.Count; ++idx)
                {
                  Event @event = new Event(idx);
                  @event.t = this.Sonevents[idx].t;
                  @event.addtime = this.Sonevents[idx].addtime;
                  @event.events = this.Sonevents[idx].events;
                  for (int index3 = 0; index3 < this.Sonevents[idx].results.Count; ++index3)
                    @event.results.Add((EventRead) this.Sonevents[idx].results[index3].Copy());
                  @event.index = this.Sonevents[idx].index;
                  barrage.Events.Add(@event);
                }
                barrage.parentid = this.id;
                layerm.LayerArray[this.parentid].Barrages.Add(barrage);
              }
            }
          }
        }
      }
    }

    private double Rand(bool Ban, bool bomb)
    {
      if (!Ban)
        return Main.Rand(bomb);
      return Main.rand.NextDouble();
    }

    public Lase Clone()
    {
      Lase lase = this.Copy() as Lase;
      lase.Parentevents = new List<Event>();
      foreach (Event parentevent in this.Parentevents)
        lase.Parentevents.Add((Event) parentevent.Clone());
      lase.Eventsexe = new List<LExecution>();
      foreach (LExecution lexecution in this.Eventsexe)
        lase.Eventsexe.Add((LExecution) lexecution.Clone());
      lase.Sonevents = new List<Event>();
      foreach (Event sonevent in this.Sonevents)
        lase.Sonevents.Add((Event) sonevent.Clone());
      return lase;
    }

    public object Copy()
    {
      return this.MemberwiseClone();
    }
  }
}
