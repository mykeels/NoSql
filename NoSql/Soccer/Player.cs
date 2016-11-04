using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;
using Extensions.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Extensions;

namespace NoSql.Soccer
{
    public class Player
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int ShirtNumber { get; set; }

        public static Player Create()
        {
            Player ret = new Player();
            ret.Age = Convert.ToInt32(Number.Rnd() * 30);
            ret.Name = StringX.RandomLetters(7).ToSentenceCase() + " " + StringX.RandomLetters(5).ToSentenceCase();
            ret.ShirtNumber = Convert.ToInt32(Number.Rnd() * 100);
            return ret;
        }

        public static IMongoCollection<Player> GetPlayers(MongoClient _client, MongoCollectionSettings _settings = null)
        {
            var _db = _client.GetDatabase(Site.AppSettings("MongoDBName"));
            return _db.GetCollection<Player>("Players", _settings);
        }
    }
}
