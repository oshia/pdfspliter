namespace PdfSpliter.Models {
    using System.Collections.Generic;
    public class SettingsModel {
        public string SourcePdfFilePath { get; set; }
        public string OutputFilesPath { get; set; }
        public List<PageNameModel> PageNameList { get; set; }
    }
}