using System.IO.Compression;
using System.Text;

namespace DiaryOfTrader.Core.Utils
{
  public static class GZip
  {
    private static void CopyTo(Stream input, Stream output)
    {
      const int bufferSize = 4096;
      var bytes = new byte[bufferSize];
      int count;
      while ((count = input.Read(bytes, 0, bytes.Length)) != 0)
      {
        output.Write(bytes, 0, count);
      }
    }
    public static void Compress(Stream source, Stream destination)
    {
      using (var output = new GZipStream(destination, CompressionMode.Compress))
      {
        CopyTo(source, output);
      }
    }
    public static void Decompress(Stream source, Stream destination)
    {
      using (var input = new GZipStream(source, CompressionMode.Decompress))
      {
        CopyTo(input, destination);
      }
    }
    public static string Compress(string value)
    {
      using (var destination = new MemoryStream())
      {
        using (var source = new MemoryStream(Encoding.Unicode.GetBytes(value)))
        {
          Compress(source, destination);
          var compressed = destination.ToArray();
          var base64 = new char[(int)(Math.Ceiling((double)compressed.Length / 3) * 4)];
          Convert.ToBase64CharArray(compressed, 0, compressed.Length, base64, 0);
          return new string(base64);
        }       
      }
    }

    public static string Decompress(string value)
    {
      using (var destination = new MemoryStream())
      {
        using (var source = new MemoryStream(Convert.FromBase64String(value)))
        {
          Decompress(source, destination);
          var decompressed = destination.ToArray();
          return Encoding.Unicode.GetString(decompressed);
        }
      }
    }

  }
}
