using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.CommandPattern
{
    class AttackCommand: Icommand
    {
        private Vector2 velocity;

        public void Execute(Player player)
        {
            player.Shoot();

        }
    }
}
