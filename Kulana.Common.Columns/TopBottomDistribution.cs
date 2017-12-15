using System;

namespace Kulana.Common.Columns
{
    public class TopBottomDistribution : IDistributionStrategy
    {
        public int GetColumnIndex(int totalColumns, int totalItems, int currentItemIndex)
        {
            int itemsPerColumn = (int)Math.Ceiling(totalItems / (double)totalColumns);
            int currentColumn = (currentItemIndex / itemsPerColumn);
            return currentItemIndex % totalColumns; 
        }
    }
}
