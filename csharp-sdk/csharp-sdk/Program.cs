using System;

namespace SharpSDK
{
    internal class Program
    {
        public static vauth api = new vauth(
            appId: "<app_id>",
            secret: "<secret>",
            version: "1.0");
        static void Main(string[] args)
        {
            api.Initialize();
            Console.Write("input: ");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    register();
                    break;
                case "2":
                    login();
                    break;
                case "3":
                    extend();
                    break;
            }
        }

        public static void register()
        {
            Console.Write("username: ");
            string username = Console.ReadLine();

            Console.Write("password: ");
            string password = Console.ReadLine();

            Console.Write("token: ");
            string token = Console.ReadLine();

            Console.Write("email: ");
            string email = Console.ReadLine();
           
            if (api.RegisterLicense(username, password, token,email)) {

                var user = api.Username.ToString();
                var dataEmail = api.Email.ToString();
                var exp = api.ExpiryDate.ToString();
                Console.Write("Welcome :)\r\n");
                Console.Write($"{user} {dataEmail} {exp}");
            }
           
        }

        public static void login()
        {
            Console.Write("username: ");
            string username = Console.ReadLine();

            Console.Write("password: ");
            string password = Console.ReadLine();

            

            if (api.LoginUser(username, password))
            {
               var user = api.Username.ToString();
               var dataEmail = api.Email.ToString();
               var exp = api.ExpiryDate.ToString();
                Console.Write("Welcome :)\n\r");
                Console.Write($"{user} {dataEmail} {exp}");

            }

        }

        public static void extend()
        {
            Console.Write("username: ");
            string username = Console.ReadLine();

          

            Console.Write("token: ");
            string token = Console.ReadLine();

            

            if (api.ExtendLicenseExpiry(username, token))
            {
                Console.Write("Welcome :)");

            }

        }
    }
}