using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace hangman1
{
    class Hangman
    {
        string word;
        StringBuilder stringBuilder;
        int lives = 10;
        bool keepLooping = true;

        public void Update()
        {
            List<string> wordList = PopulateList();
                       
            while (keepLooping)
                
            {
                word = "";
                stringBuilder = new StringBuilder();
                lives = 10;
                
                                
                Console.WriteLine("Wanna Play A Game?");
                
                 
                WordPicker(wordList);

                StringBuilder guesses = new StringBuilder();

                bool gameOver = false;

                while (!gameOver)
                {
                    string input = Console.ReadLine().ToUpper();

                    if (!guesses.ToString().Contains(input))
                    {
                        if (input.Length > 1)
                        {
                            if (input == word.ToUpper())
                            {
                                Console.WriteLine("Congratulations!");
                                gameOver = true;
                                Continue();
                            }
                            else
                            {
                                lives--;
                                if (lives == 0)
                                {
                                    Console.WriteLine("Game Over");
                                    gameOver = true;
                                    Continue();
                                }
                            }
                            
                        }                  
                        if (word.Contains(input))
                        {
                            
                            char guess = char.Parse(input);
                            for (int i = 0; i < word.Length; i++)
                            {
                                if (guess == word[i])
                                {
                                    stringBuilder[i] = word[i];
                                }
                            }
                            if (!stringBuilder.ToString().Contains("_"))
                            {
                                Console.WriteLine("Congratulations!");
                                gameOver = true;
                                Continue();
                            }


                        }
                        else
                        {
                            
                            lives -- ;  
                            if (lives == 0)
                            {
                                Console.WriteLine("Game Over");
                                gameOver = true;
                                Continue();

                            }
                        }
                        if (!gameOver)
                        {
                            Console.WriteLine("\n");
                            guesses.Append(input);
                            Console.WriteLine(stringBuilder.ToString());
                            Console.WriteLine(guesses);
                            Console.WriteLine(lives);
                        }
                        

                    Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("letter already guessed!");
                        Console.WriteLine("\n");
                    }
                                        
                }
               
            }


        }
        List<String> PopulateList()
        {
            List<String> wordList = new List<String>();
            wordList.Add("Tree");
            wordList.Add("House");
            wordList.Add("ball");
            wordList.Add("Hand");
            wordList.Add("Wheel");
            wordList.Add("Sun");
            wordList.Add("Moon");
            wordList.Add("Money");
            wordList.Add("Cup");
            wordList.Add("Night");
            wordList.Add("Day");
            wordList.Add("Key");

            return wordList;
        }
        void WordPicker(List<String> wordList)
        {
            Random randGen = new Random();
             word = wordList[randGen.Next(0, wordList.Count - 1)];
             stringBuilder = new StringBuilder();
            int wordLength = word.Length;
            for (int i = 0; i < wordLength; i++)
            {
                stringBuilder.Append("_");
            }
            Console.WriteLine(stringBuilder.ToString());
        }
        void Continue()
        {
            Console.WriteLine("Continue? (Y/N)");
            string Choice = Console.ReadLine().ToUpper();
            if (Choice == "Y")
            {
                Console.WriteLine("Hangman will continue");
                
            }
            else if (Choice == "N")
            {
                Console.WriteLine("Exiting");
                keepLooping = false;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Hangman hangman = new Hangman();
            hangman.Update();
        }
    }
}
