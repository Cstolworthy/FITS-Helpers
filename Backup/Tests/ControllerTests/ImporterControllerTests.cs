using InterfacesAndDto.Repositories;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Website.Controllers;

namespace ControllerTests
{
    [TestClass]
    public class ImporterControllerTests
    {
        [TestMethod]
        public void TestImporterIndexRetrievesRepositoriesAwaitingImport()
        {
            var mockUnityContainer = new UnityContainer();
            var mockRepo = new Mock<IFitsDataRepository>();
            mockUnityContainer.RegisterInstance(typeof (IFitsDataRepository), "", mockRepo.Object);

            var controller = new ImporterController(mockUnityContainer);
            
            controller.Index();

            mockRepo.Verify(mr=>mr.GetRepositoriesAwaitingImport(),Times.Once());
        }
    }
}
