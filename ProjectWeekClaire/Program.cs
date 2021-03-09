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

        static Random rGenerator = new Random();

        //questions  - bewerken? encrypting ++? balance as global variable? regex order problem? alt-codes?
        static void Main(string[] args)
        {
        
         
           

            //showMenu();

            int balance = 200; //to make global  - pass it through as parameter 




            /* BLACKJACK GAME

            string[] kaarten = { "A♥", "2♥", "3♥", "4♥", "5♥", "6♥", "7♥", "8♥", "9♥", "10♥", "J♥", "Q♥", "K♥",
                "A♦", "2♦", "3♦", "4♦", "5♦", "6♦", "7♦", "8♦", "9♦", "10♦", "J♦", "Q♦", "K♦",
            "A♣", "2♣", "3♣", "4♣", "5♣", "6♣", "7♣", "8♣", "9♣", "10♣", "J♣", "Q♣", "K♣",
            "A♠", "2♠", "3♠", "4♠", "5♠", "6♠", "7♠", "8♠", "9♠", "10♠", "J♠", "Q♠", "K♠"};

            int[] values = {11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,
            11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,
            11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,
            11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,};

            //variables 
            string spelerCurrentHand = "";
            string dealerCurrentHand = "";
            int spelerTotal = 0;
            int dealerTotal = 0;
            string choice = "";
            List<int> cardsDrawn = new List<int>();  //list because don't know how long it will be in advance 
            

            balance = balance - 10;

            //instructions
            Console.WriteLine("Welcome to Blackjack!         To draw a card press D, to stop drawing press S \n");

            /*Console.WriteLine("A blackjack pot costs $10.");
            Console.WriteLine("The goal is to beat the dealer. Whoever scores the highest number closest to 21 wins!");
            Console.WriteLine("If your total is greater than 21 you lose!");
            Console.WriteLine("You can choose to keep drawing(d) or stop!(s)");

           

            Console.WriteLine("Your starting hand: \n");


            for (int i = 0; i < 2; i++)
            {
                int randomNumber = rGenerator.Next(0, 52);
                spelerCurrentHand = spelerCurrentHand + kaarten[randomNumber] + "    ";
                cardsDrawn.Add(values[randomNumber]); 
            }
            
            spelerTotal = cardsDrawn.Sum();
            Console.WriteLine($"{spelerCurrentHand}                                 Total:{spelerTotal} \n"); 


            if (spelerTotal == 21)
            {
                Console.WriteLine("Wow! Your first 2 cards total 21. You win $25!");
                balance = balance + 25;
            }


            while (spelerTotal < 21 && choice != "S")
            {
                Console.Write("Draw(D)/Stop(S):");
                choice = Console.ReadLine().ToUpper();

                if (choice == "D")
                {
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
                    Console.WriteLine($"{spelerCurrentHand}                          Total:{spelerTotal}");
                }
                if (choice == "S")
                {
                    Console.WriteLine($"You have stopped. Your final total is {spelerTotal}");
                    dealerTotal = dealersTurn(dealerTotal, dealerCurrentHand, kaarten, values);

                }
              
            }

            if (spelerTotal >= 21)
            {
                Console.WriteLine($"Your total has reached 21 or over. Your final total is {spelerTotal}");
                dealerTotal = dealersTurn(dealerTotal, dealerCurrentHand, kaarten, values);
            }




            //check rules again in document 
            if (spelerTotal > 21 && dealerTotal <= 21)
            {
                Console.WriteLine("You Lose! You have more than 21.");

            } else if (spelerTotal <= 21 && (spelerTotal > dealerTotal || dealerTotal > 21))
            {
                Console.WriteLine("You win! You receive $20 and your $10 back!"); //? + 20 or 30
                balance = balance + 30;

            } else if (spelerTotal < dealerTotal && dealerTotal <= 21)
            {
                Console.WriteLine("You lose! The dealer has more.");

            } else if (spelerTotal == dealerTotal || (dealerTotal > 21 && spelerTotal > 21))
            {
                Console.WriteLine("It's a draw between you and the dealer! You both have more than 21.");
                Console.WriteLine("You get your $10 back!");  // is this needed? 
                balance = balance + 10;
            }

            
            gameMenu(balance);

            */

            // Fruit machine 
            //Random rnd = new Random();
            //string[] MyRandomArray = MyArray.OrderBy(x => rnd.Next()).ToArray();



            int random;

           

            string[] symbols = {"☺", "♠", "♣", "♦", "♥", "A", "7"};

            string[] fruitMachine = new string[9];

            
            
            string answer = "";
            do
            {
                balance = balance - 5;

                Console.WriteLine($"Welcome to the Slot Machine!");
                Console.WriteLine("Get 3 of the same symbols horizontally or diagonally to win!");

               
                for (int i = 0; i < fruitMachine.Length; i++)
                {
                    random = rGenerator.Next(0, 7);
                    fruitMachine[i] = symbols[random]; 
                }

                /*for (int i = 0; i < fruitMachine.Length; i++)
                { 
                    Console.Clear();
                    Console.WriteLine($"{fruitMachine[i]} {fruitMachine[i+1]} {fruitMachine[i+2]}");
                }*/
                
                
                Console.WriteLine($"{fruitMachine[0]} {fruitMachine[1]} {fruitMachine[2]}");

                Console.WriteLine($"{fruitMachine[3]} {fruitMachine[4]} {fruitMachine[5]}");

                Console.WriteLine($"{fruitMachine[6]} {fruitMachine[7]} {fruitMachine[8]}");


                string symbol;
                int total = 0;
                for (int i = 0; i < fruitMachine.Length; i++)
                {
                    //check for horizontal rows and update total
                    if (i == 0 || i == 3 || i == 6)
                    {
                        if (fruitMachine[i] == fruitMachine[i+1] && fruitMachine[i+1] == fruitMachine[i + 2])
                        {
                            symbol = fruitMachine[i];
                            total = symbolCheck(symbol, total, balance);
                            

                        }
                    }
                    //check for diagonal rows and update total
                    if (i == 0 || i == 7)
                    {
                        if (i == 0)
                        {
                            if (fruitMachine[i] == fruitMachine[i + 4] && fruitMachine[i+4] == fruitMachine[i + 8])
                            {
                                symbol = fruitMachine[i];
                                total = symbolCheck(symbol,total, balance);
                            }
                        }
                        if (i == 6)
                        {
                            if (fruitMachine[i] == fruitMachine[i -2] && fruitMachine[i - 2] == fruitMachine[i + 4])
                            {
                                symbol = fruitMachine[i];
                                total = symbolCheck(symbol, total, balance);
                            }
                        }
                    }
                }
                //check if no rows
                if (total == 0)
                {
                    Console.WriteLine($"No rows! Sorry you lose your $5.             Your balance: {balance}");
                }

                balance = balance + total;

                Console.WriteLine("Do you want to play again?");
                answer = Console.ReadLine().ToUpper();

                Console.Clear(); 

                

            } while (answer == "Y");


            gameMenu(balance);






















            Console.ReadLine();
        }




        //METHODS 

        //Main menu


        static int dealersTurn(int dealerTotal, string dealerCurrentHand, string[] kaarten, int[] values)
        {
           
            while (dealerTotal < 17)
            {
                int randomNumber = rGenerator.Next(0, 52);
                dealerCurrentHand = dealerCurrentHand + kaarten[randomNumber] + "    ";
                dealerTotal = dealerTotal + values[randomNumber];
                Console.WriteLine($"{dealerCurrentHand}                            Total:{dealerTotal}");
                
            }

            Console.WriteLine("The dealer's final score: ");
            Console.WriteLine($"{dealerCurrentHand}                                Total:{dealerTotal}");
            return dealerTotal;
        }


        static int symbolCheck(string symbol, int total, int balance)
        {
            switch (symbol)
            {
                case "☺":
                    total = total + 3;
                    balance = balance + total;
                    Console.WriteLine($"You win $3                    Your balance: {balance}");
                    break;
                case "♠":
                    total = total + 5;
                    balance = balance + total;
                    Console.WriteLine($"You win $5                    Your balance: {balance} ");
                    break;
                case "♣":
                   
                    total = total + 7;
                    balance = balance + total;
                    Console.WriteLine($"You win $7                    Your balance: {balance}");
                    break;
                case "♦":
                    
                    total = total + 10;
                    balance = balance + total;
                    Console.WriteLine($"You win $10                   Your balance: {balance}");
                    break;
                case "♥":
                    
                    total = total + 20;
                    balance = balance + total;
                    Console.WriteLine($"You win $20                   Your balance: {balance}");
                    break;
                case "A":
                    
                    total = total + 50;
                    balance = balance + total;
                    Console.WriteLine($"You win $50                   Your balance: {balance}");
                    break;
                case "7":
                    
                    total = total + 100;
                    balance = balance + total;
                    Console.WriteLine($"You win $100                  Your balance: {balance}");
                    break;
            }
            return total;

        }

        static void showMenu()
        {

            Console.WriteLine("Wat wil je doen? Kies een nummer:");
            Console.WriteLine("1. Gebruiker toevogen");
            Console.WriteLine("2. Gebruiker bewerken");
            Console.WriteLine("3. Gebruiker verwijderen");
            Console.WriteLine("4. Inloggen");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1": userToevoegen(); break;
                case "2": userBewerken(); break;
                case "3": userVerwijderen(); break;
                case "4": Inloggen(); break;
            }
        }



        //show game menu
        static void gameMenu(int balance =200, string username = "Unknown user")
        {
           
            Console.WriteLine($"WELCOME {username}   :)");
            //Console.WriteLine($"{date}, {time}   Je bent {length} ingelogd.");
            Console.WriteLine($"Je hebt nu ${balance} om me te spelen!");
            Console.WriteLine("Wat wil je doen? Kies een optie:");
            Console.WriteLine("1. Play Blackjack");
            Console.WriteLine("2. Play slot machine");
            Console.WriteLine("3. Play memory");
            Console.WriteLine("4. Uitloggen");


        }






        //Add a user
        static void userToevoegen()
        {
            Console.WriteLine("Kies een username. Gebruik alleen maar cijfers en letters.");
            Console.WriteLine("Username:");
            string userName = Console.ReadLine();
            Regex userPattern = new Regex(@"^[a-zA-Z0-9]+$");
            if (userPattern.IsMatch(userName))
            {
                Console.WriteLine("Valid Username!");
                string path = @"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt";
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.Contains(userName))
                        {
                            Console.WriteLine("Deze username in al in gebruik. Kies een andere username.");
                            userToevoegen();
                        }
                    }
                }

                bool valid = false;
                while (!valid)
                {
                    Console.WriteLine("Kies een password. Gebruik het volgende: \n  - 1 hoofdletter \n  - 1 kleine letter \n - 1 cijfer \n - 1 vreemd teken \n -8-20 characters");
                    Console.WriteLine("Password:");
                    string password = Console.ReadLine();
                    Regex passwordPattern = new Regex(@"[a-z]+[A-Z]+[0-9]+[^a-zA-Z0-9]+");// only working in this order - how to change??? can you check length with reg ex   At least one special character [*.!@#$%^&(){}[]:;<>,.?/~_+-=|\]
                    //change to  if password.Any(char klein) && pasword.Any(char hoofd) && password.Any(int number) && regex for symbols only  - then it can be in any order 
                    
                    if (passwordPattern.IsMatch(password) && password.Length >= 8 && password.Length <= 20)
                    {
                        Console.WriteLine("Valid password!");
                        valid = true;
                        string encryptedPassword = Encrypt(password);
                        writeToFile(userName, encryptedPassword);
                    }
                    else
                    {
                        Console.WriteLine("Invalid password. De voorwaarden zijn: \n  - 1 hoofdletter \n  - 1 kleine letter \n - 1 cijfer \n - 1 vreemd teken \n -8-20 characters \n Kies een andere password.");
                    }
                }

            } else
            {
                Console.WriteLine("Invalid username! Use letters and numbers only. Kies een andere user name.");
                userToevoegen();
            }
        }


        //Delete a user
        static void userVerwijderen()
        {
            Console.WriteLine("Geef de naam van de gebruiker dat je wil verwijderen.");
            Console.WriteLine("Username:");
            string userName = Console.ReadLine();
            string path = @"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt";
            string returnedUserDetails = searchFile(userName, path);
            if (!String.IsNullOrEmpty(returnedUserDetails)) 
            {
                Console.WriteLine("Geef de juiste wachtwoord in om deze gebruiker te verwijderen.");

                if (passwordMatch(returnedUserDetails, userName))
                {
                    
                    string[] allUsersArray = File.ReadAllLines(@"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt"); //ReadAllLines returns an array
                    List<string> allUsersList = allUsersArray.OfType<string>().ToList(); //changed to a list so I can more easily remove an item
                    int index = allUsersList.IndexOf(returnedUserDetails);
                    allUsersList.RemoveAt(index);

                    using (StreamWriter writer = new StreamWriter(@"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt"))
                    {
                        for (int i = 0; i < allUsersList.Count; i++)
                        {
                            Console.WriteLine(allUsersList[i]);  //prints the left items in list once it has been removed to console
                            writer.WriteLine(allUsersList[i]);    // writes the left items in list once it has been removed to the text file  - should be gone 
                        }
                    }

                        Console.WriteLine(allUsersList.Count); //why is this still 3? - the removed item is leaving an empty space 
                        Console.WriteLine("Deze gebruiker is successvol verwijderd.");
                }
                else
                {
                    Console.WriteLine("Foute password ingevuld. User kan niet verwijderd worden");
                    showMenu();
                }
            }
            else
            {
                Console.WriteLine("Deze gebruikersnaam bestaat niet. Probeer opnieuw.");
                userVerwijderen();
            }
        }




        
        
        //Log in 
        static void Inloggen()
        {
            Console.Write("Gebruikersnaam:");
            string userName = Console.ReadLine();
            string returnedUserDetails = searchFile(userName, @"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt");
            if (!String.IsNullOrEmpty(returnedUserDetails))
            {
                if (passwordMatch(returnedUserDetails, userName))
                {
                    gameMenu(200, userName);
                }
            }
            else
            {
                Console.WriteLine("Deze gebruikersnaam is niet herkend. Probeer opnieuw.");
                Inloggen();
            }
           
        }

        


        //Edit a username and password  - MAKE METHODS FOR NEW USERNAME AND PASSWORD REGEX CHECK
        static void userBewerken()
        {
            Console.WriteLine("Geef jouw huidige gebruikersnaam en wachtword.");
            Console.Write("Huidige gebruikersnaam:");
            string userName = Console.ReadLine();
            string currentUserDetails = searchFile(userName, @"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt");
            if (!String.IsNullOrEmpty(currentUserDetails))
            {
                Console.Write("Huidige ");

                if (passwordMatch(currentUserDetails, userName))
                {
                    Console.WriteLine("Kies een nieuwe gebruikersnaam. Gebruik alleen maar cijfers en letters.");   ///CHANGE TO METHOD 
                    Console.WriteLine("Nieuwe gebruikersnaam:");
                    string newUserName = Console.ReadLine();
                    Regex userPattern = new Regex(@"^[a-zA-Z0-9]+$");
                    if (userPattern.IsMatch(newUserName))
                    {
                        Console.WriteLine("Jouw nieuw gevruikersnaam is valid!");
                        string path = @"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt";
                        using (StreamReader reader = new StreamReader(path))
                        {
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();
                                if (line.Contains(newUserName))
                                {
                                    Console.WriteLine("Deze username in al in gebruik. Probeer opnieuw.");
                                    userBewerken();
                                }
                            }
                        }

                        bool valid = false;
                        while (!valid)
                        {
                            Console.WriteLine("Kies een password. Gebruik het volgende: \n  - 1 hoofdletter \n  - 1 kleine letter \n - 1 cijfer \n - 1 vreemd teken \n -8-20 characters");
                            Console.WriteLine("Password:");
                            string newPassword = Console.ReadLine();
                            Regex passwordPattern = new Regex(@"[a-z]+[A-Z]+[0-9]+[^a-zA-Z0-9]+");// only working in this order - how to change??? can you check length with reg ex   At least one special character [*.!@#$%^&(){}[]:;<>,.?/~_+-=|\]
                            if (passwordPattern.IsMatch(newPassword) && newPassword.Length >= 8 && newPassword.Length <= 20)
                            {
                                Console.WriteLine("Valid password!");
                                valid = true;
                                string newEncryptedPassword = Encrypt(newPassword);
                                string newUserDetails = $"{newUserName}#{newEncryptedPassword}";
                                ReplaceUserDetails(currentUserDetails, newUserDetails);
                                Console.WriteLine("Jouw gebruikersnaam en password is successvol begewerkt.");
                                Console.WriteLine("Nu kan je inloggen met deze nieuwe gegevens.");
                                showMenu();
                            }
                            else
                            {
                                Console.WriteLine("Invalid password. De voorwaarden zijn: \n  - 1 hoofdletter \n  - 1 kleine letter \n - 1 cijfer \n - 1 vreemd teken \n -8-20 characters \n Kies een andere password.");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid username! Use letters and numbers only. Kies een andere user name.");
                        userBewerken();
                    }
                }

            }      
            
        }











       
      
        //Write to file (append)
        static void writeToFile(string userName, string password)
        {
            string path = @"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt"; //will this path work on other computers?
            using (StreamWriter writer = File.AppendText(path))
            {
                string userDetails = $"{userName}#{password}";
                writer.WriteLine(userDetails);
            }
            Console.WriteLine("Jouw gebruikersnaam en wachtwoord zijn opgeslagen. Nu kan je inloggen.");
            showMenu();
        }


         




       //Replace/Edit user details 
         static void ReplaceUserDetails(string currentDetails, string newDetails)
         {
            string dataText = File.ReadAllText(@"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt");
            string newText = dataText.Replace(currentDetails, newDetails);
            Console.WriteLine(newText);
            File.WriteAllText(@"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt", newText);  //if this doesn't work do it as a loop line by line and replace 
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
                        userDetails = line;
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



        



        //Check if password matches username 
        static bool passwordMatch(string userdetails, string username)  //ADD LOOP TO ALLOW TO RUN 3 TIMES BEFORE RETURNING FALSE
        {
            
            Console.WriteLine("Password:");
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
            static string Encrypt(string password)   // change to more secure encryption? opposite value on asscii table 
            {
                char[] passwordAsChars = password.ToCharArray();
                for (int i = 0; i < passwordAsChars.Length; i++)
                {
                    passwordAsChars[i]++;
                }
                string encryptedPassword = new string(passwordAsChars);
                Console.WriteLine(encryptedPassword);
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
                Console.WriteLine(decryptedPassword);
                return decryptedPassword;
            }








        
    }
}

