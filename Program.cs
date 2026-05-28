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

        User newUser = new User
        {
            Name = "Emma Wilson",
            Age = 28,
            City = "Berlin"
        };

        users.Add(newUser);

        string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);

        File.WriteAllText(filePath, updatedJson);

        Console.WriteLine("Updated User List:\n");

        foreach (User user in users)
        {
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"City: {user.City}");
            Console.WriteLine();
        }
    }
}