using TheFramework.Design_Patterns;
using TheFramework.Worlds;

namespace Mandatory2DGameFramework.designpatterns
{
    public class WorldObjectLogger : IWorldObjectObserver
    {
        public void OnWorldObjectCreated(WorldObject worldObject)
        {
            Console.WriteLine($"\nLogger: {worldObject.Name} just created!! \nLootable: {worldObject.Lootable}. \nRemoveable: {worldObject.Removeable}\n");
        }
    }

}
