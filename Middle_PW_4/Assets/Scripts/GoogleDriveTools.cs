using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityGoogleDrive.Data;
using UnityGoogleDrive;
using System.Text;
using System;

namespace DefaultNamespace
{
    public static class GoogleDriveTools
    {
        public static List<File> FileList()
        {
            List<File> output = new List<File>();
            GoogleDriveFiles.List().Send().OnDone += fileList => { output = fileList.Files; };
            return output;
        }

        public static File Upload(String obj, Action onDone)
        {
            var file = new UnityGoogleDrive.Data.File { Name = "FirstGame.json", Content = Encoding.ASCII.GetBytes(obj) };
            GoogleDriveFiles.Create(file).Send();
            return file;
        }

        public static File Download(String fileId)
        {
            File output = new File();
            GoogleDriveFiles.Download(fileId).Send().OnDone += file => { output = file; };
            return output;
        }
    }
}
