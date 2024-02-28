using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Web_API_Google_sheet.Interface;

namespace Web_API_Google_sheet.Services
{
    public class GoogleSheetManager : IGoogleSheetManager
    {
        private readonly UserCredential _creadential;

        public GoogleSheetManager(UserCredential creadential)
        {
            _creadential = creadential;
        }

        public Spreadsheet CreateNew(string documentName)
        {
            if (string.IsNullOrEmpty(documentName))
                throw new ArgumentNullException(nameof(documentName));

            using (var sheetService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = _creadential }))
            {
                var documentCreatinRequest = sheetService.Spreadsheets.Create(new Spreadsheet()
                {
                    Sheets = new List<Sheet>()
                    {
                        new Sheet()
                        {
                            Properties = new SheetProperties()
                            {
                                Title = documentName
                            }
                        }
                    },
                    Properties = new SpreadsheetProperties()
                    {
                        Title = documentName
                    }
                });
                
                return documentCreatinRequest.Execute();
            }
        }
    }
}
