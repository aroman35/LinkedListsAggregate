using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace LinkedListsAggregates.Tests
{
    public class LinkedListExtensionsTest
    {
        [Fact]
        public void GetListHeadTest()
        {
            var list = new LinkedList<int>(new[] {1, 3, 5, 7});
            var expectedResult = 1;

            var head = list.Head();

            head.ShouldBe(expectedResult);
        }

        [Fact]
        public void GetListHeadThrowExceptionTest()
        {
            var list = new LinkedList<int>();
            var expectedExceptionMessage = "List is empty!";

            var exception = Should.Throw<InvalidOperationException>(() => list.Head());
            exception.Message.ShouldBe(expectedExceptionMessage);
        }

        [Fact]
        public void PeekListHeadTest()
        {
            var list = new LinkedList<int>(new[] {1, 3, 5, 7});
            var expectedResult = 1;

            var head = list.PeekHead();

            head.ShouldBe(expectedResult);
            list.ShouldBe(new LinkedList<int>(new [] {3, 5, 7}));
        }

        [Fact]
        public void PeekListHeadThrowExceptionTest()
        {
            var list = new LinkedList<int>();
            var expectedExceptionMessage = "List is empty!";

            var exception = Should.Throw<InvalidOperationException>(() => list.PeekHead());
            exception.Message.ShouldBe(expectedExceptionMessage);
        }
    }
}