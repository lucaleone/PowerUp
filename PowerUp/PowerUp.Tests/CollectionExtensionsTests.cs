using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        #region RemoveRange
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
        public void RemoveRange_GivenEmptyListToRemove_ShouldRemoveNothing()
        {
            var sourceList = _fixture.Create<List<string>>();
            var deleteList = new List<string>();
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

            sourceList.RemoveRange(deleteList);

            Assert.Equal(expectedCount, sourceList.Count);
        }
        #endregion

        #region Clone
        [Fact]
        public void Clone_GivenNullList_ShouldReturnNull()
        {
            List<string> testList = null;

            var clone = testList.Clone();

            Assert.Null(clone);
        }

        class Rock : ICloneable
        {
            int _weight;
            bool _round;
            bool _mossy;

            public Rock(int weight, bool round, bool mossy)
            {
                this._weight = weight;
                this._round = round;
                this._mossy = mossy;
            }

            public object Clone()
            {
                return new Rock(this._weight, this._round, this._mossy);
            }

            public override string ToString()
            {
                return string.Format("weight = {0}, round = {1}, mossy = {2}",
                    this._weight,
                    this._round,
                    this._mossy);
            }
        }
        //[Fact]
        //public void Clone_GivenValidList_ShouldReturnClone()
        //{
        //    var testList = _fixture.Create<List<Rock>>();
        //    var clone = testList.Clone();

        //    Assert.StrictEqual(clone, testList);
        //}
        #endregion

    }
}