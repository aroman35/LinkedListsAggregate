using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedListsAggregates
{
    public class MergeFactory<T> where T: IComparable<T>, IEquatable<T>
    {
        private readonly LinkedList<T>[] _sourceLists;

        public MergeFactory(params LinkedList<T>[] sourceLists)
        {
            _sourceLists = sourceLists;
        }

        public LinkedList<T> Merge()
        {
            if(!_sourceLists.Any())
                throw new InvalidOperationException("No lists were found");

            return Merge(_sourceLists);
        }

        public LinkedList<T> Merge(params LinkedList<T>[] sourceLists)
        {
            if(!sourceLists.Any())
                throw new InvalidOperationException("No lists were found");

            if (sourceLists.Length == 1)
                return sourceLists.First();

            var resultList = new LinkedList<T>();

            foreach (var linkedList in sourceLists)
            {
                resultList = MergeTwo(resultList, linkedList);
            }

            return resultList;
        }

        private LinkedList<T> MergeTwo(LinkedList<T> firstList, LinkedList<T> secondList)
        {
            var mergedList = new LinkedList<T>();
            while (firstList.Any() || secondList.Any())
            {
                var minValue = GetMinValue(firstList, secondList);
                mergedList.AddLast(minValue);
            }

            return mergedList;
        }

        private T GetMinValue(LinkedList<T> firstList, LinkedList<T> secondList)
        {
            if (!firstList.Any() && !secondList.Any())
                throw new InvalidOperationException("Both lists are empty");

            if (!firstList.Any())
                return secondList.PeekHead();

            if (!secondList.Any())
                return firstList.PeekHead();

            var firstNode = firstList.Head();
            var secondNode = secondList.Head();

            if (firstNode.CompareTo(secondNode) < 0)
                return firstList.PeekHead();

            return secondList.PeekHead();
        }
    }
}