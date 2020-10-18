using Basket.API.Data.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Data
{
    public class BasketContext: IBasketContext
    {
        private readonly ConnectionMultiplexer _redisConnectin;
        public IDatabase Redis { get; }
        public BasketContext(ConnectionMultiplexer redisConnectin)
        {
            _redisConnectin = redisConnectin;
            Redis = redisConnectin.GetDatabase();
        }
    }
}
