using System;
using System.Runtime.CompilerServices;

namespace Arkanum.Engine.Core.Math;

public struct Vector2 : IEquatable<Vector2>, IFormattable
{

    #region Fields

    public float X;
    public float Y;
    
    public float this[int index]
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
                    throw new ArgumentOutOfRangeException(nameof(index), "Indices for Vector2 run from 0 to 1, inclusive.");
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
                    throw new ArgumentOutOfRangeException(nameof(index), "Indices for Vector2 run from 0 to 1, inclusive.");
            }
        }
    }
    
    #endregion

    #region Constructors
    
    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    #endregion

    #region DefaultVectors

    public static Vector2 Zero => new Vector2(0, 0);
    public static Vector2 One => new Vector2(1, 1);
    public static Vector2 UnitX => new Vector2(1, 0);
    public static Vector2 UnitY => new Vector2(0, 1);

    #endregion
    
    #region Operators
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 operator+(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X + b.X, a.Y + b.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 operator-(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X - b.X, a.Y - b.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 operator*(Vector2 a, float b)
    {
        return new Vector2(a.X * b, a.Y * b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 operator*(float a, Vector2 b)
    {
        return new Vector2(a * b.X, a * b.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 operator/(Vector2 a, float b)
    {
        return new Vector2(a.X / b, a.Y / b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 operator/(float a, Vector2 b)
    {
        return new Vector2(a / b.X, a / b.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 operator-(Vector2 a)
    {
        return new Vector2(-a.X, -a.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator==(Vector2 a, Vector2 b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator!=(Vector2 a, Vector2 b)
    {
        return a.X != b.X || a.Y != b.Y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector2(Vector3 v)
    {
        return new Vector2(v.X, v.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector2(Vector4 v)
    {
        return new Vector2(v.X, v.Y);
    }
    
    #endregion
    
    #region Static Methods
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Dot(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X * b.X, a.Y * b.Y);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Cross(Vector2 a, Vector2 b)
    {
        return new Vector2(a.Y * b.X, a.X * b.Y);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Angle(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X * b.X, a.Y * b.Y);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Abs(Vector2 a)
    {
        return new Vector2(System.Math.Abs(a.X), System.Math.Abs(a.Y));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Min(Vector2 a, Vector2 b)
    {
        return new Vector2(System.Math.Min(a.X, b.X), System.Math.Min(a.Y, b.Y));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Max(Vector2 a, Vector2 b)
    {
        return new Vector2(System.Math.Max(a.X, b.X), System.Math.Max(a.Y, b.Y));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Clamp(Vector2 a, Vector2 min, Vector2 max)
    {
        return new Vector2(System.Math.Clamp(a.X, min.X, max.X), System.Math.Clamp(a.Y, min.Y, max.Y));
    }

    #endregion
    
    #region Methods
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float Magnitude()
    {
        return (float)System.Math.Sqrt(X * X + Y * Y);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Normalize()
    {
        float magnitude = Magnitude();
        X /= magnitude;
        Y /= magnitude;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector2 Normalized()
    {
        var v = new Vector2(X, Y);
        v.Normalize();
        return v;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float Dot(Vector2 v)
    {
        return X * v.X + Y * v.Y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float Cross(Vector2 v)
    {
        return X * v.Y - Y * v.X;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float Angle(Vector2 v)
    {
        return (float)System.Math.Acos(Dot(v) / (Magnitude() * v.Magnitude()));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float Distance(Vector2 v)
    {
        return (this - v).Magnitude();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float DistanceSquared(Vector2 v)
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
        return obj is Vector2 other && Equals(other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Vector2 other)
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

// Add a generic vector2d