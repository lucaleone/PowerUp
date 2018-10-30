using System;
using Ploeh.AutoFixture;
using Xunit;

namespace PowerUp.Tests
{
    public class GenericExtensionsTests
    {
        public GenericExtensionsTests()
        {
            _fixture = new Fixture();
        }

        private readonly IFixture _fixture;

        [Fact]
        public void BetweenExclusive_GivenBetweenRange_ShouldReturnTrue()
        {
            var betweenVal = _fixture.Create<int>();
            var lowerBound = betweenVal - _fixture.Create<int>();
            var upperBound = betweenVal + _fixture.Create<int>();
            var betweenValDate = _fixture.Create<DateTime>();
            var lowerBoundDate = betweenValDate.Add(-_fixture.Create<DateTime>().TimeOfDay);
            var upperBoundDate = betweenValDate.Add(_fixture.Create<DateTime>().TimeOfDay);

            Assert.True(betweenVal > lowerBound);
            Assert.True(betweenVal < upperBound);
            Assert.True(betweenVal.Between(lowerBound, upperBound));

            Assert.True(betweenValDate > lowerBoundDate);
            Assert.True(betweenValDate < upperBoundDate);
            Assert.True(betweenValDate.Between(lowerBoundDate, upperBoundDate));
        }

        [Fact]
        public void BetweenExclusive_GivenOutOfRange_ShouldReturnFalse()
        {
            var betweenVal = _fixture.Create<int>();
            var lowerBound = betweenVal + _fixture.Create<int>();
            var upperBound = lowerBound + _fixture.Create<int>();
            var betweenValDate = _fixture.Create<DateTime>();
            var lowerBoundDate = betweenValDate.Add(_fixture.Create<DateTime>().TimeOfDay);
            var upperBoundDate = lowerBoundDate.Add(_fixture.Create<DateTime>().TimeOfDay);

            Assert.True(betweenVal < lowerBound);
            Assert.True(betweenVal < upperBound);
            Assert.False(betweenVal.Between(lowerBound, upperBound));

            Assert.True(betweenValDate < lowerBoundDate);
            Assert.True(betweenValDate < upperBoundDate);
            Assert.False(betweenValDate.Between(lowerBoundDate, upperBoundDate));
        }

        [Fact]
        public void BetweenInclusive_GivenBetweenRange_ShouldReturnTrue()
        {
            var betweenVal = _fixture.Create<int>();
            var lowerBound = betweenVal;
            var upperBound = betweenVal + _fixture.Create<int>();

            var betweenVal2 = _fixture.Create<int>();
            var lowerBound2 = betweenVal2 - _fixture.Create<int>();
            var upperBound2 = betweenVal2;

            var betweenVal3 = _fixture.Create<int>();
            var lowerBound3 = betweenVal3;
            var upperBound3 = betweenVal3;

            Assert.True(betweenVal == lowerBound);
            Assert.True(betweenVal < upperBound);
            Assert.True(betweenVal.Between(lowerBound, upperBound, BetweenOptions.Inclusive));

            Assert.True(betweenVal2 > lowerBound2);
            Assert.True(betweenVal2 == upperBound2);
            Assert.True(betweenVal2.Between(lowerBound2, upperBound2, BetweenOptions.Inclusive));

            Assert.True(betweenVal3 == lowerBound3);
            Assert.True(betweenVal3 == upperBound3);
            Assert.True(betweenVal3.Between(lowerBound3, upperBound3, BetweenOptions.Inclusive));
        }

        [Fact]
        public void IsNotNull_GivenNotNull_ShouldReturnTrue()
        {
            var nullObject = new object();

            Assert.NotNull(nullObject);
            Assert.True(nullObject.IsNotNull());
        }

        [Fact]
        public void IsNotNull_GivenNull_ShouldReturnFalse()
        {
            object nullObject = null;

            Assert.Null(nullObject);
            Assert.False(nullObject.IsNotNull());
        }

        [Fact]
        public void IsNotNull_GivenNullableNotNull_ShouldReturnTrue()
        {
            int? nullObject = _fixture.Create<int>();

            Assert.NotNull(nullObject);
            Assert.True(nullObject.IsNotNull());
        }

        [Fact]
        public void IsNotNull_GivenNullableNull_ShouldReturnFalse()
        {
            int? nullObject = null;

            Assert.False(nullObject.IsNotNull());
        }

        [Fact]
        public void IsNull_GivenNotNull_ShouldReturnFalse()
        {
            var nullObject = new object();

            Assert.NotNull(nullObject);
            Assert.False(nullObject.IsNull());
        }

        [Fact]
        public void IsNull_GivenNull_ShouldReturnTrue()
        {
            object nullObject = null;

            Assert.Null(nullObject);
            Assert.True(nullObject.IsNull());
        }

        [Fact]
        public void IsNull_GivenNullableNotNull_ShouldReturnFalse()
        {
            int? nullObject = _fixture.Create<int>();

            Assert.NotNull(nullObject);
            Assert.False(nullObject.IsNull());
        }

        [Fact]
        public void IsNull_GivenNullableNull_ShouldReturnTrue()
        {
            int? nullObject = null;

            Assert.True(nullObject.IsNull());
        }

        [Fact]
        public void ThrowIfNull_GivenNotNull_ShouldThrowArgumentNullException()
        {
            var notNullObject = new object();

            notNullObject.ThrowIfNull(nameof(notNullObject));
            Assert.NotNull(notNullObject);
        }

        [Fact]
        public void ThrowIfNull_GivenNull_ShouldThrowArgumentNullException()
        {
            object nullObject = null;

            Assert.Null(nullObject);
            Assert.Throws<ArgumentNullException>(() => nullObject.ThrowIfNull(nameof(nullObject)));
        }
    }
}