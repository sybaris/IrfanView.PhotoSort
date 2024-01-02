using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sybaris.IrfanView.Extensions.PhotoSort.Options
{
    [Verb("SplitFolder", HelpText = "Separate pictures and move them to a new folder")]
    public class SplitFolderOptions
    {
        [Option(Required = true, HelpText = "Current path and filename of the picture that is currently displayed in irfan view")]
        public string CurrentPictureFileName { get; set; }

        [Option(Required = false, HelpText = "Launch the debugger")]
        public bool Debugger { get; set; }

    }
}
