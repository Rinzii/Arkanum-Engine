using System.Diagnostics;

namespace Arkanum.Engine.Core.Math;

public static class Time
{
    private static Stopwatch Stopwatch;
    private static float _lastTime;
    private static float _deltaTime;

    private static float LastTime;

    /// <summary>
    /// The amount of time the last frame took to process. Use to create framerate-independent movement.
    /// </summary>
    public static float DeltaTime => _deltaTime;

    /// <summary>
    /// The total number of milliseconds that have passed since the application opened.
    /// </summary>
    public static long TotalMilliseconds => Stopwatch.ElapsedMilliseconds;
    
    /// <summary>
    /// The total number of nanoseconds that have passed since the application opened.
    /// </summary>
    public static long TotalNanoSeconds => Stopwatch.ElapsedTicks * (1000000000 / Stopwatch.Frequency);

    /// <summary>
    /// The total number of seconds that have passed since the application opened.
    /// </summary>
    public static float TotalSeconds => (float) Stopwatch.Elapsed.TotalSeconds;

    internal static void Start()
    {
        Stopwatch = Stopwatch.StartNew();
        _lastTime = 0;
        _deltaTime = 0;
    }

    internal static void Update()
    {
        float time = (float) Stopwatch.Elapsed.TotalSeconds;
        LastTime = time;
        _deltaTime = time - _lastTime;
        _lastTime = time;
    }
    
    
}
