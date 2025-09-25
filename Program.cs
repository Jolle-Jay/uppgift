using App;

List<IUser> users = new List<IUser>();

users.Add(new NormalUser("JolleJ@gmail.com", "password123"));

IUser? active_user = null;