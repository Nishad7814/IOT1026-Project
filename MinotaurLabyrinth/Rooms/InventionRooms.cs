using System;

namespace MinotaurLabyrinth
{
    public class InventionRooms : Room
    {
        static InventionRooms()
        {
            RoomFactory.Instance.Register(RoomType.Custom, () => new InventionRooms());
        }

        public override RoomType Type { get; } = RoomType.Custom;

        public override DisplayDetails Display()
        {
            return new DisplayDetails($"[{Type.ToString()[0]}]", ConsoleColor.Cyan);
        }

        public override void Activate(Hero hero, Map map)
        {
            // Custom logic for the custom room activation
            ConsoleHelper.WriteLine("Welcome to the custom room! You encounter a unique challenge.", ConsoleColor.Magenta);
            // Add your custom room activation logic here
        }
    }

    namespace MinotaurLabyrinth
    {
        public enum RoomType
        {
            Entrance,
            Pit,
            Room,
            Sword,
            Wall,
            Custom
        }
    }
}
