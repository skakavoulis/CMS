using CMS.Services.Interfaces;
using CMS.Services.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Services.Clients
{
    class TestClientService : IClientService
    {
        private static readonly Client[] _clients;
        private static readonly Random _rand;
        private static readonly string[] _letters;
        private static readonly string[] _countries;
        private static readonly string[] _cities;

        static TestClientService()
        {
            _rand = new Random(Environment.TickCount);
            _letters = Enumerable.Repeat('A', 26)
                .Select((c, i) => ((char)(c + i)).ToString())
                .ToArray();
            _countries = new[] { "Greece", "Italy", "United Kingdom", "Germany", "Switzerland" };
            _cities = new[] { "Athens", "Kalamata", "Amsterdam", "London", "Buenos Aires", "Tokyo" };
            _clients = Enumerable.Repeat(0, 20)
                .Select(x => GetRandomClient())
                .ToArray();
        }

        public string AuthToken { get; set; }

        public Task<Client[]> GetClientsForBranch(string branchId)
        {
            return Task.Run(() =>
             {
                 Thread.Sleep(2000);
                 return _clients;
             });
        }

        public Task<Client> AddNewClient(Client newClient)
        {
            throw new NotImplementedException();
        }


        private static Client GetRandomClient()
        {
            return new Client
            {
                Type = GetClientType(),
                Address = GetRandomAddress(),
                Birthday = GetRandomBirthday(),
                ClientId = Guid.NewGuid(),
                ClientSince = GetRandomClientSince(),
                Lastname = RandomString(_rand.Next(5, 10)),
                Name = RandomString(_rand.Next(10, 20)),
                TACAccepted = RandomBoolean()
            };
        }

        private static DateTime GetRandomBirthday()
        {
            return DateTime.Now.AddDays(-1 * _rand.Next(1, 365) * _rand.Next(18, 50));
        }

        private static DateTime GetRandomClientSince()
        {
            return DateTime.Now.AddDays(-1 * _rand.Next(1, 365) * _rand.Next(1, 10));
        }

        private static bool RandomBoolean()
        {
            return _rand.Next(1, 100) < 50;
        }

        private static Address GetRandomAddress()
        {
            return new Address
            {
                Country = RandomCountry(),
                City = RandomCity(),
                PostCode = _rand.Next(10000, 99999).ToString(),
                StreeName = RandomString(10),
                StreetNumber = _rand.Next(1, 200)
            };
        }

        private static string RandomCity()
        {
            return _cities[_rand.Next(0, _cities.Length - 1)];
        }

        private static string RandomCountry()
        {
            return _countries[_rand.Next(0, _countries.Length - 1)];
        }

        private static string RandomString(int size)
        {
            var letters = Enumerable.Repeat("", size)
                .Select(x => _letters[_rand.Next(0, _letters.Length - 1)])
                .ToArray();
            return string.Join("", letters);
        }

        private static ClientTypeEnum GetClientType()
        {
            return RandomBoolean()
                ? ClientTypeEnum.Εταιρικός
                : ClientTypeEnum.Ιδιώτης;
        }
    }
}
