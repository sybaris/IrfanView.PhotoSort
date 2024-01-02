using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using CommandLine;
using CommandLine.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using Sybaris.IrfanView.Extensions.PhotoSort.CommandLineParserTooling;
using System.Windows.Forms;
using Sybaris.IrfanView.Extensions.PhotoSort.Verbs;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Console.WriteLine("Sybaris.IrfanView.Extensions.PhotoSort v{0}", System.Diagnostics.Process.GetCurrentProcess().MainModule.FileVersionInfo.ProductVersion);
        Application.EnableVisualStyles();
        new Program().MainInternal(args);
    }

    // Load all types using Reflection
    internal static Type[] LoadOptionClasses()
    {
        return Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();
    }

    internal static Type[] LoadVerbClasses()
    {
        Type baseType = typeof(VerbBase<>);
        return Assembly.GetExecutingAssembly().GetTypes()
             .Where(type => type.IsClass && !type.IsAbstract && type.BaseType != null && type.BaseType.IsGenericType &&
                            (type.BaseType.GetGenericTypeDefinition() == baseType || type.BaseType.BaseType?.GetGenericTypeDefinition() == baseType))
             .ToArray();
    }

    internal void MainInternal(string[] args)
    {
        var parser = new Parser(settings =>
        {
            settings.CaseSensitive = false;
            settings.HelpWriter = null;
            settings.AutoVersion = false;
        });

        var optionsClasses = LoadOptionClasses(); // https://github.com/commandlineparser/commandline/wiki/Verbs

        var parserResult = parser.ParseArguments(args, optionsClasses);

        parserResult.MapResult(options => RunInternal(options, parserResult, args), errors => RunErrors(errors, parserResult, args));
    }

    internal virtual int RunInternal(object objOptions, ParserResult<object> parserResult, string[] args)
    {
        try
        {
            if (objOptions is IOptionsValidate)
                ((IOptionsValidate)objOptions).Validate();
        }
        catch (ArgumentValidationException ex)
        {
            RunCustomErrors(ex.Message, parserResult, args);
            return 1;
        }
        return Run(objOptions, parserResult, args);
    }

    static void DisplayHelp<T>(ParserResult<T> result)
    {
        var helpText = HelpText.AutoBuild(result, h =>
        {
            h.AutoVersion = false;
            h.OptionComparison = HelpText.RequiredThenAlphaComparison;
            h.AdditionalNewLineAfterOption = false;
            h.AddDashesToOption = true;
            h.AddEnumValuesToHelpText = true;
            h.Heading = "Program tool to manage the classification of photos in album using IrfanView";
            h.Copyright = "";
            h.MaximumDisplayWidth = 300;
            return HelpText.DefaultParsingErrorsHandler(result, h);
        }/*, e => e, verbsIndex: true*/);

        Console.WriteLine(helpText);
    }

    internal virtual int RunErrors(IEnumerable<Error> errors, ParserResult<object> parserResult, string[] args)
    {
        DisplayHelp(parserResult);

        Console.WriteLine($"Original command line = '{string.Join(" ", args)}'");
        if (Debugger.IsAttached && errors != null)
        {
            Console.WriteLine($"DEBUG : Error during parsing command line (errors count = {errors.Count()})");
            foreach (var error in errors)
                Console.WriteLine("  " + error + " ");
        }
        Environment.ExitCode = 1;
        return 1;
    }

    internal virtual int RunCustomErrors(string errorMessage, ParserResult<object> parserResult, string[] args)
    {
        Console.WriteLine(errorMessage);
        return RunErrors(null, parserResult, args);
    }

    internal virtual int Run(object objOptions, ParserResult<object> parserResult, string[] args)
    {
        var optionsType = objOptions.GetType();
        var verbClasses = LoadVerbClasses();
        var verbType = verbClasses.FirstOrDefault(vType => vType.BaseType?.GenericTypeArguments[0] == optionsType);

        if (verbType == null)
            throw new NotImplementedException("DEVELOPPER : Are you missing to declare an verb/option ?");

        var verb = (IRunnable)Activator.CreateInstance(verbType, objOptions);
        CommandLineParserHelper.DisplayObjectOptions(objOptions);

        verb.Run();
        return 0;
    }
}
