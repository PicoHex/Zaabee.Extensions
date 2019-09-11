namespace Zaabee.Extensions
{
    public static class NullableExtension
    {
        public static bool IsNull<T>(this T param) => param == null;

        public static bool IsNotNull<T>(this T param) => param != null;

        public static bool IsNullOrDefault<T>(this T param) => param == null || param.Equals(default);

        public static T TryGetValue<T>(this T? param) where T : struct => param ?? default;
    }
}