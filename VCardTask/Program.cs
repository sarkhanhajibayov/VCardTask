using Newtonsoft.Json;
using System.Net;
using VCardTask.Helpers;
using VCardTask.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("How many VCard do you want to generate?");
        string answer = Console.ReadLine();
        var awaiter = GetAsync("https://randomuser.me/api/?results=" + answer);

        if(awaiter.Result != "")
        {
            Result results = JsonConvert.DeserializeObject<Result>(awaiter.Result);

            if(results != null) {

                List<User> users = new List<User>();
                foreach(var userData in results.Results) {
                    User newUser = new User
                    {
                        Name = userData.Name,
                        Email = userData.Email,
                        Phone = userData.Phone,
                        Location = userData.Location,
                    };
                    users.Add(newUser);
                }
                foreach(var user in users)
                {
                    string vcardcontents = FileHelper.CreateVCard(user);
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string folderName = "VCardsFolder"; 
                    string folderPath = System.IO.Path.Combine(desktopPath, folderName);

                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }

                    string SavePath = System.IO.Path.Combine(folderPath, $"{user.Name.First}.vcf");
                    System.IO.File.WriteAllText(SavePath, vcardcontents);
                    Console.WriteLine("File saved at " + SavePath.Trim());
                }
            }
        }
    }
    public static async Task<string> GetAsync(string url)
    {
        HttpClient client = new HttpClient();
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        client.DefaultRequestHeaders.Accept.Clear();
        var response = client.GetStringAsync(url);
        return await response;
    }
}
