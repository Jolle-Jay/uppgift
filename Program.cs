using App;
using Microsoft.VisualBasic;

List<User> users = new List<User>();

/*users.Add(new User("JolleJ@gmail.com", "password123"));*/

User? active_user = null; // en tom plats för att hålla reda på den som är inloggad

bool running = true;

while (running)
{
    Console.Clear();

    if (active_user == null)
    {
        Console.Clear();
        Console.WriteLine("Press 1 to create account:");
        Console.WriteLine("Press 2 for login");
        Console.WriteLine("Press 3 for remove account");
        string menu = Console.ReadLine();

        switch (menu)
        {
            case "1":
                Console.Clear();
                Console.WriteLine("Enter you email as username");
                string new_name = Console.ReadLine();
                Console.WriteLine("Enter your password for your account");
                string new_password = Console.ReadLine();
                users.Add(new User(new_name, new_password));
                Console.WriteLine("Congratz to your account!");
                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Enter your email to login");
                string login_name = Console.ReadLine();
                Console.WriteLine("Enter you password to login");
                string login_password = Console.ReadLine();
                foreach (User user in users)
                {
                    if (user.TryLogin(login_name, login_password))
                    {
                        active_user = user;
                        break;
                    }
                }
                break;




        }


        if (active_user != null)
        {
            Console.Clear();
            Console.WriteLine("Hello" + " " + active_user.Email);
            Console.WriteLine("Type logout to logout");
            Console.WriteLine("Type remove to remove account");
            string menu2 = Console.ReadLine();

            switch (menu2)
            {
                case "logout":
                    active_user = null;
                    break;


                case "remove":
                    Console.Clear();
                    users.Remove(active_user);
                    Console.WriteLine("Your account is now deleted");
                    active_user = null;
                    break;

            }


        }


    }





}