using Model;

/// <summary>
/// Data Access layer for LogIn Application
/// </summary>
namespace DataAccess
{
    /// <summary>
    /// An interface for Data class
    /// </summary>
    public interface IData
    {
        bool CheckUser(string userName);
        bool StoreData(RegisterModel modelObject);
        bool LogInCheck(LogInModel modelObject);
        string GetPassword(ForgotPasswordModel modelObject);
    }
}
