using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.CommandPattern
{
    class InputHandler
    {
        private Dictionary<Keys, Icommand> keybinds = new Dictionary<Keys, Icommand>();
        private static InputHandler instance;
        public static InputHandler Instance {
            get
            {
                if (instance == null)
                {
                    instance = new InputHandler();
                } 
                return instance;
            } 
        }
        public Player Entity { get; set; }

        private InputHandler()
        {
            keybinds.Add(Keys.D, new MoveCommand(new Vector2(1, 0)));
            keybinds.Add(Keys.A, new MoveCommand(new Vector2(-1, 0)));
            keybinds.Add(Keys.Space, new AttackCommand());
            keybinds.Add(Keys.J, new JumpCommand(new Vector2(0, -1000)));



        }

        public void Execute()
        {
            KeyboardState keyState = Keyboard.GetState();
            foreach (Keys key in keybinds.Keys)
            {
                if (keyState.IsKeyDown(key))
                {
                    keybinds[key].Execute(Entity);
                }
            }
        }
    }
}
