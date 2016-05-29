using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MRJoiner.utility
{
    public class AEScryptdecryptutil
    {


        public static void EncryptFile(string source, string password)
        {
            string path = source;
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine("No Such File");
                return;
            }

            byte[] bytes = File.ReadAllBytes(path);
            byte[] encrypted_bytes = Encrypt(bytes, password);

            //path += "crypt.data";
            //REPLACE

            /*if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
            */
            path += "_cr";

            File.WriteAllBytes(path, encrypted_bytes);
            Console.WriteLine("Encryption Successful");
        }

        public static bool DecryptFile(string source, string password)
        {
            string path = source;
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine("No Such File");

                throw new UnauthorizedAccessException();
            }

            byte[] bytes = File.ReadAllBytes(path);
            byte[] decrypted_bytes = null;
            try
            {
                decrypted_bytes = Decrypt(bytes, password);
            }
            catch (UnauthorizedAccessException e)
            {

                Console.WriteLine("Incorrect password");

                throw new UnauthorizedAccessException();

                Console.WriteLine("Exception caught Incorrect Password: {0}", e);
                return false;
            }

            // string path = Path.GetDirectoryName(source);
            string tempF = Path.GetDirectoryName(source) + "\\Decrypted";
            if (!Directory.Exists(tempF)) Directory.CreateDirectory(tempF);

            path = tempF + "\\" + Path.GetFileName(source);

            if (!System.IO.File.Exists(path))
            {
                FileStream fs = System.IO.File.Create(path);
                fs.Close();
            }

            File.WriteAllBytes(path, decrypted_bytes);
            //Console.WriteLine("Decryption Successful");
            return true;
        }

        public static byte[] Encrypt(byte[] data, string password)
        {
            using (RijndaelManaged m = new RijndaelManaged())
            using (SHA256Managed h = new SHA256Managed())
            {
                byte[] salt = new byte[32];
                new RNGCryptoServiceProvider().GetBytes(salt);
                Rfc2898DeriveBytes derivedKey = new Rfc2898DeriveBytes(password, salt) { IterationCount = 10000 };
                m.KeySize = 256;
                m.BlockSize = 256;
                byte[] hash = h.ComputeHash(data);
                m.Key = derivedKey.GetBytes(m.KeySize / 8);
                m.IV = derivedKey.GetBytes(m.BlockSize / 8);

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(hash, 0, hash.Length);
                    ms.Write(salt, 0, salt.Length);
                    using (CryptoStream cs = new CryptoStream(ms, m.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
        }

        public static byte[] Decrypt(byte[] data, string password)
        {
            using (MemoryStream ms = new MemoryStream(data, false))
            using (RijndaelManaged m = new RijndaelManaged())
            using (SHA256Managed h = new SHA256Managed())
            {
                try
                {
                    m.KeySize = 256;
                    m.BlockSize = 256;

                    byte[] hash = new byte[32];
                    ms.Read(hash, 0, 32);
                    byte[] salt = new byte[32];
                    ms.Read(salt, 0, 32);

                    Rfc2898DeriveBytes derivedKey = new Rfc2898DeriveBytes(password, salt) { IterationCount = 10000 };
                    m.Key = derivedKey.GetBytes(m.KeySize / 8);
                    m.IV = derivedKey.GetBytes(m.BlockSize / 8);

                    using (MemoryStream result = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, m.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            byte[] buffer = new byte[1024];
                            int len;
                            while ((len = cs.Read(buffer, 0, buffer.Length)) > 0)
                                result.Write(buffer, 0, len);
                        }

                        byte[] final = result.ToArray();
                        /*if (Convert.ToBase64String(hash) != Convert.ToBase64String(h.ComputeHash(final)))
                            throw new UnauthorizedAccessException();*/

                        return final;
                    }
                }
                catch
                {
                    //never leak the exception type...
                    throw new UnauthorizedAccessException();
                }
            }
        }
    }
}
