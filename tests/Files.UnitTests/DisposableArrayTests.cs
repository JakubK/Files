using Files.Backend.SecureStore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.UnitTests
{
    public class DisposableArrayTests
    {
        [Test]
        public void CreateCopy_MakesCopy()
        {
            //  arrange
            var sut = new DisposableArray(new byte[]
            {
                0x01,
                0x03,
                0x05
            });

            //  act
            var copy = sut.CreateCopy();
            //  assert
            Assert.That(sut != copy);
            Assert.That(sut.Bytes != copy.Bytes);

        }

        [Test]
        public void CreateCopy_ReturnsMatchingBytes()
        {
            //  arrange
            var sut = new DisposableArray(new byte[]
            {
                0x01,
                0x03,
                0x05
            });

            //  act
            var copy = sut.CreateCopy();
            //  assert
            for (int i = 0;i < 3; i++)
            {
                Assert.That(sut.Bytes[i] == copy.Bytes[i]);
            }
        }
    }
}
