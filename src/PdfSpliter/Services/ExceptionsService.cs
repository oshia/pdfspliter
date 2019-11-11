namespace PdfSpliter.Services {
    using System;
    public class ExceptionsService {
        public static void displaySynopsis(Exception ex) {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("    ____      ______   _____       ___ __           ");
            Console.WriteLine("   / __ \\____/ / __/  / ___/____  / (_) /____  _____");
            Console.WriteLine("  / /_/ / __  / /_    \\__ \\/ __ \\/ / / __/ _ \\/ ___/");
            Console.WriteLine(" / ____/ /_/ / __/   ___/ / /_/ / / / /_/  __/ /    ");
            Console.WriteLine("/_/    \\__,_/_/     /____/ .___/_/_/\\__/\\___/_/     ");
            Console.WriteLine("                        /_/                         ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Synopsis :");
            Console.WriteLine();
            Console.WriteLine(" PfSpliter SourcePdfFilePath [-c config.json] [-o OutputFilesPath]");
            Console.WriteLine();
            Console.WriteLine("-o, --output     Output PDF files path.");
            Console.WriteLine("-c, --config     Configuration JSON file path.");
            Console.WriteLine("                 [{id: 1, name: \"Pdf_Output_Filename.pdf\"}].");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            displayError(ex);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

        }

        public static void displayError(Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"src: {ex}");
        }
    }
}