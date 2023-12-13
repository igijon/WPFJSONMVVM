using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using WPFJSONMVVM.Models;

namespace WPFJSONMVVM.JSON
{
    public class UserDataComponent
    {
        public static string Path = "C:\\Users\\Alumno\\Documents\\WPF\\WPFJSONMVVM\\WPFMySQLMVVM\\Data\\users.json";
        public static List<User> readUsers()
        {
            string contenidoJson = File.ReadAllText(Path);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);
            return rootObject.Users;
        }


        public static void insertPeople(User p)
        {
            List<User> users = readUsers();
            users.Add(p);
            RootObject rootObject = new RootObject();
            rootObject.Users = users;
            string contenidoJson = JsonConvert.SerializeObject(rootObject, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Path, contenidoJson);
        }
       
        class RootObject
        {
            [JsonProperty("users")]
            public List<Models.User> Users { get; set; }
        }



       

        
    }
}
