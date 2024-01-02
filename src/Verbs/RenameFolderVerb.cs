using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using Sybaris.IrfanView.Extensions.PhotoSort.CommandLineParserTooling;
using Sybaris.IrfanView.Extensions.PhotoSort.Options;

namespace Sybaris.IrfanView.Extensions.PhotoSort.Verbs
{
    internal class RenameFolderVerb : VerbBase<RenameFolderOptions>
    {
        public RenameFolderVerb(RenameFolderOptions options) : base(options)
        {
        }

        static void KillProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                    Console.WriteLine($"Process {process.ProcessName} killed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unable to kill process {process.ProcessName}: {ex.Message}");
                }
            }
        }



        public override void Run()
        {
            return;

            if (Options.Debugger)
                System.Diagnostics.Debugger.Launch();

            Console.WriteLine(Directory.GetCurrentDirectory());
            Directory.SetCurrentDirectory("c:\\");

            string imagePath = Options.CurrentPictureFileName;

            try
            {
                DateTime dateTaken = PictureHelper.GetDateTakenFromImage(imagePath);
                //DateTime dateTaken = DateTime.Now;

                if (dateTaken == DateTime.MinValue)
                {
                    Console.WriteLine("Impossible de récupérer la date de la photo à partir des informations EXIF.");
                    return;
                }

                string prefix = dateTaken.ToString("yyyy.MM.dd");
                string oldFoldlerPath = Path.GetDirectoryName(imagePath);
                string parentFolderPath = Path.GetDirectoryName(oldFoldlerPath);
                string parentFolderName = Path.GetFileName(oldFoldlerPath);

                string newFolderPath = Path.Combine(parentFolderPath, prefix + " - " + parentFolderName);
                string newFilename = imagePath.Replace(oldFoldlerPath, newFolderPath);

                //if (!Directory.Exists(folderPath))
                //{
                //    Directory.CreateDirectory(folderPath);
                //}

                Console.WriteLine("Trying to kill IrfanView");
                KillProcess("i_view64");
                Console.WriteLine("IrfanView killed");
                Thread.Sleep(500);
                Console.WriteLine($"Renaming folder \"{oldFoldlerPath}\" to: \"{newFolderPath}\"");
                Directory.Move(oldFoldlerPath, newFolderPath);
                Thread.Sleep(500);

                Process.Start(new ProcessStartInfo()
                {
                    Arguments = $"RenameFolder --OldFolderName=\"{oldFoldlerPath}\" --NewFolderName=\"{newFolderPath}\" --PictureFileName=\"{newFilename}\"",
                    // FileName = "C:\\Program Files\\IrfanView\\i_view64.exe",
                    FileName = "D:\\Dev\\2023.12.03 - IrfanView Extension Folder Renamer\\Sybaris.IrfanView.Extensions.PhotoSort\\bin\\Debug\\net6.0\\Sybaris.IrfanView.Extensions.PhotoSort.exe",
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Normal,
                    WorkingDirectory = Path.Combine(parentFolderName, "..")
                }); ;


            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
