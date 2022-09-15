using System;
using Silk.NET.GLFW;
using Silk.NET.Input;
using Silk.NET.Maths;
using static Silk.NET.Windowing.ContextAPI;

namespace Arkanum.Engine.Engine.Window;

using Silk.NET.Windowing;

public class GameWindow
{
    // Create a silk.net window
    private IWindow window;
    private IInputContext inputContext;

    public GameWindow(int width, int height, string title)
    {
        // Create a window
        window = Window.Create(new WindowOptions
        {
            Title = title,
            Size = new Vector2D<int>(width, height),
        });
        inputContext = window.CreateInput();

        // Set the window to close when the user presses the close button using silk.net


    }
    public void Initialize()
    {
        // Initialize the window
        window.Initialize();
        window.Run();
    }
    
    public void Update()
    {

    }
    
    public bool IsClosing()
    {
        return window.IsClosing;
    }
    




}