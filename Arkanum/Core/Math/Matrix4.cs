#pragma warning disable SA1107 // Code must not contain multiple statements on one line
#pragma warning disable SA1117 // Parameters must be on same line or separate lines
#pragma warning disable SA1313 // Parameter names must begin with lower-case letter

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MatrixDotnet = System.Numerics.Matrix4x4;

namespace Arkanum.Core.Math;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Matrix4 : IEquatable<Matrix4>, IFormattable
{
    #region Initializers
    
    public static readonly int SizeInBytes = Unsafe.SizeOf<Matrix4>();
    
    public static readonly Matrix4 Zero = new Matrix4(0);
    
    public static readonly Matrix4 Identity = new Matrix4() { M11 = 1.0f, M22 = 1.0f, M33 = 1.0f, M44 = 1.0f };
    
    #endregion
    
    #region Fields
    
    public float M11 { get; set; }
    public float M12 { get; set; }
    public float M13 { get; set; }
    public float M14 { get; set; }
    public float M21 { get; set; }
    public float M22 { get; set; }
    public float M23 { get; set; }
    public float M24 { get; set; }
    public float M31 { get; set; }
    public float M32 { get; set; }
    public float M33 { get; set; }
    public float M34 { get; set; }
    public float M41 { get; set; }
    public float M42 { get; set; }
    public float M43 { get; set; }
    public float M44 { get; set; }
    
    #endregion
    
    #region Constructors
    
    public Matrix4(
        float m11, float m12, float m13, float m14, 
        float m21, float m22, float m23, float m24, 
        float m31, float m32, float m33, float m34, 
        float m41, float m42, float m43, float m44)
    {
        M11 = m11; M12 = m12; M13 = m13; M14 = m14;
        M21 = m21; M22 = m22; M23 = m23; M24 = m24;
        M31 = m31; M32 = m32; M33 = m33; M34 = m34;
        M41 = m41; M42 = m42; M43 = m43; M44 = m44;
    }
    
    public Matrix4(float[] values )
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));
        if (values.Length != 16)
            throw new ArgumentOutOfRangeException(nameof(values), "A 4x4 matrix requires exactly 16 values.");
        
        M11 = values[0]; M12 = values[1]; M13 = values[2]; M14 = values[3];
        M21 = values[4]; M22 = values[5]; M23 = values[6]; M24 = values[7];
        M31 = values[8]; M32 = values[9]; M33 = values[10]; M34 = values[11];
        M41 = values[12]; M42 = values[13]; M43 = values[14]; M44 = values[15];
    }
    
    public Matrix4(float value)
    {
        M11 = value; M12 = value; M13 = value; M14 = value;
        M21 = value; M22 = value; M23 = value; M24 = value;
        M31 = value; M32 = value; M33 = value; M34 = value;
        M41 = value; M42 = value; M43 = value; M44 = value;
    }
    
    #endregion

    #region Rows & Columns

    public Vector4 Row1
    {
        get => new(M11, M12, M13, M14);
        set { M11 = value.X; M12 = value.Y; M13 = value.Z; M14 = value.W; }
    }

    public Vector4 Row2
    {
        get => new(M21, M22, M23, M24);
        set
        { M21 = value.X; M22 = value.Y; M23 = value.Z; M24 = value.W; }
    }

    public Vector4 Row3
    {
        get => new(M31, M32, M33, M34);
        set
        { M31 = value.X; M32 = value.Y; M33 = value.Z; M34 = value.W; }
    }

    public Vector4 Row4
    {
        get => new(M41, M42, M43, M44);
        set { M41 = value.X; M42 = value.Y; M43 = value.Z; M44 = value.W; }
    }

    public Vector4 Column1
    {
        get => new(M11, M21, M31, M41);
        set { M11 = value.X; M21 = value.Y; M31 = value.Z; M41 = value.W; }
    }

    public Vector4 Column2
    {
        get => new(M12, M22, M32, M42);
        set { M12 = value.X; M22 = value.Y; M32 = value.Z; M42 = value.W; }
    }

    public Vector4 Column3
    {
        get => new(M13, M23, M33, M43);
        set { M13 = value.X; M23 = value.Y; M33 = value.Z; M43 = value.W; }
    }

    public Vector4 Column4
    {
        get => new(M14, M24, M34, M44);
        set { M14 = value.X; M24 = value.Y; M34 = value.Z; M44 = value.W; }
    }
    
    #endregion

    #region Indexers
    
    public float this[int index]
    {
        get
        {
            return index switch
            {
                0 => M11, 1 => M12, 2 => M13, 3 => M14,
                4 => M21, 5 => M22, 6 => M23, 7 => M24,
                8 => M31, 9 => M32, 10 => M33, 11 => M34,
                12 => M41, 13 => M42, 14 => M43, 15 => M44,
                _ => throw new ArgumentOutOfRangeException(nameof(index), "Indices for Matrix run from 0 to 15, inclusive.")
            };
        }

        set
        {
            switch (index)
            {
                case 0: M11 = value; break;
                case 1: M12 = value; break;
                case 2: M13 = value; break;
                case 3: M14 = value; break;
                case 4: M21 = value; break;
                case 5: M22 = value; break;
                case 6: M23 = value; break;
                case 7: M24 = value; break;
                case 8: M31 = value; break;
                case 9: M32 = value; break;
                case 10: M33 = value; break;
                case 11: M34 = value; break;
                case 12: M41 = value; break;
                case 13: M42 = value; break;
                case 14: M43 = value; break;
                case 15: M44 = value; break;
                default: throw new ArgumentOutOfRangeException(nameof(index), "Indices for Matrix run from 0 to 15, inclusive.");
            }
        }
    }
    
    public float this[int row, int column]
    {
        get
        {
            if (row < 0 || row > 3)
                throw new ArgumentOutOfRangeException(nameof(row), "Rows and columns for matrices run from 0 to 3, inclusive.");
            if (column < 0 || column > 3)
                throw new ArgumentOutOfRangeException(nameof(column), "Rows and columns for matrices run from 0 to 3, inclusive.");

            return this[(row * 4) + column];
        }

        set
        {
            if (row < 0 || row > 3)
                throw new ArgumentOutOfRangeException(nameof(row), "Rows and columns for matrices run from 0 to 3, inclusive.");
            if (column < 0 || column > 3)
                throw new ArgumentOutOfRangeException(nameof(column), "Rows and columns for matrices run from 0 to 3, inclusive.");

            this[(row * 4) + column] = value;
        }
    }
    
    #endregion
    
    #region Methods
    
    public Vector3 TranslationVector3
    {
        get => new(M41, M42, M43);
        set { M41 = value.X; M42 = value.Y; M43 = value.Z; }
    }
    
    public Vector3 ScaleVector3
    {
        get => new(M11, M22, M33);
        set { M11 = value.X; M22 = value.Y; M33 = value.Z; }
    }


    public float Determinant()
    {
        var temp1 = (M33 * M44) - (M34 * M43);
        var temp2 = (M32 * M44) - (M34 * M42);
        var temp3 = (M32 * M43) - (M33 * M42);
        var temp4 = (M31 * M44) - (M34 * M41);
        var temp5 = (M31 * M43) - (M33 * M41);
        var temp6 = (M31 * M42) - (M32 * M41);

        return ((((M11 * (((M22 * temp1) - (M23 * temp2)) + (M24 * temp3))) - (M12 * (((M21 * temp1) -
                    (M23 * temp4)) + (M24 * temp5)))) + (M13 * (((M21 * temp2) - (M22 * temp4)) + (M24 * temp6)))) -
                (M14 * (((M21 * temp3) - (M22 * temp5)) + (M23 * temp6))));
    }
    

    
    #endregion

    #region Fucked Up Methods that are doing hacky shit

    static ref MatrixDotnet UnsafeRefAsDotNet(in Matrix4 m) => ref Unsafe.As<Matrix4, MatrixDotnet>(ref Unsafe.AsRef(in m));
    static ref Matrix4 UnsafeRefFromDotNet(in MatrixDotnet m) => ref Unsafe.As<MatrixDotnet, Matrix4>(ref Unsafe.AsRef(in m));

    /// <summary>
    /// Copied from Stride3D: https://github.com/stride3d/stride
    /// 
    /// Inverts the matrix.
    /// If the matrix cannot be inverted (eg. Determinant was zero), then the matrix will be set equivalent to <see cref="Zero"/>.
    /// </summary>
    public void Invert()
    {
        Invert(ref this, out this);
    }
    
    /// <summary>
    /// Copied from Stride3D: https://github.com/stride3d/stride
    /// 
    /// Calculates the inverse of the specified matrix.
    /// If the matrix cannot be inverted (eg. Determinant was zero), then the returning matrix will be <see cref="Zero"/>.
    /// </summary>
    /// <param name="value">The matrix whose inverse is to be calculated.</param>
    /// <returns>The inverse of the specified matrix.</returns>
    public static Matrix4 Invert(Matrix4 value)
    {
        value.Invert();
        return value;
    }
    
    /// <summary>
    /// Copied from Stride3D: https://github.com/stride3d/stride
    /// 
    /// Calculates the inverse of the specified matrix.
    /// If the matrix cannot be inverted (eg. Determinant was zero), then <paramref name="result"/> will be <see cref="Zero"/>.
    /// </summary>
    /// <param name="value">The matrix whose inverse is to be calculated.</param>
    /// <param name="result">When the method completes, contains the inverse of the specified matrix.</param>
    public static void Invert(ref Matrix4 value, out Matrix4 result)
    {
        // Invert works the same in row and column major, no need to transpose
        Unsafe.SkipInit(out result);
        if (!MatrixDotnet.Invert(UnsafeRefAsDotNet(value), out UnsafeRefAsDotNet(result)))
        {
            result = Zero;
        }
    }
    
    #endregion


    public bool Equals(Matrix4 other)
    {
        throw new NotImplementedException();
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        throw new NotImplementedException();
    }
}