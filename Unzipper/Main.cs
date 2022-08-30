/*
 * Copyright Jason Fakour
 * Aug 30, 2022
 * All rights reserved
 */

using System.IO.Compression;

namespace Unzipper
{
    class UnZipperDriver
    {
        static void Main(string[] args)
        {
            List<string> arguments = new List<string>(args);


            if (arguments.Count == 0)
            {
                displayWelcomeMsg();
                Console.Write("Full path to directory containing zip files: ");
                string dp = Console.ReadLine() ?? Directory.GetCurrentDirectory();
                arguments.Add(dp);

            }

            Dictionary<string, string> extractedZipFiles = new Dictionary<string, string>();

            foreach (string dirPath in arguments)
            {
                extractedZipFiles = extractedZipFiles
                    .Concat(Unzipper.UnzipFiles(dirPath))
                    .ToDictionary(x=> x.Key, x=> x.Value);
            }

            foreach (string fp in extractedZipFiles.Keys)
            {
                Console.WriteLine("* Extracting \"" + fp + "\" To \"" + extractedZipFiles[fp] + "\"") ;
            }

        }

        static private void displayWelcomeMsg()
        {
            string msg = "**********************************************************\n" +
                         "***!!!!!           PROCEED WITH CAUTION           !!!!!***\n" +
                         "**********************************************************\n" +
                         "* This application will recursively unzip all .zip files *\n" +
                         "*  from a given directory                                *\n" +
                         "*                                                        *\n" +
                         "* DO NOT USE A ROOT-LIKE PATH!!!                         *\n" +
                         "**********************************************************\n";
            Console.Write(msg);
        }
    }
}

