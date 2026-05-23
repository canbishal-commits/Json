using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "users.json";

        string jsonData = File.ReadAllText(filePath);

        List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonData);

        Console.WriteLine("Users List:\n");

        foreach (User user in users)
        {
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"City: {user.City}");
            Console.WriteLine();
        }
    }
}