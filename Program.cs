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

public class Admin : User
{
    public string AdminLevel { get; set; }
}

public class RegularUser : User
{
    public string MembershipType { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<User> users = new List<User>();

        Admin admin = new Admin
        {
            Name = "Michael",
            Age = 35,
            City = "Chicago",
            AdminLevel = "Super Admin"
        };

        RegularUser regularUser = new RegularUser
        {
            Name = "Sarah",
            Age = 22,
            City = "Toronto",
            MembershipType = "Gold"
        };

        users.Add(admin);
        users.Add(regularUser);

        string jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);

        File.WriteAllText("user_types.json", jsonData);

        string readJson = File.ReadAllText("user_types.json");

        List<User> deserializedUsers = JsonConvert.DeserializeObject<List<User>>(readJson);

        Console.WriteLine("Deserialized Users:\n");

        foreach (User user in deserializedUsers)
        {
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"City: {user.City}");
            Console.WriteLine();
        }
    }
}