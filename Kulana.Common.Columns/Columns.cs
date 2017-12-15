using System;
using System.Collections.Generic;
using System.Linq;

namespace Kulana.Common.Columns
{
    /// <summary>
    /// Divides items equally over the specified number of columns using a specified strategy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Columns<T>
    {
        public int NumColumns { get; private set; }
        private IList<Column<T>> _columns;

        public Columns(int numColumns)
        {
            if (numColumns <= 0)
            {
                throw new ArgumentException("Number of columns must be greater than 0");
            }
            NumColumns = numColumns;
        }

        private void Initialize()
        {
            _columns = new List<Column<T>>();
            Enumerable.Range(1, NumColumns).ToList().ForEach(num => _columns.Add(new Column<T>()));
        }

        public ICollection<Column<T>> Distribute(ICollection<T> items, IDistributionStrategy strategy)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            if (strategy == null)
            {
                throw new ArgumentNullException(nameof(strategy));
            }
            Initialize();

            int itemIndex = 0;
            var @enum = items.GetEnumerator();
            while (@enum.MoveNext())
            {
                int columnIndex = strategy.GetColumnIndex(NumColumns, items.Count, itemIndex);
                _columns[columnIndex].Add(@enum.Current);
                itemIndex++;
            }
            RemoveEmptyColumns();
            return _columns;
        }

        private void RemoveEmptyColumns()
        {
            foreach (var column in _columns)
            {
                if (!column.Items.Any())
                {
                    _columns.Remove(column);
                }
            }
            NumColumns = _columns.Count;
        }
    }

    public class Column<T>
    {
        public ICollection<T> Items { get; private set; } = new List<T>();

        public void Add(T item)
        {
            Items.Add(item);
        }
    }
}

