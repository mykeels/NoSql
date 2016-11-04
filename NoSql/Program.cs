using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using Extensions.Models;
using MongoDB.Extensions;

namespace NoSql
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string connectionString = Site.AppSettings("MongoDBUri");
            MongoClient _client = new MongoClient(connectionString);

            IMongoCollection<Soccer.Player> players = Soccer.Player.GetPlayers(_client);
            players.DeleteMany(FilterDefinition<Soccer.Player>.Empty);

            for (int i = 1; i <= 20; i++)
            {
                Soccer.Player newPlayer = Soccer.Player.Create();
                players.InsertOne(newPlayer);
                Console.WriteLine(newPlayer.Id.ToString() + "\t" + newPlayer.Name);
            }

            Console.WriteLine(players.Find(FilterDefinition<Soccer.Player>.Empty).ToList().ToJson());
            Console.Read();
        }
    }
}
