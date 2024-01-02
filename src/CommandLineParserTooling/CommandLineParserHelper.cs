using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sybaris.IrfanView.Extensions.PhotoSort.CommandLineParserTooling
{
    public static class CommandLineParserHelper
    {
        public static string ObjectOptionsToString(object objOptions)
        {
            VerbAttribute verbAttribute = (objOptions.GetType()).GetCustomAttribute<VerbAttribute>();
            var result = "Verb : " + verbAttribute.Name + Environment.NewLine
                + "Options : " + Environment.NewLine
                + ReflectionHelper.PublicPropertiesToString(objOptions);
            return result;
        }

        public static void DisplayObjectOptions(object objOptions)
        {
            var s = ObjectOptionsToString(objOptions);
            Console.WriteLine(s);
        }

    }
}
