namespace AOC_Data;

public class AOCAccessData
{
    public static async Task<string?> GetData(){

        var environment = Environment.GetEnvironmentVariables();

        string cookie = environment["COOKIE"].ToString();
        string url = environment["URL"].ToString();

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("cookie", cookie);
        var response = await client.GetAsync(url);
        string responseString = await response.Content.ReadAsStringAsync();

        return responseString;
    }
}
