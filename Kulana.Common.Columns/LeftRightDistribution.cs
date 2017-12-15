namespace Kulana.Common.Columns
{
    public class LeftRightDistribution : IDistributionStrategy
    {
        public int GetColumnIndex(int totalColumns, int totalItems, int currentItemIndex)
        {
            return currentItemIndex % totalColumns; 
        }
    }
}
