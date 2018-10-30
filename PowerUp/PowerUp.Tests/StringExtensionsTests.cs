using System;
using System.Collections.Generic;
using System.Text;
using Ploeh.AutoFixture;
using Xunit;

namespace PowerUp.Tests
{
    public class StringExtensionsTests
    {
        public StringExtensionsTests()
        {
            _fixture = new Fixture();
        }

        private readonly IFixture _fixture;

        #region IsInteger
        [Fact]
        public void IsInteger_GivenValidIntegerString_ShouldReturnTrue()
        {
            var integerString = _fixture.Create<int>().ToString();

            Assert.True(integerString.IsInteger());
        }

        [Fact]
        public void IsInteger_GivenInValidIntegerString_ShouldReturnFalse()
        {
            var notIntegerString = _fixture.Create<string>();

            Assert.False(notIntegerString.IsInteger());
        }
        #endregion
    }
}
