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
        

        static void Main(string[] args)
        {
            showMenu();

            int balance = 200; //why is this not global




            Console.ReadLine();
        }




        //METHODS 

        //Main menu
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
                            Console.WriteLine("Je hebt al een account aangemaakt. Kies een andere optie(2,3 of 4).");
                            showMenu();
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





        static void Inloggen()
        {
            Console.Write("Gebruikersnaam:");
            string userName = Console.ReadLine();
            string returnedUserDetails = searchFile(userName, @"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt");
            if (!String.IsNullOrEmpty(returnedUserDetails))
            {
                if (passwordMatch(returnedUserDetails, userName))
                {
                    GameMenu(userName,200);
                }
            }
            else
            {
                Console.WriteLine("Deze gebruikersnaam is niet herkend. Probeer opnieuw.");
                Inloggen();
            }
           
        }

        static void GameMenu( string username, int balance)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME {username}   :)");
            //Console.WriteLine($"{date}, {time}   Je bent {length} ingelogd.");
            Console.WriteLine($"Je hebt ${balance} om me te spelen!");
            Console.WriteLine("Wat wil je doen? Kies een optie:");
            Console.WriteLine("1. Play Blackjack");
            Console.WriteLine("2. Play slot machine");
            Console.WriteLine("3. Play memory");
            Console.WriteLine("4. Uitloggen");
            
           
        }



        static void userBewerken()
        {
            Console.WriteLine("Geef jouw huidige gebruikersnaam en wachtword.");
            Console.Write("Huidige gebruikersnaam:");
            //save
            Console.Write("Huidige wachtwoord:");
            //save
            //set as string 
            //check if match
            //if matches 
            Console.WriteLine("Geef jouw nieuwe gebruikersnaam en wachtword.");
            Console.Write("Nieuwe gebruikersnaam:");
            Console.Write("Nieuwe wachtwoord:");
            //save as second string 
            //loop over the lines in text file and replace 2nd string with first string 


           /* string userName = Console.ReadLine();
            string returnedUserDetails = searchFile(userName, @"C:\Users\clair\source\repos\ProjectWeekClaire\ProjectWeekClaire\data.txt");
            if (!String.IsNullOrEmpty(returnedUserDetails))
            {
                if (passwordMatch(returnedUserDetails, userName))
                {
                    
                    userToevoegen();
                    Console.WriteLine("Geef nieuw username:");
                    

                }
             
            } else
            {
                Console.WriteLine("Deze gebruikersnaam bestaat niet. Probeer opnieuw.");
                userBewerken();
            }*/
        }











        //write to file (replace) 
        





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

