namespace Business
{
    /// <summary>
    /// Factory class for Business Layer
    /// </summary>
    public class BusinessFactory
    {
        /// <summary>
        /// a method to return Authenticate object
        /// </summary>
        /// <returns></returns>
        public IAuthenticate GetBusiness()
        {
            return new Authenticate();
        }
    }
}
