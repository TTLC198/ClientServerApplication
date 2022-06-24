using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PStudioLibrary
{
    public class Services
    {
        public static string GetHashString(string s)
        {
            var bytes = Encoding.Unicode.GetBytes(s);
            var CSP = new MD5CryptoServiceProvider();
            var byteHash = CSP.ComputeHash(bytes);
            return byteHash.Aggregate("", (current, b) => current + $"{b:x2}");
        }
        
        public static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms,imageIn.RawFormat);
                return  ms.ToArray();
            }
        }

        public static Image ByteArrayToImage(byte[] dataIn)
        {
            MemoryStream ms = new MemoryStream(dataIn,0,dataIn.Length);
            ms.Write(dataIn, 0, dataIn.Length);
            return Image.FromStream(ms,true);
        }
        
        public static async Task SendComplexMessageAsync(Stream stream, ComplexMessage complexMessage)
        {
            var m = SerializeAndDeserialize.Serialize(complexMessage);
            await stream.WriteAsync(m.Data, 0,
                m.Data.Length);
        }
    }
}