var environment = Environment.GetEnvironmentVariables();

string url = environment["URL"].ToString();
string cookie = environment["COOKIE"].ToString();

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Add("cookie", cookie);
var response = await client.GetAsync(url);
var responseString = await response.Content.ReadAsStringAsync();

// Funcions

int ConvertToAbsolute(int value){
    if (value < 0)
        return value*-1;

    return value;
}

// Start Report

int reportsSafes = 0;

foreach (var ListReports in responseString.Split("\n").ToList()){
    if (ListReports == "")
            continue;
    int? previusReport = null;
    int level = 0;
    bool descLevel = false; 
    bool flagReport = true;
    
    foreach (string Report in  ListReports.Split(" ").ToList() ){
        if (Report == "")
            continue;
        int value =  int.Parse(Report);

        if (previusReport == null){
            previusReport = value;
            continue;
        }

        if (previusReport == value){
            flagReport = false;
            break;
        }

        if (level == 0)
            descLevel = (int)previusReport - value < 0;

        level = (int)previusReport - value;

        
        if (descLevel != level < 0){
            flagReport = false;
            break;
        }
        level = (int)previusReport - value;

        if (ConvertToAbsolute(level) >= 4 ){
            flagReport = false;
            break;
        }
        
        previusReport = value;
        flagReport = true;
    }

    if (flagReport)
        reportsSafes++;

    Console.WriteLine($"\nFim da unidade: {ListReports}, total de reports: {reportsSafes}");
}

 Console.WriteLine($"fim do report. Reportes Seguros: {reportsSafes}");


