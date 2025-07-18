using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Processing...");

        try
        {
            // Validate number of arguments
            if (args.Length != 1)
            {
                Console.WriteLine("Error: Invalid number of arguments.");
                Console.WriteLine("Usage: VerticalLineCounter.exe <absolute_image_path>");
                return;
            }

            string imagePath = args[0];

            // Validate the image file path 
            if (!File.Exists(imagePath))
            {
                Console.WriteLine($"Error: File not found at path: {imagePath}");
                return;
            }

            int lineCount = CountVerticalLines(imagePath);
            Console.WriteLine(lineCount);
        }
        catch (Exception ex)
        {
            // Handle exceptions and print error messages
            Console.WriteLine($"Exception occurred: {ex.Message}");
        }

         Console.WriteLine("Process is complete...");
    }

    static int CountVerticalLines(string imagePath)
    {
        // Ensure the application is running on a supported Windows version
        // Bitmap processing is only supported on Windows 6.1 (Windows 7) and later
        if (!OperatingSystem.IsWindowsVersionAtLeast(6, 1))
        {
            throw new PlatformNotSupportedException("Bitmap processing is only supported on Windows 6.1 (Windows 7) and later.");
        }

        // Load the image and count vertical lines
        using (Bitmap bitmap = new Bitmap(imagePath))
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            int lineCount = 0;
            bool inLine = false;

            for (int x = 0; x < width; x++)
            {
                bool foundBlackPixel = false;

                for (int y = 0; y < height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    // Consider the pixel "black" if all RGB values are close to 0
                    if (pixelColor.R < 10 && pixelColor.G < 10 && pixelColor.B < 10)
                    {
                        foundBlackPixel = true;
                        break; // Found a black pixel in this column / improve performance
                    }
                }

                if (foundBlackPixel)
                {
                    if (!inLine)
                    {
                        // Start of a new vertical line
                        lineCount++;
                        inLine = true;
                    }
                }
                else
                {
                    inLine = false; // End of a black line
                }
            }

            return lineCount;
        }
    }
}
