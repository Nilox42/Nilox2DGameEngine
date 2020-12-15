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
using System.IO;
using System.Diagnostics;

namespace Nilox2DGameEngine
{
    public class TestGameMode : Engine
    {
        #region Init
        //var
        public Player player = null;

        Level currentLevel = null;


        //Character Movement
        private bool left;
        private bool right;
        private bool up;
        private bool down;
        //
        bool movecamera = false;


        //Fighting
        private bool space;
        //
        bool canattack = true;
        bool isattacking = false;
        int attacktick = 0;
        Sprite2D damage = null;

        private float maxspeed = 3;
        private Vector2 lastPos = Vector2.Zero();
        public Vector2 spawnPosition = new Vector2(50, 48 * 4);

        //Actors 
        public List<Actor> allactors = new List<Actor>();
        public List<Enemy> enemies = new List<Enemy>();
        public List<Projectile> projectiles = new List<Projectile>();

        //Logging
        public static List<string> logs = new List<string>();


        //Camera Movement
        public double camerathreshold = 0.8;
        //

        public TestGameMode() : base(new Vector2(1280,720), "Engine Demo") { }
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
            #region Enemymanagment
            if (enemies.Count < 1)
            {
                Random x = new Random();
                Random y = new Random();

                Vector2 v = new Vector2((int)x.Next(0, Window.Width), (int)y.Next(0, Window.Height));
                spawnActorFromClass(v,Class.enemie);
            }
            #endregion 
            //
            //
            #region Input
            if (up)
            {
                if (movecamera)
                {
                    CameraPostition -= maxspeed;
                }
                else
                {
                    player.sprite.location.Y -= maxspeed;
                }
            }
            if (down)
            {
                if (movecamera)
                {
                    CameraPostition.Y -= maxspeed;
                }
                else
                {
                    player.sprite.location.Y += maxspeed;
                }
            }
            if (left)
            {
                if (movecamera)
                {
                    CameraPostition.X += maxspeed;
                }
                else
                {
                    player.sprite.location.X -= maxspeed;
                }
            }
            if (right)
            {
                if (movecamera)
                {
                    CameraPostition.X -= maxspeed;
                }
                else
                {
                    player.sprite.location.X += maxspeed;
                }
            }
            #endregion
            //
            //
            #region Fighting
            if (isattacking)
            {
                if (attacktick >= 10)
                {
                    isattacking = false;
                    canattack = true;
                    attacktick = 0;

                    if (damage != null)
                    {
                        damage.DestroySelf();
                        damage = null;
                    }
                    Log.Warning("ATTACK STOP" + attacktick);
                }
                else
                {
                    attacktick++;
                }
            }
            else
            {
                if (canattack == true && space == true)
                {
                    isattacking = true;
                    //ATTACK
                    damage = new Sprite2D(player.sprite.location, new Vector2(48, 48), "Selector", "Damage" , true);

                    canattack = false;
                }
            }
            #endregion
            //
            //
            #region Collision
            if (player.sprite.IsCollidingWithTag("collider") != null)
            {
                player.location.X = lastPos.X;
                player.location.Y = lastPos.Y;
            }
            else
            {
                lastPos.X = player.location.X;
                lastPos.Y = player.location.Y;
            }
            #endregion
            //
            //
            #region Pickups
            player.coinpickup();
            player.keypickup();
            player.healthpickup();
            #endregion
            //
            //
            #region Map Movement
            if (player.sprite.IsCollidingWithTag("DoorRight") != null)
            {
                currentLevel.moveRight();
            }
            if (player.sprite.IsCollidingWithTag("DoorLeft") != null)
            {
                currentLevel.moveLeft();
            }
            #endregion
            //
            //
            #region AI Tick
            foreach (Enemy e in enemies)
            {
                //Update all Enemies
                e.Update();
                //
                if (damage != null && e != null)
                {
                    if (e.sprite.location.X < damage.location.X + damage.scale.X        &&
                        e.sprite.location.X + e.sprite.scale.X  > damage.location.X      &&
                        e.sprite.location.Y < damage.location.Y + damage.scale.Y        &&
                        e.sprite.location.Y + e.sprite.scale.Y  > damage.location.Y      )
                    {
                        e.Damge(null, 1000);
                    }
                    else
                    {

                    }
                }
            }

            //ProjectileMovement
            foreach (Projectile p in projectiles)
            {
                p.move();
            }
            #endregion
        }

        public override void OnClose()
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();

            string name = "log" + Engine.sessionkey;
            string path = Application.StartupPath + @"\log" + @"\" + name + ".txt";
            string time = Engine.FrameCount.ToString();

            File.WriteAllText(path, " ");

            StreamWriter sw = new StreamWriter(path);

            foreach (string s in TestGameMode.logs)
            {
                sw.WriteLine(s);
            }

            sp.Stop();
            sw.WriteLine("[TIME]    -    " + sp.ElapsedMilliseconds.ToString());

            Log.Save("[LOGGING]    -    " + sp.ElapsedMilliseconds.ToString());

            sp = null;
            sw.Dispose();
        }

        public override void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)        { up    = true; }
            if (e.KeyCode == Keys.S)        { down  = true; }
            if (e.KeyCode == Keys.D)        { right = true; }
            if (e.KeyCode == Keys.A)        { left  = true; }
            if (e.KeyCode == Keys.Space)    { space = true; }
        }

        public override void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)        { up    = false; }
            if (e.KeyCode == Keys.S)        { down  = false; }
            if (e.KeyCode == Keys.D)        { right = false; }
            if (e.KeyCode == Keys.A)        { left  = false; }
            if (e.KeyCode == Keys.Space)    { space = false; }
        }
        #endregion
        //
        // //
        //
        #region Functions
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
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "o_tile15", "Background", true);
                    }
                    //Add sprite by name with normal perameters
                    else
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), t.Map[j, i], "", true);
                    }
                }
            }


            //Player 
            spawnActorFromClass(new Vector2(200, 200),Class.player);
        }
        public void UnloadCurrentTile()
        {
            Log.Warning("Clearing all Sprites");
            int count = Engine.allSprites.Count;
            for (int i = 0; i < count; ++i)
            {
                Engine.allSprites.ElementAt(0).DestroySelf();
                Console.WriteLine(Engine.allSprites.Count.ToString());
            }
        }
        public void updateCameraPosition( Vector2 v)
        {
            
        }
        #endregion
        //
        // //
        //
        #region Actors Management
        public Actor spawnActorFromClass(Vector2 location, Class clas)
        {
            switch (clas)
            {
                default:
                    {
                        return null;
                    }
                case Class.player:
                    {
                        Sprite2D sprite = new Sprite2D(spawnPosition, new Vector2(30, 48), "Knight_Idle", "player", true);
                        player = new Player(sprite);

                        return player;
                    }
                case Class.enemie:
                    {
                        Sprite2D sprite = new Sprite2D(location, new Vector2(48, 48), "rectangle2", "Enemie", true);

                        Enemy enemie = new Enemy(sprite, location, this);
                        enemies.Add(enemie);

                        return enemie;
                    }
                case Class.projectile:
                    {
                        Sprite2D s = new Sprite2D(location, new Vector2(16, 16), "rocks1_1", "", true);

                        Projectile p = new Projectile(s, location, new Vector2(1, 0), 2, this);
                        projectiles.Add(p);

                        return p;
                    }
            }
        }


        public void destroyActor(Actor a)
        {
            switch (a.clas)
            {
                default:
                    {
                        break;
                    }
                case Class.enemie:
                    {
                        Log.Warning("[DESTROYED][ENEMY]  -  {" + a.sprite.name + "}");

                        Sprite2D sprite = a.sprite;

                        sprite.DestroySelf();

                        enemies.Remove((Enemy)a);
                        a = null;

                        break;
                    }
                case Class.projectile:
                    {
                        Log.Warning("[DESTROYED][PROJECTILE]  -  {" + a.sprite.name + "}");
                        a = null;

                        break;
                    }
                case Class.player:
                    {
                        Log.Error("PLAYER CANT BE DESTROYED!");

                        break;
                    }
            }

        }
        #endregion 
    }
}
