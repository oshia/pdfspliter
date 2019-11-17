namespace PdfSpliter.Services {
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Aspose.Pdf.Text;
    using Aspose.Pdf;
    using PdfSpliter.Models;
    public class DocumentsService {
        private SettingsModel _settings { get; set; }
        private bool _readyState { get; set; }
        public DocumentsService(SettingsModel settings) {
            _settings = settings;
            loadLicence();
        }

        private void loadLicence() {
            try {
                License lic = new License();
                lic.SetLicense("Aspose.Total.lic");
                _readyState = true;

            } catch (Exception) {
                ExceptionsService.displayError(new Exception("Error in loading License file."));
                _readyState = false;
            }
        }
        public bool isReady() => _readyState;
        public void doSplit() {
            try {
                Document sourceDocument = new Document(_settings.SourcePdfFilePath);
                int n = 0;
                sourceDocument.Pages.ToList().ForEach(
                    sourcePage => {
                        n++;
                        PageNameModel pageSettings = _settings.PageNameList.FirstOrDefault(x => x.Id == n);
                        if (pageSettings?.Name?.Trim().Length > 0) {
                            Document destinationDocument = new Document();
                            destinationDocument.Pages.Add(sourcePage);
                            destinationDocument.Save($"{_settings.OutputFilesPath}{pageSettings.Name}");
                        }
                    });
            } catch (Exception ex) {
                ExceptionsService.displayError(ex);
            }
        }
    }
}