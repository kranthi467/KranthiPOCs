using Model;

namespace Business
{
    /// <summary>
    /// An interface to Authenticate class
    /// </summary>
    public interface IAuthenticate
    {
        bool Register(RegisterModel modelObject);
        bool LogIn(LogInModel modelObject);
        string Password(ForgotPasswordModel modelObject);
    }
}