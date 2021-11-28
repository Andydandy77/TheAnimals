using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    public class JsonFileUserService
    {
        // <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {

            WebHostEnvironment = webHostEnvironment;

        }

        // Provides information of a Web Hosting Environment
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Returns path to json file
        private string JsonFileName
        {

            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json"); }

        }

        //Exposes an enumerator, iterators over
        public IEnumerable<UserModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<UserModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {

                        PropertyNameCaseInsensitive = true

                    });
            }
        }

        /// <summary>
        /// Save all user data to storage
        /// </summary>
        private void SaveData(IEnumerable<UserModel> users)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<UserModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {

                        SkipValidation = true,
                        Indented = true

                    }),
                    users
                );
            }
        }


        /// <summary>
        /// Create a new user using default values
        /// </summary>
        /// <param name="newUsername">new Username</param>
        /// <param name="newPassword">new Password</param>
        /// <returns></returns>
        public UserModel CreateUser(string newUsername, string newPassword)
        {

            // Create new product
            var data = new UserModel()
            {

                Id = System.Guid.NewGuid().ToString(),
                Username = newUsername,
                Password = newPassword,

            };

            // Get data and append new data to it
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            // Save data
            SaveData(dataSet);

            return data;
        }
    }
}
