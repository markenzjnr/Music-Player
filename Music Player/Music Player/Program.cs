using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player
{
    internal class Program
    {
        static Dictionary<string, string> songs = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            ImportMusic();


            while(true) 
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Play a song");
                Console.WriteLine("2. Add a song");
                Console.WriteLine("3. Update a song");
                Console.WriteLine("4. Delete a song");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlaySong();
                        break;
                    case "2":
                        AddSong();
                        break;
                    case "3":
                        UpdateSong();
                       break;
                    case "4":
                       DeleteSong();
                       break;
                    case "5":
                        ImportMusic();
                        break;
                    case "6":
                        Console.WriteLine("Exiting....");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;
                }
            }
        }

        static void ImportMusic()
        {
            //Directory where your music files are stored
            Console.Write("Enter the directory path to import music from: ");
            string directoryPath = @"C:\Users\42-DAWG\Music";

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Music directory not found.");
                return;
            }
            string[] files = Directory.GetFiles(directoryPath, "*.mp3");
            foreach (string file in files)
            {
                string title = Path.GetFileNameWithoutExtension(file);
                if (!songs.ContainsKey(title))
                {
                    songs[title] = file;
                    Console.WriteLine($"Added:{title}");
                }
            }

            Console.WriteLine($"{files.Length} songs imported successfully. ");
        }

        static void PlaySong()
        {
            Console.Write("Enter the title of the song you want to play: ");
            string title = Console.ReadLine();
            if (songs.ContainsKey(title))
            {
                //   code to play the song (using appropriate library or process)
                Console.WriteLine($"Playing {title}: {songs[title]}");
            }
            else
            {
                Console.WriteLine("Song not found.");
            }
        }

        static void AddSong()
        {
            Console.Write("Enter the title of the song: ");
            string title = Console.ReadLine();
            Console.Write("Enter the file path of the song: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            if (songs.ContainsKey(title))
            {
                Console.WriteLine("Song already exists. Do you want to update it? (Y/N)");
                string response = Console.ReadLine().ToUpper();
                if (response != "Y")
                {
                    return;
                }
            }

            songs[title] = filePath;
            Console.WriteLine("Song added sucessfully");
        }

        static void UpdateSong()
        {
            Console.Write("Enter the title of the song you want to update");
            string title = Console.ReadLine();
            if (songs.ContainsKey(title))
            {
                Console.Write("Enter the new file path: ");
                string newFilePath = Console.ReadLine();

                if (!File.Exists (newFilePath))
                {
                    Console.WriteLine("File not found.");
                    return;
                }

                songs[title] = newFilePath;
                Console.WriteLine("Song updated sucessfully.");
            }
            else
            {
                Console.WriteLine("Song not found");
            }
        }

        static void DeleteSong()
        {
            Console.Write("Enter the title of the song you want to delete: ");
            string title = Console.ReadLine();
            if (songs.ContainsKey(title))
            {
                songs.Remove(title);
                Console.WriteLine("Song deleted sucessfully.");
            }
            else 
            {
                Console.WriteLine("Song not found.");
            };
        }
    }
}
