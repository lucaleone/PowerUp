using System;
using System.ComponentModel;
using Xunit;

namespace PowerUp.Tests
{
    public class EnumExtensionsTests
    {
        private const string EnumValueDescription = "Value with description";

        private enum TestEnum
        {
            [Description(EnumValueDescription)] ValWithDesc = 1,
            ValNoDesc = 2
        }

        [Fact]
        public void GetDescription_GivenEnumNoDescription_ReturnEnumToString()
        {
            var testObject = TestEnum.ValWithDesc;
            Assert.Throws<ArgumentException>(() => testObject.GetDescription());
        }

        [Fact]
        public void GetDescription_GivenEnumWithDescription_ReturnEnumToString()
        {
            var testObject = TestEnum.ValNoDesc;
            Assert.Equal(EnumValueDescription, testObject.GetDescription());
        }

    }
}