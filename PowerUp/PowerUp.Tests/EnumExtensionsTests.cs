using Ploeh.AutoFixture;
using System;
using System.ComponentModel;
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
            [Description(EnumValueDescription)]
            ValWithDesc = 1,
            ValNoDesc = 2,
            AnotherNoDesc =3
        }

        #region ToEnum
        [Fact]
        public void ToEnum_GivenValidString_ReturnEnumValue()
        {
            var anotherNoDescString = TestEnum.ValWithDesc.ToString();

            Assert.Equal(TestEnum.ValWithDesc, anotherNoDescString.ToEnum<TestEnum>());
        }

        [Fact]
        public void ToEnum_GivenInvalidString_ShouldThrowArgumentException()
        {
            var notExistingEnumValString = _fixture.Create<string>();

            Assert.Throws<ArgumentException>(() => notExistingEnumValString.ToEnum<TestEnum>());
        }

        [Fact]
        public void ToEnum_GivenEmptyString_ShouldThrowArgumentNullException()
        {
            string nullString = null;

            Assert.Throws<ArgumentNullException>(() => nullString.ToEnum<TestEnum>());
        }
        #endregion

        #region GetDescription
        [Fact]
        public void GetDescription_GivenEnumWithDescription_ReturnEnumToString()
        {
            var testObject = TestEnum.ValWithDesc;
            Assert.Equal(EnumValueDescription, testObject.GetDescription());
        }

        [Fact]
        public void GetDescription_GivenEnumNoDescription_ReturnEnumToString()
        {
            var testObject = TestEnum.ValNoDesc;
            Assert.Throws<ArgumentException>(() => testObject.GetDescription());
        }
        #endregion
    }
}