using System;
using System.Runtime.CompilerServices;

namespace Arkanum.Engine.Core.Math;

public struct MathF
{
    // Useful constants that may be used elsewhere.
    public const float PI = 3.14159265f; // Copied from System.Math;
    public const float TwoPi = (PI * 2.0f);
    public const float HalfPi = (PI / 2.0f);
    public const float QuarterPi = (PI / 4.0f);
    public const float E = 2.71828183f; // Copied from System.Math;
    public static readonly float Log10E = System.MathF.Log10(E);
    public static readonly float Log2E = System.MathF.Log(E, 2.0f);
    public const float PiOver2 = (PI / 2.0f);
    public const float PiOver4 = (PI / 4.0f);
    public const float Tau = (PI * 2.0f);
    public const float Infinity = float.PositiveInfinity;
    public const float NegativeInfinity = float.NegativeInfinity;
    public const float NaN = float.NaN;
    public const float MinValue = float.MinValue;
    public const float MaxValue = float.MaxValue;
    public const float Epsilon = 1.4e-45f; // A tiny floating point value
    public const float Deg2Rad =  PI * 2.0f / 360.0f;
    public const float Rad2Deg = 1.0f / Deg2Rad;

    // Get the absolute value of a float
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Abs(float value) => System.MathF.Abs(value);

    // Get the square root of a float
    public static float Sqrt(float value) => System.MathF.Sqrt(value);

    // Get the inverse square root of a float
    public static float InvSqrt(float value) => 1.0f / Sqrt(value);

    public static float Sign(float value)
    {
        return value switch
        {
            < 0.0f => -1.0f,
            > 0.0f => 1.0f,
            0.0f => 0.0f,
            _ => throw new ArithmeticException("NaN")
        };
    }
    
    public static float Pow(float f, float p) => System.MathF.Pow(f, p);
    
    public static float Exp(float power) => (float)System.MathF.Exp(power);
    
    public static float Log(float f, float p) => (float)System.MathF.Log(f, p);
    
    public static float Log(float f) => (float)System.MathF.Log(f);
    
    public static float Log10(float f) => (float)System.MathF.Log10(f);
    
    public static float Ceil(float f) => (float)System.MathF.Ceiling(f);
    
    public static float Floor(float f) => (float)System.MathF.Floor(f);
    
    public static float Mod(float x, float m) => x - m * Floor(x / m);
    
    public static float Round(float f) => System.MathF.Round(f);
    
    public static int CeilToInt(float f) => (int)System.MathF.Ceiling(f);
    
    public static int FloorToInt(float f) => (int)System.MathF.Floor(f);
    
    public static int RoundToInt(float f) => (int)System.MathF.Round(f);
    
    public static float Sin(float value) => System.MathF.Sin(value);
    
    public static float Cos(float value) => System.MathF.Cos(value);

    public static float Tan(float value) => System.MathF.Tan(value);

    public static float Asin(float value) => System.MathF.Asin(value);

    public static float Acos(float value) => System.MathF.Acos(value);

    public static float Atan(float value) => System.MathF.Atan(value);

    public static float Atan2(float y, float x) => System.MathF.Atan2(y, x);
    
    // Get the minimum of two floats
    public static float Min(float a, float b) => a < b ? a : b;
    
    // Returns the smallest of two or more values.
    public static float Min(params float[] values)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));
        if (values.Length == 0)
            throw new ArgumentException("values");
        var num = values[0];
        for (var i = 1; i < values.Length; ++i)
        {
            if (values[i] < num)
                num = values[i];
        }

        return num;
    }
    
    // Get the minimum of two ints
    public static int Min(int a, int b) => a < b ? a : b;
    
    // Returns the smallest of two or more values.
    public static int Min(params int[] values)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));
        if (values.Length == 0)
            throw new ArgumentException("values");
        var num = values[0];
        for (var i = 1; i < values.Length; ++i)
        {
            if (values[i] < num)
                num = values[i];
        }

        return num;
    }
    
    // Get the maximum of two floats
    public static float Max(float a, float b) => a > b ? a : b;
    
    // Returns the largest of two or more floats
    public static float Max(params float[] values)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));
        if (values.Length == 0)
            throw new ArgumentException("values");
        var num = values[0];
        for (var i = 1; i < values.Length; ++i)
        {
            if (values[i] > num)
                num = values[i];
        }

        return num;
    }
    
    // Get the maximum of two ints
    public static int Max(int a, int b) => a > b ? a : b;
    
    // Returns the largest of two or more ints
    public static int Max(params int[] values)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));
        if (values.Length == 0)
            throw new ArgumentException("values");
        var num = values[0];
        for (var i = 1; i < values.Length; ++i)
        {
            if (values[i] > num)
                num = values[i];
        }

        return num;
    }

    // Clamps a value between a minimum float and maximum float value.
    public static float Clamp(float value, float min, float max)
    {
        if (value < min)
            value = min;
        else if (value > max)
            value = max;
        return value;
    }
    
    // Clamps a value between a minimum int and maximum int value.
    public static int Clamp(int value, int min, int max)
    {
        if (value < min)
            value = min;
        else if (value > max)
            value = max;
        return value;
    }
    
    // Clamps value between 0 and 1 and returns value.
    public static float Clamp01(float value)
    {
        if (value < 0.0f)
            return 0.0f;
        return value > 1.0f ? 1.0f : value;
    }
    
    // Linearly interpolates between a and b by t.
    public static float Lerp(float a, float b, float t)
    {
        return a + (b - a) * Clamp01(t);
    }
    
    // Linearly interpolates unclamped between a and b by t.
    public static float LerpUnclamped(float a, float b, float t)
    {
        return a + (b - a) * t;
    }
    
    // Linearly interpolates between a and b by t but makes sure the values interpolate correctly when they wrap around 360 degrees.
    public static float LerpAngle(float a, float b, float t)
    {
        float num = Repeat(b - a, 360.0f);
        if (num > 180.0f)
            num -= 360.0f;
        return a + num * Clamp01(t);
    }
    
    // Calculates the linear parameter between two values.
    public static float InverseLerp(float a, float b, float value)
    {
        return !a.Equals(b) ? Clamp01((value - a) / (b - a)) : 0.0f;
    }
    
    public static float InverseLerp(float a, float b, float value, float epsilon)
    {
        return Abs(b - a) > epsilon ? Clamp01((value - a) / (b - a)) : 0.0f;
    }
    
    // Moves a value current towards target.
    public static float MoveTowards(float current, float target, float maxDelta)
    {
        if (Abs(target - current) <= maxDelta)
            return target;
        return current + Sign(target - current) * maxDelta;
    }
    
    // Moves a value current towards target but makes sure the values interpolate correctly when they wrap around 360 degrees.
    public static float MoveTowardsAngle(float current, float target, float maxDelta)
    {
        var deltaAngle = DeltaAngle(current, target);
        if (-maxDelta < deltaAngle && deltaAngle < maxDelta)
            return target;
        target = current + deltaAngle;
        return MoveTowards(current, target, maxDelta);
    }
    
    // Repeats the value t, so t is never larger than length and never smaller than 0.
    public static float Repeat(float t, float length)
    {
        return t - Floor(t / length) * length;
    }
    
    // PingPongs the value t, so t is never larger than length and never smaller than 0.
    public static float PingPong(float t, float length)
    {
        t = Repeat(t, length * 2.0f);
        return length - Abs(t - length);
    }

    // Calculates the shortest difference between two given angles given in degrees.
    public static float DeltaAngle(float current, float target)
    {
        var num = Repeat(target - current, 360.0f);
        if (num > 180.0f)
            num -= 360.0f;
        return num;
    }
    
    // compare two floats with a given tolerance
    public static bool Approximately(float a, float b)
    {
        return Abs(b - a) < Max(1E-06f * Max(Abs(a), Abs(b)), Epsilon * 8.0f);
    }
    
    // compare two floats with a given tolerance
    public static bool Approximately(float a, float b, float epsilon)
    {
        return Abs(b - a) < Max(1E-06f * Max(Abs(a), Abs(b)), epsilon * 8.0f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static float SmoothStep(float from, float to, float t)
    {
        t = Clamp01(t);
        t = -2.0f * t * t * t + 3.0f * t * t;
        return to * t + from * (1.0f - t);
    }

    public static float Gamma(float value, float absMax, float gamma)
    {
        var negative = value < 0.0f;
        var absValue = Abs(value);
        if (absValue > absMax)
            return negative ? -absValue : absValue;

        var result = Pow(absValue / absMax, gamma) * absMax;
        return negative ? -result : result;
    }

    public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
    {
        smoothTime = Max(0.0001f, smoothTime);
        var omega = 2.0f / smoothTime;
        var x = omega * deltaTime;
        var exponent = 1.0f / (1.0f + x + 0.48f * x * x + 0.235f * x * x * x);
        var change = current - target;
        var ogTarget = target;
        
        // clamp max speed
        var maxChange = maxSpeed * smoothTime;
        change = Clamp(change, -maxChange, maxChange);
        target = current - change;
        
        var temp = (currentVelocity + omega * change) * deltaTime;
        currentVelocity = (currentVelocity - omega * temp) * exponent;
        var output = target + (change + temp) * exponent;
        if (ogTarget - current > 0.0f == output > ogTarget)
        {
            output = ogTarget;
            currentVelocity = (output - ogTarget) / deltaTime;
        }
        return output;
    }

    public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime)
    {
        float deltaTime = Time.DeltaTime;
        float maxSpeed = float.PositiveInfinity;
        return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }
    
    public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed)
    {
        float deltaTime = Time.DeltaTime;
        return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }
    public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
    {
        target = current + DeltaAngle(current, target);
        return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }
    
    public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime, float maxSpeedDelta)
    {
        maxSpeed = Max(maxSpeed, maxSpeedDelta / deltaTime);
        return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }

    // Infinite Line Intersection (line1 is p1-p2 and line2 is p3-p4)
    public static bool LineIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, out Vector2 result)
    {
        var bX = p2.X - p1.X;
        var bY = p2.Y - p1.Y;
        var dX = p4.X - p3.X;
        var dY = p4.Y - p3.Y;
        var bDotDPerp = bX * dY - bY * dX;
        if (bDotDPerp == 0.0f)
        {
            result = Vector2.Zero;
            return false;
        }
        var cx = p3.X - p1.X;
        var cy = p3.Y - p1.Y;
        var t = (cx * dY - cy * dX) / bDotDPerp;
        
        result = new Vector2(p1.X + t * bX, p1.Y + t * bY);
        return true;
    }
    
    // Line Segment Intersection (line1 is p1-p2 and line2 is p3-p4)
    public static bool LineSegmentIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, out Vector2 result)
    {
        var bX = p2.X - p1.X;
        var bY = p2.Y - p1.Y;
        var dX = p4.X - p3.X;
        var dY = p4.Y - p3.Y;
        var bDotDPerp = bX * dY - bY * dX;
        if (bDotDPerp == 0.0f)
        {
            result = Vector2.Zero;
            return false;
        }
        var cx = p3.X - p1.X;
        var cy = p3.Y - p1.Y;
        var t = (cx * dY - cy * dX) / bDotDPerp;
        if (t < 0.0f || t > 1.0f)
        {
            result = Vector2.Zero;
            return false;
        }
        var u = (cx * bY - cy * bX) / bDotDPerp;
        if (u < 0.0f || u > 1.0f)
        {
            result = Vector2.Zero;
            return false;
        }
        
        result = new Vector2(p1.X + t * bX, p1.Y + t * bY);
        return true;
    }
}