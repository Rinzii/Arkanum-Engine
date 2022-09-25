using System.Runtime.CompilerServices;

namespace Arkanum.Core.Math;

public struct Vector2i : IEquatable<Vector2i>, IFormattable
{
    #region Fields

    public int X;
    public int Y;
    
    public int this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            switch (index)
            {
                case 0:
                    return X;
                case 1:
                    return Y;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Indices for Vector2i run from 0 to 1, inclusive.");
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            switch (index)
            {
                case 0:
                    X = value;
                    break;
                case 1:
                    Y = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Indices for Vector2i run from 0 to 1, inclusive.");
            }
        }
    }
    
    #endregion

    #region Constructors
    
    public Vector2i(int x, int y)
    {
        X = x;
        Y = y;
    }

    #endregion

    #region DefaultVectors

    public static Vector2i Zero => new Vector2i(0, 0);
    public static Vector2i One => new Vector2i(1, 1);
    public static Vector2i UnitX => new Vector2i(1, 0);
    public static Vector2i UnitY => new Vector2i(0, 1);

    #endregion
    
    #region Operators
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i operator+(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.X + b.X, a.Y + b.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i operator-(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.X - b.X, a.Y - b.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i operator*(Vector2i a, int b)
    {
        return new Vector2i(a.X * b, a.Y * b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i operator*(int a, Vector2i b)
    {
        return new Vector2i(a * b.X, a * b.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i operator/(Vector2i a, int b)
    {
        return new Vector2i(a.X / b, a.Y / b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i operator/(int a, Vector2i b)
    {
        return new Vector2i(a / b.X, a / b.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i operator-(Vector2i a)
    {
        return new Vector2i(-a.X, -a.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator==(Vector2i a, Vector2i b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator!=(Vector2i a, Vector2i b)
    {
        return a.X != b.X || a.Y != b.Y;
    }

    // TODO: Add support for conversion to Vector3i and Vector4i
    /*
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector2i(Vector3 v)
    {
        return new Vector2i(v.X, v.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector2i(Vector4 v)
    {
        return new Vector2i(v.X, v.Y);
    }
    */
    
    #endregion
    
    #region Static Methods
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i Dot(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.X * b.X, a.Y * b.Y);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i Cross(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.Y * b.X, a.X * b.Y);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i Angle(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.X * b.X, a.Y * b.Y);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i Abs(Vector2i a)
    {
        return new Vector2i(System.Math.Abs(a.X), System.Math.Abs(a.Y));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i Min(Vector2i a, Vector2i b)
    {
        return new Vector2i(System.Math.Min(a.X, b.X), System.Math.Min(a.Y, b.Y));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i Max(Vector2i a, Vector2i b)
    {
        return new Vector2i(System.Math.Max(a.X, b.X), System.Math.Max(a.Y, b.Y));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2i Clamp(Vector2i a, Vector2i min, Vector2i max)
    {
        return new Vector2i(System.Math.Clamp(a.X, min.X, max.X), System.Math.Clamp(a.Y, min.Y, max.Y));
    }

    #endregion
    
    #region Methods
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Magnitude()
    {
        return (int)System.Math.Sqrt(X * X + Y * Y);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Normalize()
    {
        int magnitude = Magnitude();
        X /= magnitude;
        Y /= magnitude;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector2i Normalized()
    {
        var v = new Vector2i(X, Y);
        v.Normalize();
        return v;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Dot(Vector2i v)
    {
        return X * v.X + Y * v.Y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Cross(Vector2i v)
    {
        return X * v.Y - Y * v.X;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Angle(Vector2i v)
    {
        return (int)System.Math.Acos(Dot(v) / (Magnitude() * v.Magnitude()));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Distance(Vector2i v)
    {
        return (this - v).Magnitude();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int DistanceSquared(Vector2i v)
    {
        return (this - v).Dot(this - v);
    }

    #endregion

    #region InheritedMethodsAndOverrides

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return X.GetHashCode() ^ (Y.GetHashCode() << 2);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        return obj is Vector2i other && Equals(other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Vector2i other)
    {
        throw new NotImplementedException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return $"({X.ToString(format, formatProvider)}, {Y.ToString(format, formatProvider)})";
    }
    
    #endregion
}