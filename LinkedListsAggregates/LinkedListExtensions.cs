using System;
using System.Collections.Generic;

namespace LinkedListsAggregates
{
    public static class LinkedListExtensions
    {
        private static void TryRemove<T>(this LinkedList<T> linkedList, T value)
        {
            var valueForRemove = linkedList.Find(value);

            if (valueForRemove != null)
                linkedList.Remove(valueForRemove);
        }

        public static T Head<T>(this LinkedList<T> linkedList)
        {
            if (linkedList.First == null)
                throw new InvalidOperationException("List is empty!");
            return linkedList.First.Value;
        }

        public static T PeekHead<T>(this LinkedList<T> linkedList)
        {
            var head = linkedList.Head();
            linkedList.TryRemove(head);
            return head;
        }
    }
}