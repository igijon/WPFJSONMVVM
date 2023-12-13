using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Xml;
using WPFJSONMVVM.Models;

namespace WPFJSONMVVM.JSON
{
    public class UserDataComponent
    {
        public static string Path = "C:\\Users\\Alumno\\Documents\\WPF\\WPFJSONMVVM\\WPFMySQLMVVM\\Data\\users.json";
        public static ObservableCollection<User> readUsers()
        {
            string contenidoJson = File.ReadAllText(Path);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);
            return rootObject.Users;
        }


        public static void insertPeople(User p)
        {
            ObservableCollection<User> users = readUsers();
            users.Add(p);
            RootObject rootObject = new RootObject();
            rootObject.Users = users;
            string contenidoJson = JsonConvert.SerializeObject(rootObject, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Path, contenidoJson);
        }
       
        class RootObject
        {
            [JsonProperty("users")]
            public ObservableCollection<Models.User> Users { get; set; }
            
        }



       

        
    }
}
