using DesignPaterns.ComponentPatern;
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
            go.AddComponent(new Player());
            go.AddComponent(new SpriteRenderer());
        }

        public GameObject GetResult()
        {
            return go;
        }
    }
}
