using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Arkanum.Core.Math;

[StructLayout(LayoutKind.Sequential)]
public struct Quaternion : IEquatable<Quaternion>, IFormattable
{

    #region Fields

    public float X; // X field of a Quaternion. Don't use directly.
    public float Y; // Y field of a Quaternion. Don't use directly.
    public float Z; // Z field of a Quaternion. Don't use directly.
    public float W; // W field of a Quaternion. Don't use directly.

    public float this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            switch (index)
            {
                case 0: return X;
                case 1: return Y;
                case 2: return Z;
                case 3: return W;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index),
                        "Indices for Quaternion run from 0 to 3, inclusive.");
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
                    throw new ArgumentOutOfRangeException(nameof(index),
                        "Indices for Quaternion run from 0 to 3, inclusive.");
            }
        }
    }

    #endregion

    #region Constructors

    public Quaternion(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    #endregion


    public static Quaternion Identity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    } = new(0, 0, 0, 1);
    
    #region Operators
    // This helped a lot: https://en.wikipedia.org/wiki/Quaternion

    // Combines rotations l and r.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Quaternion operator*(Quaternion l, Quaternion r)
    {
        return new Quaternion(
            l.W * r.X + l.X * r.W + l.Y * r.Z - l.Z * r.Y,
            l.W * r.Y + l.Y * r.W + l.Z * r.X - l.X * r.Z,
            l.W * r.Z + l.Z * r.W + l.X * r.Y - l.Y * r.X,
            l.W * r.W - l.X * r.X - l.Y * r.Y - l.Z * r.Z);
    }

    // Rotates the point /point/ with /rotation/.
    public static Vector3 operator*(Quaternion rotation, Vector3 point)
    {
        var x = rotation.X * 2F;
        var y = rotation.Y * 2F;
        var z = rotation.Z * 2F;
        var xx = rotation.X * x;
        var yy = rotation.Y * y;
        var zz = rotation.Z * z;
        var xy = rotation.X * y;
        var xz = rotation.X * z;
        var yz = rotation.Y * z;
        var wx = rotation.W * x;
        var wy = rotation.W * y;
        var wz = rotation.W * z;

        Vector3 res = default;
        res.X = (1F - (yy + zz)) * point.X + (xy - wz) * point.Y + (xz + wy) * point.Z;
        res.Y = (xy + wz) * point.X + (1F - (xx + zz)) * point.Y + (yz - wx) * point.Z;
        res.Z = (xz - wy) * point.X + (yz + wx) * point.Y + (1F - (xx + yy)) * point.Z;
        return res;
    }
    
    public const float Epsilon = 1e-6F;
    
    private static bool IsEqualUsingDot(float dot)
    {
        // This is a more stable version of (1f - dot * dot < Epsilon * Epsilon)
        // which avoids a square root.
        return dot >= 1f - Epsilon * Epsilon;
    }
    
    public static bool operator==(Quaternion left, Quaternion right)
    {
        return IsEqualUsingDot(Dot(left, right));
    }
    
    public static bool operator!=(Quaternion left, Quaternion right)
    {
        return !left.Equals(right);
    }

    #endregion
    
    #region Methods
    
    public static float Dot(Quaternion left, Quaternion right)
    {
        return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
    }
    
    
    
    #endregion

    
    #region OverridesAndInterfaces
    public override bool Equals(object? obj)
    {
        return obj is Quaternion other && Equals(other);
    }
    public bool Equals(Quaternion other)
    {
        return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        return string.Format(formatProvider, "({0}, {1}, {2}, {3})", X.ToString(format, formatProvider),
            Y.ToString(format, formatProvider), Z.ToString(format, formatProvider), W.ToString(format, formatProvider));
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W);
    }



    #endregion
}