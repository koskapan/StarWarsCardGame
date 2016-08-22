using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsCardGame.Web.Api.Controllers;
using StarWarsCardGame.Domain.Abstract;
using StarWarsCardGame.Domain.Concrete;
using StarWarsCardGame.Web.Api.Models;
using Moq;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using System.Web.Http;
using System.Threading;
using System.Web;

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
            Assert.AreEqual(ConnectionStatuses.Success, gameControllerVm.Status);
            Assert.AreNotEqual(null, gameControllerVm.GameRoomControllerId);
        }

        [TestMethod]
        public void Can_Join_Existing_Room()
        {
            RoomsController controller = new RoomsController();
            GameRoomControllerViewModel gameControllerVm = controller.CreateRoom();
            GameRoomControllerViewModel joinGameControllerVM = controller.JoinRoom(gameControllerVm.GameRoomControllerId);
            Assert.AreEqual(ConnectionStatuses.Success, joinGameControllerVM.Status);
        }

        [TestMethod]
        public void Cant_Join_NON_Existing_Room()
        {
            RoomsController controller = new RoomsController();
            GameRoomControllerViewModel gameControllerVm = controller.CreateRoom();
            GameRoomControllerViewModel joinGameControllerVM = controller.JoinRoom(gameControllerVm.GameRoomControllerId + "___");
            Assert.AreNotEqual(ConnectionStatuses.Success, joinGameControllerVM.Status);
        }

        [TestMethod]
        public void Cant_Join_Again()
        {
            RoomsController controller = new RoomsController();
            GameRoomControllerViewModel controllerCreateResult = controller.CreateRoom();
            GameRoomControllerViewModel joinGameResult = controller.JoinRoom(controllerCreateResult.GameRoomControllerId);
            Assert.AreEqual(ConnectionStatuses.Success, joinGameResult.Status);
            joinGameResult = controller.JoinRoom(controllerCreateResult.GameRoomControllerId);
            Assert.AreEqual(ConnectionStatuses.UserExists, joinGameResult.Status);
        }

        [TestMethod]
        public void Cant_Connect_Full_Room()
        {
            RoomsController controller = new RoomsController();
            GameRoomControllerViewModel controllerCreateResult = controller.CreateRoom();

            for (int i = 0; i <= 4; i++)
            {
                var identity = new GenericIdentity("User" + i);
                IPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
                GameRoomControllerViewModel joinGameResult = controller.JoinRoom(controllerCreateResult.GameRoomControllerId);
                Assert.AreEqual(ConnectionStatuses.Success, joinGameResult.Status);
            }
            var controlIdentity = new GenericIdentity("User");
            IPrincipal controlPrincipal = new GenericPrincipal(controlIdentity, null);
            Thread.CurrentPrincipal = controlPrincipal;
            HttpContext.Current.User = controlPrincipal;
            var controllJoinGameResult = controller.JoinRoom(controllerCreateResult.GameRoomControllerId);
            Assert.AreEqual(ConnectionStatuses.Full, controllJoinGameResult.Status);
        }
    }
}
