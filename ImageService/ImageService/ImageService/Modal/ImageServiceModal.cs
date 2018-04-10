using ImageService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ImageService.Modal
{
    public class ImageServiceModal : IImageServiceModal
    {
        #region Members
        private string m_OutputFolder;            // The Output Folder
        private int m_thumbnailSize;              // The Size Of The Thumbnail Size
       
        #endregion
        public string AddFile(string path,string fileName, out bool result)
        {
            // Create a file name for the file you want to create. 
           // string fileName = System.IO.Path.GetRandomFileName();
            // Verify the path that you have constructed.
            Console.WriteLine("Path to my file: {0}\n", path);
            if (System.IO.File.Exists(pathString))
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }
        }

        public string createFolder(string path,string folderName, out bool result)
        {
            string pathString = System.IO.Path.Combine(path,folderName);

            // Create the subfolder. You can verify in File Explorer that you have this
            System.IO.Directory.CreateDirectory(pathString);
            return pathString;
        }

        public string copyFile(string path, out bool result)
        {
            string fileName = "test.txt";
            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
        }

        public string copyFolder(string path, out bool result)
        {
            string sourcePath = @"C:\Users\Public\TestFolder";
            string targetPath = @"C:\Users\Public\TestFolder\SubDir";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
        }

        public string moveFile(string SourcePath, string DestPath, out bool result)
        {
            // To move a file or folder to a new location:
            System.IO.File.Move(SourcePath, DestPath);
        }

        public string moveFolder(string SourcePath,string DestPath, out bool result)
        {
            // To move a file or folder to a new location:
            System.IO.File.Move(SourcePath, DestPath);
        }

        public string deleteFile(string SourcePath, string DestPath, out bool result)
        {
            // Delete a file by using File class static method...
            if (System.IO.File.Exists(@"C:\Users\Public\DeleteTest\test.txt"))
            {
                try
                {
                    System.IO.File.Delete(@"C:\Users\Public\DeleteTest\test.txt");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }

        public string deleteFolder(string SourcePath, string DestPath, out bool result)
        {
            // Delete a directory. Must be writable or empty.
            try
            {
                System.IO.Directory.Delete(@"C:\Users\Public\DeleteTest");
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}