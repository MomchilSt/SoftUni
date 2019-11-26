using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomListSorter
{
    public class SoftUniList<T> : ISoftUniList<T>
        where T : IComparable<T>
    {
        private List<T> softUniList;

        public SoftUniList()
        {
            this.softUniList = new List<T>();
        }

        public void Add(T element)
        {
            this.softUniList.Add(element);
        }

        public T Remove(int index)
        {
            T element = this.softUniList[index];
            this.softUniList.RemoveAt(index);

            return element;
        }

        public bool Contains(T element)
        {
            return this.softUniList.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            T temp = this.softUniList[index1];
            this.softUniList[index1] = this.softUniList[index2];
            this.softUniList[index2] = temp;
        }

        public int CountGreaterThan(T element)
        {
            return this.softUniList.Count(e => e.CompareTo(element) > 0);
        }

        public T Max()
        {
            return this.softUniList.Max();
        }

        public T Min()
        {
            return this.softUniList.Min();
        }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, this.softUniList);
        }

        public void Sorter()
        {
            List<T> sortedList = this.softUniList.OrderBy(e => e).ToList();
            this.softUniList = sortedList;
        }
    }
}
