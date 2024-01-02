using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sybaris.IrfanView.Extensions.PhotoSort.Options
{
    [Verb("RenameFolder", HelpText = "Rename a folder")]
    public class RenameFolderOptions
    {
        [Option(Required = true, HelpText = "Current path and filename of the picture that is currently displayed in IrfanView")]
        public string CurrentPictureFileName { get; set; }

        [Option(Required = false, HelpText = "Launch the debugger")]
        public bool Debugger { get; set; }
    }
}
