using System;
using System.ComponentModel;
using Ploeh.AutoFixture;
using Xunit;

namespace PowerUp.Tests
{
    public class EnumExtensionsTests
    {
        public EnumExtensionsTests()
        {
            _fixture = new Fixture();
        }

        private readonly IFixture _fixture;
        private const string EnumValueDescription = "Value with description";

        private enum TestEnum
        {
            [Description(EnumValueDescription)] ValWithDesc = 1,
            ValNoDesc = 2,
            AnotherNoDesc = 3
        }

        [Fact]
        public void GetDescription_GivenEnumNoDescription_ReturnEnumToString()
        {
            var testObject = TestEnum.ValNoDesc;
            Assert.Throws<ArgumentException>(() => testObject.GetDescription());
        }

        [Fact]
        public void GetDescription_GivenEnumWithDescription_ReturnEnumToString()
        {
            var testObject = TestEnum.ValWithDesc;
            Assert.Equal(EnumValueDescription, testObject.GetDescription());
        }
    }
}