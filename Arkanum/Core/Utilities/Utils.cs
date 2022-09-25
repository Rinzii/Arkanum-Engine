using System.Drawing;

namespace Arkanum.Core.Utilities;

public class Utils
{
    public static Size CalculateAspectRatio(Size rez)
    {
        var h = rez.Height;
        var w = rez.Width;
        var quotient = h / (float)w;
        
        return new Size();
    }
    
    public static Size ConvertAspectRatio(Size rez, (int, int) ratio)
    {
        var h = rez.Height;
        var w = rez.Width;
        var quotient = h / (float)w;

        return new Size();
    }
}