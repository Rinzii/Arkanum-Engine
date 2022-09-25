using Silk.NET.GLFW;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using MouseButton = Silk.NET.GLFW.MouseButton;

namespace Arkanum.Engine.Window;
 
 public unsafe class GameWindow : IDisposable
 {

     internal static Glfw GLFW;
     
     internal static GL Gl;

     private WindowHandle* WinHandle;
     
     
     private string _title;

     private bool _visible;

     private GlfwCallbacks.KeyCallback _keyCallback;
     private GlfwCallbacks.MouseButtonCallback _mouseCallback;
     private GlfwCallbacks.ScrollCallback _scrollCallback;
     private GlfwCallbacks.WindowSizeCallback _sizeCallback;
     private GlfwCallbacks.CharCallback _charCallback;
     
     //private InputManager _inputManager;

     public GameWindow(int width = 1920, int height = 1080, string title = "Arkanum Engine")
     {
         // Initialize GLFW
            GLFW = Glfw.GetApi();
            GLFW.SetErrorCallback((error, description) => Console.WriteLine($"GLFW Error: {error} - {description}"));

            if (!GLFW.Init())
            {
                Dispose();
                throw new Exception("GLFW failed to initialize!");
            }
            
            // Set window hints
            GLFW.DefaultWindowHints();
            
            
            // set window hints for OpenGL
            GLFW.WindowHint(WindowHintClientApi.ClientApi, ClientApi.OpenGL);



            // Create Window
            WinHandle = GLFW.CreateWindow(width, height, title, null, null);
            GLFW.MakeContextCurrent(WinHandle);
            
            // Set window callbacks
            _keyCallback = (window, key, scancode, action, mods) =>
            {
                if (key == Keys.Escape && action == InputAction.Press)
                {
                    GLFW.SetWindowShouldClose(window, true);
                }
            };
            GLFW.SetKeyCallback(WinHandle, _keyCallback);
            
            _mouseCallback = (window, button, action, mods) =>
            {
                if (button == MouseButton.Left && action == InputAction.Press)
                {
                    Console.WriteLine("Left Mouse Button Pressed");
                }
            };
            GLFW.SetMouseButtonCallback(WinHandle, _mouseCallback);
            
            _scrollCallback = (window, xoffset, yoffset) =>
            {
                Console.WriteLine($"Scroll: {xoffset}, {yoffset}");
            };
            GLFW.SetScrollCallback(WinHandle, _scrollCallback);
            
            _sizeCallback = (window, width, height) =>
            {
                Console.WriteLine($"Window Size: {width}, {height}");
            };
            GLFW.SetWindowSizeCallback(WinHandle, _sizeCallback);
            
            _charCallback = (window, codepoint) =>
            {
                Console.WriteLine($"Char: {codepoint}");
            };
            GLFW.SetCharCallback(WinHandle, _charCallback);
     }


     public void Show()
    {
        GLFW.ShowWindow(WinHandle);
        _visible = true;
    }
    
    public void Hide()
    {
        GLFW.HideWindow(WinHandle);
        _visible = false;
    }
    
    public void SetTitle(string title)
    {
        GLFW.SetWindowTitle(WinHandle, title);
        _title = title;
    }
    
    public void SetSize(int width, int height)
    {
        GLFW.SetWindowSize(WinHandle, width, height);
    }
    
    public void SetPosition(int x, int y)
    {
        GLFW.SetWindowPos(WinHandle, x, y);
    }
    
    public void SetKeyCallback(GlfwCallbacks.KeyCallback callback)
    {
        GLFW.SetKeyCallback(WinHandle, callback);
        _keyCallback = callback;
    }
    
    public void SetMouseCallback(GlfwCallbacks.MouseButtonCallback callback)
    {
        GLFW.SetMouseButtonCallback(WinHandle, callback);
        _mouseCallback = callback;
    }
    
    public void SetScrollCallback(GlfwCallbacks.ScrollCallback callback)
    {
        GLFW.SetScrollCallback(WinHandle, callback);
        _scrollCallback = callback;
    }
    
    public void SetSizeCallback(GlfwCallbacks.WindowSizeCallback callback)
    {
        GLFW.SetWindowSizeCallback(WinHandle, callback);
        _sizeCallback = callback;
    }
    
    public void SetCharCallback(GlfwCallbacks.CharCallback callback)
    {
        GLFW.SetCharCallback(WinHandle, callback);
        _charCallback = callback;
    }
    
    public void SwapBuffers()
    {
        GLFW.SwapBuffers(WinHandle);
    }
    
    public void PollEvents()
    {
        GLFW.PollEvents();
    }



    public bool ShouldClose()
     {
         return GLFW.WindowShouldClose(WinHandle);
     }
     
    public void Dispose()
    {
        GLFW.DestroyWindow(WinHandle);
        GLFW.Terminate();
        GLFW.Dispose();
    }
 }