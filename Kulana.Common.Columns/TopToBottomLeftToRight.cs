using System;

namespace Kulana.Common.Columns
{
    public class TopToBottomLeftToRight : IDistributionMethod
    {
        public int GetColumnIndex(int totalColumns, int totalItems, int currentItemIndex)
        {
            int itemsPerColumn = (int)Math.Ceiling(totalItems / (double)totalColumns);
            int currentColumn = (int)Math.Ceiling(currentItemIndex / (double)itemsPerColumn);
            return currentColumn; 
        }
    }
}
