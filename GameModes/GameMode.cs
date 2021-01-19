using Nilox2DGameEngine.Objects;
using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Map;
using Nilox2DGameEngine.Menus;
using Nilox2DGameEngine.Util;
//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Nilox2DGameEngine
{
    public class GameMode : Engine
    {
        //
        #region Init

        public Controller cr = null;

        //Level
        public Level currentLevel = null;
        public bool canmoveon = false;
        public bool canmoveback = false;
        public bool ismoving = false;

        //Player
        public Player player = null;
        public bool playercanmove = false;
        public Vector2 spawnPosition = new Vector2(50, 48 * 4);
        //
        //Character Movement
        private bool left;
        private bool right;
        private bool up;
        private bool down;
        private float speed = 5;
        //
        //Fighting
        private bool space;
        bool canattack = true;
        bool isattacking = false;
        int attacktick = 0;
        Sprite2D damage = null;

        //Actors 
        public List<Actor> allactors = new List<Actor>();
        public List<Enemy> allenemies = new List<Enemy>();
        public List<Projectile> allprojectiles = new List<Projectile>();
        public List<Item> allitems = new List<Item>();
        public List<Boss> allbosses = new List<Boss>();

        //Logging
        public static List<string> logs = new List<string>();


        public GameMode(Controller cr0) : base(new Vector2(1280, 720), "Engine Demo")
        {
            cr = cr0;
        }
        #endregion
        //
        // //
        //
        #region Overrrides
        public override void onLoad()
        {
            backgroundColor = Color.Black;
            currentLevel = new Level("One", this);
        }

        public override void onDraw()
        {

        }

        public override void onUpdate()
        {
            #region Player
            if (player != null)
            {
                player.update();
            }
            #endregion
            //
            //
            #region Enemymanagment
            if (allenemies.Count < 1 && false)
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
            if (playercanmove == true)
            {
                if (up && player != null)
                {
                    //player.sprite.location.Y -= maxspeed;
                    //player.setLocation(new Vector2 (player.location.X, player.location.Y - maxspeed));
                    player.move(new Vector2(0, speed * -1));
                }
                if (down && player != null)
                {
                    //player.sprite.location.Y += maxspeed;
                    //player.setLocation(new Vector2(player.location.X, player.location.Y + maxspeed));
                    player.move(new Vector2(0, speed));
                }
                if (left && player != null)
                {
                    //player.sprite.location.X -= maxspeed;
                    //player.setLocation(new Vector2(player.location.X - maxspeed, player.location.Y));
                    player.move(new Vector2(speed * -1, 0));
                }
                if (right && player != null)
                {
                    //player.sprite.location.X += maxspeed;
                    //player.setLocation(new Vector2(player.location.X + maxspeed, player.location.Y));
                    player.move(new Vector2(speed, 0));
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
                        damage.destroySelf();
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
                    damage = new Sprite2D(player.sprite.location, new Vector2(48, 48), "Selector", "Damage", false);
                    player.shoot();
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

            // logging
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

            Log.save("[LOGGING]    -   Saving took " + sp.ElapsedMilliseconds.ToString());

            cr.closeGame();

            sw.Dispose();
            sw = null;
        }

        public override void keyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)     { up    = true; updatePlayerFacing("up");    }
            if (e.KeyCode == Keys.S)     { down  = true; updatePlayerFacing("down");  }
            if (e.KeyCode == Keys.D)     { right = true; updatePlayerFacing("right"); }
            if (e.KeyCode == Keys.A)     { left  = true; updatePlayerFacing("left");  }
            if (e.KeyCode == Keys.Space) { space = true;}

            //Debug
            if (e.KeyCode == Keys.U) { unloadCurrentTile(); }
            if (e.KeyCode == Keys.N) { loadNewTile(currentLevel.tiles.ElementAt(Convert.ToInt32(currentLevel.currentlocation.X))); }
            if (e.KeyCode == Keys.M) { currentLevel.moveRight(); }
            if (e.KeyCode == Keys.B) { currentLevel.moveLeft(); }
            if (e.KeyCode == Keys.O)
            {
                player.setActorLocation(currentLevel.tiles.ElementAt(Convert.ToInt32(currentLevel.currentlocation.X)).spawnlocation);
                Log.error("RESET TO LOCATION: " + currentLevel.tiles.ElementAt(Convert.ToInt32(currentLevel.currentlocation.X)).spawnlocation.ToString());
            }
            if (e.KeyCode == Keys.F) { player.sprite.Flip(); }

            if (e.KeyCode == Keys.V)
            {
                if (Engine.disablerenderer == true)
                {
                    Engine.disablerenderer = false;
                }
                else
                {
                    Engine.disablerenderer = true;
                }
            }
        }

        public override void keyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.D) { right = false; }
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.Space) { space = false; }
        }
        #endregion
        //
        // //
        //
        #region Functions
        //tilerelated
        public void loadNewTile(Tile t)
        {
            //Map
            Log.info($"[LOADING]:  Name: {t.name};  Size:{t.tilesize};  Spawnlocation:{t.spawnlocation.ToString()}");
            for (int i = 0; i < t.map.GetLength(0); i++)
            {
                for (int j = 0; j < t.map.GetLength(1); j++)
                {
                    //Add Sprite2D if i has the name "." with special parameters
                    if (t.map[j, i] == ".")
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), "o_tile15", "background", true);
                    }
                    //Add sprite by name with normal perameters
                    else
                    {
                        new Sprite2D(new Vector2(i * 48, j * 48), new Vector2(48, 48), t.map[j, i], "", true);
                    }
                }
            }

            //Spawn Player
            player = (Player)spawnActorFromClass(new Vector2(t.spawnlocation.X, t.spawnlocation.Y), Class.player);

            // Set level varibles
            ismoving = false;
            canmoveon = false;
            canmoveback = false;

            // enable Player
            resetPlayer();
            playercanmove = true;

            // enable Engine
            Engine.disablerenderer = false;
            Log.warning("[ENGINE]  -  EGNINE ENABLED -----------------------------------------------------------------------------------------------");

            spawnActorFromClass(new Vector2(-100, -100), Class.item);

            //Spawn Tileenemies
            t.spawnStartenemies();
        }
        public void unloadCurrentTile()
        {
            // Prep
            Engine.disablerenderer = true;
            Log.warning("[ENGINE]  -  EGNINE DISABLED ----------------------------------------------------------------------------------------------");

            //Player
            if (player != null)
            {
                player.destroy();
                player = null;
                Log.warning("[GameMode]  -  Player Destroyed! ------------------------------------------------------------------------------------------");

            }
            else
            {
                Log.warning("[GameMode]  -  Player doesnt exist");
            }
        


        //Kill all Actors
        ka:
            try
            {
                if (allactors.Count > 0)
                {
                    while (allactors.Count > 0)
                    {
                        destroyActor(allactors.ElementAt(0));
                    }
                }
            }
            catch
            {
                Log.error("[GAMEMODE]  -  Kill Actors Failed");
                goto ka;
            }
            Log.warning("[GameMode]  -  Actors Destroyed! ------------------------------------------------------------------------------------------");

            //Remove all Sprites
            Engine.clearAllSprite2Ds();
            Log.warning("[GameMode]  -  Sprites2D Cleared! -----------------------------------------------------------------------------------------");

            Log.warning("[GameMode]  -  Tile UNLOADED! ---------------------------------------------------------------------------------------------");
            Thread.Sleep(100);
        }

        //Palyerrelated
        public void resetPlayer()
        {
            Tile t = currentLevel.tiles.ElementAt(Convert.ToInt32(currentLevel.currentlocation.X));
            player.setActorLocation(new Vector2(t.spawnlocation.X, t.spawnlocation.Y));
        }
        public void updatePlayerFacing(string s)
        {
            if (player != null)
            {
                player.updateFacing(s);
            }
        }

        //engine related
        public void endGame()
        {
            unloadCurrentTile();
            disablerenderer = false;
            listfordestruction();
        }
        #endregion
        //
        // //
        //
        #region Actors Management
        public Actor spawnActorFromClass(Vector2 location, Class clas, Actor onwer = null)
        {

            switch (clas)
            {
                default:
                    {
                        return null;
                    }
                case Class.player:
                    {
                        Sprite2D sprite = new Sprite2D(new Vector2(location.X, location.Y), new Vector2(22, 40), "Knight_Idle", "player", true);

                        Player player = new Player(sprite, this);
                        player.setActorLocation(location);

                        return player;
                    }
                case Class.enemie:
                    {
                        Sprite2D sprite = new Sprite2D(location, new Vector2(48, 48), "rectangle2", "enemie", true);

                        Enemy enemie = new Enemy(sprite, this);

                        allenemies.Add(enemie);
                        allactors.Add(enemie);

                        return enemie;
                    }
                case Class.projectile:
                    {
                        Sprite2D sprite = new Sprite2D(location, new Vector2(20, 20), "fireball", "", true);

                        Projectile projectile = new Projectile(sprite, new Vector2(1, 0), 10, this, onwer);

                        allprojectiles.Add(projectile);
                        allactors.Add(projectile);

                        return projectile;
                    }
                case Class.item:
                    {
                        Sprite2D sprite = new Sprite2D(location, new Vector2(20, 20), "coin", "", true);

                        Item item = new Item(sprite, this);

                        allitems.Add(item);
                        allactors.Add(item);

                        return item;
                    }
                case Class.boss:
                    {
                        Sprite2D sprite = new Sprite2D(location, new Vector2(100, 100), "bosstangle", "boss", true);

                        Boss boss = new Boss(sprite, this);

                        allbosses.Add(boss);
                        allactors.Add(boss);

                        return boss;
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
                        sprite.destroySelf();

                        allenemies.Remove((Enemy)a);
                        allactors.Remove(a);

                        Log.warning("[DESTROYED][ENEMY]  -  {" + a.sprite.name + "}");
                        a = null;

                        break;
                    }
                case Class.projectile:
                    {
                        a.sprite.destroySelf();

                        allprojectiles.Remove((Projectile)a);
                        allactors.Remove(a);

                        Log.warning("[DESTROYED][PROJECTILE]  -  {" + a.sprite.name + "}");
                        a = null;

                        break;
                    }
                case Class.player:
                    {
                        player.sprite.destroySelf();
                        player = null;

                        break;
                    }
                case Class.item:
                    {
                        Sprite2D sprite = a.sprite;
                        sprite.destroySelf();

                        allitems.Remove((Item)a);
                        allactors.Remove(a);

                        Log.warning("[DESTROYED][Item]  -  {" + a.sprite.name + "}");
                        a = null;

                        break;
                    }
                case Class.boss:
                    {
                        Sprite2D sprite = a.sprite;
                        sprite.destroySelf();

                        allbosses.Remove((Boss)a);
                        allactors.Remove(a);

                        Log.warning("[DESTROYED][BOSS]  -  {" + a.sprite.name + "}");
                        a = null;

                        break;
                    }


            }
        }
        #endregion
        //
    }
}