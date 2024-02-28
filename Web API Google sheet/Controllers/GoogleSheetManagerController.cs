using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Web_API_Google_sheet.Interface;

namespace Web_API_Google_sheet.Controllers
{
    [ApiController]
    public class GoogleSheetManagerController : ControllerBase
    {
        private readonly IGoogleSheetManager _googleSheetManager;
        private readonly GoogleAuthencation _googleAuthencation;

        public GoogleSheetManagerController(IGoogleSheetManager googleSheetManager, GoogleAuthencation googleAuthencation)
        {
            _googleSheetManager = googleSheetManager;
            _googleAuthencation = googleAuthencation;
        }

        [HttpPost]
        public IActionResult CreateNewSheet()
        {
       /*     string googleClentId = "488672609428-laf6sfcjj63pasidds1odqb7v0v84d9h.apps.googleusercontent.com";
            string googleClientSecret = "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";
            string[] scopes = new[] { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets };

            UserCredential credential = GoogleAuthencation.Login(googleClentId, googleClientSecret, scopes);*/
            string newdoc = Console.ReadLine();

            var a = _googleSheetManager.CreateNew(newdoc);
            return Ok(a);
        }
    }
}
