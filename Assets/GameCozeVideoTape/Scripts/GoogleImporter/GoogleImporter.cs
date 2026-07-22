using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class GoogleImporter
{
    private List<string> _headers;
    private readonly SheetsService _service;
    private readonly string _sheetId;


    public GoogleImporter(string credentialsPath, string sheetId)
    {
        _sheetId = sheetId;
        GoogleCredential credential;
        using (var stream = new System.IO.FileStream(credentialsPath, System.IO.FileMode.Open))
        {
            credential = GoogleCredential.FromStream(stream).CreateScoped(SheetsService.Scope.Spreadsheets);

        }

        _service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
        {
            HttpClientInitializer = credential
        });
    }


    public async Task DownloandAndParseSheet(string sheetName, IGoogleParser googleParser)
    {
        _headers = new();
        Debug.Log($"Starting Downloand sheet ({sheetName}) ...");

        var range = $"{sheetName}!A1:Z";
        var request = _service.Spreadsheets.Values.Get(_sheetId, range);

        ValueRange response;
        try
        {
            response = await request.ExecuteAsync();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error google Data {e.Message}");
            return;
        }

        if (response != null && response.Values != null)
        {
            var tableArray = response.Values;
            Debug.Log($"Sheet Downloand Successfully ({sheetName}) . Parse ");

            var firstRow = tableArray[0];

            foreach (var cell in firstRow)
            {
                _headers.Add(cell.ToString());
            }

            var rowsCount = tableArray.Count;

            for (int i = 1; i < rowsCount; i++)
            {
                var row = tableArray[i];
                var rowLenght = row.Count;

                for (int j = 0; j < rowLenght; j++)
                {
                    var cell = row[j];
                    var header = _headers[j];
                    Debug.Log($"Header: {header}, Value: {cell}");

                    googleParser.Parse(header, cell.ToString());
                }


            }
            Debug.Log($"Sheet Parse Successfully");
        }
        else
        {
            Debug.LogWarning($"No Data found in Google sheet ");
        }
    }


}
