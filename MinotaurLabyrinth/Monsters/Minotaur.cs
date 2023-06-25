namespace MinotaurLabyrinth
{
   
    public class Minotaur : Monster
    {
       
        /// <param name="hero">The hero encountering the minotaur.</param>
        /// <param name="map">The current game map.</param>
        public override void Activate(Hero hero, Map map)
        {
            const int RowMove = 1;
            const int ColMove = 2;
            ConsoleHelper.WriteLine("You have encountered the minotaur! He charges at you and knocks you into another room.", ConsoleColor.Magenta);
            if (hero.HasSword)
            {
                hero.HasSword = false;
                ConsoleHelper.WriteLine("After recovering your senses, you notice you are no longer in possession of the magic sword!", ConsoleColor.Magenta);
            }

            Location currentLocation = hero.Location;

            // Clamp the player to a new location
            hero.Location = Clamp(new Location(hero.Location.Row - RowMove, hero.Location.Column + ColMove), map.Rows, map.Columns);

            
            for (int i = RowMove; i >= 0; --i)
            {
                for (int j = ColMove; j >= 0; --j)
                {
                    Location newLocation = Clamp(new Location(currentLocation.Row + i, currentLocation.Column - j), map.Rows, map.Columns);
                    Room room = map.GetRoomAtLocation(newLocation);
                    if (room.Type == RoomType.Room && !room.IsActive)
                    {
                        room.AddMonster(this);
                        map.GetRoomAtLocation(currentLocation).RemoveMonster();
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Takes a location and a map size, and produces a new location that is as much the same
        /// as possible, but guarantees it is on the map.
        /// </summary>
        /// <param name="location">The current location of the entity.</param>
        /// <param name="totalRows">The total number of rows on the map.</param>
        /// <param name="totalColumns">The total number of columns on the map.</param>
        /// <returns>Returns a new location that is guaranteed to be within the map's boundaries provided totalRows and totalColumns are correctly specified.</returns>
        private static Location Clamp(Location location, int totalRows, int totalColumns)
        {
            int row = location.Row;
            row = Math.Clamp(row, 0, totalRows - 1);
            int column = location.Column;
            column = Math.Clamp(column, 0, totalColumns - 1);

            return new Location(row, column);
        }

        
        /// <param name="hero">The hero sensing the minotaur.</param>
        /// <param name="heroDistance">The distance between the hero and the minotaur.</param>
        /// <returns>Returns true if a message was displayed; otherwise, false.</returns>
        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (heroDistance == 1)
            {
                ConsoleHelper.WriteLine("You hear growling and stomping. The minotaur is nearby!", ConsoleColor.Red);
                return true;
            }
            return false;
        }

        /// <returns>Returns a DisplayDetails object containing the minotaur's display information.</returns>
        public override DisplayDetails Display()
        {
            return new DisplayDetails("[M]", ConsoleColor.Red);
        }
    }
}
