using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.Components
{
    class Laser: Component
    {
        private float speed;
        private Vector2 velocity;
        public float Height{ get; set; }
        public Laser(float speed, Vector2 velocity)
        {
            this.speed = speed;
            this.velocity = velocity;
        }


        public override void Update(GameTime gameTime)
        {
            Move();
            Destroy();
        }
        private void Move()
        {
            GameObject.Transform.Translate(velocity * speed * Game1.Instance.delta);
        }

        private void Destroy()
        {
            if (GameObject.Transform.Position.Y <= -Height)
            {
                Game1.Instance.RemoveGameObject(GameObject);
            }
        }
        public Laser Clone()
        {
            return (Laser)this.MemberwiseClone();
        }
    }
}
