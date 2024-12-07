
internal class Program
{
    private static async global::System.Threading.Tasks.Task Main(string[] args)
    {
        string path = $"{System.IO.Directory.GetCurrentDirectory()}/Assets/";
        string map = "map.txt";
        string mapFinish = "mapFinish.txt";

        string linearMap = "";
        
        string fullPath = path+map;

        var environment = Environment.GetEnvironmentVariables();

        string url = environment["URL"].ToString();
        string cookie = environment["COOKIE"].ToString();

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("cookie", cookie);
        var response = await client.GetAsync(url);
        string responseString = await response.Content.ReadAsStringAsync();


// string responseString = @"....#.....
// .........#
// ..........
// ..#.......
// .......#..
// ..........
// .#..^.....
// ........#.
// #.........
// ......#...";

        bool fileExits = File.Exists(fullPath);
        if (!fileExits)
           File.WriteAllText(fullPath, responseString);


        //==== lendo arquivo
        string[] lines = File.ReadAllLines(fullPath);
        string[] editableLines = new string[lines.Length];

        Array.Copy(lines, editableLines, lines.Length);

        int row  = lines.Length;
        int col = lines[0].Length;

        int[] position = { 0, 0 };

        
        for (int i = 0; i < row; i++){
            string line = lines[i];
            if (line.Contains("^")){
                position = new  int[2]{i,line.IndexOf("^")} ;
                break;
            }
        }    

        int direction = 0; // 0 -up 1-down 2-right 3-left
        int[] nextPostion = {0,0};
        
        while (true){
            // 0 -UP 1-RIGHT 2-DOWN 3-LEFT
            char[] wordArray = editableLines[position[0]].ToCharArray();
            wordArray[position[1]] = 'X';

            editableLines[position[0]] = new string(wordArray);

           if (position[0] == col-1 || position[1] == row-1 || position[0] == -1 || position[1] == -1)
            break;

            if (direction == 0)
            {
                nextPostion[0] = position[0]-1;
                nextPostion[1] = position[1];
            } 
            else  if (direction == 1)
            {
                nextPostion[0] = position[0];
                nextPostion[1] = position[1]+1;
            } 
            else  if (direction == 2)
            {
                nextPostion[0] = position[0]+1;
                nextPostion[1] = position[1];
            } 
            else  if (direction == 3)
            {
                nextPostion[0] = position[0];
                nextPostion[1] = position[1]-1;
            };
            if (
                lines[nextPostion[0]][nextPostion[1]] == '#'){
                direction++;
                if (direction == 4)
                    direction = 0;
                continue;
            }
        
            position[0] =  nextPostion[0];
            position[1] = nextPostion[1];
        }

        linearMap = string.Join("\n",editableLines);

        File.WriteAllText($"{path}{mapFinish}", linearMap);

        int stepsCount = linearMap.Count(value => value == 'X' );

        Console.Write($"\n\n{stepsCount}\n\n");
    }
}