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
            List<string> allZipFiles = GetAllZipFilesFrom(path);

            return UnzipFiles(allZipFiles);
        }

        /// <summary>
        /// Unzips all the files provided in the input list
        /// </summary>
        /// <param name="zipFilePaths"></param>
        /// <returns>Dictionary<string: zip src, string: extracted dir></returns>
        public static Dictionary<string, string> UnzipFiles(List<string> zipFilePaths)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (string fp in zipFilePaths)
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

            return result;
        }

        /// <summary>
        /// Returns a list of absolute paths to ALL files recusrively found from the specified path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List<string> of all files in directory and subdirectories of path</string></returns>
        public static List<string> GetAllFilesFrom(string path)
        {
            List<string> result = new List<string>();

            try
            {
                result.AddRange(Directory.GetFiles(path));

                foreach (string str in Directory.GetDirectories(path))
                {
                    result.AddRange(GetAllFilesFrom(str));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Returns a list of absolute paths to zip files found recursively from the specified path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> GetAllZipFilesFrom(string path)
        {
            List<string> temp = GetAllFilesFrom(path);
            List<string> result = new List<string>(temp.Count);
            Regex reg = new Regex(@"(?i)(.*\.zip)");

            foreach (string fn in temp)
            {
                if (reg.IsMatch(fn))
                {
                    result.Add(fn);
                }
            }


            return result;
        }

    }
}