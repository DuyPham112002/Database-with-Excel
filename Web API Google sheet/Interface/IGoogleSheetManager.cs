using Google.Apis.Sheets.v4.Data;

namespace Web_API_Google_sheet.Interface
{
    public interface IGoogleSheetManager
    {
        Spreadsheet CreateNew(string documentName);

    }
}
