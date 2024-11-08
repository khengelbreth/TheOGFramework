using FramworkCheck.Div;
using Mandatory2DGameFramework.designpatterns;
using TheFramework.Design_Patterns;
using TheFramework.Interfaces;
using TheFramework.Libraries;
using TheFramework.Model.Attack;
using TheFramework.Model.Creature;
using TheFramework.Model.Defence;
using TheFramework.Worlds;

namespace FramworkCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameConfigReader configReader = new GameConfigReader();
            configReader.LoadFromXml("C:\\ObligatoriskeOpgaver\\TheFramework\\FramworkCheck\\Div\\Config.xml");

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("XML Check:\n");

            Console.WriteLine($"Games Y coordinates are: {configReader.MaxY}");
            Console.WriteLine($"Games X coordinates are: {configReader.MaxX}");

            foreach (var creature in configReader.Creatures)
            {
                Console.WriteLine($"Creature Name: {creature.Name}, Hit Points: {creature.HitPoints}");
            }

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Logging Check:\n");

            MyLogger.Instance.LogInfo("Application started.");
            MyLogger.Instance.LogWarning("This is a warning message.");
            MyLogger.Instance.LogError("An error occurred.");
            MyLogger.Instance.LogCritical("Critical failure!");
            MyLogger.Instance.Close();

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Check of Interfaces and Libraries:\n");

            IDefenceLibrary defenceLibrary = new DefenceLibrary();
            IAttackLibrary attackLibrary = new AttackLibrary(defenceLibrary);
            ILootLibrary lootLibrary = new LootLibrary();

            AttackItem sword = new AttackItem("Sword", 10, 1);
            DefenceItem shield = new DefenceItem("Shield", 8);
            AttackItem bow = new AttackItem("Bow", 8, 3);

            Creature creature1 = new Creature(attackLibrary, defenceLibrary, lootLibrary) { Name = "Jerry Berry the Slaughter", HitPoints = 100 };
            Creature creature2 = new Creature(attackLibrary, defenceLibrary, lootLibrary) { Name = "The Mighty Oak", HitPoints = 120 };

            creature1.Loot(bow);

            creature1.AddAttackItem(sword);
            creature2.AddDefenceItem(shield);

            attackLibrary.Hit(creature1, creature2);

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Factory Method Check:\n");

            ICreatureFactory creatureFactory = new CreatureFactory(attackLibrary, defenceLibrary, lootLibrary);

            Creature warrior = creatureFactory.CreateCreature("warrior", "Jerry the Brave");
            Creature mage = creatureFactory.CreateCreature("mage", "Gandalf the Wise");
            Creature archer = creatureFactory.CreateCreature("archer", "Legolas");

            Console.WriteLine($"{warrior.Name}, HP: {warrior.HitPoints}");
            Console.WriteLine($"{mage.Name}, HP: {mage.HitPoints}");
            Console.WriteLine($"{archer.Name}, HP: {archer.HitPoints}");

            Creature warrior2 = creatureFactory.CreateCreature("warrior", "The Hound");
            Console.WriteLine($"{warrior2.Name}, HP: {warrior2.HitPoints}");

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Strategy Method Check and Liskov Check:\n");

            warrior.SetAttackStrategy(new MeleeAttack());
            mage.SetAttackStrategy(new RangedAttack());
            warrior2.SetAttackStrategy(new RangedAttack());

            warrior.PerformAttack(mage);
            mage.PerformAttack(warrior);
            warrior2.PerformAttack(warrior);
            Console.WriteLine();
            warrior.PerformAttack(warrior2);


            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Observer Method Check:\n");

            World world = new World();
            WorldObjectLogger logger = new WorldObjectLogger();

            world.AddObserver(logger);

            WorldObject tree = new WorldObject("Tree", false, true);
            WorldObject chest = new WorldObject("Chest", true, true);

            world.AddWorldObject(tree);
            world.AddWorldObject(chest);
        }
    }
}
