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

        [Fact]
        public void RemoveRange_GivenListContainsElements_ShouldRemoveCommonOnes()
        {
            var sourceList = _fixture.Create<List<string>>();
            var deleteList = sourceList.ToList();
            var newElements = _fixture.Create<List<string>>();
            sourceList.AddRange(newElements);

            sourceList.RemoveRange(deleteList);

            Assert.Equal(newElements, sourceList);
        }

        [Fact]
        public void RemoveRange_GivenListNotContainsElements_ShouldRemoveNothing()
        {
            var sourceList = _fixture.Create<List<string>>();
            var deleteList = _fixture.Create<List<string>>();
            var newElements = _fixture.Create<List<string>>();
            sourceList.AddRange(newElements);
            var expectedCount = sourceList.Count;

            sourceList.RemoveRange(deleteList);

            Assert.Equal(expectedCount, sourceList.Count);
        }
    }
}