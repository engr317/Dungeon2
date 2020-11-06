using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLIbrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeon of Doom";
            Console.WriteLine("Your journey begins...\n");

            //1 TODO Create a Player

            Weapon sword = new Weapon("Short Sword", 1, 6, 0, false);

            //MINI-LAB! Create another weapon and display it to the screen
            Weapon vorpalSword = new Weapon("Vorpal Sword", 12, 24, 5, true);

            //Console.WriteLine(sword);
            //Console.WriteLine(vorpalSword);

            Player player = new Player("Leeeeeerooooy Jenkins!!!", 15, 15, 10, 5, sword, Race.Elf);

            Console.WriteLine(player);
            Console.WriteLine();

            //TODONE Create a loop for the room
            bool exit = false;

            do
            {
                //enter a room
                //3 TODO write a method for getting room descriptions
                Console.WriteLine(GetRoom());
                //4 TODO Create a Monster in the room
                Demon d1 = new Demon("Imp", 10, 10, 3, 12, 1, 6, "A small, flying demon with a barbed tail", 55);
                Demon d2 = new Demon("Summoner", 15, 15, 5, 10, 2, 8, "Summons other demons", 0);

                Monster[] monsters =
                {
                    d1, d1, d1, d2
                };

                Monster monster = monsters[new Random().Next(monsters.Length)];
                Console.WriteLine("In this room you see a " + monster.Name + "!");

                //5 Create loop for menu
                bool reload = false;
                do
                {
                    Console.WriteLine("\nChoose an action:\n" +
                        "A)ttack \n" +
                        "R)un away \n" +
                        "P)layer Stats \n" +
                        "M)onster Stats \n" +
                        "E)xit");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                    //8 Build out the switch for userChoice
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //9 TODO If player Fights
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You killed the {0}!", monster.Name);
                                System.Threading.Thread.Sleep(2000);
                                Console.ResetColor();
                                Console.Clear();
                                reload = true;

                            }
                            break;
                        case ConsoleKey.R:
                            //10 TODO If player Runs
                            Console.WriteLine("RUN AWAY!");
                            int blockedIn = new Random().Next(1);
                            if (blockedIn == 1)
                            {
                                reload = true;
                            }
                            else
                            {
                                Console.WriteLine("The Monster has pushed you back!!");
                            }
                            Combat.DoAttack(monster, player);
                            break;
                        case ConsoleKey.P:
                            //11 TODO If viewing Players info
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            //12 TODO If viewing Monsters info
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.E:
                            Console.WriteLine("Come back and fight, loser!!...");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("That's not an option. Please try again");
                            break;
                    }//end of switch

                    //15 TODO Check Players life

                    //16 TODO If they died end application

                    //17 TODO Keep looping through if they're alive
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You have been slain by the {0}!",
                            monster.Name);
                        exit = true;
                    }

                } while (!exit && !reload);
            } while (!exit);

            Console.WriteLine("GAME OVER");

        }//End Main()

        private static string GetRoom()
        {
            string[] room =
            {
                "A dozen statues stand or kneel in this room, and each one lacks a head and stands in a posture of action or defense. All are garbed for battle. It's difficult to tell for sure without their heads, but two appear to be dwarves, one might be an elf, six appear human, and the rest look like they might be orcs.",
                "Three low, oblong piles of rubble lie near the center of this small room. Each has a weapon jutting upright from one end -- a longsword, a spear, and a quarterstaff. The piles resemble cairns used to bury dead adventurers.",
                "In the center of this large room lies a 30-foot-wide round pit, its edges lined with rusting iron spikes. About 5 feet away from the pit's edge stand several stone semicircular benches. The scent of sweat and blood lingers, which makes the pit's resemblance to a fighting pit or gladiatorial arena even stronger.",
                "Huge rusted metal blades jut out of cracks in the walls, and rusting spikes project down from the ceiling almost to the floor. This room may have once been trapped heavily, but someone triggered them, apparently without getting killed. The traps were never reset and now seem rusted in place.",
                "You open the door, and the reek of garbage assaults your nose. Looking inside, you see a pile of refuse and offal that nearly reaches the ceiling. In the ceiling above it is a small hole that is roughly as wide as two human hands. No doubt some city dweller high above disposes of his rubbish without ever thinking about where it goes.",
                "A small pair of granite doors in a eerie cliff side marks the entrance to this dungeon. Beyond the pair of granite doors lies a massive, humid room. It's covered in dirt, cobwebs and remains.",
                "Your torch allows you to see remnants of sacks, crates and caskets, tattered and maimed by time itself.Further ahead are three paths, you take the right. Its twisted trail leads passed several empty rooms and soon you enter a humid area. It's littered with skeletons, but no weaponry in sight. What happened in this place?You advance carefully onwards, deeper into the dungeon's secret passages. You pass dozens of similar rooms and passages, each leading to who knows where, or what. You eventually make it to what is likely the final room. An ominous wooden door blocks your path. Dried blood splatters are all over it, somehow untouched by time and the elements. You step closer to inspect it and.. wait.. did the door just change its appearance?",
                " A short dark cave in a dark woods marks the entrance to this dungeon. Beyond the dark cave lies a grand, deteriorated room. It's covered in broken stone, remains and puddles of water.Your torch allows you to see rows of vertical tombs, aged and eaten by time itself.  Further ahead are two paths, you take the right. Its twisted trail leads passed countless other pathways and soon you enter a damp area. There's a seemingly endless hole in the center. Around it are what seem like runes. What happened in this place?  You slowly march onwards, deeper into the dungeon's depths. You pass dozens of similar rooms and passages, each with their own twists, turns and destinations. You eventually make it to what is likely the final room. A large metal door blocks your path. Dried blood splatters are all over it, somehow untouched by time and the elements. You step closer to inspect it and.. wait.. is that a scratching sound coming from behind the door?",
                " A massive dark cave in a gloomy morass marks the entrance to this dungeon. Beyond the dark cave lies a narrow, dusty room. It's covered in broken pottery, bat droppings and roots.  Your torch allows you to see what seems like some form of a sacrificial chamber, demolished and wrecked by time itself. Further ahead are two paths, but the right is a dead end. Its twisted trail leads passed broken and pillaged tombs and soon you enter a damp area. The room is filled with lifelike statues of terrified people. What happened in this place?  You press onwards, deeper into the dungeon's secret passages. You pass many different passages, each leading to who knows where, or what. You eventually make it to what is likely the final room. A large metal door blocks your path. Various odd symbols are all over it, somehow untouched by time and the elements. You step closer to inspect it and.. wait.. what was that sound? ",
                " A large waterfall in a misty grove marks the entrance to this dungeon. Beyond the waterfall lies a massive, worn room. It's covered in rubble, ash and moss.  Your torch allows you to see carved out openings filled with pottery, forgotten and taken by time itself.  Further ahead are two paths, you take the right. Its twisted trail leads passed long lost rooms and tombs and soon you enter a putrid area. It's filled with tombs, some of which no longer hold their owner. What happened in this place? You press onwards, deeper into the dungeon's secrets. You pass a few more passages, each seem to go on forever, leading to who knows what. You eventually make it to what is likely the final room. An ominous metal door blocks your path. Ash and soot is all over it, somehow untouched by time and the elements. You step closer to inspect it and.. wait.. you're pretty sure you're being watched."



            };

            return room[new Random().Next(room.Length)];
        }
    }
}
