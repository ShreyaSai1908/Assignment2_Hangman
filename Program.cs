using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Assignment2_Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            int guessCounter = 0;
            int guessType = 0;
            int secretWordPicker = 0;
            int secretWordLenght = 0;
            int i = 0;
            int hit = 0;
            int repeatedGuess = 0;
            int gamePoint = 0;

            String[] secretWordList = { "forest", "hicking", "lagoon", "river", "mountains" };
            char[] secretWord;
            char[] usrGuessWord;


            StringBuilder incorrectLetters = new StringBuilder();

            secretWordPicker = RandomNumberGenerator.GetInt32(5);
            secretWord = secretWordList[secretWordPicker].ToCharArray();
            usrGuessWord = secretWordList[secretWordPicker].ToCharArray();

            foreach (char c in secretWord)
            {
                secretWordLenght++;
            }

            for (i = 0; i < secretWordLenght; i++)
            {
                usrGuessWord[i] = '_';
            }

            /*
            Console.WriteLine("Secret Word");
            for (i = 0; i < secretWordLenght; i++)
            {
                Console.Write(secretWord[i] + "\t");
            }
            
            Console.WriteLine();
            
            Console.WriteLine("UserGuess Word");            
            for (i = 0; i < secretWordLenght; i++)
            {
               Console.Write(usrGuessWord[i] + "\t");
            }
            */
            Console.WriteLine();
            Console.WriteLine("Do you want to guess:");
            Console.WriteLine("(1) One letter at a time");
            Console.WriteLine("(2) Whole word");
            Console.Write("Your Choice ( 1 or 2 ):");
            guessType = Convert.ToInt32(Console.ReadLine());

            if (guessType == 1)
            {
                //GuessLetters
                while (gamePoint < secretWordLenght && guessCounter < 10)
                {
                    hit = 0;
                    repeatedGuess = 0;
                    char usrGuess = '_';
                    Console.Write("Guess a Letter:");
                    usrGuess = Convert.ToChar(Console.ReadLine());

                    for (i = 0; i < secretWordLenght; i++)
                    {
                        if (secretWord[i] == usrGuess)
                        {
                            if (usrGuessWord[i] == usrGuess)
                            {
                                repeatedGuess = -111;
                                hit = -393;
                            }
                            else
                            {
                                usrGuessWord[i] = usrGuess;
                                hit = -393;
                                gamePoint++;
                            }                            
                        }
                        
                    }

                    if (incorrectLetters.ToString().Contains(usrGuess))
                    {
                        repeatedGuess = -111;
                    }
                    

                    if (hit != -393 && repeatedGuess != -111)
                    {
                        incorrectLetters.Append(usrGuess);
                    }
                    
                    if (repeatedGuess != -111)
                    {
                        guessCounter++;
                    }

                    //Results after every guess
                    Console.WriteLine("--------------------------------------------------------");
                    Console.Write("Your Guess " + guessCounter + ":");
                    for (i = 0; i < secretWordLenght; i++)
                    {
                        Console.Write(usrGuessWord[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Incorrect Guess:" + incorrectLetters);
                    Console.WriteLine("Game Point:" + gamePoint);
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                //GuessWords
                String tmpSecretWord = new String(secretWord);
                String tmpUsrGuessWord = new String(usrGuessWord);
                guessCounter = 0;

                while (guessCounter < 10)
                {
                    Console.Write("Guess the word:");
                    tmpUsrGuessWord = Console.ReadLine();

                    if (tmpSecretWord.CompareTo(tmpUsrGuessWord) == 0)
                    {
                        Console.WriteLine("Whooooooaaaaaaaaa!");
                        break;
                    }

                    guessCounter++;
                    Console.WriteLine("Guess count:" + guessCounter);
                }
            }


        }
    }
}
