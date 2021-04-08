using Microsoft.Xna.Framework;
using DesignPaterns.ComponentPatern;
using DesignPaterns.Components;
using System;
using System.Collections.Generic;
using System.Text;
using DesignPatterns;

namespace DesignPaterns.FactoryPattern
{
    class PlatformFactory : Factory
    {
        private static Random rnd = new Random();
        private Platform platform;

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
                    platform = new Platform(50, new Vector2(0, 2));
                    sr.SetSprite("bluebox");
                    go.AddComponent(new Collider(sr, platform) { CheckCollisionEvents = true});
                    go.AddComponent(platform);
                    break;
                case "Black":
                    platform = new Platform(50, new Vector2(0, 2));
                    sr.SetSprite("blackbox");
                    go.AddComponent(new Collider(sr, platform) { CheckCollisionEvents = true });
                    go.AddComponent(platform);
                    break;
            }
            return go;
        }
    }
}
