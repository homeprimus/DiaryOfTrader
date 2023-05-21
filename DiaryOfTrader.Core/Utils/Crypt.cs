using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace DiaryOfTrader.Core.Utils
{
  public class Crypt
  {
    // magic key
    private const string PasswordKey = "6ivgfh-386y6ivg-fh386y6ivg,6ivgfh3-86y6iv";
    private const string PasswordKeyForRestore = "86y6iv-6ivgfh3-fh386y6ivg,386y6ivg-6ivgfh";
    private static readonly byte[] liteSpeedKey = { 68, 107, 156, 66, 154, 56, 50, 212, 251, 209, 122, 220, 149, 8, 249, 221 };
    private const int DESBlockSize = 8;

    #region Import WinAPI

    [DllImport("advapi32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    protected static extern bool CryptAcquireContextA(ref IntPtr phProv, string pszContainer, string pszProvider, int dwProvType, uint dwFlags);
    [DllImport("advapi32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    protected static extern bool CryptCreateHash(IntPtr hProv, uint algid, IntPtr hKey, uint dwFlags, ref IntPtr phHash);
    [DllImport("advapi32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    protected static extern bool CryptDecrypt(IntPtr hKey, IntPtr hHash, bool final, uint dwFlags, byte[] pbData, ref uint pdwDataLen);
    [DllImport("advapi32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    protected static extern bool CryptDestroyHash(IntPtr hHash);
    [DllImport("advapi32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    protected static extern bool CryptDestroyKey(IntPtr hKey);
    [DllImport("advapi32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    protected static extern bool CryptEncrypt(IntPtr hKey, IntPtr hHash, bool final, uint dwFlags, byte[] pbData, ref uint pdwDataLen, uint dwBufLen);
    [DllImport("advapi32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    protected static extern bool CryptHashData(IntPtr hHash, byte[] pbData, uint dwDataLen, uint dwFlags);
    [DllImport("advapi32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    protected static extern bool CryptReleaseContext(IntPtr hProv, uint dwFlags);
    [DllImport("advapi32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    protected static extern bool CryptDeriveKey(IntPtr hProv, uint algid, IntPtr hHash, uint dwFlags, ref IntPtr hKey);

    protected static readonly uint CRYPT_VERIFYCONTEXT = 0xF0000000;
    protected static readonly uint CRYPT_NEWKEYSET = 0x00000008;
    protected static readonly uint CRYPT_MACHINE_KEYSET = 0x00000020;
    protected static readonly uint CALG_3DES = (3 << 13 | 3 << 9 | 3);
    protected static readonly int PROV_RSA_FULL = 1;
    protected static readonly uint HP_HASHVAL = 0x0002;
    protected static readonly int CALG_MD2 = 0x8001;
    protected static readonly int CALG_MD4 = 0x8002;
    protected static readonly int CALG_MD5 = 0x8003;
    protected static readonly int CALG_SHA1 = 0x8004;

    protected static int GetLastError()
    {
      return Marshal.GetLastWin32Error();
    }

    #endregion

    #region Private Methods

    private static bool AcquireContext(ref IntPtr provider)
    {
      var result =
        CryptAcquireContextA(ref provider, null, null, PROV_RSA_FULL,
                             CRYPT_VERIFYCONTEXT | CRYPT_MACHINE_KEYSET);
      if (!(result))
      {
        if ((uint)GetLastError() == 0x80090016)
        {
          result = CryptAcquireContextA(ref provider, null, null, PROV_RSA_FULL,
                                        CRYPT_NEWKEYSET | CRYPT_MACHINE_KEYSET);
        }
      }
      return result;
    }

    private static string EncryptString(string s)
    {
      var result = s;
      var hProv = IntPtr.Zero;
      if (AcquireContext(ref hProv))
      {
        try
        {
          var hHash = IntPtr.Zero;
          if (CryptCreateHash(hProv, (uint)CALG_MD5, (IntPtr)0, 0, ref hHash))
          {
            try
            {
              var pbData = Encoding.Unicode.GetBytes(PasswordKey);
              var dwLength = (uint)pbData.Length;
              if (CryptHashData(hHash, pbData, dwLength, 0))
              {
                var hKey = IntPtr.Zero;
                if (CryptDeriveKey(hProv, CALG_3DES, hHash, 0, ref hKey))
                {
                  try
                  {
                    var bArray = Encoding.Unicode.GetBytes(s);
                    dwLength = 0;
                    if (CryptEncrypt(hKey, (IntPtr) 0, true, 0, null, ref dwLength, (uint) bArray.Length))
                    {
                      var pbDataPwd = new byte[(uint)bArray.Length + dwLength];
                      dwLength = (uint)bArray.Length;
                      for (var i = 0; i < bArray.Length; i++)
                      {
                        pbDataPwd[i] = bArray[i];
                      }
                      if (CryptEncrypt(hKey, (IntPtr) 0, true, 0, pbDataPwd, ref dwLength, (uint) pbDataPwd.Length))
                      {
                        var encrypt = new byte[dwLength];
                        for (var i = 0; i < dwLength; i++)
                          encrypt[i] = pbDataPwd[i];


                        var base64 = new char[(int) (Math.Ceiling((double) encrypt.Length/3)*4)];
                        Convert.ToBase64CharArray(encrypt, 0, encrypt.Length, base64, 0);
                        result = new String(base64);
                      }
                    }
                  }
                  finally
                  {
                    CryptDestroyKey(hKey);
                  }
                }
              }
            }
            finally
            {
              CryptDestroyHash(hHash);
            }
          }
        }
        finally
        {
          CryptReleaseContext(hProv, 0);
        }
      }
      return result;
    }
    private static string DecryptString(byte[] bArray)
    {
      var result = string.Empty;
      var hProv = IntPtr.Zero;
      if (AcquireContext(ref hProv))
      {
        try
        {
          var hHash = IntPtr.Zero;
          if (CryptCreateHash(hProv, (uint)CALG_MD5, (IntPtr)0, 0, ref hHash))
          {
            try
            {
              var pbData = Encoding.Unicode.GetBytes(PasswordKey);
              var dwLength = (uint)pbData.Length;
              if (CryptHashData(hHash, pbData, dwLength, 0))
              {
                var hKey = IntPtr.Zero;
                if (CryptDeriveKey(hProv, CALG_3DES, hHash, 0, ref hKey))
                {
                  try
                  {
                    dwLength = (uint)bArray.Length;
                    if (CryptDecrypt(hKey, (IntPtr)0, true, 0, bArray, ref dwLength))
                    {
                      var decrypt = new byte[dwLength];
                      for (var i = 0; i < dwLength; i++)
                        decrypt[i] = bArray[i];
                      result = Encoding.Unicode.GetString(decrypt);
                    }
                  }
                  finally
                  {
                    CryptDestroyKey(hKey);
                  }
                }
              }
            }
            finally
            {
              CryptDestroyHash(hHash);
            }
          }
        }
        finally
        {
          CryptReleaseContext(hProv, 0);
        }
      }
      return result;
    }

    private static String EncryptString(String inString, byte[] key)
    {

      var block = new byte[DESBlockSize];
      var inBytes = Encoding.Default.GetBytes(inString);

      var lastBlockDataLen = inBytes.Length % DESBlockSize;
      var padding = new byte[8 - lastBlockDataLen];
      padding[padding.Length - 1] = (byte)lastBlockDataLen;

      var ms = new MemoryStream();
      var tdes = new TripleDESCryptoServiceProvider {Padding = PaddingMode.None};
      tdes.GenerateIV();
      var csBase64 = new CryptoStream(ms, new ToBase64Transform(), CryptoStreamMode.Write);

      Array.Copy(tdes.IV, block, DESBlockSize);
      csBase64.Write(block, 0, DESBlockSize);

      tdes.Mode = CipherMode.CBC;
      var cs = new CryptoStream(csBase64, tdes.CreateEncryptor(key, block), CryptoStreamMode.Write);
      cs.Write(inBytes, 0, inBytes.Length);
      cs.Write(padding, 0, padding.Length);
      cs.Close();
      csBase64.Close();
      ms.Close();
      return Encoding.Default.GetString(ms.ToArray());

    }

    private static String DecryptString(String encryptedString, byte[] key)
    {
      var block = new byte[DESBlockSize];
      var inBytes = Encoding.Default.GetBytes(encryptedString);

      var ms = new MemoryStream(inBytes);
      var csBase64 = new CryptoStream(ms, new FromBase64Transform(), CryptoStreamMode.Read);
      csBase64.Read(block, 0, DESBlockSize);

      var tdes = new TripleDESCryptoServiceProvider {Mode = CipherMode.CBC, Padding = PaddingMode.None};

      var ms2 = new MemoryStream();
      var cs = new CryptoStream(csBase64, tdes.CreateDecryptor(key, block), CryptoStreamMode.Read);

      int readLength;
      var tmpBuffer = new byte[500];
      while ((readLength = cs.Read(tmpBuffer, 0, tmpBuffer.Length)) > 0)
      {
        ms2.Write(tmpBuffer, 0, readLength);
      }
      cs.Close();
      csBase64.Close();
      ms.Close();

      var tmpArray = ms2.ToArray();
      ms2.SetLength(tmpArray.LongLength - (DESBlockSize - tmpArray[tmpArray.Length - 1]));
      ms2.Close();

      return Encoding.Default.GetString(ms2.ToArray());
    }


    #endregion

    #region Public Methods

    public static string EncryptKey(string key)
    {
      var result = EncryptString(key);
      return result;

    }

    public static string DecryptKey(string key)
    {
      var result = DecryptString(Convert.FromBase64String(key));
      return result;
    }

    public static string DecryptPassword(string password)
    {
      return DecryptString(password, liteSpeedKey);
    }

    public static string EncryptPassword(string password)
    {
      return EncryptString(password, liteSpeedKey);
    }


    #endregion
  }
}
