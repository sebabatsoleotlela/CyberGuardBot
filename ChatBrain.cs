using System;
using System.Collections; // Required for ArrayList

namespace CyberGuardBot
{
    internal class ChatBrain
    {
        // Topic-specific lists to prevent mixing answers
        ArrayList passwordTips = new ArrayList();
        ArrayList phishingTips = new ArrayList();
        ArrayList securityTips = new ArrayList();

        // List for words to ignore during search
        ArrayList ignoring = new ArrayList();

        // Index trackers to ensure we give one answer at a time and alternate them
        int pIndex = 0;
        int phIndex = 0;
        int sIndex = 0;

        public ChatBrain()
        {
            // --- PASSWORDS ---
            passwordTips.Add("PASSWORD: Use at least 12 characters including uppercase, lowercase, and symbols.");
            passwordTips.Add("PASSWORD: Never reuse the same password across different websites or apps.");
            passwordTips.Add("PASSWORD: Use a Password Manager to store complex codes safely.");

            // --- PHISHING ---
            phishingTips.Add("PHISHING: Check the sender's email address for misspellings like 'g00gle.com'.");
            phishingTips.Add("PHISHING: Real banks will never ask you for your PIN or password via SMS or email.");
            phishingTips.Add("PHISHING: Be wary of 'Urgent' messages that threaten to close your account.");

            // --- CYBER SECURITY ---
            securityTips.Add("CYBER SECURITY: Enable Multi-Factor Authentication (MFA) on every account you own.");
            securityTips.Add("CYBER SECURITY: Keep your software and operating system updated to patch security holes.");
            securityTips.Add("CYBER SECURITY: Avoid using public Wi-Fi for banking; hackers can 'sniff' your data.");

            // Words to filter out (Based on your logic)
            ignoring.Add("what");
            ignoring.Add("is");
            ignoring.Add("about");
            ignoring.Add("the");
        }

        public bool HandleChat(string question)
        {
            // Clean input for checking EXIT
            string input = question.ToLower().Trim();

            if (input == "exit")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nCHATBOT: Session Terminated. Stay safe!");
                Console.ResetColor();
                return false; // Tells Program.cs loop to stop
            }

            // Get words from the question
            string[] find_words = input.Split(' ');
            bool topicFound = false;

            foreach (string word in find_words)
            {
                // Skip ignored words
                if (ignoring.Contains(word)) continue;

                // Logic: Match specific topic and show ONE alternating answer
                if (word == "password" || word == "passwords")
                {
                    ShowAlternatingTip(passwordTips, ref pIndex);
                    topicFound = true;
                    break;
                }
                else if (word == "phishing")
                {
                    ShowAlternatingTip(phishingTips, ref phIndex);
                    topicFound = true;
                    break;
                }
                else if (word == "security" || word == "cyber")
                {
                    ShowAlternatingTip(securityTips, ref sIndex);
                    topicFound = true;
                    break;
                }
            }

            if (!topicFound)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("CHATBOT: I don't have information on that. Try 'password', 'phishing', or 'security'.");
                Console.ResetColor();
            }

            return true; // Keeps the loop running
        }

        // Method to handle the "One answer at a time / Alternating" requirement
        private void ShowAlternatingTip(ArrayList list, ref int currentIndex)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("CHATBOT: ");
            Console.ForegroundColor = ConsoleColor.White;

            // Print only the specific tip at the current index
            Console.WriteLine(list[currentIndex]);

            // Update index to the next tip for next time (loops back to 0 at the end)
            currentIndex = (currentIndex + 1) % list.Count;

            Console.ResetColor();
        }
    }
}