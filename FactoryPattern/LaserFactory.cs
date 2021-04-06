using Microsoft.Xna.Framework;
using DesignPaterns.ComponentPatern;
using DesignPaterns.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.FactoryPattern
{
    class LaserFactory : Factory
    {
        private static LaserFactory instance;
        public static LaserFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LaserFactory();
                }
                return instance;
            }
        }
        private Laser playerLaser;
        private SpriteRenderer playerRenderer;
        private SpriteRenderer enemyRenderer;
        private LaserFactory()
        {
            CreatePrototype(ref playerRenderer, ref playerLaser,"laserBlue05", 500, new Vector2(0, -1));
        }
        private void CreatePrototype(ref SpriteRenderer spriteRenderer, ref Laser laser, string sprite, float speed, Vector2 velocity)
        {
            laser = new Laser(speed, velocity);
            spriteRenderer = new SpriteRenderer(sprite);

            laser.Height = spriteRenderer.Sprite.Height;
        }
        public override GameObject Create(string type)
        {
            GameObject go = new GameObject();
            switch(type)
            {
                case "Player":
                    go.AddComponent(playerLaser.Clone());
                    go.AddComponent(playerRenderer.Clone());
                    break;
            }
            return go;

        }
    }
}
