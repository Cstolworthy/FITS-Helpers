using System;
using FitsLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FitsLogicTests
{
    [TestClass]
    public class ImageHduHandlerTests
    {
        [TestMethod]
        public void TestSingleColorParsing()
        {
            var grid = new Array[3];
            grid[0] = new float[3] { 0.0f, 0.1f, 0.2f };
            grid[1] = new float[3] { 0.0f, 0.1f, 0.2f };
            grid[2] = new float[3] { 0.0f, 0.1f, 0.2f };

            var handler = new Mock<ImageHduHandler>("");

            handler.Object.HandleImageData(grid);

            handler.Verify(h => h.SaveImageData(It.IsAny<Array>()), Times.Exactly(3));
        }

        [TestMethod]
        public void TestSingleColorIsPassed()
        {
            var grid = new float[3] {0.0f, 0.1f, 0.2f};

            var handler = new Mock<ImageHduHandler>("");

            handler.Object.HandleImageData(grid);

            handler.Verify(h => h.SaveImageData(It.IsAny<Array>()), Times.Exactly(3));
        }


        [TestMethod]
        public void TestMultiColorParsing()
        {
            var grid = new Array[3];

            var red = new Array[3];
            red[0] = new float[4] {0.0f,0.1f,0.2f,0.3f};
            red[1] = new float[4] { 0.0f, 0.1f, 0.2f, 0.3f };
            red[2] = new float[4] { 0.0f, 0.1f, 0.2f, 0.3f };

            var green = new Array[3];
            green[0] = new float[4] { 0.0f, 0.1f, 0.2f, 0.3f };
            green[1] = new float[4] { 0.0f, 0.1f, 0.2f, 0.3f };
            green[2] = new float[4] { 0.0f, 0.1f, 0.2f, 0.3f };

            var blue = new Array[3];
            blue[0] = new float[4] { 0.0f, 0.1f, 0.2f, 0.3f };
            blue[1] = new float[4] { 0.0f, 0.1f, 0.2f, 0.3f };
            blue[2] = new float[4] { 0.0f, 0.1f, 0.2f, 0.3f };

            grid[0] = red;// new float[3] { 0.0f, 0.1f, 0.2f };
            grid[1] = green;
            grid[2] = blue;

            var handler = new Mock<ImageHduHandler>("");

            handler.Object.HandleImageData(grid);

            handler.Verify(h => h.SaveImageData(It.IsAny<Array>()), Times.Exactly(9));
        }
    }
}
