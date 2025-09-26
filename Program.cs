using App;

List<IUser> users = new List<IUser>();

users.Add(new User("JolleJ@gmail.com", "password123"));

IUser? active_user = null; // en tom plats för att hålla reda på den som är inloggad

bool running = true;

while (running)
{
    Console.Clear();

    if (active_user == null)
    {
        Console.Clear();
        Console.Write("Username:");
        string username = Console.ReadLine();

        Console.Clear();
        Console.Write("Password");
        string password = Console.ReadLine();
        Console.Clear();


        foreach (IUser user in users)
        {
            if (user.TryLogin(username, password))
            {
                active_user = user;
                break;
            }
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Welcome to the inventory:");

        switch (active_user.GetRole())
        {
            case Role.User:
                Console.WriteLine("Welcome User");
                break;
        }

        if (active_user.IsRole(Role.User))
        {
            Console.WriteLine("Upload information about your item");
            Console.WriteLine("What type is you item?");
            string Type = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What Rarity is your item?");
            string Rarity = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("How much damage does it got?");
            int Damage = int.Parse(Console.ReadLine());
        }
    }

}