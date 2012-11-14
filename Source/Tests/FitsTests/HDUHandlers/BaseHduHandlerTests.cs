using System;
using Core.HDUHandlers;
using NUnit.Framework;

namespace FitsTests
{
    [TestFixture]
    public class BaseHduHandlerTests
    {
        [SetUp]
        public void Setup()
        { }

        [Test]
        public void GivenANullHDU_CTOR_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => { new BaseHduHandler(null); });
        }
    }
}