using System;
using System.Collections.Generic;
using System.Linq;

namespace Kulana.Common.Columns
{
    /// <summary>
    /// Divides items equally over the specified number of columns
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Columns<T>
    {
        public int NumColumns { get; private set; }
        public IList<Column<T>> Items { get; private set; }
        public DistributionDirection Direction { get; private set; }

        public Columns(int numColumns, IEnumerable<T> items) :
            this(numColumns, items, DistributionDirection.LEFTRIGHT)
        {
        }

        public Columns(int numColumns, IEnumerable<T> items, DistributionDirection direction)
        {
            NumColumns = numColumns;
            Items = new List<Column<T>>();
            for (int col = 0; col < NumColumns; col++)
            {
                bool first = !Items.Any();
                Items.Add(new Column<T>(first));
            }
            Direction = direction;
            Distribute(items);
        }

        private void Distribute(IEnumerable<T> items)
        {
            int colIndex = 0;
            var @enum = items.GetEnumerator();
            while (@enum.MoveNext())
            {
                Items[colIndex].Add(@enum.Current);
                colIndex++;
                colIndex = colIndex % NumColumns;
            }
            RemoveEmptyColumns();
        }

        private void RemoveEmptyColumns()
        {
            foreach (var column in Items)
            {
                if (!column.Items.Any())
                {
                    Items.Remove(column);
                }
            }
            NumColumns = Items.Count;
        }
    }

    public class Column<T>
    {
        public IList<T> Items { get; private set; } = new List<T>();
        public bool IsFirst { get; private set; }

        public Column(bool first)
        {
            IsFirst = first;
        }

        public void Add(T item)
        {
            Items.Add(item);
        }
    }

    public class DistributionDirection
    {
        public static DistributionDirection TOPBOTTOM = new DistributionDirection(TopBottom);
        public static DistributionDirection LEFTRIGHT = new DistributionDirection(LeftRight);
        private readonly Func<int, int, int> _strategy;

        private int _columnIndex = 0;
        private int _itemIndex = 0;

        private DistributionDirection(Func<int, int, int> strategy)
        {
            _strategy = strategy;
        }

        public int NextColumn<T>(int totalColumns, int numItems, int itemIndex)
        {
            return _strategy(totalColumns, itemIndex);
        }

        private static int TopBottom(int totalColumns, int itemIndex)
        {
            return 0;
        }

        private static int LeftRight(int totalColumns, int itemIndex)
        {
            return itemIndex % totalColumns;
        }
    }
}

