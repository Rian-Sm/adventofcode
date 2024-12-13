namespace AOC_Data.Tests;

public class LaunchSettingsFixture { 
    public LaunchSettingsFixture() { 
        using (var file = File.OpenText("Properties/launchSettings.json")) 
        { 
            var reader = new JsonTextReader(file); 
            var jObject = JObject.Load(reader);
            var variables = jObject["profiles"]["local"]["environmentVariables"];
            foreach (var variable in variables.Children<JProperty>())
            { 
                // Console.WriteLine(variable.Value);
                Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString()); 
            } 
        }
    }
}

[CollectionDefinition("LaunchSettings collection")] 
public class LaunchSettingsCollection : ICollectionFixture<LaunchSettingsFixture> { 
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the 
    // ICollectionFixture<> interfaces.
}

[Collection("LaunchSettings collection")]
public class AOCAccessDataTest
{
    [Fact]
    public async void TestErrorOnGetData()
    {
        // Arrange
        Environment.SetEnvironmentVariable("URL", "https://adventofcode.com/2024/day/1/input");
        Environment.SetEnvironmentVariable("COOKIE", "https://adventofcode.com/2024/day/1/input");
        string messageErro = "BadRequest";
        
        // Act 
        string[] result =  await AOCAccessData.GetData();

        // Assert
        Assert.Equal(messageErro, result[0]);
    }

    [Fact]
    public async void TestGetData()
    {
        // Arrange
        string path = $"{System.IO.Directory.GetCurrentDirectory()}/StaticFiles/mapTest.txt";
        string textComparation = "OK";
        
        // Act 
        string[] result = await AOCAccessData.GetData();

        // Assert
        Assert.Equal(textComparation, result[0]);
    }
}