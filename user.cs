namespace App;

class User  // för att user ska ha egenskaper avv IUSER
{
    public string Email; // för att användarna ska ha sina Email som användarnamn

    string _password; // vi gjorde det i andra övningarna med _framför, kunde lika bra stått banana

    public User(string username, string password)
    {
        Email = username;
        _password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Email && password == _password;
    }
}