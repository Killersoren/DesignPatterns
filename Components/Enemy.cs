//using Microsoft.Xna.Framework;
//using DesignPaterns.ObjectPool;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DesignPaterns.Components
//{
//    class Enemy: Component
//    {
//        private float speed;
//        private Vector2 velocity;
//        public Enemy(float speed, Vector2 velocity)
//        {
//            this.speed = speed;
//            this.velocity = velocity;
//        }

//        public override void Update(GameTime gameTime)
//        {
//            Move();
//            Destroy();
//        }
//        private void Move()
//        {
//            GameObject.Transform.Translate(velocity *speed * Game1.Instance.delta);
//        }
//        private void Destroy()
//        {
//            if (GameObject.Transform.Position.Y > Game1.Instance.GraphicsDevice.Viewport.Height)
//            {
//                EnemyPool.Instance.RealeaseObject(GameObject);
//            }
//        }
	

	
//    }
//}
