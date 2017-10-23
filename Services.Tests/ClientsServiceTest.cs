using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contracts.Services;
using Moq;
using Stubs;
using Models.Enumerations;

namespace Services.Tests
{
    [TestClass]
    public class ClientsServiceTest
    {
        private const string urlMocky = "http://www.mocky.io/v2/5808862710000087232b75ac";

        private readonly Mock<IMockyConnectorService> _mockyConnectorService;
        private ClientsService _service;

        public ClientsServiceTest()
        {
            _mockyConnectorService = new Mock<IMockyConnectorService>();

            _service = new ClientsService(_mockyConnectorService.Object);
        }


        [TestMethod]
        public void GetByUserName_MustReturnUserWithData()
        {
            string key = "name";
            string name = "Britney";

            _mockyConnectorService.Setup(x => x.GetByKey(urlMocky, JsonModels.clients, key, name)).Returns(MockyConnectorStubs.GetClient(key, name));
            
            var result = _service.GetByUserName(name);

            Assert.AreEqual("admin", result.Role);
            Assert.AreEqual(name, result.UserName);
        }

        [TestMethod]
        public void GetByUserName_MustReturnUserWithoutData()
        {
            string key = "name";
            string name = "Mauro";

            _mockyConnectorService.Setup(x => x.GetByKey(urlMocky, JsonModels.clients, key, name)).Returns(MockyConnectorStubs.GetClient(key, name));

            var result = _service.GetByUserName(name);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetById_MustReturnUserWithData()
        {
            string key = "id";
            string id = "a0ece5db-cd14-4f21-812f-966633e7be86";

            _mockyConnectorService.Setup(x => x.GetByKey(urlMocky, JsonModels.clients, key, id)).Returns(MockyConnectorStubs.GetClient(key, id));

            var result = _service.GetById(id);

            Assert.AreEqual("admin", result.Role);
            Assert.AreEqual(id, result.Id);
        }

        [TestMethod]
        public void GetById_MustReturnUserWithoutData()
        {
            string key = "id";
            string id = "a0ece5db-cd14-4f21-812f-966633e7be86ss";

            _mockyConnectorService.Setup(x => x.GetByKey(urlMocky, JsonModels.clients, key, id)).Returns(MockyConnectorStubs.GetClient(key, id));

            var result = _service.GetById(id);

            Assert.IsNull(result);
        }
    }
}
