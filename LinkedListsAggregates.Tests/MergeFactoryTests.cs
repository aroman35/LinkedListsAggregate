using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace LinkedListsAggregates.Tests
{
    public class MergeFactoryTests
    {
        [Fact]
        public void MergeTestThreeLists_Positive()
        {
            var list_1 = new LinkedList<int>(new[] {1, 3, 5, 7});
            var list_2 = new LinkedList<int>(new[] {2, 4, 6, 8});
            var list_3 = new LinkedList<int>(new[] {0, 9, 10, 11});

            var expectedResultSource = list_1.Concat(list_2).Concat(list_3).OrderBy(x => x).ToList();
            var expectedResult = new LinkedList<int>(expectedResultSource);

            var factory = new MergeFactory<int>(list_1, list_2, list_3);
            var actualResult = factory.Merge();

            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        public void MergeTestOneList_Positive()
        {
            var list_1 = new LinkedList<int>(new[] {1, 3, 5, 7});

            var expectedResultSource = list_1.ToList();
            var expectedResult = new LinkedList<int>(expectedResultSource);

            var factory = new MergeFactory<int>(list_1);
            var actualResult = factory.Merge();

            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        public void CatchEmptyListsException()
        {
            var expectedExceptionMessage = "No lists were found";
            var factory = new MergeFactory<int>();
            var exception = Should.Throw<InvalidOperationException>(() => factory.Merge());
            exception.Message.ShouldBe(expectedExceptionMessage);
        }
    }
}