namespace PdfSpliter.Services {
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System;
    using Newtonsoft.Json;
    using PdfSpliter.Models;
    public class ProgramArgumentsService {
        public SettingsModel checkProgrammArguments(string[] args) {
            try {
                if (args.Length < 1 || new [] { 2, 4 }.Contains(args.Length) || args.Length > 5) {
                    throw new Exception("Incorrect arguments.");
                }
                SettingsModel settingsModel = new SettingsModel();
                // --- SourcePdfFilePath ---
                if (!File.Exists(args[0])) {
                    throw new Exception("SourcePdfFilePath not found.");
                } else {
                    settingsModel.SourcePdfFilePath = args[0];
                }
                // --- First Option ---
                if (args.Length > 1 && args[1] != null && args[2] != null) {
                    settingsModel = checkOptions(args[1], args[2], settingsModel);
                }
                // --- Second Option ---
                if (args.Length > 3 && args[3] != null && args[4] != null) {
                    settingsModel = checkOptions(args[3], args[4], settingsModel);
                }
                return settingsModel;
            } catch (System.Exception ex) {
                ExceptionsService.displaySynopsis(ex);
                return null;
            }
        }

        private SettingsModel checkOptions(string name, string value, SettingsModel settingsModel) {
            try {
                switch (name) {
                    case "-o":
                    case "--output":
                        if (!Directory.Exists(value)) {
                            throw new Exception("OutputFilesPath not found.");
                        }
                        settingsModel.OutputFilesPath = value;
                        break;
                    case "-c":
                    case "--config":
                        settingsModel.PageNameList = readConfigFile(value);
                        if (settingsModel.PageNameList == null) {
                            throw new Exception("Reading configuration Impossible");
                        }
                        break;
                }
                return settingsModel;
            } catch (Exception) {
                throw;
            }
        }

        private List<PageNameModel> readConfigFile(string configFilePath) {
            try {
                if (!File.Exists(configFilePath)) {
                    throw new Exception("ConfigFilePath not found.");
                }
                var json = File.ReadAllText(configFilePath);
                return JsonConvert.DeserializeObject<List<PageNameModel>>(json);
            } catch (Exception) {
                throw;
            }
        }
    }
}