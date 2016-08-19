using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsCardGame.Web.Api.Controllers;
using StarWarsCardGame.Domain.Abstract;
using StarWarsCardGame.Domain.Concrete;
using StarWarsCardGame.Web.Api.Models;
using Moq;

namespace StarWarsCardGame.Web.Api.Tests.Controllers
{
    [TestClass]
    public class GameRoomsControllerTest
    {
        [TestMethod]
        public void Can_Create_Game_Rooms()
        {
            GameRoomsController controller = new GameRoomsController();
            GameRoomControllerViewModel gameControllerVm = controller.CreateRoom();
            Assert.AreNotEqual(null, gameControllerVm.GameRoomControllerId);
        }

        [TestMethod]
        public void Can_Join_Existing_Room()
        {
            GameRoomsController controller = new GameRoomsController();
            GameRoomControllerViewModel gameControllerVm = controller.CreateRoom();
            GameRoomControllerViewModel joinGameControllerVM = controller.JoinRoom(gameControllerVm.GameRoomControllerId);
            Assert.AreEqual(gameControllerVm.GameRoomControllerId, joinGameControllerVM.GameRoomControllerId);
        }

        [TestMethod]
        public void Cant_Join_NON_Existing_Room()
        {
            GameRoomsController controller = new GameRoomsController();
            GameRoomControllerViewModel gameControllerVm = controller.CreateRoom();
            GameRoomControllerViewModel joinGameControllerVM = controller.JoinRoom(gameControllerVm.GameRoomControllerId + "___");
            Assert.AreEqual("noroom", joinGameControllerVM.GameRoomControllerId.ToLower());
        }
    }
}
