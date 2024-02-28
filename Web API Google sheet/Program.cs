using Google.Apis.Auth.OAuth2;
using Web_API_Google_sheet.Interface;
using Web_API_Google_sheet.Services;

namespace Web_API_Google_sheet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string googleClentId = "488672609428-laf6sfcjj63pasidds1odqb7v0v84d9h.apps.googleusercontent.com";
            string googleClientSecret = "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";
            string[] scopes = new[] { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets };

            UserCredential credential = GoogleAuthencation.Login(googleClentId, googleClientSecret, scopes);


            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IGoogleSheetManager,GoogleSheetManager>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
