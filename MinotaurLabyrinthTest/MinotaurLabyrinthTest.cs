using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinotaurLabyrinth;

namespace MinotaurLabyrinthTest
{
    [TestClass]
    public class MinotaurLabyrinthTest
    {
        [TestMethod]
        public void DummyTest()
        {
            Assert.AreNotSame(1, 2);
        }

        [TestMethod]
        public void CustomRoom_Activate_Success()
        {
            // Arrange
            var hero = new Hero();
            var map = new Map();
            var customRoom = new InventionRooms();

            // Act
            customRoom.Activate(hero, map);

            // Assert
            // Add your assertions here
        }

        [TestMethod]
        public void Entrance_Activate_HeroHasSword_Victory()
        {
            // Arrange
            var hero = new Hero { HasSword = true };
            var map = new Map();
            var entrance = new Entrance();

            // Act
            entrance.Activate(hero, map);

            // Assert
            Assert.IsTrue(hero.IsVictorious);
        }

        [TestMethod]
        public void Pit_Activate_HeroFallsIn_Death()
        {
            // Arrange
            var hero = new Hero(new Location(0, 0));
            var map = new Map(5, 5);
            var pit = new Pit();

            // Act
            pit.Activate(hero, map);

            // Assert
            Assert.IsTrue(hero.IsDead);
            Assert.IsFalse(hero.IsAlive);
        }

        [TestMethod]
        public void Room_DisplaySense_NoMonster_ReturnsFalse()
        {
            // Arrange
            var hero = new Hero();
            var room = new Room();

            // Act
            var result = room.DisplaySense(hero, 1);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Sword_DisplaySense_HeroDistanceZero_SwordIsNearby()
        {
            // Arrange
            var hero = new Hero();
            var sword = new Sword();

            // Act
            var result = sword.DisplaySense(hero, 0);

            // Assert
            Assert.IsTrue(result);
            // Add additional assertions to verify the expected output
        }

        [TestMethod]
        public void Wall_Display_ReturnsCorrectDisplayDetails()
        {
            // Arrange
            var wall = new Wall();
            var expectedDisplay = new DisplayDetails("[ ]", ConsoleColor.Black);

            // Act
            var actualDisplay = wall.Display();

            // Assert
            Assert.AreEqual(expectedDisplay, actualDisplay);
        }
    }
}
