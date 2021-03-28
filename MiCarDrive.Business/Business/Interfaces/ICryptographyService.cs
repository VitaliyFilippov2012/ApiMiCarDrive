namespace Business.Interfaces
{
    public interface ICryptographyService
    {
        string EncryptString(string str);

        string DecryptString(string str);
    }
}
