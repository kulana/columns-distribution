namespace Kulana.Common.Columns
{
    public interface IDistributionMethod
    {
        /// <summary>
        /// Returns the column index in which to place the n-th item
        /// </summary>
        /// <param name="totalColumns">Total number of columns requested</param>
        /// <param name="totalItems">Total number of items to be distributed</param>
        /// <param name="currentItemIndex">Index of current item to place, index should be 1-based</param>
        /// <returns></returns>
        int GetColumnIndex(int totalColumns, int totalItems, int currentItemIndex);
    }
}
