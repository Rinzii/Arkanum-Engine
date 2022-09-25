using Arkanum.Core.Math;
using Arkanum.Engine.Input;
using Silk.NET.GLFW;

namespace Arkanum.Engine.Window;

public unsafe class InputState
{
    private List<KeyCode> _keysPressed;
    private string _textEntered;
    
    public KeyCode[] KeysPressed => _keysPressed.ToArray();
    public string TextEntered => _textEntered;
    
    public bool IsKeyPressed(KeyCode key) => _keysPressed.Contains(key);
    
    public Vector2 MousePosition { get; private set; }

    internal InputState(GameWindow2 window, WindowHandle* handle, Glfw glfw)
    {
        _keysPressed = new List<KeyCode>();
        
        window.KeyDown += key => _keysPressed.Add(key);
        window.KeyUp += key => _keysPressed.Remove(key);
        window.TextInput += c => _textEntered += c;

        Update(handle, glfw);
    }

    private void Update(WindowHandle* handle, Glfw glfw)
    {
        _textEntered = string.Empty;
        
        glfw.GetCursorPos(handle, out var mouseX, out var mouseY);
        MousePosition = new Vector2((float) mouseX, (float) mouseY);
    }
}