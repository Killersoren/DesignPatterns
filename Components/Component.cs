using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DesignPaterns.ComponentPatern;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns
{
  public abstract class Component
    {
        public bool IsEnabled { get; set; } = true;
        public GameObject GameObject { get; set; }

        public virtual void Awake()
        {

        }
        public virtual void Start()
        {

        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
        public virtual void Destroy()
        { 
        }


    }
}
