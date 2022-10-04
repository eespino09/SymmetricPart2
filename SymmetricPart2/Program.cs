using System;
using Bc = BCrypt.Net.BCrypt;


namespace SymmetricPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;

            while (loop)
            {
                String userOptionInput = " ";
                Console.WriteLine("symmetric key encryption, password hashing or exit: ");
                userOptionInput = Console.ReadLine();



                if (userOptionInput.Equals("symmetric key encryption",StringComparison.OrdinalIgnoreCase )) //userOptionInput == "symmetric key encryption")
                {
                    encryptPassword();
                }
                else if (userOptionInput.Equals("password hashing",StringComparison.OrdinalIgnoreCase))//== "password hashing")
                {
                    hashPassword();
                }
                else if (userOptionInput.Equals("exit",StringComparison.OrdinalIgnoreCase) )//== "exit program")
                {
                    endProgram();
                }
                else if (userOptionInput.ToLower() != "symmetric key encryption" || userOptionInput.ToLower() == "password hashing" || userOptionInput.ToLower() == "exit")
                {
                    Console.WriteLine("PLease enter a valid input such as (symmetric key encrption), (password hashing) or (exit).");
                }

            }
            Console.ReadKey();
        }

        public static void encryptPassword()
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            Console.WriteLine("Please enter a string for encryption");
            String str = Console.ReadLine();
            String encryptedPassword = AesOperation.EncryptString(key, str);
            Console.WriteLine($"encrypted string = {encryptedPassword}");

        }

        public static void hashPassword()
        {
            Console.WriteLine("Please enter a password to hash");
            String passToHash = Console.ReadLine();

            String hashPass = Bc.HashPassword(passToHash);

            Console.WriteLine("Entered Password: " + passToHash);
            Console.WriteLine("Hashed Password: " + hashPass);
            Console.WriteLine("------------------");
            Console.WriteLine("Verifying You Are Who You Say You Are... ");

            Console.WriteLine("Enter Your Password: ");
            String testPass = Console.ReadLine();

            if (Bc.Verify(testPass, hashPass))
            {
                Console.WriteLine("Successful login.");
            }
            else
            {
                Console.WriteLine("Failed Login");
            }

        }

        public static void endProgram()
        {
                Environment.Exit(0);
        }

    }
}
