using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreateCsv
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter File Path to Read");
            string fileName = Console.ReadLine();
            Console.WriteLine("Enter File Path to Create CSV");
            string pathforcsv = Console.ReadLine();
            //string fileName = @"C:\Users\llol1\Desktop\Profit.txt";
            FileInfo oFileInfo = new FileInfo(fileName);
            if (oFileInfo != null || oFileInfo.Length == 0)
            {
                Console.WriteLine("My File's Name: \"" + oFileInfo.Name + "\"");
                // For calculating the size of files it holds.
                Console.WriteLine("myFile filepath: " + oFileInfo.DirectoryName);
                Console.WriteLine("myFile total Size: " + oFileInfo.Length.ToString());
            }

            if (!oFileInfo.Exists)
            {
                throw new FileNotFoundException("The file was not found.", fileName);
            }

            DateTime dtCreationTime = oFileInfo.CreationTime;
            Console.WriteLine("Date and Time File Created: " + dtCreationTime.ToString());
            Console.WriteLine("myFile Extension: " + oFileInfo.Extension);

            // Set the path and filename variable "path", filename being MyTest.csv in this example.
            // Change SomeGuy for your username.

            // Set the variable "delimiter" to ", ".
            string delimiter = ", ";

            // This text is added only once to the file.
            if (!File.Exists(pathforcsv))
            {
                // Create a file to write to.
                string createText = "FileName" + delimiter + "FilePath" + delimiter + "FileSize" + delimiter + "FileDateTime" + delimiter + "FileExtension" + delimiter + Environment.NewLine;
                File.WriteAllText(pathforcsv, createText);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string appendText = oFileInfo.Name + delimiter + oFileInfo.DirectoryName + delimiter + oFileInfo.Length.ToString() + delimiter + dtCreationTime.ToString() + delimiter + oFileInfo.Extension + Environment.NewLine;
            File.AppendAllText(pathforcsv, appendText);

            // Open the file to read from.
            string readText = File.ReadAllText(pathforcsv);
            Console.WriteLine(readText);
        }
    }
}