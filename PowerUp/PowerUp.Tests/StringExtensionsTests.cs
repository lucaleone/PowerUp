using System;
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

        private enum TestEnum
        {
            Val1,
            Val2,
            Val3
        }

        [Fact]
        public void IsInteger_GivenInValidIntegerString_ShouldReturnFalse()
        {
            var notIntegerString = _fixture.Create<string>();

            Assert.False(notIntegerString.IsInteger());
        }

        [Fact]
        public void IsInteger_GivenValidIntegerString_ShouldReturnTrue()
        {
            var integerString = _fixture.Create<int>().ToString();

            Assert.True(integerString.IsInteger());
        }

        [Fact]
        public void ToEnum_GivenEmptyString_ShouldThrowArgumentNullException()
        {
            string nullString = null;

            Assert.Throws<ArgumentNullException>(() => nullString.ToEnum<TestEnum>());
        }

        [Fact]
        public void ToEnum_GivenInvalidString_ShouldThrowArgumentException()
        {
            var notExistingEnumValString = _fixture.Create<string>();

            Assert.Throws<ArgumentException>(() => notExistingEnumValString.ToEnum<TestEnum>());
        }

        [Fact]
        public void ToEnum_GivenValidString_ReturnEnumValue()
        {
            var val1EnumString = TestEnum.Val1.ToString();

            Assert.Equal(TestEnum.Val1, val1EnumString.ToEnum<TestEnum>());
        }
    }
}