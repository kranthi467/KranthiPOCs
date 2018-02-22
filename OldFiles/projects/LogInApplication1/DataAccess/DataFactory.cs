namespace DataAccess
{
    /// <summary>
    /// A factory class to get Data object
    /// </summary>
    public class DataFactory
    {
        /// <summary>
        /// A method to return object of Data class
        /// </summary>
        /// <returns></returns>
        public IData GetData()
        {
            return new Data();
        }
    }
}
