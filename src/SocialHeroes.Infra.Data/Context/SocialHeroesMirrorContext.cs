using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SocialHeroes.Domain.Core.Models;
using System;

namespace SocialHeroes.Infra.Data.Context
{
    public class SocialHeroesMirrorContext
    {
        private IConfiguration _configuration { get; set; }
        public  IMongoDatabase Db { get; set; }      

        public SocialHeroesMirrorContext()
        {
            MongoClient client = new MongoClient("mongodb://cristian:cri022010@ds034807.mlab.com:34807/blog");
            Db = client.GetDatabase("blog");         
        }

    }
}
