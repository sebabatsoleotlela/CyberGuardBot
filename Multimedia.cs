using System;
using System.IO;
using System.Media;
using System.Drawing;

namespace CyberGuardBot
{
    public class Multimedia
    {
        // global path variable (used by your methods)
        string path_logo = AppDomain.CurrentDomain.BaseDirectory;

        // --- VOICE INTRO (calls your method) ---
        public void VoiceIntro()
        {
            voice(); // 👈 calls YOUR method
        }

        // --- YOUR VOICE METHOD (fixed slightly to avoid crashes) ---
        private void voice()
        {
            try
            {
                // get base path
                string path = AppDomain.CurrentDomain.BaseDirectory;

                // replace Debug\bin\
                string fullpath = path.Replace(@"bin\Debug\", "");

                // join path to audio file
                string joined_path = fullpath + "greet.wav";

                // check if file exists
                if (!File.Exists(joined_path))
                {
                    Console.WriteLine("[Audio skipped: greet.wav not found]");
                    return;
                }

                // create an instance for the sound player class
                SoundPlayer voice_play = new SoundPlayer(joined_path);

                // load the audio
                voice_play.Load();

                // play till the end
                voice_play.PlaySync();
            }
            catch
            {
                Console.WriteLine("[Audio error]");
            }
        }

        // --- ASCII LOGO ---
        public void DrawLogo()
        {
            try
            {
                asci();
            }
            catch
            {
                Console.WriteLine("[Logo skipped: logo.jpg not found]");
            }
        }

        // --- YOUR ASCII METHOD ---
        private void asci()
        {
            // replace bin and debug-> bin/Debug
            string full_path = path_logo.Replace(@"\bin\Debug\", @"\logo.jpg");

            // path of the logo
            string path = full_path;

            if (!File.Exists(path))
            {
                Console.WriteLine("[Logo skipped: logo.jpg not found]");
                return;
            }

            Bitmap image = new Bitmap(path);

            int width = 150;
            int height = 70;
            Bitmap resized = new Bitmap(image, new Size(width, height));

            string asciiChars = "@#S%?*+;:,. ";

            for (int y = 0; y < resized.Height; y++)
            {
                for (int x = 0; x < resized.Width; x++)
                {
                    Color pixel = resized.GetPixel(x, y);

                    int gray = (pixel.R + pixel.G + pixel.B) / 3;

                    int index = (gray * (asciiChars.Length - 1)) / 255;

                    Console.Write(asciiChars[index]);
                }
                Console.WriteLine();
            }
        }
    }
}