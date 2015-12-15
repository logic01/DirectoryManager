using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using SystemWrapper.IO;

namespace DirectoryManager.BusinessDomain.Tests
{
    [TestClass]
    public class DirectoryBusinessTests
    {
        private IDirectoryBusiness _business = new DirectoryBusiness();

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        // expect exceptions to bubble up to the UI
        public async Task InvalidDirectory_ThrowsDirectoryNotFoundException()
        {
            IDirectoryInfoWrap info = new DirectoryInfoWrap("NotValidPath");
            await _business.MeasureDirectoryAsync(info);
        }

        [TestMethod]
        [ExpectedException(typeof(PathTooLongException))]
        // expect exceptions to bubble up to the UI
        public async Task InvalidDirectory_ThrowsPathToLongException()
        {
            IDirectoryInfoWrap info = new DirectoryInfoWrap(RandomString(260));
            await _business.MeasureDirectoryAsync(info);
        }


        [TestMethod]
        // this test shows the ability to test the business layer without dependency on the users machine
        public async Task InvalidDirectory_EmptyDirectoryNoSize()
        {
            var directoryInfo = new Moq.Mock<IDirectoryInfoWrap>();
            directoryInfo.Setup(s => s.GetFiles()).Returns(new FileInfoWrap[0]);
            directoryInfo.Setup(s => s.GetDirectories()).Returns(new DirectoryInfoWrap[0]);

            var size = await _business.MeasureDirectoryAsync(directoryInfo.Object);

            Assert.AreEqual(0, size);
        }


        private static string RandomString(int Size)
        {
            Random rand = new Random();

            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, Size)
                                   .Select(x => input[rand.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }
    }
}
