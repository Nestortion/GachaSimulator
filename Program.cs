using System;
using System.Collections.Generic;

namespace GachaSimulator
{
    class Program
    {
        static String[] fiveStarCharactersStandard = new String[] {"Diluc","Jean","Qiqi","Mona","Keqing"};
        static String[] fourStarCharacters = new String[] { "Razor", "Fischl", "Amber", "Kaeya", "Noelle", 
                                                            "Chongyun", "Xiangling", "Sucrose", "Lisa", "Diona",
                                                            "Ningguang", "Bennett", "Rosaria", "Beidou", "Xingqiu","Barbara","Xinyan"};
        static String[] EventCharacter = new string[] { "Venti", "Klee", "Tartaglia", "Zhongli", "Albedo",
                                                        "Ganyu", "Xiao", "Hu tao"};
        static List<FiveStar> fiveStars = new List<FiveStar>();
        static List<FourStar> fourStars = new List<FourStar>();
        static FiveStar eventChar;
        static int amountOfPulls;
        static int amountSelected;
        static bool guaranteedEvent = false;
        static int pityCounterFiveStar = 1;
        static int pityCounterFourStar = 1;
        static double softPityAddition = 0.066662;
        static double fiveStarDropChance = 0.006;
        static double fourStarDropChance = 0.051;
        static Random rand = new Random();
        static double pullResult;
        static string question = "How many pulls would you like to use? 1 OR 10";

        static void Main(string[] args)
        {
            charCreation(fiveStarCharactersStandard, fourStarCharacters, EventCharacter);

            Console.WriteLine("Welcome to Genshin Impact Gacha Simulator!");
            Console.WriteLine("Enter an amount of pulls: ");
            amountOfPulls = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Today's Event Character is: " + eventChar.getName());

            while (amountOfPulls > 0)
            {
                Console.WriteLine(question);
                amountSelected = Convert.ToInt32(Console.ReadLine());
                    if (amountSelected == 10 && amountOfPulls < 10)
                    {
                        Console.WriteLine("Insufficient amount of pulls");
                    }
                    else if (amountSelected == 1)
                    {
                        gachaRoll();
                        amountOfPulls -= 1;
                    }
                    else if (amountSelected == 10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            gachaRoll();
                        }
                            amountOfPulls -= 10;
                    }
                    else
                    {
                        Console.WriteLine("Sorry you can only choose between 1 or 10, pls try again");
                    }
            }
            
        }
        static void gachaRoll()
        {
            if (pityCounterFiveStar == 90)
            {
                if (guaranteedEvent == true)
                {
                    Console.WriteLine("You got " + eventChar.getName());
                    pityCounterFiveStar = 0;
                    guaranteedEvent = false;
                }
                else
                {
                    int half = rand.Next(2);
                    if (half == 0)
                    {
                        Console.WriteLine("You got " + eventChar.getName());
                        pityCounterFiveStar = 0;
                        guaranteedEvent = false;

                    }
                    else
                    {
                        Console.WriteLine("You got " + fiveStars[rand.Next(fiveStars.Count)].getName());
                        pityCounterFiveStar = 0;
                        guaranteedEvent = true;
                    }
                }
            }
            else if (pityCounterFiveStar > 74 && pityCounterFiveStar < 90)
            {
                fiveStarDropChance += softPityAddition;
                fourStarDropChance += softPityAddition;
                if (pullResult >= 0.0 && pullResult < fiveStarDropChance)
                {
                    if (guaranteedEvent == true)
                    {
                        Console.WriteLine("You got " + eventChar.getName());
                        pityCounterFiveStar = 0;
                        guaranteedEvent = false;
                    }
                    else
                    {
                        int half = rand.Next(2);
                        if (half == 0)
                        {
                            Console.WriteLine("You got " + eventChar.getName());
                            pityCounterFiveStar = 0;
                            guaranteedEvent = false;

                        }
                        else
                        {
                            Console.WriteLine("You got " + fiveStars[rand.Next(fiveStars.Count)].getName());
                            pityCounterFiveStar = 0;
                            guaranteedEvent = true;
                        }
                    }
                }
                else if (pullResult >= fiveStarDropChance && pullResult < fourStarDropChance)
                {
                    Console.WriteLine("You got " + fourStars[rand.Next(fourStars.Count)].getName());
                    pityCounterFourStar = 0;
                    pityCounterFiveStar++;
                }
                else
                {
                    Console.WriteLine("You got a 3 star character");
                    pityCounterFourStar++;
                    pityCounterFiveStar++;
                }
            }

            else if (pityCounterFourStar == 10)
            {
                Console.WriteLine("You got " + fourStars[rand.Next(fourStars.Count)].getName());
                pityCounterFourStar = 0;
                pityCounterFiveStar++;
            }
            else if (pityCounterFourStar < 10 && pityCounterFiveStar < 90)
            {
                pullResult = rand.NextDouble();
                if (pullResult >= 0.0 && pullResult < 0.006)
                {
                    if (guaranteedEvent == true)
                    {
                        Console.WriteLine("You got " + eventChar.getName());
                        pityCounterFiveStar = 0;
                        guaranteedEvent = false;
                    }
                    else
                    {
                        int half = rand.Next(2);
                        if (half == 0)
                        {
                            Console.WriteLine("You got " + eventChar.getName());
                            pityCounterFiveStar = 0;
                            guaranteedEvent = false;

                        }
                        else
                        {
                            Console.WriteLine("You got " + fiveStars[rand.Next(fiveStars.Count)].getName());
                            pityCounterFiveStar = 0;
                            guaranteedEvent = true;
                        }
                    }
                }
                else if (pullResult >= 0.0061 && pullResult < 0.051)
                {
                    Console.WriteLine("You got " + fourStars[rand.Next(fourStars.Count)].getName());
                    pityCounterFourStar = 0;
                    pityCounterFiveStar++;
                }
                else
                {
                    Console.WriteLine("You got a 3 star character");
                    pityCounterFourStar++;
                    pityCounterFiveStar++;

                }
            }
        }
        static void charCreation(String[] fivStars, String[] forStars, String[] eventChars)
        {
            Random rand = new Random();
            for (int i = 0; i < fivStars.Length; i++)
            {
                fiveStars.Add(new FiveStar(fivStars[i]));
                
            }

            for (int i = 0; i < forStars.Length; i++)
            {
                fourStars.Add(new FourStar(forStars[i]));
            }
            eventChar = new FiveStar(eventChars[rand.Next(eventChars.Length)]);
        }
    }

    class Character
    {
        private string name;
        private string baseAttack;
        private string baseHealth;

        public void setName(string name)
        {
            this.name = name;
        }
        public String getName()
        {
            return this.name;
        }

    }

    class FiveStar : Character
    {
        String rarity = "Five Star";
        double dropChance = 0.006;
        public FiveStar(string name)
        {
            setName(name);
        }
        public double getDropChance()
        {
            return this.dropChance;
        }
    }
    class FourStar : Character
    {
        String rarity = "Four Star";
        double dropChance = 0.051;
        public FourStar(string name)
        {
            setName(name);
        }
        public double getDropChance()
        {
            return this.dropChance;
        }
    }
    class ThreeStar : Character
    {
        String rarity = "Five Star";
        double dropChance = 0.943;
        public ThreeStar()
        {
            setName("3Star");
        }
        public double getDropChance()
        {
            return this.dropChance;
        }
    }

}

