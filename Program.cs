using System;

namespace CyberGuardBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate our project classes
            Multimedia media = new Multimedia();
            ChatBrain chat = new ChatBrain();
            User currentUser = new User();

            // 1. Multimedia Sequence
            media.VoiceIntro();
            media.DrawLogo();

            // 2. User Setup - Name Prompting Loop
            Console.ForegroundColor = ConsoleColor.Gray;
            do
            {
                Console.WriteLine("\n[ SYSTEM INITIALIZED ]");
                Console.Write("Please enter your name: ");

                // User input in Purple
                Console.ForegroundColor = ConsoleColor.Magenta;
                currentUser.Name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;

            } while (string.IsNullOrEmpty(currentUser.Name));

            // 3. User Guidance & Termination Message
            Console.Clear();

            // Header in Blue
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==================================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Welcome, {currentUser.Name}. Your Security Assistant is online.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==================================================");

            // Capabilities (Neutral White)
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("I can assist with:");
            Console.WriteLine("PASSWORDS");
            Console.WriteLine("PHISHING");
            Console.WriteLine("CYBER SECURITY");

            // THE TERMINATION INSTRUCTION (Yellow to stand out)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[ INSTRUCTION ]");
            Console.WriteLine("To securely terminate this session, please type 'EXIT'.");
            Console.WriteLine("--------------------------------------------------");
            Console.ResetColor();

            // 4. Main Chat Loop
            string input = "";
            do
            {
                // User Prompt in Blue, User Typing in Purple
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n" + currentUser.Name + " > ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                input = Console.ReadLine();
                Console.ResetColor();

                // The loop continues until HandleChat returns 'false' (when user types EXIT)
            } while (chat.HandleChat(input));

            // 5. Final Shutdown
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n[ SYSTEM ] Session closed successfully.");
            Console.WriteLine("Press any key to exit the application window...");
            Console.ReadKey();
        }
    }
}