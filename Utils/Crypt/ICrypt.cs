namespace Utils.Crypt
{
    public interface ICrypt
    {
       string Crypt(string str);
       string DeCrypt(string str);
    }
}