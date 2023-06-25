namespace MinotaurLabyrinth
{
    public class Wall : Room
    {
        static Wall()
        {
            RoomFactory.Instance.Register(RoomType.Wall, () => new Wall());
        }

        public override RoomType Type { get; } = RoomType.Wall;

        public override DisplayDetails Display()
        {
            return new DisplayDetails("[ ]", ConsoleColor.Black);
        }
    }
}
