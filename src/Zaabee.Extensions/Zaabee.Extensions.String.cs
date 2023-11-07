﻿namespace Zaabee.Extensions;

public static partial class ZaabeeExtension
{
    private static readonly Encoding Utf8Encoding = Encoding.UTF8;

    public static string ToHex(this string str)
    {
        var sb = new StringBuilder();
        foreach (var t in str)
            sb.Append(Convert.ToInt32(t).ToString("X2"));
        return sb.ToString();
    }

    public static string FromHex(this string str)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < str.Length; i += 2)
            sb.Append((char)Convert.ToInt32(str.Substring(i, 2), 16));
        return sb.ToString();
    }

    public static string TrimStart(this string target, string? trimString)
    {
        if (string.IsNullOrEmpty(trimString)) return target;

        var result = target;
        while (result.StartsWith(trimString))
#if NETSTANDARD2_0
            result = result.Substring(trimString!.Length);
#else
            result = result[trimString.Length..];
#endif
        return result;
    }

    public static string TrimEnd(this string target, string? trimString)
    {
        if (string.IsNullOrEmpty(trimString)) return target;

        var result = target;
        while (result.EndsWith(trimString))
#if NETSTANDARD2_0
            result = result.Substring(0, result.Length - trimString!.Length);
#else
            result = result[..^trimString.Length];
#endif

        return result;
    }

    public static bool IsNullOrEmpty(this string? value) =>
        string.IsNullOrEmpty(value);

    public static bool IsNullOrWhiteSpace(this string? value) =>
        string.IsNullOrWhiteSpace(value);

    public static string StringJoin<T>(this IEnumerable<T> values, string separator) =>
        string.Join(separator, values);

    public static string Format(this string format, params object[] args) =>
        string.Format(format, args);

    public static string GetLetterOrDigit(this string source) =>
        new(source.Where(char.IsLetterOrDigit).ToArray());

    public static string? TryReplace(this string? str, string oldValue, string? newValue) =>
        string.IsNullOrEmpty(str) ? str : str!.Replace(oldValue, newValue);
}