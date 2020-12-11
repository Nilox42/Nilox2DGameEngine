﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Nilox2DGameEngine.Map;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Core
{
    public class BaseGameMode : Engine
    {
        #region Init
        Sprite2D player = null;

        bool left;
        bool right;
        bool up;
        bool down;

        float maxspeed = 1;
        Vector2 lastPos = Vector2.Zero();

        

        public BaseGameMode() : base(new Vector2(1280,720), "Engine Demo") { }
        #endregion
        //
        // //
        //
        #region Overrrides
        public override void OnLoad()
        {
            BackgroundColor = Color.Black;

            player = new Sprite2D(new Vector2(48, 48), new Vector2(48, 48), "Overworld/Objects/rocks1_7", "Player", true);
        }

        public override void OnDraw()
        {
            
        }

        public override void OnUpdate()
        {
            if (up)
            {
                player.location.Y -= maxspeed;
            }
            if (down)
            {
                player.location.Y += maxspeed;
            }
            if (left)
            {
                player.location.X -= maxspeed;
            }
            if (right)
            {
                player.location.X += maxspeed;
            }
            if (player.IsCollidingWithTag("Collider") != null)
            {
                player.location.X = lastPos.X;
                player.location.Y = lastPos.Y;
            }
            else
            {
                lastPos.X = player.location.X;
                lastPos.Y = player.location.Y;
            }
        }

        public override void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = true; }
            if (e.KeyCode == Keys.S) { down = true; }
            if (e.KeyCode == Keys.D) { right = true; }
            if (e.KeyCode == Keys.A) { left = true; }
        }

        public override void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.D) { right = false; }
            if (e.KeyCode == Keys.A) { left = false; }
        }

        public void LoadNewTile(Tile t)
        {
            for (int i = 0; i < t.Map.GetLength(0); i++)
            {
                for (int j = 0; j < t.Map.GetLength(1); j++)
                {
                    if (t.Map[j, i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Overworld/Tiles/tile22", "Collider", true);
                    }
                    if (t.Map[j, i] == "w")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Overworld/Tiles/tile53", "Collider", true);
                    }
                    if (t.Map[j, i] == "s")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Overworld/Tiles/tile12", "BackGround", true);
                    }
                }
            }
        }

        public void UnloadCurrentTile()
        {
            Log.Warning("Clearing all Sprites");
            int count = Engine.allSprites.Count;
            for (int i = 0 ; i < count; ++i)
            {
                Engine.allSprites.ElementAt(0).DestroySelf();
                Console.WriteLine(Engine.allSprites.Count.ToString());
            }
        }

        public override void OnClose()
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
