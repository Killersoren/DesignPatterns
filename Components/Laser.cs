using DesignPaterns.ObserverPattern;
using DesignPatterns;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPaterns.Components
{
    class Laser: Component, IGameListner
    {
        private float speed;
        private Vector2 velocity;
        public float Height{ get; set; }
        public Laser(float speed, Vector2 velocity)
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
            Destroy1();
        }
        private void Move()
        {
            GameObject.Transform.Translate(velocity * speed * Game1.Instance.delta);
        }

        private void Destroy1()
        {
            if (GameObject.Transform.Position.Y <= -Height)
            {
                GameObject.Destroy();
            }
        }

        public override void Destroy()
        {
            Game1.Instance.Colliders.Remove((Collider)GameObject.GetComponent("Collider"));

        }

        public Laser Clone()
        {
            return (Laser)this.MemberwiseClone();
        }

        public void Notify(GameEvent gameEvent, Component component)
        {
            if (gameEvent.Title == "Collision" && component.GameObject.Tag == "Platform")
            {
                GameObject.Destroy();
            }
        }
    }
}
