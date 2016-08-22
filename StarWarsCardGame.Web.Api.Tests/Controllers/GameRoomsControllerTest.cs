using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsCardGame.Web.Api.Controllers;
using StarWarsCardGame.Domain.Abstract;
using StarWarsCardGame.Domain.Concrete;
using StarWarsCardGame.Web.Api.Models;
using Moq;
using System.Linq;

namespace StarWarsCardGame.Web.Api.Tests.Controllers
{
    [TestClass]
    public class GameRoomsControllerTest
    {
        [TestMethod]
        public void Can_Create_Game_Rooms()
        {
            RoomsController controller = new RoomsController();
            GameRoomControllerViewModel gameControllerVm = controller.CreateRoom();
            Assert.AreEqual(GameRoomControllerStatuses.OK, gameControllerVm.Status);
            Assert.AreNotEqual(null, gameControllerVm.GameRoomControllerId);
        }

        [TestMethod]
        public void Can_Join_Existing_Room()
        {
            RoomsController controller = new RoomsController();
            GameRoomControllerViewModel gameControllerVm = controller.CreateRoom();
            GameRoomControllerViewModel joinGameControllerVM = controller.JoinRoom(gameControllerVm.GameRoomControllerId);
            Assert.AreEqual(GameRoomControllerStatuses.OK, joinGameControllerVM.Status);
        }

        [TestMethod]
        public void Cant_Join_NON_Existing_Room()
        {
            RoomsController controller = new RoomsController();
            GameRoomControllerViewModel gameControllerVm = controller.CreateRoom();
            GameRoomControllerViewModel joinGameControllerVM = controller.JoinRoom(gameControllerVm.GameRoomControllerId + "___");
            Assert.AreNotEqual(GameRoomControllerStatuses.OK, joinGameControllerVM.Status);
        }

        [TestMethod]
        public void Cant_Join_Again()
        {
            RoomsController controller = new RoomsController();
            GameRoomControllerViewModel controllerCreateResult = controller.CreateRoom();
            GameRoomControllerViewModel joinGameResult = controller.JoinRoom(controllerCreateResult.GameRoomControllerId);
            Assert.AreEqual(GameRoomControllerStatuses.OK, joinGameResult.Status);
            joinGameResult = controller.JoinRoom(controllerCreateResult.GameRoomControllerId);
            Assert.AreEqual(GameRoomControllerStatuses.ERR, joinGameResult.Status);
        }
    }
}
