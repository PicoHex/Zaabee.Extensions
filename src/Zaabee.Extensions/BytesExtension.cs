using System;
using System.Text;

namespace Zaabee.Extensions
{
    public static class BytesExtension
    {
        public static string GetStringByUtf8(this byte[] bytes) => bytes.GetString(Encoding.UTF8);

        public static string GetStringByAscii(this byte[] bytes) => bytes.GetString(Encoding.ASCII);

        public static string GetStringByBigEndianUnicode(this byte[] bytes) => bytes.GetString(Encoding.BigEndianUnicode);

        public static string GetStringByDefault(this byte[] bytes) => bytes.GetString(Encoding.Default);

        public static string GetStringByUtf32(this byte[] bytes) => bytes.GetString(Encoding.UTF32);

        public static string GetStringByUtf7(this byte[] bytes) => bytes.GetString(Encoding.UTF7);

        public static string GetStringByUnicode(this byte[] bytes) => bytes.GetString(Encoding.Unicode);

        public static string ToBase64String(this byte[] bytes) => Convert.ToBase64String(bytes);

        public static byte[] ToBase64Bytes(this byte[] bytes, Encoding encoding = null) =>
            Convert.ToBase64String(bytes).ToBytes(encoding);

        public static byte[] DecodeBase64ToBytes(this byte[] bytes, Encoding encoding = null) =>
            Convert.FromBase64String(bytes.GetString(encoding));

        public static string DecodeBase64ToString(this byte[] bytes, Encoding encoding = null) =>
            Convert.FromBase64String(bytes.GetString(encoding)).GetString(encoding);

        public static string GetString(this byte[] bytes, Encoding encoding = null) =>
            bytes is null ? throw new ArgumentNullException(nameof(bytes)) :
            encoding is null ? Encoding.UTF8.GetString(bytes) : encoding.GetString(bytes);
    }
}