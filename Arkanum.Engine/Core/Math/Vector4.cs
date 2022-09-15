using System;
using System.Runtime.CompilerServices;

namespace Arkanum.Engine.Core.Math;


public struct Vector4 : IEquatable<Vector4>, IFormattable
{
    #region Fields
    
    public float X;
    public float Y;
    public float Z;
    public float W;
    
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
                case 2:
                    return Z;
                case 3:
                    return W;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Indices for Vector4 run from 0 to 3, inclusive.");
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
                case 2:
                    Z = value;
                    break;
                case 3:
                    W = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Indices for Vector4 run from 0 to 3, inclusive.");
            }
        }
    }

    #endregion
    public Vector4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public Vector4(Vector3 v, float w)
    {
        X = v.X;
        Y = v.Y;
        Z = v.Z;
        W = w;
    }
    
    public static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);
    public static readonly Vector4 One = new Vector4(1, 1, 1, 1);
    
    public float Length
    {
        get { return (float)System.Math.Sqrt(X * X + Y * Y + Z * Z + W * W); }
    }
    
    public float LengthSquared
    {
        get { return X * X + Y * Y + Z * Z + W * W; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector4 Normalize()
    {
        float length = Length;
        if (length != 0)
        {
            X /= length;
            Y /= length;
            Z /= length;
            W /= length;
        }
        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 Normalize(Vector4 v)
    {
        Vector4 result = v;
        result.Normalize();
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 operator+(Vector4 v1, Vector4 v2)
    {
        return new Vector4(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z, v1.W + v2.W);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 operator-(Vector4 v1, Vector4 v2)
    {
        return new Vector4(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z, v1.W - v2.W);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 operator-(Vector4 v)
    {
        return new Vector4(-v.X, -v.Y, -v.Z, -v.W);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 operator*(Vector4 v, float s)
    {
        return new Vector4(v.X * s, v.Y * s, v.Z * s, v.W * s);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 operator*(float s, Vector4 v)
    {
        return new Vector4(v.X * s, v.Y * s, v.Z * s, v.W * s);
    }

    #region InheritedMethodsAndOverrides

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj)
    {
        return obj is Vector4 vector4 && Equals(vector4);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Vector4 other)
    {
        return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        // ToString vector4
        return $"({X.ToString(format, formatProvider)}, {Y.ToString(format, formatProvider)}, {Z.ToString(format, formatProvider)}, {W.ToString(format, formatProvider)})";
    }
    

    #endregion
}