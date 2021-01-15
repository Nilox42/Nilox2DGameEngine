using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Core;
using System.Windows.Forms;

namespace Nilox2DGameEngine.Character
{
    public class Player : Actor
    {
        #region Init
        GameMode gm = null;
        Vector2 lastPos = Vector2.zero();

        int health = 100;
        int maxhealth = 100;

        public int coins = 0;

        string facing = "right";

        public Player(Sprite2D sprite0, GameMode gm0)
        {
            sprite = sprite0;
            gm = gm0;

            clas = Class.player;
            sprite.actor = this;
        }
        #endregion
        //
        //
        //
        #region movement
        public void move(Vector2 vector)
        {
            addActorLocation(vector);
        }

        public void updateFacing(string facing0)
        {
            if (facing0 != facing)
            {
                switch (facing0)
                {
                    default:
                        Log.error("[Player]  -  Facing is not possible");
                        break;

                    case "right":
                        sprite.Flip();
                        facing = "right";
                        break;

                    case "left":
                        sprite.Flip();
                        facing = "left";
                        break;
                    case "up":
                        facing = "up";
                        break;
                    case "down":
                        facing = "down";
                        break;
                }
            }
        }
        #endregion
        //
        //
        //
        #region overrides
        public override void damge(Actor instigator, int damage)
        {
            health -= damage;

            gm.updatehealtbar((health/maxhealth)*100 +1);

            if (health <= 0) 
            {
                Log.error("[PLAYER]  -  Died!");
                health = maxhealth;
                gm.resetPlayer();
            }

            Log.warning("[PLAYER]  -  Took Damage");
        }

        public override void destroy()
        {
            
        }

        public override void update()
        {
            // Collider
            if (sprite.isCollidingWithTag("collider") != null)
            {
                setActorLocation(lastPos);
            }
            else
            {
                lastPos = getActorLocation();
            }

            // Mapmovement
            if (sprite.isCollidingWithTag("doorright") != null && gm.canmoveon && gm.ismoving == false)
            {
                gm.currentLevel.moveRight();
            }
            if (sprite.isCollidingWithTag("doorleft") != null && gm.canmoveback && gm.ismoving == false)
            {
                gm.currentLevel.moveLeft();
               
            }

            // Coin 
            Sprite2D coin = sprite.isCollidingWithTag("coin");
            if (coin != null)
            {
                coins++;
                coin.actor.destroy();
                Engine.Window.label1.Text = coins.ToString();
            }

            // Levelcondition coins
            if (coins >= 3 && gm.ismoving == false && gm.canmoveon == false)
            {
                gm.canmoveon = true;
                Log.warning("[CINDITION] - Coin Condition met");
            }
        }
        #endregion
        //
        //
        //
        #region functions

        #region pikups
        public void keypickup()
        {
            Sprite2D key0 = sprite.isCollidingWithTag("key");
            if (key0 != null)
            {
                key0.destroySelf();
                key0 = null;
            }
        }
        public void healthpickup()
        {
            Sprite2D heart0 = sprite.isCollidingWithTag("heart");
            if (heart0 != null)
            {
                heart0.destroySelf();
                heart0 = null;
            }
        }
        public void coinpickup()
        {
            Sprite2D coin0 = sprite.isCollidingWithTag("coin");
            if (coin0 != null)
            {
                coin0.destroySelf();
                coin0 = null;
            }
        }
        #endregion

        #region Fighting
        public void shoot()
        {
            if (facing == "up")
            {
                Projectile p =  (Projectile)gm.spawnActorFromClass(getActorLocation() + (getActorScale2D() / 2), Class.projectile, this);
                p.direction = new Vector2(0,-1);
                p.speed = 20;
            }
            if (facing == "down")
            {
                Projectile p = (Projectile)gm.spawnActorFromClass(getActorLocation() + (getActorScale2D() / 2), Class.projectile, this);
                p.direction = new Vector2(0,1);
                p.speed = 20;
            }
            if (facing == "right")
            {
                Projectile p = (Projectile)gm.spawnActorFromClass(getActorLocation() + (getActorScale2D() / 2), Class.projectile, this);
                p.direction = new Vector2(1,0);
                p.speed = 20;
            }
            if (facing == "left")
            {
                Projectile p = (Projectile)gm.spawnActorFromClass(getActorLocation() + (getActorScale2D() / 2), Class.projectile, this);
                p.direction = new Vector2(-1,0);
                p.speed = 20;
            }
        }
        #endregion

        public void hide()
        {
            sprite.draw = false;
        }
        public void show()
        {
            sprite.draw = true;
        }
        #endregion
    }
}
