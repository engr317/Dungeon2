using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using DungeonLibrary;
using MonsterLIbrary;
using static System.Console;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
                 

            var myplayer = new SoundPlayer(Properties.Resources.looperman);
            myplayer.PlayLooping();


            WriteLine(@"
 __| |____________________________________________| |__
(__   ____________________________________________   __)
   | |                                            | |
   | |                                            | |
   | |             Dungeon of Doom                | |
   | |                                            | |
   | |                                            | |
   | |          Your journey begins...            | |
 __| |____________________________________________| |__
(__   ____________________________________________   __)
   | |                                            | |

");            

            //1 TODO Create a Player

            Weapon sword = new Weapon("Short Sword", 1, 6, 0, false);            
            Weapon vorpalSword = new Weapon("Vorpal Sword", 12, 24, 5, true);
            Weapon slingshot = new Weapon("Sling Shot", 1, 3, 50, true);
            Weapon doubleAxe = new Weapon("Double Bladed Axe", 5, 15, 0, true);
            Weapon battleStaff = new Weapon("Staff of Enlightenment", 10, 20, 9, true);
            Weapon Bow = new Weapon("Bow", 5, 5, 9, true);
            

            Player player = new Player("Leeeeeerooooy Jenkins!!!", 15, 15, 10, 5, sword, Race.Elf);
            Player Player2 = new Player("Player2", 10, 15, 10, 2, slingshot, Race.Troll);
            Player Player3 = new Player("Ranger", 20, 20, 10, 5, sword, Race.Human);
            Player Player4 = new Player("Gandalf the White", 10, 10, 5, 5, battleStaff, Race.Human);
            Player Player5 = new Player("Ragnor Lothbrok", 10, 10, 8, 8, doubleAxe, Race.Human);

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
                Demon d1 = new Demon("Imp", 10, 10, 3, 12, 1, 6, "A small, flying demon w- barbed tail", 55);

                Demon d2 = new Demon("Changeling", 15, 15, 5, 10, 2, 8, "This sensual magical girl's deep-set eyes are the color of wild moss and her neck-length, straight, silky, black hair is worn in a complex style. She has a busty build. She has avian powers that are invoked by concentration. Her costume is yellow and black, and it strongly resembles a french maid's uniform.", 0);

                Demon d3 = new Demon("Chiuahua", 10, 10, 2, 10, 4, 8, "This conceited warlock is spurred onward by religious fanaticism. He employs necromancy in his plots, usually ressurecting the dead to gain their knowledge to achieve his goals. He has a peculiar affinity for magical items.", 7);

                Demon d4 = new Demon("Ghost", 15, 15, 5, 10, 2, 8, "This chaste sorceress is motivated by greed. She uses high magic in her schemes, commonly taking over instutitions of magical training to achieve her goals. She is from an unusual family line.", 0);

                Demon d5 = new Demon("Death Eater", 15, 15, 5, 10, 2, 8, "This cute magic-user is motivated by greed. She uses demonology in her plots, commonly kidnapping important magic-users to achieve her goals. She has little money.", 0);

                Demon d6 = new Demon("Wraith", 15, 15, 5, 10, 2, 8, "This ugly warlock is motivated by egotism. He uses necromancy in his plots, commonly stealing the souls of political leaders to achieve his goals. He has a peculiar affinity for magic.", 0);

                Demon d7 = new Demon("Firey Poodle", 15, 15, 5, 10, 2, 8, "The social female half-Satyr poacher who is prone to odd statements. She has a muscular build. Her wardrobe is utilitarian. Her non-human ancestry is very obvious and not-concealable, but not particuarly disturbing.", 0);

                Demon d8 = new Demon("Zombie", 15, 15, 5, 10, 2, 8, "Summons other demons", 0);

                Demon d9 = new Demon("Porcelain Doll", 15, 15, 5, 10, 2, 8, "This goddess of famine takes the form of a mature woman. She is short and has a plump build. Her eyes are sunken, like those of a corpse. She has lemon-yellow skin. She is usually portrayed as wearing a dignified uniform made from the skin of a dead god, and various ornaments. She carries an axe. She can starve a person to death with a touch.", 0);

                Demon d10 = new Demon("Ninja", 15, 15, 5, 10, 2, 8, "This vicious ninja has a lean build. He has burn marks on his body. His narrow eyes are white. He has medium-length jade-colored hair worn in a straightforward style. He uses an elaborate form of martial arts that emphasizes breaking an opponent's bones and using headbutting. His preferred weapon is a spear. He is skilled in interrogation and cryptography. He uses his martial arts to produce gravitic disturbances.", 0);

                Monster[] monsters =
                {
                    d1, d3, d1, d2, d4, d5, d6, d7, d8, d9, d10
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
                                Console.ForegroundColor = ConsoleColor.Cyan;
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
