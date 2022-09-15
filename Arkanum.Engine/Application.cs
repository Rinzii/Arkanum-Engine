using Arkanum.Engine.Engine.Window;

namespace Arkanum.Engine;

public class Application
{
    public static void Main()
    {
        // This does not work
        GameWindow window = new GameWindow(400, 400, "Arkanum Engine");
        
        window.Initialize();

        while (window.IsClosing())
        {
            window.Update();
            //window.Render();
        }

        
        
    }
}