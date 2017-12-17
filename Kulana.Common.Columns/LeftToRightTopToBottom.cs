namespace Kulana.Common.Columns
{
    public class LeftToRightTopToBottom : IDistributionMethod
    {
        public int GetColumnIndex(int totalColumns, int totalItems, int currentItemIndex)
        {
            if (currentItemIndex % totalColumns == 0)
            {
                return totalColumns;
            }
            return (currentItemIndex % totalColumns);
        }
    }
}
