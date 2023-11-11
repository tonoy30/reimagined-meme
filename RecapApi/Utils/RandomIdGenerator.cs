using NanoidDotNet;

namespace RecapApi.Utils;

public static class RandomIdGenerator
{
    private const string DefaultAlphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Generate(string prefix, int size = 14)
    {
        return $"{prefix}_{Nanoid.Generate(alphabet: DefaultAlphabet, size: size)}";
    }
}