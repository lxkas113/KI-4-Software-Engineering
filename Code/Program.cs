using OvenProject.OvenControllerModule;

namespace OvenProject;

class Program
{
    static void Main(string[] args)
    {
        OvenController controller = new OvenController();
        controller.Loop();
    }
}