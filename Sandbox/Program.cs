using Arkanum;
using Arkanum.Engine.Window;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace Sandbox;

public static class Program
{
    public static void Main()
    {
        var gameWindow = new GameWindow();
        
        while (!gameWindow.ShouldClose())
        {
            gameWindow.SwapBuffers();
            gameWindow.PollEvents();
            
            //GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
        }

    }
}