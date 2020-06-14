namespace CryptographyLibrary
{
    public interface ICipher
    {
        byte[] Encrypt(string message);
        byte[] Decrypt(string message);
        byte[] Encrypt(byte[] message);
        byte[] Decrypt(byte[] message);
    }
}
