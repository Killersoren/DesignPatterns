using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DesignPaterns.BuildPattern;
using DesignPaterns.CommandPattern;
using DesignPaterns.ComponentPatern;
using DesignPaterns.FactoryPattern;
using DesignPaterns.ObjectPool;
using System;
using System.Collections.Generic;
using DesignPatterns;

namespace DesignPaterns
{
    public class Game1 : Game
    {


        private static Game1 instance;
        public static Game1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game1();
                }
                return instance;
            }
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 playerStartPos;
        public float delta;
        private List<GameObject> gameObjects = new List<GameObject>();
        private float spawnTime;
        private float cooldown = 2;
        private Random rnd = new Random();

        private static Vector2 screensize;

        public static Vector2 Screensize { get => screensize; set => screensize = value; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1400;
            _graphics.PreferredBackBufferHeight = 800;
            screensize = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Director director = new Director(new PlayerBuilder());
            gameObjects.Add(director.Construct());

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Awake();
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Start();
            }

            

            // player.Loadcontent(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
             delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            InputHandler.Instance.Execute();
            // TODO: Add your update logic here

          
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(gameTime);
            }
            SpawnPlatforms();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            // player.Draw(_spriteBatch);
           
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw(_spriteBatch);
            }

            

            _spriteBatch.End();
            base.Draw(gameTime);
        }
        public void AddGameObject(GameObject go)
        {
            gameObjects.Add(go);
        }
        public void RemoveGameObject(GameObject go)
        {
            gameObjects.Remove(go);
        }
        private void SpawnPlatforms()
        {
            spawnTime += delta;
            if (spawnTime >= cooldown)
            {
                GameObject go = PlatformPool.Instance.GetObject();
                go.Transform.Position = new Vector2(rnd.Next(0, GraphicsDevice.Viewport.Width), 0);
                gameObjects.Add(go);
                spawnTime = 0;
            }
        }
    }
}
