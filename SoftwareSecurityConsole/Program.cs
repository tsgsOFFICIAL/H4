using SoftwareSecurityConsole;
using SoftwareSecurityConsole.DAL;
using SoftwareSecurityConsole.Models;

DBMan dBMan = new DBMan();

PrintHeader();
PrintLoginMenu();

Console.WriteLine("Press any key to exit");
Console.ReadKey(true);

void GetUsers()
{
    PrintHeader();
}

void PrintHeader()
{
    Console.Clear();
    Console.WriteLine("\r\n __        __   _                            _____                                    \r\n \\ \\      / /__| | ___ ___  _ __ ___   ___  |_   _|__                                 \r\n  \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\   | |/ _ \\                                \r\n   \\ V  V /  __/ | (_| (_) | | | | | |  __/   | | (_) |                               \r\n  __\\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|   |_|\\___/                    _ _         \r\n / ___|  ___  / _| |___      ____ _ _ __ ___  / ___|  ___  ___ _   _ _ __(_) |_ _   _ \r\n \\___ \\ / _ \\| |_| __\\ \\ /\\ / / _` | '__/ _ \\ \\___ \\ / _ \\/ __| | | | '__| | __| | | |\r\n  ___) | (_) |  _| |_ \\ V  V / (_| | | |  __/  ___) |  __/ (__| |_| | |  | | |_| |_| |\r\n |____/ \\___/|_|  \\__| \\_/\\_/ \\__,_|_|  \\___| |____/ \\___|\\___|\\__,_|_|  |_|\\__|\\__, |\r\n                                                                                |___/ \r\n");
}

void PrintLoginMenu()
{
    Console.WriteLine("\r\n  _           _                _                     \r\n / |         | |    ___   __ _(_)_ __                \r\n | |  _____  | |   / _ \\ / _` | | '_ \\               \r\n | | |_____| | |__| (_) | (_| | | | | |              \r\n |_|__       |_____\\___/ \\__, |_|_| |_| _            \r\n |___ \\          |  _ \\ _|___/_ _(_)___| |_ ___ _ __ \r\n   __) |  _____  | |_) / _ \\/ _` | / __| __/ _ \\ '__|\r\n  / __/  |_____| |  _ <  __/ (_| | \\__ \\ ||  __/ |   \r\n |_____|         |_| \\_\\___|\\__, |_|___/\\__\\___|_|   \r\n  _____           _____     |___/                    \r\n |___ /          | ____|_  _(_) |_                   \r\n   |_ \\   _____  |  _| \\ \\/ / | __|                  \r\n  ___) | |_____| | |___ >  <| | |_                   \r\n |____/          |_____/_/\\_\\_|\\__|                  \r\n                                                     \r\n");
    Console.Write("Option: ");
    ConsoleKeyInfo key = Console.ReadKey();

    switch (key.Key)
    {
        case ConsoleKey.D1: // Login
            LoginScreen();
            break;
        case ConsoleKey.D2: // Register
            RegistrationScreen();
            break;
        case ConsoleKey.D3: // Exit
            Environment.Exit(0);
            break;
    }
}

async Task RegistrationScreen()
{
    Console.Clear();
    Console.WriteLine("\r\n  _____       _                                                                                      \r\n | ____|_ __ | |_ ___ _ __   _   _  ___  _   _ _ __   _   _ ___  ___ _ __ _ __   __ _ _ __ ___   ___ \r\n |  _| | '_ \\| __/ _ \\ '__| | | | |/ _ \\| | | | '__| | | | / __|/ _ \\ '__| '_ \\ / _` | '_ ` _ \\ / _ \\\r\n | |___| | | | ||  __/ |    | |_| | (_) | |_| | |    | |_| \\__ \\  __/ |  | | | | (_| | | | | | |  __/\r\n |_____|_| |_|\\__\\___|_|     \\__, |\\___/ \\__,_|_|     \\__,_|___/\\___|_|  |_| |_|\\__,_|_| |_| |_|\\___|\r\n                             |___/                                                                   \r\n");
    Console.WriteLine("\r\n   ____             __ _                           _ _   _       _ _ _____ _   _ _____ _____ ____  _ _ \r\n  / ___|___  _ __  / _(_)_ __ _ __ ___   __      _(_) |_| |__   ( | ) ____| \\ | |_   _| ____|  _ \\( | )\r\n | |   / _ \\| '_ \\| |_| | '__| '_ ` _ \\  \\ \\ /\\ / / | __| '_ \\   V V|  _| |  \\| | | | |  _| | |_) |V V \r\n | |__| (_) | | | |  _| | |  | | | | | |  \\ V  V /| | |_| | | |     | |___| |\\  | | | | |___|  _ <     \r\n  \\____\\___/|_| |_|_| |_|_|  |_| |_| |_|   \\_/\\_/ |_|\\__|_| |_|     |_____|_| \\_| |_| |_____|_| \\_\\    \r\n                                                                                                       \r\n");

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Username: ");

    Console.ForegroundColor = ConsoleColor.Cyan;
    string enteredUsername = Console.ReadLine() ?? "";
    Console.ForegroundColor = ConsoleColor.White;
    Console.Clear();

    if (await dBMan.DoesUserExist(enteredUsername))
    {
        Console.WriteLine("User already exists...");
        Thread.Sleep(2500);
        _ = RegistrationScreen();
    }

    Console.WriteLine("\r\n  _____       _                                                                                 _ \r\n | ____|_ __ | |_ ___ _ __   _   _  ___  _   _ _ __   _ __   __ _ ___ _____      _____  _ __ __| |\r\n |  _| | '_ \\| __/ _ \\ '__| | | | |/ _ \\| | | | '__| | '_ \\ / _` / __/ __\\ \\ /\\ / / _ \\| '__/ _` |\r\n | |___| | | | ||  __/ |    | |_| | (_) | |_| | |    | |_) | (_| \\__ \\__ \\\\ V  V / (_) | | | (_| |\r\n |_____|_| |_|\\__\\___|_|     \\__, |\\___/ \\__,_|_|    | .__/ \\__,_|___/___/ \\_/\\_/ \\___/|_|  \\__,_|\r\n                             |___/                   |_|                                          \r\n");
    Console.WriteLine("\r\n   ____             __ _                           _ _   _       _ _ _____ _   _ _____ _____ ____  _ _ \r\n  / ___|___  _ __  / _(_)_ __ _ __ ___   __      _(_) |_| |__   ( | ) ____| \\ | |_   _| ____|  _ \\( | )\r\n | |   / _ \\| '_ \\| |_| | '__| '_ ` _ \\  \\ \\ /\\ / / | __| '_ \\   V V|  _| |  \\| | | | |  _| | |_) |V V \r\n | |__| (_) | | | |  _| | |  | | | | | |  \\ V  V /| | |_| | | |     | |___| |\\  | | | | |___|  _ <     \r\n  \\____\\___/|_| |_|_| |_|_|  |_| |_| |_|   \\_/\\_/ |_|\\__|_| |_|     |_____|_| \\_| |_| |_____|_| \\_\\    \r\n                                                                                                       \r\n");

    Console.Write("Password: ");

    Console.ForegroundColor = ConsoleColor.Cyan;
    ConsoleKeyInfo key;
    string passwordInput = "";

    do
    {
        key = Console.ReadKey(true);

        //Backspace should not work here, as its used to delete the last character
        if (key.Key != ConsoleKey.Backspace)
        {
            if (key.Key != ConsoleKey.Enter)
            {
                passwordInput += key.KeyChar;
                Console.Write("*");
            }
        }
        else
        {
            try
            {
                passwordInput = passwordInput[..^1];
                Console.Write("\b \b"); //\b \b is a backspace keypress
            }
            catch (Exception)
            { }
        }
    }
    //Stops recieving keys once enter has been pressed
    while (key.Key != ConsoleKey.Enter);

    Console.ForegroundColor = ConsoleColor.White;
    User user = new User()
    {
        Username = enteredUsername,
        Password = Encryptor.Base64Encode(Encryptor.Hash(passwordInput)),
    };

    Console.WriteLine();

    if (!await dBMan.DoesUserExist(user.Username))
    {
        Console.WriteLine("Adding new user");
        await dBMan.AddUser(user);
    }
    else
    {
        Console.WriteLine("User already exists...");
        Thread.Sleep(2500);
        RegistrationScreen();
    }
}

async Task LoginScreen()
{
    Console.Clear();
    Console.WriteLine("\r\n  _____       _                                                                                      \r\n | ____|_ __ | |_ ___ _ __   _   _  ___  _   _ _ __   _   _ ___  ___ _ __ _ __   __ _ _ __ ___   ___ \r\n |  _| | '_ \\| __/ _ \\ '__| | | | |/ _ \\| | | | '__| | | | / __|/ _ \\ '__| '_ \\ / _` | '_ ` _ \\ / _ \\\r\n | |___| | | | ||  __/ |    | |_| | (_) | |_| | |    | |_| \\__ \\  __/ |  | | | | (_| | | | | | |  __/\r\n |_____|_| |_|\\__\\___|_|     \\__, |\\___/ \\__,_|_|     \\__,_|___/\\___|_|  |_| |_|\\__,_|_| |_| |_|\\___|\r\n                             |___/                                                                   \r\n");
    Console.WriteLine("\r\n   ____             __ _                           _ _   _       _ _ _____ _   _ _____ _____ ____  _ _ \r\n  / ___|___  _ __  / _(_)_ __ _ __ ___   __      _(_) |_| |__   ( | ) ____| \\ | |_   _| ____|  _ \\( | )\r\n | |   / _ \\| '_ \\| |_| | '__| '_ ` _ \\  \\ \\ /\\ / / | __| '_ \\   V V|  _| |  \\| | | | |  _| | |_) |V V \r\n | |__| (_) | | | |  _| | |  | | | | | |  \\ V  V /| | |_| | | |     | |___| |\\  | | | | |___|  _ <     \r\n  \\____\\___/|_| |_|_| |_|_|  |_| |_| |_|   \\_/\\_/ |_|\\__|_| |_|     |_____|_| \\_| |_| |_____|_| \\_\\    \r\n                                                                                                       \r\n");

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Username: ");

    Console.ForegroundColor = ConsoleColor.Cyan;
    string enteredUsername = Console.ReadLine() ?? "";
    Console.ForegroundColor = ConsoleColor.White;
    Console.Clear();

    if (!await dBMan.DoesUserExist(enteredUsername))
    {
        Console.WriteLine("User doesn't exist...");
        Thread.Sleep(2500);
        LoginScreen();
    }

    User user = await dBMan.GetUser(enteredUsername);
    string hashedPassword = user.Password!;

    if (Login(hashedPassword, 3))
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Welcome in!");
    }
}

static bool Login(string hashedPassword, byte attempts = 1)
{
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("\r\n  _____       _                                                                                 _ \r\n | ____|_ __ | |_ ___ _ __   _   _  ___  _   _ _ __   _ __   __ _ ___ _____      _____  _ __ __| |\r\n |  _| | '_ \\| __/ _ \\ '__| | | | |/ _ \\| | | | '__| | '_ \\ / _` / __/ __\\ \\ /\\ / / _ \\| '__/ _` |\r\n | |___| | | | ||  __/ |    | |_| | (_) | |_| | |    | |_) | (_| \\__ \\__ \\\\ V  V / (_) | | | (_| |\r\n |_____|_| |_|\\__\\___|_|     \\__, |\\___/ \\__,_|_|    | .__/ \\__,_|___/___/ \\_/\\_/ \\___/|_|  \\__,_|\r\n                             |___/                   |_|                                          \r\n");
    Console.WriteLine("\r\n   ____             __ _                           _ _   _       _ _ _____ _   _ _____ _____ ____  _ _ \r\n  / ___|___  _ __  / _(_)_ __ _ __ ___   __      _(_) |_| |__   ( | ) ____| \\ | |_   _| ____|  _ \\( | )\r\n | |   / _ \\| '_ \\| |_| | '__| '_ ` _ \\  \\ \\ /\\ / / | __| '_ \\   V V|  _| |  \\| | | | |  _| | |_) |V V \r\n | |__| (_) | | | |  _| | |  | | | | | |  \\ V  V /| | |_| | | |     | |___| |\\  | | | | |___|  _ <     \r\n  \\____\\___/|_| |_|_| |_|_|  |_| |_| |_|   \\_/\\_/ |_|\\__|_| |_|     |_____|_| \\_| |_| |_____|_| \\_\\    \r\n                                                                                                       \r\n");

    Console.Write("Password: ");

    Console.ForegroundColor = ConsoleColor.Cyan;
    ConsoleKeyInfo key;
    string passwordInput = "";

    do
    {
        key = Console.ReadKey(true);

        //Backspace should not work here, as its used to delete the last character
        if (key.Key != ConsoleKey.Backspace)
        {
            if (key.Key != ConsoleKey.Enter)
            {
                passwordInput += key.KeyChar;
                Console.Write("*");
            }
        }
        else
        {
            try
            {
                passwordInput = passwordInput[..^1];
                Console.Write("\b \b"); //\b \b is a backspace keypress
            }
            catch (Exception)
            { }
        }
    }
    //Stops recieving keys once enter has been pressed
    while (key.Key != ConsoleKey.Enter);

    if (Encryptor.Verify(passwordInput.Trim(), hashedPassword))
    {
        return true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nIncorrect password!");
        attempts--;
    }
    if (attempts <= 0)
    {
        return false;
    }

    Login(hashedPassword, attempts);
    
    return true;
}