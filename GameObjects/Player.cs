﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Core;
using System.Windows.Forms;

namespace Nilox2DGameEngine.Objects
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
            //setup
            gm = gm0;

            //sprite setup
            sprite = sprite0;
            sprite.actor = this;

            //Actor setup
            clas = Class.player;
 
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

            gm.health = (health / maxhealth) * 100 + 1;

            if (health <= 0) 
            {
                Log.error("[PLAYER]  -  Died!");
                health = maxhealth;
                gm.resetPlayer();
            }

            Log.warning("[PLAYER]  -  Took Damage");
        }

        public override void destroy(string reason = "")
        {


            gm.destroyActor(this);
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

                gm.coins = coins;
            }

            // Levelcondition coins
            if (coins >= 3 && gm.ismoving == false && gm.canmoveon == false)
            {
                gm.canmoveon = true;
                Log.debug("[CINDITION] - Coin Condition met");

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

                //coins
                gm.coins = coins;
            }
        }
        #endregion

        #region Fighting
        public void shoot()
        {
            if (facing == "up")
            {
                Projectile p =  (Projectile)gm.spawnActorFromClass(getActorLocation() + (getActorScale2D() / 5), Class.projectile, this);
                p.direction = new Vector2(0,-1);
                p.speed = 20;
            }
            if (facing == "down")
            {
                Projectile p = (Projectile)gm.spawnActorFromClass(getActorLocation() + (getActorScale2D() / 5), Class.projectile, this);
                p.direction = new Vector2(0,1);
                p.speed = 20;
            }
            if (facing == "right")
            {
                Projectile p = (Projectile)gm.spawnActorFromClass(getActorLocation() + (getActorScale2D() / 5), Class.projectile, this);
                p.direction = new Vector2(1,0);
                p.speed = 20;
            }
            if (facing == "left")
            {
                Projectile p = (Projectile)gm.spawnActorFromClass(getActorLocation() + (getActorScale2D() / 5), Class.projectile, this);
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
