using System;

namespace CyberGuardBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate project classes
            Multimedia media = new Multimedia();
            ChatBrain chat = new ChatBrain();
            User currentUser = new User();

            // 1. Multimedia Intro
            media.VoiceIntro();
            media.DrawLogo();

            // 2. User Setup (Cleaned up as requested)
            Console.ForegroundColor = ConsoleColor.Gray;
            do
            {
                Console.Write("Please enter your name: ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                currentUser.Name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;

            } while (string.IsNullOrEmpty(currentUser.Name));

            // 3. Navigation UI & Termination Instruction
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==================================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Welcome, {currentUser.Name}. Your Security Assistant is online.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==================================================");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("I can assist with: PASSWORDS, PHISHING, and SECURITY.");

            // Clear termination instruction
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[ INSTRUCTION ]");
            Console.WriteLine("To securely terminate this session, please type 'EXIT'.");
            Console.WriteLine("--------------------------------------------------");
            Console.ResetColor();

            // 4. Main Chat Loop
            string input = "";
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n" + currentUser.Name + " > ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                input = Console.ReadLine();
                Console.ResetColor();

            } while (chat.HandleChat(input));

            // 5. Final Shutdown
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n[ SYSTEM ] Session closed successfully.");
            Console.WriteLine("Press any key to exit the application window...");
            Console.ReadKey();
        }
    }
}