﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.ComponentPatern
{
    public class GameObject
    {
        public Transform Transform {  get; private set; }
        private Dictionary<string, Component> components = new Dictionary<string, Component>();
        public string Tag { get; set; }

        public GameObject()
        {
            Transform = new Transform();
        }
        public void AddComponent(Component component)
        {
            components.Add(component.ToString(), component);
            component.GameObject = this;
        }
        public Component GetComponent(string component)
        {
            return components[component];

        }
        public void Awake()
        {
            foreach (Component component in components.Values)
            {
                component.Awake();
            }
        }
        public void Start()
        {
            foreach (Component component in components.Values)
            {
                component.Start();
            }
        }
        public void Update(GameTime gameTime)
        {
            foreach (Component component in components.Values)
            {
                if (component.IsEnabled)
                {
                    component.Update(gameTime);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component component in components.Values)
            {
                if (component.IsEnabled)
                {
                    component.Draw(spriteBatch);
                }
            }
        }

        public void Destroy()
        {
            foreach (Component component in components.Values)
            {
                component.Destroy();
            }
            Game1.Instance.RemoveGameObject(this);
        }
    }
}
