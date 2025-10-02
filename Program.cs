using System.Collections;
using App;
using Microsoft.VisualBasic;

List<User> users = new List<User>(); // Vi skapar en tom låda som heter "users" Denna låda kan bara hålla lappar som beskriver en Användare User.
User? active_user = null; // Vi skapar en plats som heter "active_user" Just nu är platsen tom (NULL). Här ska vi lägga lappen för den användare som är inloggad
bool running = true; // Vi har en strömbrytare som körs och är inkopplad
while (running) // Evig loop som körs sålängre strömbrytaren är "running"
{

    if (active_user == null) // Avstämmning, är platsen för den inloggade användaren tom?
    {

        Console.WriteLine("Press 1 to create account:");
        Console.WriteLine("Press 2 for login");
        Console.WriteLine("Press 3 for remove account");
        string menu = Console.ReadLine(); // Programmet inväntar på användare att skriver något tex 123 och sparar det i en lapp som heter menu

        switch (menu) // Programmet tittar på lappen menu och hoppar till rätt instruktion
        {
            case "1": // Om jag skriver 1 så följer den instruktioner för att skapa konto
                Console.Clear(); // gör det rent o fint i consolen
                Console.WriteLine("Enter you email as username");
                string new_name = Console.ReadLine(); //Programmet sparar användarnamnet i lappen "new_name"
                Console.WriteLine("Enter your password for your account");
                string new_password = Console.ReadLine(); //Programmet sparar lösenordetr i lappen "new_password"
                users.Add(new User(new_name, new_password)); // Programmet skapar EN NY användar LAPP med min epost och lösen och lägger det i lådan USERS.
                Console.WriteLine("Congratz to your account!");
                File.AppendAllText("./Account_names.txt", new_name + "\n"); //Programmet skriver NER min nya epost adress i en textfil som heter Account_names.txt så att den finns kvar även om programmet stängs av.
                break; // slut

            case "2": // Om du skriver 2 så vill du logga in
                Console.Clear();
                Console.WriteLine("Enter your email to login");
                string login_name = Console.ReadLine(); // Programmet sparar login namnet i lappen login_name
                Console.Clear();
                Console.WriteLine("Enter you password to login");
                string login_password = Console.ReadLine(); // programmet sparar login namnet i lappen login_password
                foreach (User user in users) // Programmet tar fram varje användar lapp (user) ur "users"-lådan en i taget
                {
                    if (user.TryLogin(login_name, login_password)) //Programmet frågar användar lappen "matchar e-posten och lösenordet du fick?
                    {
                        active_user = user; //""OM DET STÄMMER -----> lägg den matchande användar lappen på den tomma platsen "active_user"
                        break;
                    }
                }
                break;


        }

    }


    if (active_user != null) // KOLLAR --> är platsen för den inloggade användare INTE TOM?! ÄR NÅGON INLOGGAD?
    {
        Console.Clear();
        Console.WriteLine("Hello" + " " + active_user.Email); // Programmet säöger Hej till den inloggade användarens epost
        Console.WriteLine("Type logout to logout");
        Console.WriteLine("Type delete to remove account");
        Console.WriteLine("Type Add to add item");
        Console.WriteLine("Type Show inventory to see inventory");
        Console.WriteLine("Type Show Market to see market");
        Console.WriteLine("Type show requests to see requests"); // Ett menyval när anvä'ndare är inloggad

        string menu2 = Console.ReadLine(); // Programmet tittar på menu2 och hoppar till rätt instrultio för den inloggade menyn -> I menu2 strängen finns det flera oliaka variabler för olika menyval

        switch (menu2)
        {
            case "logout": // Om du skriver Logout
                active_user = null; // Programmet tömmer platsen "active_user" -> nu är ingen inloggad längre
                break;


            case "delete": // Om du skriver delete
                Console.Clear();
                users.Remove(active_user); // PRogrammet tar bort den inloggade användar lappen från lådan "users"
                Console.WriteLine("Your account is now deleted");
                active_user = null; // Programmet tömmer platsen "active_user"
                break;




            case "Add": //

                Console.Clear();
                Console.WriteLine("Please type what you would like to add");
                string item = Console.ReadLine(); //Programmet sparar namnet på föremålet i item
                Console.WriteLine("Please enter info about the item");
                string info = Console.ReadLine(); // programmet spara namnet på informationen i info
                File.AppendAllText("./Personitems/" + active_user.Email + ".txt", item + "\n"); //programmet skriver till en fil som heter personitems"användarenamn".txt
                File.AppendAllText("./Personitems/" + active_user.Email + ".txt", info + "\n"); // programmet skriver till samma fil och lägger in Info om föremålet
                File.AppendAllText("./Personitems/" + active_user.Email + ".txt", " " + "\n"); // programmet lägger till en tom rad i filen
                break;

            case "Show inventory":
                Console.Clear();
                File.AppendAllText("./Personitems/" + active_user.Email + ".txt", ""); // "se till att filen är där knepet" så att programmet inte kraschar och försäkrar mig att min inventarie fil finns
                string[] rows = File.ReadAllLines("./Personitems/" + active_user.Email + ".txt"); // Öppnar txt filen och läser in varje rad av text, varje rad sparas som en liten lapp i en hög som heter ROWS

                foreach (string line in rows) //Tar fram lapparna som heter line från högen rows, en i taget.
                {
                    Console.WriteLine(line); // skriver utt texten som står på lapparna line, en i taget
                }
                Console.WriteLine("Type Yes to accept request");
                string choice = Console.ReadLine();
                if (choice == "Yes")
                    // {
                    //     Console.WriteLine("You accepted the request");
                    //     string trade = Console.ReadLine();
                    //     Console.WriteLine("Please enter the row of tiems ytou want to request example row 1 is number 1");
                    //     string row = Console.ReadLine();
                    //     string filepath = "./Personitems/" + names + ".txt";
                    //     int targetrow = int.Parse(row);

                    //     List<string> lines = new List<string>(File.ReadAllLines(filepath));
                    //     if (targetrow > 0 && targetrow <= lines.Count)
                    //     {
                    //         lines[targetrow - 1] += " " + active_user.Email + " " + "And you get" + " " + trade + " " + "/Request" + "\n";
                    //         File.WriteAllLines(filepath, lines);
                    //         File.AppendAllText("./Request_items.txt", lines[targetrow - 1] + "\n");
                    //     }
                    // }

















                    Console.WriteLine("Press enter to go back to the menu");
                Console.ReadLine();

                break;

            case "Show market":
                Console.Clear();
                string[] rows_1 = File.ReadAllLines("./Account_names.txt"); // All text som står i accountnames.txt kommer att skrivas på lapparna rows_1

                foreach (string line in rows_1) // För varje linje i Row_1 lapparna
                {
                    Console.WriteLine(line); // skriv ut varje linje
                }

                Console.WriteLine("Please enter an account name to see their items");
                string names = Console.ReadLine(); // Det som användaren matar in kommer att vara strängar under names
                Console.Clear();
                Console.WriteLine("Here is" + " " + names + "items");
                File.AppendAllText("./Personitems/" + names + ".txt", ""); // en tom rad som bara kollar om filen finns där så att programmet inte kraschar
                string[] rows_2 = File.ReadAllLines("./Personitems/" + names + ".txt"); // All text från Personitems.txt ska komma på row_2 lapparna

                foreach (string line in rows_2) // För varje linje i row_2 lapparna
                {
                    Console.WriteLine(line); //skriv varenda linje
                }

                Console.WriteLine("Do you wan to request any of this items?");
                Console.WriteLine("Type yes if you want to and no if you dont");
                string request = Console.ReadLine(); //en sträng som jag kan skriva in
                if (request == "yes") // om strängen är yes
                {
                    Console.WriteLine("Write what item you want to put for exchange");
                    string trade = Console.ReadLine(); // det du skriver här kommer sparas i trade strängen
                    Console.WriteLine("Please enter the row of tiems ytou want to request example row 1 is number 1");
                    string row = Console.ReadLine(); //Det du skriver här sparas i row strängen
                    string filepath = "./Personitems/" + names + ".txt"; //Personitems/names.txt kommer att sparas i filepath strängen
                    int targetrow = int.Parse(row); // gör om row till nummer så att jag kan skriva det i targetrow

                    List<string> lines = new List<string>(File.ReadAllLines(filepath)); // skapar en ny flexibel behållare som heter lines
                                                                                        // vi säger åt att fylla den nya behållaren lines med alla rader från filen
                    if (targetrow > 0 && targetrow <= lines.Count) // om targetrow är större än 0 && om targetrow är mindre eller lika med lines count
                    {
                        lines[targetrow - 1] += " " + active_user.Email + " " + "And you get" + " " + trade + " " + "/Request" + "\n";
                        File.WriteAllLines(filepath, lines);
                        File.AppendAllText("./Request_items.txt", lines[targetrow - 1] + "\n");
                    }
                }
                else if (request == "no")
                {
                    break;
                }

                Console.WriteLine("Press enter to go back to menu");
                Console.ReadLine();
                break;

            case "show requests":
                Console.Clear();
                string[] rows_3 = File.ReadAllLines("./Request_items.txt");
                foreach (string line in rows_3)
                {
                    System.Console.WriteLine(line);
                }
                Console.ReadLine();
                Console.WriteLine("Press enter to go back");
                break;

        }


    }





}

