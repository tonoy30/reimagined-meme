using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using RecapApi.Utils;

namespace RecapApi.ValueGenerators;

public class IdentityValueGenerator : ValueGenerator<string>
{
    private readonly string _prefix;
    private readonly int _size;

    public IdentityValueGenerator(string prefix, int size)
    {
        _prefix = prefix;
        _size = size;
    }

    public override bool GeneratesTemporaryValues => false;

    public override string Next(EntityEntry entry)
    {
        return RandomIdGenerator.Generate(_prefix, _size);
    }
}