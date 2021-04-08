using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DesignPaterns.CommandPattern;
using DesignPaterns.ComponentPatern;
using DesignPaterns.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Text;
using DesignPaterns.BuildPattern;
using DesignPatterns;
using DesignPaterns.ObserverPattern;
using System.Diagnostics;

namespace DesignPaterns
{
    class Player: Component, IGameListner
    {
        private float speed;
        private SpriteRenderer spriteRenderer;
        private bool canShoot;
        private bool canJump;
        private bool applyGravity;


        private float shootTime;
        private float jumpTime;

        private float cooldown = 1;

        private Vector2 gravityVelocity;
        private Vector2 gravityAcceleration = new Vector2(0.0f,20f);

        public Player()
        {
            this.speed = 400;
            canShoot = true;
            canJump = true;
            InputHandler.Instance.Entity = this;


        }
        public void Move(Vector2 velocity)
        {
           
                if (velocity != Vector2.Zero)
                {
                    velocity.Normalize();
                }
                velocity *= speed;
                GameObject.Transform.Translate(velocity * Game1.Instance.delta);

        }

        public override void Awake()
        {
            GameObject.Tag = "Platform";

            GameObject.Transform.Position = new Vector2(Game1.Instance.GraphicsDevice.Viewport.Width / 2, Game1.Instance.GraphicsDevice.Viewport.Height);
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");

        }
        //public override void Start()
        //{
        //    SpriteRenderer sr = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
        //    sr.Origin = new Vector2(sr.Sprite.Width/2, (sr.Sprite.Height/2)+35);
        //}
        public override void Update(GameTime gameTime)
        {
            // gravity
            if (applyGravity)
            {
                gravityVelocity += gravityAcceleration;
                GameObject.Transform.Translate(gravityVelocity * Game1.Instance.delta);
            }
            //
            shootTime += Game1.Instance.delta;
            jumpTime += Game1.Instance.delta;
            //if (GameObject.Transform.Position.Y >= Game1.Instance.GraphicsDevice.Viewport.Height)
            //{
            //    Debug.WriteLine("baa");
            //    GameObject.Transform.Position = new Vector2(Game1.Instance.GraphicsDevice.Viewport.Height, GameObject.Transform.Position.Y);
            //}

            //if (GameObject.Transform.Position.Y <= -Height)
            //{
            //    GameObject.Destroy();
            //}

            if (jumpTime >= cooldown)
            {
                canJump = true;
            }
            if (shootTime >= cooldown)
            {
                canShoot = true;

            }

        }
        public override string ToString()
        {
            return "Player";
        }

        public void Shoot()
        {
            if (canShoot)
            {
                canShoot = false;
                shootTime = 0;
                GameObject laserObject = LaserFactory.Instance.Create("Player");
                laserObject.Transform.Position = GameObject.Transform.Position;
                laserObject.Transform.Position += new Vector2(-3, -(spriteRenderer.Sprite.Height + 40));
                Game1.Instance.AddGameObject(laserObject);
            }
           

        }
        public void Jump(Vector2 velocity)
        {
            //enable jump when player is standing on a platform
            if (canJump)
            {
                applyGravity = true;
                canJump = false;
                jumpTime = 0;
                gravityVelocity = velocity;
                if (velocity != Vector2.Zero)
                {
                    velocity.Normalize();
                }
                GameObject.Transform.Translate(velocity * Game1.Instance.delta);
            }
        }

        public void Notify(GameEvent gameEvent, Component component)
        {
           
            if (gameEvent.Title == "Collision" && component.GameObject.Tag == "Platform")
            {
                if (component.GameObject.Transform.Position.Y >= (this.GameObject.Transform.Position.Y)-20) // it works =?
                {
                    if (this.GameObject.Transform.Position.X <= (component.GameObject.Transform.Position.X)+150 && this.GameObject.Transform.Position.X >= (component.GameObject.Transform.Position.X))
                    {
                        applyGravity = false;
                        this.GameObject.Transform.Position = new Vector2(this.GameObject.Transform.Position.X, (component.GameObject.Transform.Position.Y) - 5);
                        canJump = true;
                    }
                    else
                    {
                        applyGravity = true;

                    }
                    // && this.GameObject.Transform.Position.X >= (component.GameObject.Transform.Position.X) - 10
                    //this.GameObject.Transform.Position.X <= (component.GameObject.Transform.Position.X) + 10);
                }
            }
            

        }
    }
}
