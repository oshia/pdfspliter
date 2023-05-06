dotnet build

$_AppPath = ".\bin\Debug\netcoreapp2.2\PdfSpliter.dll"

$_BaseDirectory = "./pdfspliter\sandbox"

$SourcePdfFilePath = "${_BaseDirectory}\LargeDoc.pdf"

$ConfigFilePath = "${_BaseDirectory}\config.json"

$OutputFilesPath = "${_BaseDirectory}\output\"

dotnet $_AppPath $SourcePdfFilePath -c "${ConfigFilePath}" -o "${OutputFilesPath}"
