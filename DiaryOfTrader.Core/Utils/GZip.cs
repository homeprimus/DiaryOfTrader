using System.IO.Compression;
using System.Text;

namespace DiaryOfTrader.Core.Utils
{
  public static class GZip
  {
    private static void CopyTo(Stream input, Stream output)
    {
      const int BUFFER_SIZE = 1024 * 10;
      var bytes = new byte[BUFFER_SIZE];
      int count;
      while ((count = input.Read(bytes, 0, bytes.Length)) != 0)
      {
        output.Write(bytes, 0, count);
      }
    }

    public static void Compress(Stream source, Stream destination)
    {
      using var output = new GZipStream(destination, CompressionMode.Compress);
      CopyTo(source, output);
    }

    public static void Decompress(Stream source, Stream destination)
    {
      using var input = new GZipStream(source, CompressionMode.Decompress);
      CopyTo(input, destination);
    }

    public static string Compress(string value)
    {
      var compressed = Compress(Encoding.Unicode.GetBytes(value));
      var base64 = new char[(int)(Math.Ceiling((double)compressed.Length / 3) * 4)];
      Convert.ToBase64CharArray(compressed, 0, compressed.Length, base64, 0);
      return new string(base64);
    }

    public static string Decompress(string value)
    {
      var decompressed = Decompress(Convert.FromBase64String(value));
      return Encoding.Unicode.GetString(decompressed);
    }

    public static byte[] Compress(byte[] value)
    {
      using var destination = new MemoryStream();
      using var source = new MemoryStream(value);
      Compress(source, destination);
      return destination.ToArray();
    }

    public static byte[] Decompress(byte[] value)
    {
      using var destination = new MemoryStream();
      using var source = new MemoryStream(value);
      Decompress(source, destination);
      return destination.ToArray();
    }

  }
}
