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
        //private Texture2D sprite;
        //private Transform transform;


        private float speed;
        private SpriteRenderer spriteRenderer;
        private bool canShoot;
        private bool canJump;

        private float shootTime;
        private float JumpTime;

        private float cooldown = 1;

        // private Vector2 origin;

        //public Player(Vector2 startPosition)
        //{
        //    //transform = new Transform();
        //    //transform.Position = startPosition;
        //    this.speed = 100;
        //}
        public Player()
        {
            //transform = new Transform();
            //transform.Position = startPosition;
            this.speed = 100;
            canShoot = true;
            InputHandler.Instance.Entity = this;
        }
        public void Move(Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            velocity *= speed;
            //transform.Translate(velocity * Game1.Instance.delta);
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
            sr.SetSprite("worker");
            sr.Origin = new Vector2(sr.Sprite.Width/2, (sr.Sprite.Height/2)+35);
        }
        public override void Update(GameTime gameTime)
        {
            shootTime += Game1.Instance.delta;
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
        public void Jump()
        {
            if (canJump)
            {
                canJump = false;
                JumpTime = 0;
                //GameObject laserObject = LaserFactory.Instance.Create("Player");
                //laserObject.Transform.Position = GameObject.Transform.Position;
                //laserObject.Transform.Position += new Vector2(-3, -(spriteRenderer.Sprite.Height + 40));
                ////Game1.Instance.AddGameObject(laserObject);
            }


        }
     
    }
}
