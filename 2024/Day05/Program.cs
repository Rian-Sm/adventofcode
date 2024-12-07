using System;
using System.Collections.Generic;
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

// STRING DE TESTE
//         string responseString  = @"47|53
// 97|13
// 97|61
// 97|47
// 75|29
// 61|13
// 75|53
// 29|13
// 97|29
// 53|29
// 61|53
// 97|53
// 61|29
// 47|13
// 75|47
// 97|75
// 47|61
// 75|61
// 47|29
// 75|13
// 53|13

// 75,47,61,53,29
// 97,61,53,29,13
// 75,29,13
// 75,97,47,61,53
// 61,13,29
// 97,13,75,29,47";

    int countMid = 0;

    string[] responseList = responseString.Split("\n\n");
    List<string> pageRules = responseList[0].Split("\n",StringSplitOptions.RemoveEmptyEntries).ToList();
    List<string> PageUpdates = responseList[1].Split("\n",StringSplitOptions.RemoveEmptyEntries).ToList();

    pageRules.Sort();

        foreach (string PageUpdate in PageUpdates){
            string[]  ArrayItems =  PageUpdate.Split(",",StringSplitOptions.RemoveEmptyEntries);
            bool safe = true;

            for (int i = 0; i < ArrayItems.Length; i++){
                if (!safe)
                    break;

                for (int j = i+1; j < ArrayItems.Length; j++){
                    int ruleIndex = pageRules.BinarySearch($"{ArrayItems[i]}|{ArrayItems[j]}");
                    
                    if (ruleIndex<0){
                        safe = false;
                        break;
                    }
                } 
            }

            if (safe){
                countMid += int.Parse(ArrayItems[ArrayItems.Length/2]);
            }
        }
            Console.WriteLine(countMid);

    }
}