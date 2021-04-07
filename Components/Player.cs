using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DesignPaterns.CommandPattern;
using DesignPaterns.ComponentPatern;
using DesignPaterns.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns
{
    class Player: Component
    {
        private float speed;
        private SpriteRenderer spriteRenderer;
        private bool canShoot;
        private bool canJump;

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
            GameObject.Transform.Position = new Vector2(Game1.Instance.GraphicsDevice.Viewport.Width / 2, Game1.Instance.GraphicsDevice.Viewport.Height);
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
        }
        public override void Start()
        {
            SpriteRenderer sr = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
            //sr.SetSprite("worker");
            sr.Origin = new Vector2(sr.Sprite.Width/2, (sr.Sprite.Height/2)+35);
        }
        public override void Update(GameTime gameTime)
        {
            // gravity
            gravityVelocity += gravityAcceleration;
            GameObject.Transform.Translate(gravityVelocity * Game1.Instance.delta);
            //
            shootTime += Game1.Instance.delta;
            jumpTime += Game1.Instance.delta;

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
                canJump = false;
                //jumpTime = 0;
                gravityVelocity = velocity;
                if (velocity != Vector2.Zero)
                {
                    velocity.Normalize();
                }
                GameObject.Transform.Translate(velocity * Game1.Instance.delta);
            }
        }
    }
}
