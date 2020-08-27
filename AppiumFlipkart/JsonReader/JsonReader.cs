//-----------------------------------------------------------------------
// <copyright file="JsonReader.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System.IO;

namespace AppiumFlipkart.Reader
{
    /// <summary>
    /// Json file reader
    /// </summary>
    public class JsonReader
    {
        public string email;
        public string password;
        public string flipkartPass;
        public string flipkartEmail;
        public string json;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReader"/> class
        /// </summary>
        public JsonReader()
        {
            using (StreamReader reader = new StreamReader("C:\\Users\\sidth\\Desktop\\DataDriven\\credentials.json"))
            {
                json = reader.ReadToEnd();
            }
            dynamic array = JsonConvert.DeserializeObject(json);
            email = array["email"];
            password = array["password"];
            flipkartEmail = array["flipkartEmail"];
            flipkartPass =  array["flipkartPass"];
        }
    }
}