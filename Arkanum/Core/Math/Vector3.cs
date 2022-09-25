using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Arkanum.Core.Math;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Vector3 : IEquatable<Vector3>, IFormattable
{
    #region Default Vector Initializers

    /// <summary>Returns a vector of (0, 0, 0)</summary>
    public static readonly Vector3 Zero = new Vector3(0F, 0F, 0F);
    
    /// <summary>Returns a vector of (1, 1, 1)</summary>
    public static readonly Vector3 One = new Vector3(1F, 1F, 1F);
    
    /// <summary>Returns a vector of (1, 0, 0) on the X-axis</summary>
    public static readonly Vector3 UnitX = new Vector3(1F, 0F, 0F);
    
    /// <summary>Returns a vector of (0, 1, 0) on the Y-axis</summary>
    public static readonly Vector3 UnitY = new Vector3(0F, 1F, 0F);
    
    /// <summary>Returns a vector of (0, 0, 1) on the Z-axis</summary>
    public static readonly Vector3 UnitZ = new Vector3(0F, 0F, 1F);
    
    /// <summary>Returns a vector of (0, 0, 1)</summary>
    public static readonly Vector3 Forward = new Vector3(0F, 0F, 1F);
    
    /// <summary>Returns a vector of (0, 0, -1)</summary>
    public static readonly Vector3 Back = new Vector3(0F, 0F, -1F);
    
    /// <summary>Returns a vector of (0, 1, 0)</summary>
    public static readonly Vector3 Up = new Vector3(0F, 1F, 0F);
    
    /// <summary>Returns a vector of (0, -1, 0)</summary>
    public static readonly Vector3 Down = new Vector3(0F, -1F, 0F);
    
    /// <summary>Returns a vector of (1, 0, 0)</summary>
    public static readonly Vector3 Right = new Vector3(1F, 0F, 0F);
    
    /// <summary>Returns a vector of (-1, 0, 0)</summary>
    public static readonly Vector3 Left = new Vector3(-1F, 0F, 0F);

    /// <summary>Shorthand for writing Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity)</summary>
    public static readonly Vector3 PositiveInfinity = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
    
    /// <summary>Shorthand for writing Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity)</summary>
    public static readonly Vector3 NegativeInfinity = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
    

    // Access the x, y, and z fields using [0], [1], and [2] respectively.
    public float this[int index]
    {
        get
        {
            return index switch
            {
                0 => X,
                1 => Y,
                2 => Z,
                _ => throw new ArgumentOutOfRangeException(
                    nameof(index),  
                    "Indices for Vector3 run from 0 to 2, inclusive.")
            };
        }
        set
        {
            switch (index)
            {
                case 0: X = value; break;
                case 1: Y = value; break;
                case 2: Z = value; break;
                default: throw new ArgumentOutOfRangeException(
                    nameof(index), 
                    "Indices for Vector3 run from 0 to 2, inclusive.");
            }
        }
    }
    
    #endregion
    
    #region Fields & Variables
    
    /// <summary>The size of the Vector3 struct in bytes.</summary>
    static readonly int SizeInBytes = Unsafe.SizeOf<Vector3>();
    /// <summary>An epsilon value for floating point comparisons using MathF.Epsilon to produce the value 1.4E-45f</summary>
    static readonly float Epsilon = MathF.Epsilon;
    
    /// <summary>The X component of a vector.</summary>
    public float X { get; set; }
    
    /// <summary>The Y component of a vector.</summary>
    public float Y { get; set; }
    
    /// <summary>The Z component of a vector.</summary>
    public float Z { get; set; }
    
    #endregion
    
    #region Constructors
    
    /// <summary>
    /// Default constructor. Creates a vector of (0, 0, 0) should generally be avoided as it is not explicit.
    /// </summary>
    public Vector3()
    {
        X = 0f;
        Y = 0f;
        Z = 0f;
    }
    
    /// <summary>
    /// Constructors a vector with the given component.
    /// </summary>
    /// <param name="value"></param>
    public Vector3(float value)
    {
        X = value;
        Y = value;
        Z = value;
    }
    
    /// <summary>
    /// Constructs a new vector with the given components.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    /// <summary>
    /// Constructs a new vector with the given components.
    /// </summary>
    /// <param name="values"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Vector3(float[] values)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));
        if (values.Length != 3)
            throw new ArgumentOutOfRangeException(nameof(values), "Vector3 requires exactly 3 input values to initialize.");
        
        X = values[0];
        Y = values[1];
        Z = values[2];
    }
    
    /// <summary>
    /// Constructs a new vector with the given components.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="z"></param>
    public Vector3(Vector2 value, float z)
    {
        X = value.X;
        Y = value.Y;
        Z = z;
    }

    #endregion
    
    #region Methods
    
    /// <summary>
    /// Gets the absolute value of a the current vector.
    /// </summary>
    /// <returns>The absolute value.</returns>
    public Vector3 GetAbs() => new (MathF.Abs(X), MathF.Abs(Y), MathF.Abs(Z));
    
    /// <summary>
    /// Raises the vector to the given power.
    /// </summary>
    /// <param name="power"></param>
    public void Pow(float power)
    {
        X = MathF.Pow(X, power);
        Y = MathF.Pow(Y, power);
        Z = MathF.Pow(Z, power);
    }
    
    /// <summary>
    /// Calculates the length of the vector.
    /// </summary>
    /// <returns></returns>
    public readonly float Length() => MathF.Sqrt((X * X) + (Y * Y) + (Z * Z));
    
    /// <summary>
    /// Calculates the squared length of this vector.
    /// </summary>
    /// <returns></returns>
    public readonly float LengthSquared() => (X * X) + (Y * Y) + (Z * Z);
    
    /// <summary>
    /// Normalizes the vector by converting it to a unit vector.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Normalize()
    {
        var length = Length();
        if (length > MathF.Epsilon)
        {
            var inv = 1.0f / length;
            X *= inv;
            Y *= inv;
            Z *= inv;
        }
    }
    
    /// <summary>
    /// Converts the vector to an array.
    /// </summary>
    /// <returns>An array of the Vector.</returns>
    public float[] ToArray() => new[] {X, Y, Z};
    
    #endregion

    #region Static Methods for Reference Types
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref Vector3 left, ref Vector3 right, out Vector3 result)
    {
        result = new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Subtract(ref Vector3 left, ref Vector3 right, out Vector3 result)
    {
        result = new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref Vector3 left, ref Vector3 right, out Vector3 result)
    {
        result = new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref Vector3 left, ref Vector3 right, out Vector3 result)
    {
        result = new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Mod(ref Vector3 left, ref Vector3 right, out Vector3 result)
    {
        result = new Vector3(
            MathF.Mod(left.X, right.X), 
            MathF.Mod(left.Y, right.Y), 
            MathF.Mod(left.Z, right.Z));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Negate(ref Vector3 value, out Vector3 result)
    {
        result = new Vector3(-value.X, -value.Y, -value.Z);
    }
    
    /// <summary>
    /// Outputs the minimum of the two referenced vectors.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Min(ref Vector3 left, ref Vector3 right, out Vector3 result)
    {
        result = default;
        result.X = MathF.Min(left.X, right.X);
        result.Y = MathF.Min(left.Y, right.Y);
        result.Z = MathF.Min(left.Z, right.Z);
    }
    
    /// <summary>
    /// Outputs the maximum of the two referenced vectors.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Max(ref Vector3 left, ref Vector3 right, out Vector3 result)
    {
        result = default;
        result.X = MathF.Max(left.X, right.X);
        result.Y = MathF.Max(left.Y, right.Y);
        result.Z = MathF.Max(left.Z, right.Z);
    }
    
    public static void Abs(ref Vector3 value, out Vector3 result)
    {
        result = new Vector3(MathF.Abs(value.X), MathF.Abs(value.Y), MathF.Abs(value.Z));
    }

    public static void Pow(ref Vector3 value, float power, out Vector3 result)
    {
        result = new Vector3(
            MathF.Pow(value.X, power), 
            MathF.Pow(value.Y, power), 
            MathF.Pow(value.Z, power));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Dot(ref Vector3 left, ref Vector3 right, out float result)
    {
        result = (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z);
    }
    
    public static void Cross(ref Vector3 left, ref Vector3 right, out Vector3 result)
    {
        result = new Vector3(
            (left.Y * right.Z) - (left.Z * right.Y),
            (left.Z * right.X) - (left.X * right.Z),
            (left.X * right.Y) - (left.Y * right.X));
    }
    
    public static void Distance(ref Vector3 left, ref Vector3 right, out float result)
    {
        result = MathF.Sqrt(
            ((left.X - right.X) * (left.X - right.X)) +
            ((left.Y - right.Y) * (left.Y - right.Y)) +
            ((left.Z - right.Z) * (left.Z - right.Z)));
    }
    
    public static void DistanceSquared(ref Vector3 left, ref Vector3 right, out float result)
    {
        result = ((left.X - right.X) * (left.X - right.X)) +
                 ((left.Y - right.Y) * (left.Y - right.Y)) +
                 ((left.Z - right.Z) * (left.Z - right.Z));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Magnitude(ref Vector3 value, out float result)
    {
        result = MathF.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z));
    }
    
    public static void MagnitudeSquared(ref Vector3 value, out float result)
    {
        result = (value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Normalize(ref Vector3 value, out Vector3 result)
    {
        var length = value.Length();
        if (length > MathF.Epsilon)
        {
            var inv = 1.0f / length;
            result = new Vector3(value.X * inv, value.Y * inv, value.Z * inv);
        }
        else
        {
            result = default;
        }
    }
    
    public static void Clamp(ref Vector3 value, ref Vector3 min, ref Vector3 max, out Vector3 result)
    {
        result = default;
        result.X = MathF.Clamp(value.X, min.X, max.X);
        result.Y = MathF.Clamp(value.Y, min.Y, max.Y);
        result.Z = MathF.Clamp(value.Z, min.Z, max.Z);
    }
    
    public static void Clamp01(ref Vector3 value, out Vector3 result)
    {
        result = default;
        result.X = MathF.Clamp(value.X, 0, 1);
        result.Y = MathF.Clamp(value.Y, 0, 1);
        result.Z = MathF.Clamp(value.Z, 0, 1);
    }
    
    public static void Lerp(ref Vector3 left, ref Vector3 right, float amount, out Vector3 result)
    {
        result = default;
        result.X = MathF.Lerp(left.X, right.X, amount);
        result.Y = MathF.Lerp(left.Y, right.Y, amount);
        result.Z = MathF.Lerp(left.Z, right.Z, amount);
    }
    
    public static void SmoothStep(ref Vector3 left, ref Vector3 right, float amount, out Vector3 result)
    {
        result = default;
        result.X = MathF.SmoothStep(left.X, right.X, amount);
        result.Y = MathF.SmoothStep(left.Y, right.Y, amount);
        result.Z = MathF.SmoothStep(left.Z, right.Z, amount);
    }
    
    public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
    {
        var dot = Dot(vector, normal);
        result = new Vector3(
            vector.X - 2.0f * dot * normal.X,
            vector.Y - 2.0f * dot * normal.Y,
            vector.Z - 2.0f * dot * normal.Z);
    }
    
    public static void Refract(ref Vector3 vector, ref Vector3 normal, float refractionIndex, out Vector3 result)
    {
        var dot = Dot(vector, normal);
        var k = 1.0f - refractionIndex * refractionIndex * (1.0f - dot * dot);
        if (k < 0.0f)
        {
            result = default;
        }
        else
        {
            result = new Vector3(
                refractionIndex * vector.X - (refractionIndex * dot + MathF.Sqrt(k)) * normal.X,
                refractionIndex * vector.Y - (refractionIndex * dot + MathF.Sqrt(k)) * normal.Y,
                refractionIndex * vector.Z - (refractionIndex * dot + MathF.Sqrt(k)) * normal.Z);
        }
    }

    // Vector3 transform outputs
    
    
    public static void Transform(ref Vector3 position, ref Matrix4 matrix, out Vector3 result)
    {
        result = new Vector3(
            position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41,
            position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42,
            position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43);
    }
    
    public static void Transform(ref Vector3 position, ref Quaternion rotation, out Vector3 result)
    {
        var x = 2.0f * rotation.Y * position.Z - 2.0f * rotation.Z * position.Y;
        var y = 2.0f * rotation.Z * position.X - 2.0f * rotation.X * position.Z;
        var z = 2.0f * rotation.X * position.Y - 2.0f * rotation.Y * position.X;
        result = new Vector3(
            position.X + rotation.W * x + rotation.Y * z - rotation.Z * y,
            position.Y + rotation.W * y + rotation.Z * x - rotation.X * z,
            position.Z + rotation.W * z + rotation.X * y - rotation.Y * x);
    }
    
    public static void Transform(ref Vector3 position, ref Quaternion rotation, ref Vector3 scale, out Vector3 result)
    {
        var x = 2.0f * rotation.Y * position.Z - 2.0f * rotation.Z * position.Y;
        var y = 2.0f * rotation.Z * position.X - 2.0f * rotation.X * position.Z;
        var z = 2.0f * rotation.X * position.Y - 2.0f * rotation.Y * position.X;
        result = new Vector3(
            (position.X + rotation.W * x + rotation.Y * z - rotation.Z * y) * scale.X,
            (position.Y + rotation.W * y + rotation.Z * x - rotation.X * z) * scale.Y,
            (position.Z + rotation.W * z + rotation.X * y - rotation.Y * x) * scale.Z);
    }
    
    // Vector4 transform outputs
    
    
    public static void Transform(ref Vector3 value, ref Matrix4 matrix, out Vector4 result)
    {
        result = new Vector4(
            value.X * matrix.M11 + value.Y * matrix.M21 + value.Z * matrix.M31 + matrix.M41,
            value.X * matrix.M12 + value.Y * matrix.M22 + value.Z * matrix.M32 + matrix.M42,
            value.X * matrix.M13 + value.Y * matrix.M23 + value.Z * matrix.M33 + matrix.M43,
            value.X * matrix.M14 + value.Y * matrix.M24 + value.Z * matrix.M34 + matrix.M44);
    }
    
    public static void Transform(ref Vector3 value, ref Quaternion rotation, out Vector4 result)
    {
        var x = 2.0f * rotation.Y * value.Z - 2.0f * rotation.Z * value.Y;
        var y = 2.0f * rotation.Z * value.X - 2.0f * rotation.X * value.Z;
        var z = 2.0f * rotation.X * value.Y - 2.0f * rotation.Y * value.X;
        result = new Vector4(
            value.X + rotation.W * x + rotation.Y * z - rotation.Z * y,
            value.Y + rotation.W * y + rotation.Z * x - rotation.X * z,
            value.Z + rotation.W * z + rotation.X * y - rotation.Y * x,
            1.0f);
    }
    
    public static void Transform(ref Vector3 value, ref Quaternion rotation, ref Vector3 scale, out Vector4 result)
    {
        var x = 2.0f * rotation.Y * value.Z - 2.0f * rotation.Z * value.Y;
        var y = 2.0f * rotation.Z * value.X - 2.0f * rotation.X * value.Z;
        var z = 2.0f * rotation.X * value.Y - 2.0f * rotation.Y * value.X;
        result = new Vector4(
            (value.X + rotation.W * x + rotation.Y * z - rotation.Z * y) * scale.X,
            (value.Y + rotation.W * y + rotation.Z * x - rotation.X * z) * scale.Y,
            (value.Z + rotation.W * z + rotation.X * y - rotation.Y * x) * scale.Z,
            1.0f);
    }
    
    public static void Project(ref Vector3 vector, ref Vector3 onNormal, out Vector3 result)
    {
        var dot = Dot(vector, onNormal);
        result = new Vector3(
            onNormal.X * dot,
            onNormal.Y * dot,
            onNormal.Z * dot);
    }
    
    #endregion
    
    #region Static Methods
    
    /// <summary>
    /// Returns the minimum of two vectors.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Vector3 Min(Vector3 left, Vector3 right) => new (MathF.Min(left.X, right.X), MathF.Min(left.Y, right.Y), MathF.Min(left.Z, right.Z));
    
    /// <summary>
    /// Returns the maximum of the two vectors.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Vector3 Max(Vector3 left, Vector3 right) => new (MathF.Max(left.X, right.X), MathF.Max(left.Y, right.Y), MathF.Max(left.Z, right.Z));
    
    /// <summary>
    /// Gets the absolute value of a vector.
    /// </summary>
    /// <param name="value">Vector to perform the abs on.</param>
    /// <returns>The absolute value.</returns>
    public static Vector3 Abs(Vector3 value) => new (MathF.Abs(value.X), MathF.Abs(value.Y), MathF.Abs(value.Z));
    
    /// <summary>
    /// Moves the current point in a straight line towards a target point.
    /// </summary>
    /// <param name="current"></param>
    /// <param name="target"></param>
    /// <param name="maxDistanceDelta"></param>
    /// <returns></returns>
    public static Vector3 MoveTowards(in Vector3 current, in Vector3 target, float maxDistanceDelta)
    {
        var toVector = target - current;
        var distance = toVector.Length();
        if (distance <= maxDistanceDelta || distance < Epsilon)
            return target;
        return current + (toVector / distance) * maxDistanceDelta;
    }
    
    /// <summary>
    /// Linearly interpolates between two vectors.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector3 Lerp(Vector3 left, Vector3 right, float amount)
    {
        return new Vector3(
            MathF.Lerp(left.X, right.X, amount),
            MathF.Lerp(left.Y, right.Y, amount),
            MathF.Lerp(left.Z, right.Z, amount));
    }
    
    /// <summary>
    /// Linearly interpolates between two vectors unclamped.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector3 LerpUnclamped(Vector3 left, Vector3 right, float amount)
    {
        return new Vector3(
            MathF.LerpUnclamped(left.X, right.X, amount),
            MathF.LerpUnclamped(left.Y, right.Y, amount),
            MathF.LerpUnclamped(left.Z, right.Z, amount));
    }
    
    /// <summary>
    /// Calculate the reflection vector of the given vector and normal.
    /// </summary>
    /// <param name="inDirection"></param>
    /// <param name="inNormal"></param>
    /// <returns></returns>
    public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal) 
        => -2.0f * Dot(inNormal, inDirection) * inNormal + inDirection;

    /// <summary>
    /// Calculates the normalized vector of the given vector.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
        public static Vector3 Normalize(Vector3 value)
    {
        var length = value.Length();
        if (length > Epsilon)
        {
            var inv = 1.0f / length;
            return new Vector3(value.X * inv, value.Y * inv, value.Z * inv);
        }
        return Zero;
    }
    
    /// <summary>
    /// Calculate the Dot product of two vectors.
    /// </summary>
    /// <param name="a">First Vector</param>
    /// <param name="b">Second Vector</param>
    /// <returns>The dot product</returns>
    public static float Dot(Vector3 a, Vector3 b) => (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
    
    /// <summary>
    /// Calculate the cross product of two vectors.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Vector3 Cross(Vector3 left, Vector3 right)
    {
        return new Vector3(
            (left.Y * right.Z) - (left.Z * right.Y),
            (left.Z * right.X) - (left.X * right.Z),
            (left.X * right.Y) - (left.Y * right.X));
    }

    /// <summary>
    /// Calculate the distance between two vectors.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float Distance(Vector3 a, Vector3 b) => (a - b).Length();
    
    /// <summary>
    /// Calculate the magnitude of a vector.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static float Magnitude(Vector3 a) => MathF.Sqrt(Dot(a, a));
    
    #endregion

    #region Operators

    /// <summary>
    /// Add two vectors together.
    /// </summary>
    /// <param name="a">First vector to add.</param>
    /// <param name="b">Second vector to add.</param>
    /// <returns>The Sum of two vectors.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 operator+(Vector3 a, Vector3 b) => new (a.X + b.X, a.Y + b.Y, a.Z + b.Z);

    /// <summary>
    /// Add a vector and a scalar together.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 operator+(Vector3 value) => value;

    /// <summary>
    /// Subtract one vector from another vector.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>The difference of two vectors.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 operator-(Vector3 a, Vector3 b) => new (a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    
    /// <summary>
    /// Negate a vector.
    /// </summary>
    /// <param name="a"></param>
    /// <returns>A negated vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 operator-(Vector3 a) => new (-a.X, -a.Y, -a.Z);
    
    /// <summary>
    /// Multiplies a vector by a scalar.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 operator*(Vector3 a, float d) => new (a.X * d, a.Y * d, a.Z * d);
    
    /// <summary>
    /// Multiplies a vector by a scalar.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 operator*(float d, Vector3 a) => new (a.X * d, a.Y * d, a.Z * d);
    
    /// <summary>
    /// Multiplies a vector by another vector.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)] // TODO: Pay attention to this operator, not sure if it will work how I want it to.
    public static Vector3 operator*(Vector3 a, Vector3 b) => new (a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    
    /// <summary>
    /// Divides a vector by a scalar.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 operator/(Vector3 a, float d) => new (a.X / d, a.Y / d, a.Z / d);

    // TODO: Adjust this to be more accurate. By taking advantaged of a mixture of a default tolerance and a user defined tolerance.
    /// <summary>
    /// Compare two vectors for equality and if they are equal to a specified tolerance, return true.
    /// </summary>
    /// <param name="l">Left vector to compare.</param>
    /// <param name="r">Right vector to compare.</param>
    /// <returns>Returns a boolean.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator==(Vector3 l, Vector3 r)
    {
        // Returns false in the event of a NaN values
        float diffX = l.X - r.X;
        float diffY = l.Y - r.Y;
        float diffZ = l.Z - r.Z;
        float sqrtMag = diffX * diffX + diffY * diffY + diffZ * diffZ;
        return sqrtMag < Epsilon * Epsilon; // TODO: Pay attention to this, could have problems.
    }

    /// <summary>
    /// Compare two vectors for inequality and if they are not equal to a specified tolerance, return true.
    /// </summary>
    /// <param name="l">Left vector to compare.</param>
    /// <param name="r">Right vector to compare.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator!=(Vector3 l, Vector3 r)
    {
        // Returns true in the event of a NaN values.
        return !(l == r);
    }
    
    #endregion

    #region Inherited Methods And Overrides
    
    /// <summary>
    /// Allow a vector to be represented in a hashtable.
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => X.GetHashCode() ^ (Y.GetHashCode() << 2) ^ (Z.GetHashCode() >> 2);

    /// <summary>
    /// Compare a object to a vector and if they are equal, return true.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj) => obj is Vector3 other && Equals(other);

    // TODO: Add a Equals method that takes a tolerance.
    /// <summary>
    /// Compare a vector to another vector and if they are equal, return true.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Vector3 other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }
    
    /// <summary>
    /// Allow a vector to be represented as a string.
    /// </summary>
    /// <param name="format"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ToString(string format, IFormatProvider formatProvider) 
        => $"({X.ToString(format, formatProvider)}, {Y.ToString(format, formatProvider)}, {Z.ToString(format, formatProvider)})";

    #endregion
}