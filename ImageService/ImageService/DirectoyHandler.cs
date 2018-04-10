using ImageService.Modal;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageService.Infrastructure;
using ImageService.Infrastructure.Enums;
using ImageService.Logging;
using ImageService.Logging.Modal;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Drawing;

namespace ImageService.Controller.Handlers
    
{
    public class DirectoyHandler : IDirectoryHandler
    {
        #region Members
        private IImageController m_controller;              // The Image Processing Controller
        private ILoggingService m_logging;
        private FileSystemWatcher m_dirWatcher;             // The Watcher of the Dir
        private string m_path;                              // The Path of directory
        #endregion

        public event EventHandler<DirectoryCloseEventArgs> DirectoryClose; // The Event That Notifies that the Directory is being closed
        public ImageServiceModal ism;

        /*********************************************************************/

        public void StartHandleDirectory(string dirPath) {

        }

        /*********************************************************************/

        public void OnCloseServer() {

        }

        /*********************************************************************/

        public CommandRecievedEventArgs onCommandReceived(command) {

            //check if command is meant for its directory, if yes – handle command(for now will just be to close handler)
        }

        /*********************************************************************/

        public void closeHandler() {
            //– close FileSystemWatcher and invoke onClose event
            m_dirWatcher.
            DirectoryClose.Invoke(this,);
        }

        /*********************************************************************/

        //we init this once so that if the function is repeatedly called
        //it isn't stressing the garbage man
        private static Regex r = new Regex(":");

        //retrieves the datetime WITHOUT loading the whole image
        public static DateTime GetDateTakenFromImage(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image myImage = Image.FromStream(fs, false, false))
            {
                PropertyItem propItem = myImage.GetPropertyItem(36867);
                string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                return DateTime.Parse(dateTaken);
            }
        }

        /*********************************************************************/
        public void createDateFolder()
        {
            string result;
            //create folder with the year date
            string path = ism.createFolder("c:/OutputDir", GetDateTakenFromImage("c:/OutputDir").Year.ToString(), out result);
            //create folder with the month date
            string pathMonth = ism.createFolder(path,GetDateTakenFromImage("c:/OutputDir").Month.ToString(), out result);
            //move image
            ism.moveFile(path,pathMonth, out result);

            //notify logger
            m_logging.Log(,);

            //for thumbnails directory
            string pathFolder = ism.createFolder("c:/OutputDir", "Thumbnails", out result);
            //create folder with the year date
            string path2 = ism.createFolder("c:/OutputDir", "Year",out result);
            //create folder with the month date
            string pathMonth2 = ism.createFolder(path, "Month", out result);
            string ThumbSize = ConfigurationManager.AppSettings["ThumbnailSize"];
            ism.AddFile(pathMonth,"Thumbnails",out result);

            //notify logger
            m_logging.
        }

    }
}
