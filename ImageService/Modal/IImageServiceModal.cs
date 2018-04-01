﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageService.Modal
{
    public interface IImageServiceModal
    {
        /// <summary>
        /// The Function Addes A file to the system
        /// </summary>
        /// <param name="path">The Path of the Image from the file</param>
        /// <returns>Indication if the Addition Was Successful</returns>
        string AddFile(string path, out bool result);
        string createFolder(string path, out bool result);
        string copyFile(string path, out bool result);
        string copyFolder(string path, out bool result);
        string moveFile(string SourcePath, string DestPath, out bool result);
        string moveFolder(string SourcePath, string DestPath, out bool result);
        string deleteFile(string SourcePath, string DestPath, out bool result);
        string deleteFolder(string SourcePath, string DestPath, out bool result);

    }
}
