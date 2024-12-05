
using System.Text.RegularExpressions;

internal class Program
{
    private static async global::System.Threading.Tasks.Task Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariables();

        string url = environment["URL"].ToString();
        string cookie = environment["COOKIE"].ToString();

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("cookie", cookie);
        var response = await client.GetAsync(url);
        string responseString = await response.Content.ReadAsStringAsync();

        string stringPatter  = @"(mul)+(\()+(\d{1,3})+(,)+(\d{1,3})+(\))";

        Regex regex = new Regex(stringPatter, RegexOptions.IgnoreCase);
        MatchCollection matches = regex.Matches(responseString);


        int totalResult = 0;

        foreach (Match match in matches){

            
            totalResult += int.Parse(match.Groups[3].ToString()) * int.Parse(match.Groups[5].ToString()) ;
        }

        Console.WriteLine(totalResult);

    }
}