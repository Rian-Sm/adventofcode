using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
internal class Program
{
    private static async global::System.Threading.Tasks.Task Main(string[] args)
    {   
        int totalMatchs = 0;
        int strLen = 4;

        string path = $"{System.IO.Directory.GetCurrentDirectory()}/Assets/caca-palavras.txt";

        var environment = Environment.GetEnvironmentVariables();

        string url = environment["URL"].ToString();
        string cookie = environment["COOKIE"].ToString();

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("cookie", cookie);
        var response = await client.GetAsync(url);
        string  responseString = await response.Content.ReadAsStringAsync();

//         path = $"{System.IO.Directory.GetCurrentDirectory()}/Assets/caca-palavras2.txt";
//         string responseString = @"MMMSXXMASM
// MSAMXMSMSA
// AMXSXMAAMM
// MSAMASMSMX
// XMASAMXAMM
// XXAMMXXAMA
// SMSMSASXSS
// SAXAMASAAA
// MAMMMXMMMM
// MXMXAXMASX";

        bool fileExits = File.Exists(path);
        if (!fileExits)
           File.WriteAllText(path, responseString);

        string regx1  = @"(XMAS)";
        string regx2  = @"(SAMX)";

        Regex regex = new Regex(regx1, RegexOptions.IgnoreCase);
        MatchCollection matches = regex.Matches(responseString);

        totalMatchs += matches.Count;

        regex = new Regex(regx2, RegexOptions.IgnoreCase);
        matches = regex.Matches(responseString);

        totalMatchs += matches.Count;


        //==== lendo arquivo
        string[] lines = File.ReadAllLines(path);

        int row = lines.Length;
        int col = lines[0].Length;

        char[,] matrix = new char[row, col];

        for (int i = 0; i < row; i++){
            string rowStr = lines[i];

            for (int j = 0; j < col; j++){

                matrix[i, j] = rowStr[j];
            }
        }

       

        //==== Leitura por coluna
        for (int i = 0; i < row ; i++){
           for (int j = 0; j < col; j++){
               
            // leitura vertical
            if (i < row-3){
               if (matrix[i, j] == 'X')
                        if (matrix[i+1, j] == 'M')
                            if (matrix[i+2, j] == 'A')
                                if (matrix[i+3, j] == 'S')
                                    totalMatchs++;
                    if (matrix[i, j] == 'S')
                        if (matrix[i+1, j] == 'A')
                            if (matrix[i+2, j] == 'M')
                                if (matrix[i+3, j] == 'X')
                                    totalMatchs++;
            }

                if (j < col-3){
                    // // leitura diagonal-frente
                    if (i < row-3){
                        if (matrix[i, j] == 'X')
                            if (matrix[i+1, j+1] == 'M')
                                if (matrix[i+2, j+2] == 'A')
                                    if (matrix[i+3, j+3] == 'S')
                                        totalMatchs++;

                        if (matrix[i, j] == 'S')
                            if (matrix[i+1, j+1] == 'A')
                                if (matrix[i+2, j+2] == 'M')
                                    if (matrix[i+3, j+3] == 'X')
                                        totalMatchs++;
                    }

                }

                if (j > strLen-2){
                    if (i < row-3) {
                        if (matrix[i, j] == 'X')
                            if (matrix[i+1, j-1] == 'M')
                                if (matrix[i+2, j-2] == 'A')
                                    if (matrix[i+3, j-3] == 'S')
                                        totalMatchs++;

                        if (matrix[i, j] == 'S')
                            if (matrix[i+1, j-1] == 'A')
                                if (matrix[i+2, j-2] == 'M')
                                    if (matrix[i+3, j-3] == 'X')
                                        totalMatchs++;
                    }
                }
               
              
           }
        }

        Console.WriteLine(totalMatchs);
    }
}