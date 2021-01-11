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
    public class GameMode : Engine
    {
        #region Init
      //Level
        public Level currentLevel = null;
        public bool canmoveon = false;
        public bool canmoveback = false;
        public bool ismoving = false;

        //Player
        public Player player = null;
        public bool canmove = false;
        //Character Movement
        private bool left;
        private bool right;
        private bool up;
        private bool down;
        //Fighting
        private bool space;
        //
        bool canattack = true;
        bool isattacking = false;
        int attacktick = 0;
        Sprite2D damage = null;
        //Movement
        private float maxspeed = 13;
        private Vector2 lastPos = Vector2.Zero();
        public Vector2 spawnPosition = new Vector2(50, 48 * 4);

      //Actors 
        public List<Actor> allactors = new List<Actor>();
        public List<Enemy> allenemies = new List<Enemy>();
        public List<Projectile> allprojectiles = new List<Projectile>();
        public List<Item> allitems = new List<Item>();

      //Logging
        public static List<string> logs = new List<string>();
 

        public GameMode() : base(new Vector2(1280,720), "Engine Demo") 
        {
            
        }
        #endregion
        //
        // //
        //
        #region Overrrides
        public override void onLoad()
        {
            backgroundColor = Color.Black;
            currentLevel = new Level("One",this);
        }

        public override void onDraw()
        {
            
        }

        public override void onUpdate()
        {
            #region Player
            player.update();
            #endregion
            //
            //
            #region Enemymanagment
            if (allenemies.Count < 3)
            {
                Vector2 v = new Vector2(0, 0);

                Random random = new Random();
                v.X = (int)random.Next(0, Window.Width - 50);
                v.Y = (int)random.Next(0, Window.Height - 50);
                random = null;

                spawnActorFromClass(v, Class.enemie);
            }
            #endregion 
            //
            //
            #region Input
            if (canmove == true)
            {
                if (up && player != null)
                {
                    //player.sprite.location.Y -= maxspeed;
                    //player.setLocation(new Vector2 (player.location.X, player.location.Y - maxspeed));
                    player.move(new Vector2(0,maxspeed * -1));
                }
                if (down && player != null)
                {
                    //player.sprite.location.Y += maxspeed;
                    //player.setLocation(new Vector2(player.location.X, player.location.Y + maxspeed));
                    player.move(new Vector2(0, maxspeed));
                }
                if (left && player != null)
                {
                    //player.sprite.location.X -= maxspeed;
                    //player.setLocation(new Vector2(player.location.X - maxspeed, player.location.Y));
                    player.move(new Vector2(maxspeed * -1, 0));
                }
                if (right && player != null)
                {
                    //player.sprite.location.X += maxspeed;
                    //player.setLocation(new Vector2(player.location.X + maxspeed, player.location.Y));
                    player.move(new Vector2(maxspeed, 0));
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
                    //Reset Attack
                    isattacking = false;
                    canattack = true;
                    attacktick = 0;

                    //Destroy Damage Sprite e
                    if (damage != null)
                    {
                        damage.DestroySelf();
                        damage = null;
                    }
                    //Log.Warning("ATTACK STOP" + attacktick);
                }
                else
                {
                    //Increase Attacktick to give the attack some duration
                    attacktick++;
                    damage.location = player.sprite.location;
                }
            }
            else
            {
                //Determin if player can attack
                if (canattack == true && space == true)
                {
                    isattacking = true;
                    canattack = false;
                    //ATTACK
                    damage = new Sprite2D(player.sprite.location, new Vector2(48, 48), "Selector", "Damage" , true);
                }
            }
            #endregion
            //
            //
            #region AI Tick
            foreach (Actor a in allactors)
            {
                //Update all Actors
                a.update();
                //
                if (a.clas == Class.enemie)
                {
                    //Damage
                    if (damage != null && a != null)
                    {
                        if (a.sprite.location.X < damage.location.X + damage.scale.X &&
                            a.sprite.location.X + a.sprite.scale.X > damage.location.X &&
                            a.sprite.location.Y < damage.location.Y + damage.scale.Y &&
                            a.sprite.location.Y + a.sprite.scale.Y > damage.location.Y)
                        {
                            a.damge(player, 1000);
                        }
                    }
                }
            }

            //ProjectileMovement
            foreach (Projectile p in allprojectiles)
            {
                p.move();
            }
            #endregion
        }

        public override void onClose()
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();

            string name = "log" + Engine.sessionkey;
            string path = Application.StartupPath + @"\log" + @"\" + name + ".txt";
            string time = Engine.frameCount.ToString();

            File.WriteAllText(path, " ");

            StreamWriter sw = new StreamWriter(path);

            foreach (string s in GameMode.logs)
            {
                sw.WriteLine(s);
            }

            sp.Stop();
            sw.WriteLine("[TIME]    -    " + sp.ElapsedMilliseconds.ToString());

            Log.Save("[LOGGING]    -    " + sp.ElapsedMilliseconds.ToString());

            sw = null;
            sw.Dispose();
        }

        public override void keyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)        { up    = true; }
            if (e.KeyCode == Keys.S)        { down  = true; }
            if (e.KeyCode == Keys.D)        { right = true; }
            if (e.KeyCode == Keys.A)        { left  = true; }
            if (e.KeyCode == Keys.Space)    { space = true; }

            //Debug
            if(e.KeyCode == Keys.U)         { unloadCurrentTile(); }
            if (e.KeyCode == Keys.N)        { loadNewTile(currentLevel.tiles.ElementAt(Convert.ToInt32(currentLevel.currentlocation.X))); }
            if (e.KeyCode == Keys.O)
            { 
                player.setLocation(currentLevel.tiles.ElementAt(Convert.ToInt32(currentLevel.currentlocation.X)).spawnlocation);
                Log.Error("RESET TO LOCATION: " + currentLevel.tiles.ElementAt(Convert.ToInt32(currentLevel.currentlocation.X)).spawnlocation.ToString());
            }
        }

        public override void keyUp(KeyEventArgs e)
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
        public void loadNewTile(Tile t)
        {
            //Map
            Log.Info($"[LOADING]:  Name: {t.name};  Size:{t.tilesize};  Spawnlocation:{t.spawnlocation.ToString()}");
            for (int i = 0; i < t.map.GetLength(0); i++)
            {
                for (int j = 0; j < t.map.GetLength(1); j++)
                {
                    //Add Sprite2D if i has the name "." with special parameters
                    if (t.map[j, i] == ".")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "o_tile15", "Background", true);
                    }
                    //Add sprite by name with normal perameters
                    else
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), t.map[j, i], "", true);
                    }
                }
            }

            //Spawn Player
            spawnActorFromClass(new Vector2(t.spawnlocation.X, t.spawnlocation.Y), Class.player);

            // Set level varibles
            ismoving = false;
            canmoveon = true;

            // enable Player
            resetPlayer();
            canmove = true;

            // enable Engine
            Engine.disablerenderer = false;
            Log.Warning("[ENGINE]  -  EGNINE ENABLED -----------------------------------------------------------------------------------------------");
        }
        public void unloadCurrentTile()
        {      
            // Prep
            Engine.disablerenderer = true;
            Log.Warning("[ENGINE]  -  EGNINE DISABLED ----------------------------------------------------------------------------------------------");

            //Player
            player.destroy();
            player = null;
            Log.Warning("[GameMode]  -  Player Destroyed! ------------------------------------------------------------------------------------------");

            //Kill all Actors
            while(allactors.Count > 0)
            {
                destroyActor(allactors.ElementAt(0));
            }
            Log.Warning("[GameMode]  -  Actors Destroyed! ------------------------------------------------------------------------------------------");

            //Remove all Sprites
            Engine.clearAllSprite2Ds();
            Log.Warning("[GameMode]  -  Sprites2D Cleared! -----------------------------------------------------------------------------------------");

            Log.Warning("[GameMode]  -  Tile UNLOADED! ---------------------------------------------------------------------------------------------");
            Thread.Sleep(100);
        }

        public void resetPlayer()
        {
            Tile t = currentLevel.tiles.ElementAt(Convert.ToInt32(currentLevel.currentlocation.X));
            player.setLocation(new Vector2(t.spawnlocation.X, t.spawnlocation.Y));
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
                        Sprite2D sprite = new Sprite2D(new Vector2(location.X,location.Y), new Vector2(30, 48), "Knight_Idle", "player", true);

                        player = new Player(sprite, this);
                        player.setLocation(location);
                        sprite.actor = player;

                        return player;
                    }
                case Class.enemie:
                    {
                        Sprite2D sprite = new Sprite2D(location, new Vector2(48, 48), "rectangle2", "enemie", true);

                        Enemy enemie = new Enemy(sprite, sprite.location, this);
                        sprite.actor = enemie;

                        allenemies.Add(enemie);
                        allactors.Add(enemie);

                        enemie.clas = Class.enemie;

                        return enemie;
                    }
                case Class.projectile:
                    {
                        Sprite2D sprite = new Sprite2D(location, new Vector2(16, 16), "rocks1_1", "", true);

                        Projectile projectile = new Projectile(sprite, sprite.location, new Vector2(1, 0), 2, this);
                        sprite.actor = projectile;

                        allprojectiles.Add(projectile);
                        allactors.Add(projectile);

                        projectile.clas = Class.projectile;

                        return projectile;
                    }
                case Class.item:
                    {
                        Sprite2D sprite = new Sprite2D(location, new Vector2(20, 20), "coin", "", true);

                        Item item = new Item(sprite, location, this);
                        sprite.actor = item;

                        allitems.Add(item);
                        allactors.Add(item);
                        item.clas = Class.item;

                        return item;
                    }
            }
        }

        public void destroyActor(Actor a)
        {
            if (a == null)
            {
                return;
            }
            switch (a.clas)
            {
                default:
                    {
                        break;
                    }
                case Class.enemie:
                    {
                        Sprite2D sprite = a.sprite;
                        sprite.DestroySelf();

                        allenemies.Remove((Enemy)a);
                        allactors.Remove(a);

                        Log.Warning("[DESTROYED][ENEMY]  -  {" + a.sprite.name + "}");
                        a = null;

                        break;
                    }
                case Class.projectile:
                    {
                        Sprite2D sprite = a.sprite;
                        sprite.DestroySelf();

                        allprojectiles.Remove((Projectile)a);
                        allactors.Remove(a);

                        Log.Warning("[DESTROYED][PROJECTILE]  -  {" + a.sprite.name + "}");
                        a = null;

                        break;
                    }
                case Class.player:
                    {
                        player.destroy();
                        player.sprite.DestroySelf();
                        player = null;

                        break;
                    }
                case Class.item:
                    {
                        Sprite2D sprite = a.sprite;
                        sprite.DestroySelf();

                        allitems.Remove((Item)a);
                        allactors.Remove(a);

                        Log.Warning("[DESTROYED][Item]  -  {" + a.sprite.name + "}");
                        a = null;

                        break;
                    }
            }
        }

        #endregion
    }
}
