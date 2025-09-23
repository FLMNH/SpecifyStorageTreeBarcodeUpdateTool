using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecifyStorageTreeUpdateTool.Classes
{
    public class UserProperty
    {
        public string username {  get; set; }
        public string key { get; set; }
        public string dbServerAddress { get; set; }
        public string dbName { get; set; }
        public string collectionName { get; set; }
        
        public UserProperty() { }

        public UserProperty(string username, string key, string dbServerAddress, string dbName, string collectionName)
        {
            this.username = username;
            this.key = key;
            this.dbServerAddress = dbServerAddress;
            this.collectionName = collectionName;
            this.dbName = dbName;
        }

    }
}
