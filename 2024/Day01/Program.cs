// See https://aka.ms/new-console-template for more information

var environment = Environment.GetEnvironmentVariables();

string url = environment["URL"].ToString();
string cookie = environment["COOKIE"].ToString();

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Add("cookie", cookie);
var response = await client.GetAsync(url);

var responseString = await response.Content.ReadAsStringAsync();

responseString = responseString.Replace("\n", " ");

List<int> left = new List<int>();
List<int> right = new List<int>();

int index = 1;
foreach (string str in responseString.Split(" ").ToList()){
    if (str == "")
        continue;

    if (index % 2 ==  0)
        right.Add(int.Parse(str));
    else
        left.Add(int.Parse(str));
    index++;
}

right.Sort();
left.Sort(); 

int diferenceTotal = 0;

for (int i = 0; i < right.Count; i++){
    int diference = right[i] - left[i];

    if (diference == 0)
        continue;

    if (diference < 0)
        diference = diference * -1;

    diferenceTotal = diferenceTotal+diference;
}


Console.WriteLine(diferenceTotal);
