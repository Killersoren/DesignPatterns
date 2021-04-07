using DesignPaterns.ComponentPatern;
using DesignPatterns;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.BuildPattern
{
    class PlayerBuilder : IBuilder
    {
        private GameObject go;

        public void BuildGameObject()
        {
            go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();
            go.AddComponent(sr);
            sr.SetSprite("worker");
            sr.Origin = new Vector2(sr.Sprite.Width / 2, (sr.Sprite.Height) -5);
            go.AddComponent(new Collider(sr));
            go.AddComponent(new Player());

        }

        public GameObject GetResult()
        {
            return go;
        }
    }
}
