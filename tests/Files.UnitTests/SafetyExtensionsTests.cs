using Files.Shared;
using Files.Shared.Extensions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.UnitTests
{
    public class SafetyExtensionsTests
    {
        [Test]
        public void IgnoreExceptions_DoesNotThrow()
        {
            //  arrange
            int numberOfCalls = 0;
            Func<Task> func = () =>
            {
                numberOfCalls++;
                return Task.Delay(0);
            };
            //  act & assert
            Assert.DoesNotThrowAsync(async() =>
            {
                await SafetyExtensions.IgnoreExceptions(func);
            });
        }

        [Test]
        public void IgnoreExceptions_WhenExceptionOccured_CallsLogger()
        {
            //  arrange
            Func<Task> func = () =>
            {
                throw new Exception("text");
            };
            //  act
            var response = SafetyExtensions.IgnoreExceptions(func);
            var result = response.Result;
            //  assert
            Assert.That(result == false);
        }
    }
}
