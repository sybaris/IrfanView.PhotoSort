using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sybaris.IrfanView.Extensions.PhotoSort.CommandLineParserTooling
{
    public abstract class VerbBase<TOptions> : IRunnable
    {
        protected TOptions Options { get; private set; }

        public VerbBase(TOptions options)
        {
            Options = options;
        }
        public abstract void Run();
    }
}
