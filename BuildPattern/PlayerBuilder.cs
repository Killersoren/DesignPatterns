using DesignPaterns.ComponentPatern;
using DesignPatterns;
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
            go.AddComponent(new Collider(sr));
            go.AddComponent(new Player());

        }

        public GameObject GetResult()
        {
            return go;
        }
    }
}
