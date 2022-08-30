# Unzipper

A simple static C# class to recursively discover and extract zip files from a given directory

> ## Version 1.00
### Basic features implemented
- Find all files from a directory and all subdirectories
- Find all .zip files from a directory and all subdirectories
- Extract all .zip files from a directory and all subdirectories
- Extract all .zip files from a List<string> of .zip file paths

## Usage
### Get all files from a directory and all subdirectories:
```
List<string> allFiles = Unzipper.GetAllFilesFrom("/Users/hamsterMacOS/Downloads"); 
```
### Get all zip files from a directory and all subdirectories
```
List<string> zipFiles = Unzipper.GetAllZipFilesFrom("c:\Users\hamsterWindows\Downloads");
```
### Extract all zip files from a directory and all subdirectories
```
Dictionary<string, string> xtractions = Unzipper.UnzipFiles("/Users/hamsterMacOS/Downloads"); 
/* xtractions' key is the path to the zip file; value is the path of the extracted .zip archive */
```
### Extract all zip files from a List<string> of .zip file paths
```
List<string> zipFilesList = new List<string>();
zipFilesList.add("c:\archive1.zip");
zipFilesList.add("c:\temp\archive2.zip");
zipFilesList.add("d:\temp\temp.zip");

Dictionary<string, string> xtractions = Unzipper.UnzipFiles(zipFilesList);
/* xtractions' key is the path to the zip file; value is the path of the extracted .zip archive */

