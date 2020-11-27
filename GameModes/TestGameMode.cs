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
using Nilox2DGameEngine.Character;

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


        public List<Enemy> enemies = new List<Enemy>();
        public List<Projectile> projectiles = new List<Projectile>();


        int aitick = 0;

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
            //input
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

            //Collosion
            if (player.IsCollidingWithTag("collider") != null)
            {
                player.location.X = lastPos.X;
                player.location.Y = lastPos.Y;
            }
            else
            {
                lastPos.X = player.location.X;
                lastPos.Y = player.location.Y;
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

            //AI Movement
            //Enemy Movement
            foreach (Enemy e in enemies)
            {
                e.aiTick(player);
            }

            //ProjectileMovement
            foreach (Projectile p in projectiles)
            {
                p.move();
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
            //Map
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


            //Player 
            player = new Sprite2D(spawnPosition, new Vector2(30, 48), "Knight_Idle", "player");
            player.fetchimage();

            spawnenemie(new Vector2(200, 200));

        }

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
        //
        // //
        //
        #region Actors
        public void spawnenemie(Vector2 location)
        {
            Sprite2D s = new Sprite2D(location, new Vector2(48, 48), "rectangle2", "");
            s.fetchimage();
        
            Enemy e = new Enemy(s,location,this);
            enemies.Add(e);
        }

        public void spawnProjectile(Vector2 location)
        {
            Sprite2D s = new Sprite2D(location, new Vector2(16, 16), "rocks1_1", "");
            s.fetchimage();

            Projectile p = new Projectile(s, location, new Vector2(1,0), 2, this);
            projectiles.Add(p);
        }


        public void desroyEnemie(Enemy e)
        {
            Log.Warning("[DESTROYED][ENEMY]  -  {" + e.sprite.name + "}");
            e = null;
        }

        public void destroyProjectile(Projectile p)
        {
            Log.Warning("[DESTROYED][PROJECTILE]  -  {" + p.sprite.name + "}");
            p = null;
        }

        #endregion
    }
}
