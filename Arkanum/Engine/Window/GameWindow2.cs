using System;
using System.Drawing;
using Arkanum.Core.Math;
using Arkanum.Engine.Input;
using Silk.NET.GLFW;
using Keys = Silk.NET.GLFW.Keys;

//using Silk.NET.Windowing;

namespace Arkanum.Engine.Window;

public unsafe class GameWindow2
{
    private Glfw _glfw;
    private WindowHandle* _handle;
    private InputState _inputState;

    public GameWindow2(Glfw glfw, WindowHandle* handle)
    {
        _glfw = glfw;
        _handle = handle;
        SetupCallbacks();
        _inputState = new InputState(this, handle, glfw);
    }
    
    

    #region Callbacks

    public event OnResize Resize;
    public event OnKeyDown KeyDown;
    public event OnKeyUp KeyUp;

    public event OnTextInput TextInput;

    private GlfwCallbacks.WindowSizeCallback _windowSizeCallback;
    private GlfwCallbacks.KeyCallback _keyCallback;
    private GlfwCallbacks.CharCallback _charCallback;

    private void SetupCallbacks()
    {
        _windowSizeCallback = WindowSizeCallback;
        _keyCallback = KeyCallback;
        _charCallback = CharCallback;
        // TODO: Add all glfw callbacks https://www.glfw.org/docs/3.3/input_guide.html

        _glfw.SetWindowSizeCallback(_handle, _windowSizeCallback);
        _glfw.SetKeyCallback(_handle, _keyCallback);
        _glfw.SetCharCallback(_handle, _charCallback);
    }

    private void KeyCallback(WindowHandle* window, Silk.NET.GLFW.Keys key, int scancode, InputAction action,
        KeyModifiers mods)
    {
        switch (action)
        {
            case InputAction.Press:
                KeyDown?.Invoke((KeyCode)key);
                break;
            case InputAction.Release:
                KeyUp?.Invoke((KeyCode)key);
                break;
        }
    }

    private void WindowSizeCallback(WindowHandle* window, int width, int height)
    {
        Resize?.Invoke(new Vector2i(width, height));
    }

    private void CharCallback(WindowHandle* window, uint codepoint)
    {
        TextInput?.Invoke((char)codepoint);
    }

    public delegate void OnResize(Vector2i args);

    public delegate void OnKeyDown(KeyCode key);

    public delegate void OnKeyUp(KeyCode key);

    public delegate void OnTextInput(char c);

    #endregion
}