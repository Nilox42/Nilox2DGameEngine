using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Nilox2DGameEngine.Map;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine
{
    public class TestGameMode : Engine
    {
        #region Init
        Sprite2D player = null;
        Level currentLevel = null;

        private bool left;
        private bool right;
        private bool up;
        private bool down;

        private float maxspeed = 3;
        private Vector2 lastPos = Vector2.Zero();
        public Vector2 spawnPosition = new Vector2(50, 48 * 4);

        public TestGameMode() : base(new Vector2(735,330), "Engine Demo") { }
        #endregion
        //
        // //
        //
        #region Overrrides
        public override void OnLoad()
        {
            BackgroundColor = Color.Black;

            currentLevel = new Level("Test",this);
        }

        public override void OnDraw()
        {
            
        }

        public override void OnUpdate()
        {
            if (up)
            {
                player.Position.Y -= maxspeed;
            }
            if (down)
            {
                player.Position.Y += maxspeed;
            }
            if (left)
            {
                player.Position.X -= maxspeed;
            }
            if (right)
            {
                player.Position.X += maxspeed;
            }

            //Collosion
            if (player.IsCollidingWithTag("Collider") != null)
            {
                player.Position.X = lastPos.X;
                player.Position.Y = lastPos.Y;
            }
            else
            {
                lastPos.X = player.Position.X;
                lastPos.Y = player.Position.Y;
            }

            //Map Movement
            if (player.IsCollidingWithTag("DoorRight") != null)
            {
                currentLevel.moveRight();
            }
            if (player.IsCollidingWithTag("DoorLeft") != null)
            {
                currentLevel.moveLeft();
            }

        }

        public override void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = true; }
            if (e.KeyCode == Keys.S) { down = true; }
            if (e.KeyCode == Keys.D) { right = true; }
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.Space) {  }
        }

        public override void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.D) { right = false; }
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.Space) {  }
        }

        public void LoadNewTile(Tile t)
        {
            Log.Info("[LOADING]:" + t.name);
            for (int i = 0; i < t.Map.GetLength(0); i++)
            {
                for (int j = 0; j < t.Map.GetLength(1); j++)
                {
                    //Add Sprite2D if i has the name "." with special parameters
                    if (t.Map[j, i] == ".")
                    {
                        Sprite2D s = new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "o_tile15", "Background");
                    }
                    //Add sprite by name with normal perameters
                    else
                    {
                        Sprite2D s = new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), t.Map[j, i], "");
                    }
                }
            }

            //Create the palyer Sprite2D 
            player = new Sprite2D(spawnPosition, new Vector2(30, 48), "Knight_Idle", "Player");
            player.fetchimage();
        }
        /*
        public void OLDLoadNewTile(Tile t)
        {
            Log.Info("[LOADING]:" + t.name);
            for (int i = 0; i < t.Map.GetLength(0); i++)
            {
                for (int j = 0; j < t.Map.GetLength(1); j++)
                {
                    if (t.Map[j, i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Overworld/Tiles/o_tile22", "Collider");
                    }
                    if (t.Map[j, i] == "w")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Overworld/Tiles/o_tile53", "Collider");
                    }
                    if (t.Map[j, i] == "s")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Overworld/Tiles/o_tile12", "BackGround");
                    }
                    if (t.Map[j, i] == "dr")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Default/tile60", "DoorRight");
                    }
                    if (t.Map[j, i] == "dl")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Default/tile60", "DoorLeft");
                    }
                }
            }
            player = new Sprite2D(spawnPosition, new Vector2(48, 48), "Overworld/Objects/rocks1_7", "Player");
        }
        */

        public void UnloadCurrentTile()
        {
            Log.Warning("Clearing all Sprites");
            int count = Engine.AllSprites.Count;
            for (int i = 0 ; i < count; ++i)
            {
                Engine.AllSprites.ElementAt(0).DestroySelf();
                Console.WriteLine(Engine.AllSprites.Count.ToString());
            }
        }
        #endregion







    }
}
