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
        Vector2 lastPos = Vector2.zero();

        

        public BaseGameMode() : base(new Vector2(1280,720), "Engine Demo") { }
        #endregion
        //
        // //
        //
        #region Overrrides
        public override void onLoad()
        {
            backgroundColor = Color.Black;

            player = new Sprite2D(new Vector2(48, 48), new Vector2(48, 48), "Overworld/Objects/rocks1_7", "Player", true);
        }

        public override void onDraw()
        {
            
        }

        public override void onUpdate()
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
            if (player.isCollidingWithTag("Collider") != null)
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

        public override void keyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = true; }
            if (e.KeyCode == Keys.S) { down = true; }
            if (e.KeyCode == Keys.D) { right = true; }
            if (e.KeyCode == Keys.A) { left = true; }
        }

        public override void keyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.D) { right = false; }
            if (e.KeyCode == Keys.A) { left = false; }
        }

        public void loadNewTile(Tile t)
        {
            for (int i = 0; i < t.map.GetLength(0); i++)
            {
                for (int j = 0; j < t.map.GetLength(1); j++)
                {
                    if (t.map[j, i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Overworld/Tiles/tile22", "Collider", true);
                    }
                    if (t.map[j, i] == "w")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Overworld/Tiles/tile53", "Collider", true);
                    }
                    if (t.map[j, i] == "s")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "Overworld/Tiles/tile12", "BackGround", true);
                    }
                }
            }
        }

        public void unloadCurrentTile()
        {
            Log.warning("Clearing all Sprites");
            int count = Engine.allSprites.Count;
            for (int i = 0 ; i < count; ++i)
            {
                Engine.allSprites.ElementAt(0).destroySelf();
                Console.WriteLine(Engine.allSprites.Count.ToString());
            }
        }

        public override void onClose()
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
