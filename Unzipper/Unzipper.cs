using System;
using System.Text.RegularExpressions;
using System.IO.Compression;
/*
 * Copyright Jason Fakour
 * Aug 30, 2022
 * All rights reserved
 */

namespace Unzipper
{
    public static class Unzipper
    {
        /// <summary>
        /// Recursively collects all the .zip files and extracts them.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Dictionary<string: zip src, string: extracted dir></returns>
        public static Dictionary<string, string> UnzipFiles(string path)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            List<string> allFiles = GetAllFilesFromPath(path);

            Regex reg = new Regex(@"(?i)(.*\.zip)");

            foreach (string fp in allFiles)
            {
                string fn = Path.GetFileName(fp);


                if (reg.IsMatch(fn))
                {
                    string dirXtract = Path.GetDirectoryName(fp) ?? "";
                    string fXtractName = Path.GetFileNameWithoutExtension(fp);
                    string xtractPath = Path.Combine(dirXtract, fXtractName);

                    try
                    {
                        ZipFile.ExtractToDirectory(fp, xtractPath);
                        result.Add(fp, xtractPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }

            return result;

        }

        /// <summary>
        /// Recursively collects ALL files in a directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List<string> of all files in directory and subdirectories of path</string></returns>
        public static List<string> GetAllFilesFromPath(string path)
        {
            List<string> result = new List<string>();

            try
            {
                result.AddRange(Directory.GetFiles(path));

                foreach (string str in Directory.GetDirectories(path))
                {
                    result.AddRange(GetAllFilesFromPath(str));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

    }
}