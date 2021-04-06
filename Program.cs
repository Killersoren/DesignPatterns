using System;

namespace DesignPaterns
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = Game1.Instance)
                game.Run();
        }
    }
}
