using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Sybaris.IrfanView.Extensions.PhotoSort.CommandLineParserTooling;
using Sybaris.IrfanView.Extensions.PhotoSort.Options;

namespace Sybaris.IrfanView.Extensions.PhotoSort.Verbs
{
    internal class SplitFolderVerb : VerbBase<SplitFolderOptions>
    {
        public SplitFolderVerb(SplitFolderOptions options) : base(options)
        {
        }

        private void Logs(string message)
        {
            
        }

        public override void Run()
        {
            if (Options.Debugger)
                System.Diagnostics.Debugger.Launch();

            try
            {
                Directory.SetCurrentDirectory("c:\\");

                string imagePath = Options.CurrentPictureFileName;
                DateTime dateSelectedFile = PictureHelper.GetDateTakenFromImage(imagePath);

                string folderPath = Path.GetDirectoryName(imagePath);
                string imageFileName = Path.GetFileName(imagePath);
                var files = Directory.GetFiles(folderPath, "*.jpg").OrderBy(f => f, StringComparer.CurrentCultureIgnoreCase).Select(f => Path.GetFileName(f)).ToList();
                var indexLast = files.IndexOf(imageFileName);
                if (indexLast == -1)
                {
                    var text = $"Une erreur s'est produite : Impossible de retrouver le fichier {imageFileName} dans le dossier {folderPath}";
                    MessageBox.Show(text,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                DateTime dateFirstFile = PictureHelper.GetDateTakenFromImage(Path.Combine(folderPath, files[0]));
                string newFolderName = dateFirstFile.ToString("yyyy.MM.dd") + " - ";

                string infoDate = "";
                if (dateFirstFile.Date != dateSelectedFile.Date)
                    infoDate = $"{dateFirstFile.ToString("yyyy.MM.dd")} --> {dateSelectedFile.ToString("yyyy.MM.dd")} | {(dateSelectedFile.Date- dateFirstFile.Date).Days} jours";

                string info = $"{indexLast + 1}/{files.Count} fichiers à déplacer";

                if (SplitFolderForm.Run(ref newFolderName, info, infoDate) != DialogResult.OK)
                    return;

                var filesToMove = files.Take(indexLast + 1).ToList();
                var newFolderNameFull = Path.Combine(Path.Combine(folderPath, ".."), newFolderName);

                Console.WriteLine("Creating folder");
                Directory.CreateDirectory(newFolderNameFull);

                Console.WriteLine("Starting to move files");
                foreach (var file in filesToMove)
                {
                    string source = Path.Combine(folderPath, file);
                    string destination = Path.Combine(newFolderNameFull, file);
                    Console.WriteLine($"  Moving {file}");
                    File.Move(source, destination);
                }
                Console.WriteLine("Move done");
            }
            catch (Exception ex)
            {
                var text = $"Une erreur s'est produite : {ex.Message}";
                MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
