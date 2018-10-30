using System;
using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;
using Xunit;

namespace PowerUp.Tests
{
    public class CollectionExtensionsTests
    {
        public CollectionExtensionsTests()
        {
            _fixture = new Fixture();
        }

        private readonly IFixture _fixture;

        private class Rock : ICloneable
        {
            public readonly bool round;
            public int weight;

            public Rock(int weight, bool round)
            {
                this.weight = weight;
                this.round = round;
            }

            public object Clone()
            {
                return new Rock(weight, round);
            }

            public override bool Equals(object obj)
            {
                var rock = obj as Rock;
                return rock != null &&
                       weight == rock.weight &&
                       round == rock.round;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(weight, round);
            }
        }

        [Fact]
        public void Clone_GivenNullList_ShouldReturnNull()
        {
            List<string> testList = null;

            var clone = testList.Clone();

            Assert.Null(clone);
        }

        [Fact]
        public void Clone_OneListModified_ShouldNotAffectTheFirstOne()
        {
            var testList = _fixture.Create<List<Rock>>();
            var clone = testList.Clone();

            Assert.NotNull(clone);
            Assert.Equal(clone, testList);
            Assert.False(clone.First() == testList.First());
            clone.First().weight = _fixture.Create<int>();
            Assert.NotEqual(clone.First().weight, testList.First().weight);
        }

        [Fact]
        public void GetLastIndex_GivenEmptyList_ShouldTrowsArgumentException()
        {
            var sourceList = new List<int>();

            Assert.Empty(sourceList);
            Assert.Throws<ArgumentException>(() => sourceList.GetLastIndex());
        }

        [Fact]
        public void GetLastIndex_GivenValidList_ShouldReturnLenghtMinusOne()
        {
            var sourceList = new List<int>();
            var lenght = _fixture.Create<int>();
            for (var i = 0; i < lenght; i++)
            {
                sourceList.Add(_fixture.Create<int>());
            }

            Assert.NotEmpty(sourceList);
            Assert.Equal(sourceList.GetLastIndex(), lenght - 1);
        }

        [Fact]
        public void RemoveRange_GivenEmptyListToRemove_ShouldRemoveNothing()
        {
            var sourceList = _fixture.Create<List<string>>();
            var deleteList = new List<string>();
            var expectedCount = sourceList.Count;

            Assert.Empty(deleteList);
            sourceList.RemoveRange(deleteList);

            Assert.Equal(expectedCount, sourceList.Count);
        }

        [Fact]
        public void RemoveRange_GivenListContainsElements_ShouldRemoveCommonOnes()
        {
            var sharedElements = _fixture.Create<List<string>>();
            var deleteList = sharedElements.Clone();
            var testList = _fixture.Create<List<string>>();
            var expectedResultList = testList.Clone();
            testList.AddRange(sharedElements);

            testList.RemoveRange(deleteList);

            Assert.Equal(expectedResultList, testList);
        }

        [Fact]
        public void RemoveRange_GivenListNotContainsElements_ShouldRemoveNothing()
        {
            var sourceList = _fixture.Create<List<string>>();
            var deleteList = _fixture.Create<List<string>>();
            var expectedCount = sourceList.Count;

            sourceList.RemoveRange(deleteList);

            Assert.Equal(expectedCount, sourceList.Count);
        }

        [Fact]
        public void RemoveRange_GivenNullListToRemove_ShouldRemoveNothing()
        {
            var sourceList = _fixture.Create<List<string>>();
            List<string> deleteList = null;
            var expectedCount = sourceList.Count;

            Assert.Null(deleteList);
            sourceList.RemoveRange(deleteList);

            Assert.Equal(expectedCount, sourceList.Count);
        }
    }
}