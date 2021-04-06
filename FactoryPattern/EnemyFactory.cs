//using Microsoft.Xna.Framework;
//using DesignPaterns.ComponentPatern;
//using DesignPaterns.Components;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DesignPaterns.FactoryPattern
//{
//    class EnemyFactory : Factory
//    {
//        private static Random rnd = new Random();
//        private static EnemyFactory instance;
//        public static EnemyFactory Instance
//        {
//            get
//            {
//                if (instance == null)
//                {
//                    instance = new EnemyFactory();
//                }
//                return instance;
//            }
//        }
//        public override GameObject Create(string type)
//        {

//            GameObject go = new GameObject();
//            SpriteRenderer sr = new SpriteRenderer();
//            go.AddComponent(sr);
//            go.Transform.Position = new Vector2(rnd.Next(0, Game1.Instance.GraphicsDevice.Viewport.Width), 0);

//           switch (type)
//            {
//                case "Blue":
//                    sr.SetSprite("enemyBlue2");
//                    go.AddComponent(new Enemy(50, new Vector2(0, 1)));
//                        break;
//                case "Black":
//                    sr.SetSprite("enemyBlack1");
//                    go.AddComponent(new Enemy(100, new Vector2(0, 1)));
//                    break;
//            }
//            return go;
//        }
//    }
//}
