using Microsoft.Xna.Framework;
using DesignPaterns.ObjectPool;
using System;
using System.Collections.Generic;
using System.Text;
using DesignPaterns.ObserverPattern;
using DesignPatterns;
using System.Diagnostics;

namespace DesignPaterns.Components
{
    class Platform : Component, IGameListner
    {
        private float speed;
        private Vector2 velocity;
        public Platform(float speed, Vector2 velocity)
        {
            this.speed = speed;
            this.velocity = velocity;
        }
        public override void Awake()
        {
            GameObject.Tag = "Platform";
        }
        
        public override void Update(GameTime gameTime)
        {
            Move();
            BorderDestroy();
        }
        private void Move()
        {
            GameObject.Transform.Translate(velocity * speed * Game1.Instance.delta);
        }
        private void BorderDestroy()
        {
            if (GameObject.Transform.Position.Y > Game1.Instance.GraphicsDevice.Viewport.Height)
            {
                GameObject.Destroy();
            }
        }
        public override void Destroy()
        {
           PlatformPool.Instance.RealeaseObject(GameObject);
        }
    
        public void Notify(GameEvent gameEvent, Component component)
        {
            if (gameEvent.Title == "Collision" && component.GameObject.Tag== "Laser")
            {
              GameObject.Destroy();
            }
           
        }
            
}
}
