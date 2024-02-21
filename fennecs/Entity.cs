// SPDX-License-Identifier: MIT

using System.Runtime.InteropServices;

namespace fennecs;

/// <summary>
/// Refers to an identity:
/// real entity, tracked object, or virtual concept (e.g. any/none wildcard).
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public readonly struct Entity : IEquatable<Entity>, IComparable<Entity>
{
    [FieldOffset(0)] internal readonly ulong Value;

    //Identity Components
    [FieldOffset(0)] public readonly int Id;
    [FieldOffset(4)] public readonly ushort Generation;
    [FieldOffset(4)] public readonly TypeID Decoration;

    //Type header (only used in TypeExpression, so must be 0 here) 
    [FieldOffset(6)] internal readonly TypeID RESERVED = 0;

    //Constituents for GetHashCode()
    [FieldOffset(0)] internal readonly uint DWordLow;
    [FieldOffset(4)] internal readonly uint DWordHigh;
    
    public static readonly Entity None = default; // == 0-bit == new(0,0)
    public static readonly Entity Any = new(-1, TypeID.MaxValue);
    
    // Entity Reference.
    public bool IsReal => Id > 0 && Generation > 0;

    // Tracked Object Reference.
    public bool IsObject => Decoration < 0;

    // Special Entities, such as None, Any.
    public bool IsVirtual => Decoration >= 0 && Id <= 0;

    #region  IComparable/IEquatable Implementation
    
    public static bool operator ==(Entity left, Entity right) => left.Equals(right);
    public static bool operator !=(Entity left, Entity right) => !left.Equals(right);

    public bool Equals(Entity other) => Value == other.Value;

    public int CompareTo(Entity other) => Value.CompareTo(other.Value);
    
    
    public override bool Equals(object? obj)
    {
      throw new InvalidCastException("Entity: Boxing equality comparisons disallowed. Use IEquatable<Entity>.Equals(Entity other) instead.");
      //return obj is Entity other && Equals(other); //<-- second best option   
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            return (int) (0x811C9DC5u * DWordLow + 0x1000193u * DWordHigh + 0xc4ceb9fe1a85ec53u);
        }
    }
    
    #endregion


    public Type Type => Decoration switch
    {
        // Decoration is Type Id
        <= 0 => LanguageType.Resolve(Math.Abs(Decoration)),
        // Decoration is Generation
        _ => typeof(Entity),
    };
    
    #region Constructors / Creators
    
    public static Entity Of<T>(T item) where T : class => new(item.GetHashCode(), LanguageType<T>.TargetId);


    internal Entity(int id, TypeID decoration = 1) : this((uint) id | (ulong) decoration << 32)
    {
    }


    public Entity(ulong value)
    {
        Value = value;
    }

    internal Entity Successor
    {
        get
        {
            if (!IsReal) throw new InvalidCastException("Cannot reuse virtual Identities");

            var generationWrappedStartingAtOne = (TypeID) (Generation % (TypeID.MaxValue - 1) + 1);
            return new Entity(Id, generationWrappedStartingAtOne);
        }
    }
    
    #endregion

    public override string ToString()
    {
        if (Equals(None))
            return "\u25c7None";

        if (Equals(Any))
            return "\u25c6Any";

        if (IsObject)
            return $"\u25c8{Type}#{Id:X8}";

        return $"\u2756{Id:x8}:{Generation:D5}";
    }
}