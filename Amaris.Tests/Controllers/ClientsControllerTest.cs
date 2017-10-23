using Amaris.Controllers;
using Amaris.ViewsModels;
using Contracts.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System.Web.Http.Results;

namespace Amaris.Tests.Controllers
{
    [TestClass]
    public class ClientsControllerTest
    {
        private readonly Mock<IClientsService> _clientsService;

        private ClientsController _controller;

        public ClientsControllerTest()
        {
            _clientsService = new Mock<IClientsService>();

            _controller = new ClientsController(_clientsService.Object);
        }

        [TestMethod]
        public void GetByEmail_MustReturnOk()
        {
            var client = new ApplicationUser { Role = "admin", UserName = "Britney", Email = "Britney@amaris.com" };

            _clientsService.Setup(x => x.GetByUserName(client.UserName)).Returns(client);

            var result = _controller.GetByUserName(client.UserName) as OkNegotiatedContentResult<ClientVm>;

            Assert.AreEqual(client.UserName, result.Content.Name);
            Assert.AreEqual(client.Role, result.Content.Role);
            Assert.AreEqual(client.Email, result.Content.Email);
            Assert.AreEqual(client.UserName, result.Content.Name);
        }

        [TestMethod]
        public void GetByEmail_MustReturnNoContent()
        {
            ApplicationUser client = null;
            var name = "amaris"; 

            _clientsService.Setup(x => x.GetByUserName(name)).Returns(client);

            var result = _controller.GetByUserName(name);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
