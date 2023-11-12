namespace RecapApi.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class IdentityAttribute : Attribute
{
    public string Prefix { get; set; }
    public int Size { get; set; } = 14;

    public IdentityAttribute(string prefix)
    {
        Prefix = prefix;
    }

    public IdentityAttribute(string prefix, int size)
    {
        Prefix = prefix;
        Size = size;
    }
}