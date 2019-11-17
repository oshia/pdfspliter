namespace PdfSpliter {
    using System;
    using PdfSpliter.Models;
    using PdfSpliter.Services;
    class Program {
        static void Main(string[] args) {
            ProgramArgumentsService programArgumentsService = new ProgramArgumentsService();
            SettingsModel settingsModel = programArgumentsService.checkProgrammArguments(args);
            if (settingsModel != null) {
                DocumentsService documentsService = new DocumentsService(settingsModel);
                if (documentsService.isReady()) {
                    documentsService.doSplit();
                }
                Console.WriteLine();
                Console.WriteLine("<<[#___ END OF SPLIT ___#]>>");
                Console.WriteLine();
            }
        }
    }
}