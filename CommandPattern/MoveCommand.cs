using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.CommandPattern
{
    class MoveCommand : Icommand
    {
        private Vector2 velocity;

        public MoveCommand(Vector2 velocity)
        {
            this.velocity = velocity;
        }
        public void Execute(Player player)
        {
            player.Move(velocity);

        }
    }
}
