using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ProjectWeekClaire
{
    class Program
    {
        
        //global
        static Random rGenerator = new Random(); 
        static DateTime loginTime; 

       
        static void Main(string[] args)
        {

            showMenu();
    
            Console.ReadLine();
        }

       
       
       

        //Show main menu
        static void showMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Edit User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. Log In");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    userToevoegen();
                    break;
                case "2":
                    Console.Clear();
                    userBewerken();
                    break;
                case "3":
                    Console.Clear();
                    userVerwijderen();
                    break;
                case "4":
                    Console.Clear();
                    Inloggen(); 
                    break;
            }
        }


        //Show game menu
        static void gameMenu(int balance, string username)
        {
            Console.Clear();
            Console.Write("\nWELCOME ");
            changeColour(ConsoleColor.Blue, $"{username}!\n");
            Console.Write(DateTime.Now.ToString("\ndd/MM/yyyy    HH:mm"));
            Double TotalTimeOnline = Math.Round((DateTime.Now - loginTime).TotalMinutes);
            Console.WriteLine($"   You've been logged in for {TotalTimeOnline} minutes.");
            
            Console.Write("\nYou have ");
            changeColour(ConsoleColor.Green, $"${balance} ");
            Console.WriteLine("left to play with!\n");

            Console.WriteLine("What do you want to do? Choose an option:\n");
            Console.WriteLine("1. Play Blackjack ($10)");
            Console.WriteLine("2. Play Slot Machine ($5)");
            Console.WriteLine("3. Play Memory ($20)");
            Console.WriteLine("4. Log Out");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    BlackJack(balance, username);
                    break;

                case "2":
                    Console.Clear();
                    SlotMachine(balance, username);                 
                    break;
                case "3":
                    Console.Clear();
                    Memory(balance, username);              
                    break;
                case "4":
                    Console.Clear();
                    showMenu();                 
                    break;
            }
        }


        //Memory Game
        static void Memory(int balance, string username)
        {
            string[] memorySymbols = { "☺", "♠", "♣", "♦", "♥", "▲", "Ω", "☺", "♠", "♣", "♦", "♥", "▲", "Ω", "☺", "♠", "♣", "♦", "♥", "▲", "Ω" };
            string[] sequence = new string[9];
            string input;
            string answer;
            string convertedAnswer;
            bool valid = true;

            do
            {
                balance = balance - 20;

                //creates the new sequence
                Console.WriteLine($"\nWelcome to the Memory Game!                                       Balance:£{balance}\n");
               
                for (int i = 1; i <= 9; i++)
                {
                    Console.Write(i + "    ");
                }
                Console.WriteLine("");

                for (int i = 0; i < sequence.Length; i++)
                {
                    sequence[i] = memorySymbols[rGenerator.Next(0, 21)];
                    rightColour(sequence[i]);
                    System.Threading.Thread.Sleep(150);

                }

                Console.WriteLine("\n\nYou have 10 seconds to remember the 9 digit sequence above.\n ");
                System.Threading.Thread.Sleep(10000);
                Console.Clear();


                Console.WriteLine("\nNow write the sequence using the key below. e.g. 173452266 \n");
                Console.WriteLine("Key:  ☺ = 1     ♠ = 2      ♣ = 3      ♦ = 4      ♥ = 5    ▲ = 6     Ω = 7 ");
                


                do
                {

                    Console.Write("\nSequence: ");

                    answer = Console.ReadLine().Replace(" ", "");

                   
                    if (answer.Length != 9 || answer.Contains("8") || answer.Contains("9") || answer.Contains("0") || !Regex.IsMatch(answer, @"^\d+$"))
                    {
                        Console.WriteLine("Your answer must be 9 digits and use numbers 1-7 only. Try again.\n");
                        valid = false;
                    }
                    else
                    {
                        valid = true;
                    }

                } while (!valid);

                convertedAnswer = answer.Replace("1", "☺ ")
                        .Replace("2", "♠   ")
                        .Replace("3", "♣   ")
                        .Replace("4", "♦   ")
                        .Replace("5", "♥   ")
                        .Replace("6", "▲   ")
                        .Replace("7", "Ω   ");
               

                string sequenceString = string.Join(" ", sequence);
                

                Console.Clear();
                Console.WriteLine($"\nYour answer: {convertedAnswer}");
                Console.Write($"\nThe original sequence: ");
                for (int i = 0; i < sequence.Length; i++)
                {
                    rightColour(sequence[i]);
                }

                if (convertedAnswer == sequenceString)
                {
                    balance = balance + 30;
                    Console.WriteLine($"\nCorrect sequence!! You get your $20 back and win $10!                        Balance:£{balance}");

                }
                else
                {
                    Console.WriteLine($"\nWrong! You lose your $20.                                                     Balance:£{balance}");
                }

                Console.WriteLine("\n Do you want to play again? (Y/N)");
                input = Console.ReadLine().ToUpper();

                Console.Clear();

            } while (input == "Y");

            gameMenu(balance, username);

        }



        //Slot Machine 
        static void SlotMachine(int balance, string username)
        {
            int random;
            string[] symbols = { "☺", "♠", "♣", "♦", "♥", "A", "7" };
            string[] fruitMachine = new string[9];
            string answer = "";

            do
            {
                balance = balance - 5;

                Console.WriteLine($"\nWelcome to the Slot Machine!");
                Console.WriteLine("\nGet 3 of the same symbols horizontally or diagonally to win!\n");


                for (int i = 0; i < fruitMachine.Length; i++)
                {
                    random = rGenerator.Next(0, 7);
                    fruitMachine[i] = symbols[random];
                }

                for (int i = 0; i < fruitMachine.Length; i++)
                {

                    if (i==2 || i == 5)
                    {
                        rightColour(fruitMachine[i]);
                        Console.WriteLine("\n");
                        
                    } else
                    {
                        rightColour(fruitMachine[i]);
                       
                    }
                    System.Threading.Thread.Sleep(150);
                }

                System.Threading.Thread.Sleep(1000);
                string symbol;
                int total = 0;
                for (int i = 0; i < fruitMachine.Length; i++)
                {
                    //checks for horizontal rows and returns money won
                    if (i == 0 || i == 3 || i == 6)
                    {
                        if (fruitMachine[i] == fruitMachine[i + 1] && fruitMachine[i + 1] == fruitMachine[i + 2])
                        {
                            symbol = fruitMachine[i];
                            total = symbolCheck(symbol, total, balance);


                        }
                    }
                    //checks for diagonal rows and returns money won
                    if (i == 0 || i == 7)
                    {
                        if (i == 0)
                        {
                            if (fruitMachine[i] == fruitMachine[i + 4] && fruitMachine[i + 4] == fruitMachine[i + 8])
                            {
                                symbol = fruitMachine[i];
                                total = symbolCheck(symbol, total, balance);
                            }
                        }
                        if (i == 6)
                        {
                            if (fruitMachine[i] == fruitMachine[i - 2] && fruitMachine[i - 2] == fruitMachine[i + 4])
                            {
                                symbol = fruitMachine[i];
                                total = symbolCheck(symbol, total, balance);
                            }
                        }
                    }
                }
                //checks if no rows/no money returned
                if (total == 0)
                {
                    Console.WriteLine($"\n\nNo rows! Sorry you lose your $5.");
                    Console.WriteLine($"\nBalance: ${balance}");
                }

                balance = balance + total;

                Console.WriteLine("\nDo you want to play again?");
                answer = Console.ReadLine().ToUpper();

                Console.Clear();



            } while (answer == "Y");


            gameMenu(balance, username);


        }


        //Check symbols to calculate money
        static int symbolCheck(string symbol, int total, int balance)
        {
            switch (symbol)
            {
                case "☺":
                    total = total + 3 + 5;
                    balance = balance + total;
                    Console.WriteLine($"You win $3 and get your $5 back!!");
                    Console.WriteLine($"\nBalance: ${balance}");
                    break;
                case "♠":
                    total = total + 5 + 5;
                    balance = balance + total;
                    Console.WriteLine($"You win $5 and get your $5 back!!");
                    Console.WriteLine($"\nBalance: ${balance}");
                    break;
                case "♣":

                    total = total + 7 + 5;
                    balance = balance + total;
                    Console.WriteLine($"You win $7 and get your $5 back!!");
                    Console.WriteLine($"\nBalance: ${balance}");
                    break;
                case "♦":

                    total = total + 10 + 5;
                    balance = balance + total;
                    Console.WriteLine($"You win $10 and get your $5 back!!");
                    Console.WriteLine($"\nBalance: ${balance}");
                    break;
                case "♥":

                    total = total + 20 + 5;
                    balance = balance + total;
                    Console.WriteLine($"You win $20 and get your $5 back!!");
                    Console.WriteLine($"\nBalance: ${balance}");
                    break;
                case "A":

                    total = total + 50 + 5;
                    balance = balance + total;
                    Console.WriteLine($"You win $50 and get your $5 back!!");
                    Console.WriteLine($"\nBalance: ${balance}");
                    break;
                case "7":

                    total = total + 100 + 5;
                    balance = balance + total;
                    Console.WriteLine($"You win $100 and get your $5 back!");
                    Console.WriteLine($"\nBalance: ${balance}");
                    break;
            }
            return total;

        }



        //Blackjack
        static void BlackJack(int balance, string username)
        {
            string[] kaarten = { "A♥", "2♥", "3♥", "4♥", "5♥", "6♥", "7♥", "8♥", "9♥", "10♥", "J♥", "Q♥", "K♥",
                "A♦", "2♦", "3♦", "4♦", "5♦", "6♦", "7♦", "8♦", "9♦", "10♦", "J♦", "Q♦", "K♦",
            "A♣", "2♣", "3♣", "4♣", "5♣", "6♣", "7♣", "8♣", "9♣", "10♣", "J♣", "Q♣", "K♣",
            "A♠", "2♠", "3♠", "4♠", "5♠", "6♠", "7♠", "8♠", "9♠", "10♠", "J♠", "Q♠", "K♠"};

            int[] values = {11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,
            11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,
            11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,
            11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,};

            //variables 
            string spelerCurrentHand;
            string dealerCurrentHand = "";
            int spelerTotal;
            int dealerTotal = 0;
            string choice = "";
            List<int> cardsDrawn = new List<int>();  
            string keepPlaying;

            
            Console.WriteLine($"\nWelcome to Blackjack!");                               
            Console.WriteLine("\nThe game will start in 10 seconds.");
            Console.WriteLine("\nYou will get 2 starting cards in your hand.");
            Console.WriteLine("\nKeep drawing cards to get as close to 21 as possible.");
            Console.WriteLine("\nBut don't go over 21 or you'll lose!");
            Console.WriteLine("\nTo draw a card press D, to stop drawing press S.");
            System.Threading.Thread.Sleep(10000);
            Console.Clear();



            do {
                //reset values
                spelerCurrentHand = "";
                cardsDrawn.Clear();
                balance = balance - 10;
                choice = "";
                dealerTotal = 0;

                Console.WriteLine($"Balance: ${balance}");
                for (int i = 0; i < 2; i++)
                {
                    int randomNumber = rGenerator.Next(0, 52);
                    spelerCurrentHand = spelerCurrentHand + kaarten[randomNumber] + "    ";
                    cardsDrawn.Add(values[randomNumber]);
                }

                spelerTotal = cardsDrawn.Sum();
                Console.WriteLine($"\n{spelerCurrentHand}                                 Total:{spelerTotal}");


                if (spelerTotal == 21)
                {
                    balance = balance + 25;
                    Console.WriteLine($"Balance: ${balance}");
                    Console.WriteLine($"\nWow! Your first 2 cards total 21. You win $25!");
                    
                }

                
                while (spelerTotal < 21 && choice != "S")
                {
                    Console.Write("\nDraw(D)/Stop(S):");
                    choice = Console.ReadLine().ToUpper();

                    if (choice == "D")
                    {
                        Console.Clear();
                        Console.WriteLine($"Balance: ${balance}");
                        int randomNumber = rGenerator.Next(0, 52);
                        spelerCurrentHand = spelerCurrentHand + kaarten[randomNumber] + "    ";
                        cardsDrawn.Add(values[randomNumber]);
                        spelerTotal = cardsDrawn.Sum();
                        if (spelerTotal > 21)
                        {
                            for (int i = 0; i < cardsDrawn.Count; i++)
                            {
                                if (cardsDrawn[i] == 11)
                                {
                                    cardsDrawn[i] = 1;
                                }
                            }
                            spelerTotal = cardsDrawn.Sum();
                        }
                        Console.WriteLine($"\n{spelerCurrentHand}                          Total:{spelerTotal}");
                    }
                    if (choice == "S")
                    {
                        Console.WriteLine("\nNow the dealer will draw.");
                        dealerTotal = dealersTurn(dealerTotal, dealerCurrentHand, kaarten, values, balance);

                    }

                }

                if (spelerTotal == 21)
                {
                    Console.WriteLine($"\nW0W 21! Now it's the dealer's turn to draw.");
                    dealerTotal = dealersTurn(dealerTotal, dealerCurrentHand, kaarten, values, balance);
                }
                if (spelerTotal > 21)
                {
                    Console.WriteLine($"\nYou have gone bust!");
                }


                

               
                if (spelerTotal > 21)
                {
                    
                    Console.WriteLine($"\nYou Lose! You don't get your $10 back.");

                }
                else if (spelerTotal <= 21 && (spelerTotal > dealerTotal || dealerTotal > 21))
                {
                    balance = balance + 30;
                    Console.WriteLine("\nYour final score: ");
                    Console.WriteLine($"{spelerCurrentHand}                         Total:{spelerTotal}");
                    Console.WriteLine($"\nYou win! You receive $20 and your $10 back!");
                    Console.WriteLine($"\nBalance: ${balance}");


                }
                else if (spelerTotal < dealerTotal && dealerTotal <= 21)
                {
                    
                    Console.WriteLine("\nYour final score: ");
                    Console.WriteLine($"{spelerCurrentHand}                         Total:{spelerTotal}");
                    Console.WriteLine($"\nYou lose! The dealer has more and you lose your $10.");
                    Console.WriteLine($"\nBalance: ${balance}");


                }
                else if (spelerTotal == dealerTotal)
                {
                    balance = balance + 10;
                    
                    Console.WriteLine("\nYour final score: ");
                    Console.WriteLine($"{spelerCurrentHand}                         Total:{spelerTotal}");
                    Console.WriteLine($"\nIt's a draw between you and the dealer! You get your $10 back!");
                    Console.WriteLine($"\nBalance: ${balance}");

                }

                Console.WriteLine("\nDo you want to play again?");
                keepPlaying = Console.ReadLine().ToUpper();

                Console.Clear();

            } while (keepPlaying == "Y");

            gameMenu(balance, username);
        }


        //Dealer's turn
        static int dealersTurn(int dealerTotal, string dealerCurrentHand, string[] kaarten, int[] values, int balance)
        {
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            while (dealerTotal < 17)
            {
                Console.WriteLine($"Balance: ${balance}");
                int randomNumber = rGenerator.Next(0, 52);
                dealerCurrentHand = dealerCurrentHand + kaarten[randomNumber] + "    ";
                dealerTotal = dealerTotal + values[randomNumber];
                Console.WriteLine($"\n{dealerCurrentHand}                        Total:{dealerTotal}");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
            Console.WriteLine("The dealer's final score: ");
            Console.WriteLine($"{dealerCurrentHand}                              Total:{dealerTotal}");
            return dealerTotal;
        }


        //Add a user
        static void userToevoegen()
        {
            Console.WriteLine("\nChoose a username. Use letters and numbers only.");
            Console.Write("\nUsername:");
            string userName = Console.ReadLine();
            Regex userPattern = new Regex(@"^[a-zA-Z0-9]+$");
            if (userPattern.IsMatch(userName))
            {
                
                string path = "../../data.txt";
                string returnedUserDetails = searchFile(userName, path);
                if (!String.IsNullOrEmpty(returnedUserDetails))
                {
                    Console.WriteLine("This username is already in use. Choose another one.");
                    userToevoegen();
                }

                bool valid = false;
                while (!valid)
                {
                    Console.WriteLine("\nChoose a password. Your password must have: \n1 capital letter \n1 lowercase letter \n1 number \n1 symbol \n8-20 characters");
                    Console.Write("\nPassword:");
                    string password = Console.ReadLine();
                    
                    if (validatePassword(password))
                    {
                        changeColour(ConsoleColor.Green,"Valid password.");
                        valid = true;
                        string encryptedPassword = Encrypt(password);
                        writeToFile(userName, encryptedPassword);
                    }
                    else
                    {
                    changeColour(ConsoleColor.Red,"Invalid password!");
                    }
                }

            } else
            {
                changeColour(ConsoleColor.Red, "Invalid username!");
                userToevoegen();
            }
        }


        //Delete a user
        static void userVerwijderen()
        {
            Console.WriteLine("Give the name of the user you want to delete.");
            Console.WriteLine("Username:");
            string userName = Console.ReadLine();
            string path = "../../data.txt";
            string returnedUserDetails = searchFile(userName, path);
            if (!String.IsNullOrEmpty(returnedUserDetails)) 
            {
                Console.WriteLine("Give the correct password to delete the user.");

                if (passwordMatch(returnedUserDetails, userName))
                {
                    
                    string[] allUsersArray = File.ReadAllLines("../../data.txt"); //ReadAllLines returns an array
                    List<string> allUsersList = allUsersArray.OfType<string>().ToList(); //changed to a list so can more easily remove an item
                    int index = allUsersList.IndexOf(returnedUserDetails);
                    allUsersList.RemoveAt(index);

                    using (StreamWriter writer = new StreamWriter("../../data.txt"))
                    {
                        for (int i = 0; i < allUsersList.Count; i++)
                        {
                            writer.WriteLine(allUsersList[i]);    // writes the left items in list once it has been removed to the text file  - should be gone 
                        }
                    }

                    Console.WriteLine("This user has been successfully deleted.");
                    System.Threading.Thread.Sleep(3000);
                    showMenu();
                }
                else
                {
                    Console.WriteLine("Incorrect password. User cannot be deleted.");
                    System.Threading.Thread.Sleep(3000);
                    showMenu();
                }
            }
            else
            {
                Console.WriteLine("This username is not recognised. Try again.");
                userVerwijderen();
            }
        }

        
        //Log in 
        static void Inloggen()
        {
            Console.Write("\nUsername:");
            string userName = Console.ReadLine().ToLower();
            string returnedUserDetails = searchFile(userName, "../../data.txt");
            if (!String.IsNullOrEmpty(returnedUserDetails))
            {
                if (passwordMatch(returnedUserDetails, userName))
                {
                    loginTime = DateTime.Now;
                    gameMenu(200, userName);
                }
                else
                {
                    Console.WriteLine("\nThe password for this user was incorrect. Try entering your username and password again.");
                    Inloggen();
                }
            }
            else
            {
                Console.WriteLine("\nThis username is not recognised. Try again.");
                Inloggen();
            }
           
        }

        

        //Edit a username and password  
        static void userBewerken()
        {
            Console.WriteLine("Give your current username or password.");
            Console.Write("Current username:");
            string userName = Console.ReadLine().ToLower();
            string path = "../../data.txt";
            string currentUserDetails = searchFile(userName,path);
            if (!String.IsNullOrEmpty(currentUserDetails))
            {
                Console.Write("Current ");
                if (passwordMatch(currentUserDetails, userName))
                {
                    Console.WriteLine("Choose a new username. Use letters and numbers only.");   
                    Console.WriteLine("New username:");
                    string newUserName = Console.ReadLine();
                    Regex userPattern = new Regex(@"^[a-zA-Z0-9]+$");
                    if (userPattern.IsMatch(newUserName))
                    {
                        string returnedUserDetails = searchFile(newUserName, path);
                        if (!String.IsNullOrEmpty(returnedUserDetails))
                        {
                            Console.WriteLine("Username already in use. Try again.");
                            userBewerken();
                        }

                        bool valid = false;
                        while (!valid)
                        {
                            Console.WriteLine("\nChoose a password.Your password must have: \n1 capital letter \n1 lowercase letter \n1 number \n1 symbol \n8 - 20 characters");
                            Console.WriteLine("Password:");
                            string newPassword = Console.ReadLine();
                            if (validatePassword(newPassword))
                            {
                                changeColour(ConsoleColor.Green, "\nValid password!");
                                valid = true;
                                string newEncryptedPassword = Encrypt(newPassword);
                                string newUserDetails = $"{newUserName}#{newEncryptedPassword}";
                                ReplaceUserDetails(currentUserDetails, newUserDetails);
                                Console.WriteLine("\nYour username and password have been successfully changed.");
                                Console.WriteLine("Now you can log in with these new details.");
                                System.Threading.Thread.Sleep(3000);
                                showMenu();
                            }
                            else
                            {
                                changeColour(ConsoleColor.Red, "Invalid password!");
                            }
                        }

                    }
                    else
                    {
                        changeColour(ConsoleColor.Red, "Invalid username! Try again.");
                        userBewerken();
                    }
                } else
                {
                    Console.WriteLine("\nThe password for this user was incorrect. Try entering your username and password again.");
                    userBewerken();
                }

            } else
            {
                Console.WriteLine("\nThis username is not recognised. Try again.");
                userBewerken();
            }   
            
        }


      
        //Write to file (append)
        static void writeToFile(string userName, string password)
        {
            string path = "../../data.txt"; //will this path work on other computers?
            using (StreamWriter writer = new StreamWriter(path, true)) // 2nd parameter: false = overwrites text and true = appends text
            {
                string userDetails = $"{userName}#{password}";
                writer.WriteLine(userDetails);
            } 
            Console.WriteLine("\nYour username and password have been saved. Now you can log in.");
            System.Threading.Thread.Sleep(3000);
            showMenu();
        }



       //Replace/Edit user details 
         static void ReplaceUserDetails(string currentDetails, string newDetails)
         {
            string dataText;
            using (StreamReader reader = new StreamReader("../../data.txt"))
            {
                dataText = reader.ReadToEnd();
                
            }
            string newText = dataText.Replace(currentDetails, newDetails);
            File.WriteAllText("../../data.txt", newText); 
                
        }



        //Search File for Username
        static string searchFile(string username, string path)
        {
            string userDetails = "";
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Contains(username))
                    {
                        string[] split = line.Split('#');
                        if (split[0] == username)
                        {
                            userDetails = line;
                        }
                        
                        break;
                    }
                    else if (reader.EndOfStream)
                    {

                        userDetails = "";

                    }

                }

            }
            return userDetails;
        }


        //validate password (requirements/length)
        static bool validatePassword(string password)
        {

            string specialCharacters = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

            if (password.Any(char.IsDigit) && password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(letter => specialCharacters.Contains(letter)) && password.Length >= 8 && password.Length <= 20) 
            {                                                                                              //iterates over each letter and checks if the letter contains one of the special characters
                return true;
            }
            else
            {
                return false;
            }
        }          



        //Check username matches password 
        static bool passwordMatch(string userdetails, string username)  
        {
            
            Console.Write("Password:");
            string password = Console.ReadLine();
            string[] subs = userdetails.Split('#');
            string decryptedPassword = Decrypt(subs[1]);
            if (username == subs[0] && password == decryptedPassword)
             {
                return true;
             } 
            else 
             {
                return false;
             }
        }


        //Encrypt 
        static string Encrypt(string password)   
            {
                char[] passwordAsChars = password.ToCharArray();
                for (int i = 0; i < passwordAsChars.Length; i++)
                {
                    passwordAsChars[i]++;
                }
                string encryptedPassword = new string(passwordAsChars);
                return encryptedPassword;
            }


        //Decrypt
        static string Decrypt(string password)
            {
                char[] passwordAsChars = password.ToCharArray();
                for (int i = 0; i < passwordAsChars.Length; i++)
                {
                    passwordAsChars[i]--;
                }
                string decryptedPassword = new string(passwordAsChars);
                return decryptedPassword;
            }


        //Change colour 
        public static void changeColour (ConsoleColor colour, string text)
        {
            ConsoleColor originalColour = Console.ForegroundColor;
            Console.ForegroundColor = colour;
            Console.Write(text);
            Console.ForegroundColor = originalColour;
        }

        
        // determines colour of symbols before printing
        public static void rightColour(string symbol)
        {
            switch (symbol)
            {
                case "☺": changeColour(ConsoleColor.Yellow, "☺    ");break;
                case "♠": changeColour(ConsoleColor.Blue, "♠    "); break;
                case "♣": changeColour(ConsoleColor.Green, "♣    "); break;
                case "♦": changeColour(ConsoleColor.Red, "♦    "); break;
                case "♥": changeColour(ConsoleColor.DarkRed, "♥    "); break;
                case "A": changeColour(ConsoleColor.DarkBlue, "A    "); break;
                case "7": changeColour(ConsoleColor.DarkGreen, "7    "); break;
                case "▲": changeColour(ConsoleColor.White, "▲    "); break;
                case "Ω": changeColour(ConsoleColor.Cyan, "Ω    "); break;
            }
        }



    }
}

