using System;
using Xunit;

namespace PC.Core.Tests
{
    public class FirstTests
    {
        [Fact]
        public void emptyTest()
        {
            var fakeClass = new FakeClass();

            Assert.True(true);
        }
    }
}
