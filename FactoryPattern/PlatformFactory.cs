using Microsoft.Xna.Framework;
using DesignPaterns.ComponentPatern;
using DesignPaterns.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.FactoryPattern
{
    class PlatformFactory : Factory
    {
        private static Random rnd = new Random();
        private static PlatformFactory instance;
        public static PlatformFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlatformFactory();
                }
                return instance;
            }
        }
        public override GameObject Create(string type)
        {

            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();
            go.AddComponent(sr);
            go.Transform.Position = new Vector2(rnd.Next(0, Game1.Instance.GraphicsDevice.Viewport.Width), rnd.Next(Game1.Instance.GraphicsDevice.Viewport.Height));

            switch (type)
            {
                case "Blue":
                    sr.SetSprite("bluebox");
                    go.AddComponent(new Platform(50, new Vector2(1, 2)));
                    break;
                case "Black":
                    sr.SetSprite("blackbox");
                    go.AddComponent(new Platform(100, new Vector2(1, 2)));
                    break;
            }
            return go;
        }
    }
}
