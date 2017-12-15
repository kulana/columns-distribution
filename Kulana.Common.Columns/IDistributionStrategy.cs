namespace Kulana.Common.Columns
{
    public interface IDistributionStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalColumns">Total number of columns requested</param>
        /// <param name="totalItems">Total number of items to be distributed</param>
        /// <param name="currentItemIndex">Index of current item to distribute, index should be 0-based</param>
        /// <returns></returns>
        int GetColumnIndex(int totalColumns, int totalItems, int currentItemIndex);
    }
}
