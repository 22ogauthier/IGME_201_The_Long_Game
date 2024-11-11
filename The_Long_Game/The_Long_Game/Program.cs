using System;
using System.IO;
using System.Text;

namespace The_Long_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            int score;
            string userName = "";

            //reads in the user's name
            Console.WriteLine("Please enter your name.");
            userName = Console.ReadLine();


            score = LoadData(userName);


            Console.WriteLine("Press keys to increase your score");

            //check for keypress
            //if keypress = enter, quit program
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.ReadKey();
                score++;
                Console.WriteLine("Score: " + score);
            }

            //if enter is pressed, save data and exit program
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Saving data");
                SaveData(score, userName);
                Console.WriteLine("Exiting program");
            }
        }

        //did use ChatGPT to help me learn how to save and read data using the prompt: "How would I use IO and FileStream".
        //did my best to put the code into "my own words"
        public static void SaveData(int score, string userName)
        {
            string fileName = $"{userName}.txt";

            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write)) using (BinaryWriter writer = new BinaryWriter(fileStream))
            {
                writer.Write(score);
                writer.Write(userName);
            }
        }

        public static int LoadData(string username)
        {
            string fileName = $"{username}.txt";
            int score;

            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read)) using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    score = reader.ReadInt32();
                    username = reader.ReadString();
                }

                Console.WriteLine("Data loaded");
                Console.WriteLine("Current Score: " + score);
            }
            else
            {
                score = 0;
            }

            return score;
        }
    }
}
