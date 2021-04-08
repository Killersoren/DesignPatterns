using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.ComponentPatern
{
    public class SpriteRenderer: Component
    {
        public Texture2D Sprite { get; set; }
        public Vector2 Origin { get; set; }

        public SpriteRenderer()
        {

        }
        public SpriteRenderer(string spriteName)
        {
            SetSprite(spriteName);
        }
        public void SetSprite(string SpriteName)
        {
            Sprite = Game1.Instance.Content.Load<Texture2D>(SpriteName);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, GameObject.Transform.Position, null, Color.White, 0, Origin,1, SpriteEffects.None, 0);
        }
        public override string ToString()
        {
            return "SpriteRenderer";
        }
        public SpriteRenderer Clone()
        {
            return (SpriteRenderer)this.MemberwiseClone();
        }
    }
}
