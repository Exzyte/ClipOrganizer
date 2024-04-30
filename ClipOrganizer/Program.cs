using System;
using System.IO;
using System.Text;


public class ClipOrganizer
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nClip Organizer Menu:");
            Console.WriteLine("1. Add New Clip");
            Console.WriteLine("2. View Saved Clips");
            Console.WriteLine("X. Exit");
            Console.WriteLine("Enter your choice: ");

            string choice = Console.ReadLine().ToUpper();

            switch (choice)
            {
                case "1":
                    // Code for saving clips
                    string clipsFolder = Path.Combine(Environment.CurrentDirectory, "clips");
                    if (!Directory.Exists(clipsFolder))
                    {
                        Directory.CreateDirectory(clipsFolder);
                    }
                    Console.WriteLine("Enter your clip text (enter a blank line to finish):");
                    StringBuilder clipText = new StringBuilder();

                    while (true)
                    {       
                        string line = Console.ReadLine();
                        if (string.IsNullOrEmpty(line))
                        {
                            break;
                        }
                        clipText.AppendLine(line);
                    }
                    
                    Console.WriteLine("Enter a filename to save your clip (with .txt extension):");
                    string desiredFilename = Console.ReadLine();
                    string filename = Path.Combine(clipsFolder, desiredFilename + ".txt");
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filename))
                        {
                            writer.Write(clipText.ToString());
                        }
                            Console.WriteLine("Clip saved successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error saving clip: " + ex.Message);
                    }
                        break;
                case "2":
                    // Code for viewing saved clips (list filenames or previews)
                    int previewLength = 30;
                    string clipFolders = Path.Combine(Environment.CurrentDirectory, "clips");
                    string[] clipFiles = Directory.GetFiles(clipFolders, "*.txt");

                    if (clipFiles.Length == 0)
                    {
                        Console.WriteLine("No clips found.");
                    }
                    else
                    {
                        Console.WriteLine("\nSaved Clips:");
                        foreach (string filename1 in clipFiles)
                        {           
                            using(StreamReader reader = new StreamReader(filename1))
                            {
                                char[] previewChars = new char[previewLength];  // Allocate character array
                                int charsRead = reader.ReadBlock(previewChars, 0, previewLength);
                                string preview = new string(previewChars, 0, charsRead);
                                Console.WriteLine($"{filename1}: {preview}...");
                            }
                        }
                    }
                    break;
                case "X":
                    Console.WriteLine("Exiting Clip Organizer...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

