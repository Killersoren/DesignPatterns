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
            sr.Origin = new Vector2(sr.Sprite.Width / 2, (sr.Sprite.Height) -10);
           // sr.Origin = new Vector2(go.Transform.Position.X, go.Transform.Position.Y);

            Player player = new Player();
            go.AddComponent(new Collider(sr, player) { CheckCollisionEvents = true });
            go.AddComponent(player);
            /// To add player to collider list
            Game1.Instance.AddGameObject(go);
            ///
        }

        public GameObject GetResult()
        {
            return go;
        }
    }
}
