using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsCardGame.Domain.Abstract;
using StarWarsCardGame.Domain.Concrete;

namespace StarWarsCardGame.Domain.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Create_GameRoomController()
        {
            string newGameControllerId = GameRoomControllerFactory.CreateController().Id;
            Assert.AreNotEqual(null, newGameControllerId);
            Assert.AreNotEqual(null, GameRoomControllerFactory.GetController(newGameControllerId));
        }
    }
}
