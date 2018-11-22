using CMS.Repositories.Interfaces;
using CMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    public class TestClientsRepository : IClientRepository
    {
        private static List<ClientRepo> _clients;
        private static readonly Random _rand;
        private static readonly string[] _letters;
        private static readonly string[] _countries;
        private static readonly string[] _cities;

        static TestClientsRepository()
        {
            _rand = new Random(Environment.TickCount);
            _letters = Enumerable.Repeat('A', 26)
                .Select((c, i) => ((char)(c + i)).ToString())
                .ToArray();
            _countries = new[] { "Greece", "Italy", "United Kingdom", "Germany", "Switzerland" };
            _cities = new[] { "Athens", "Kalamata", "Amsterdam", "London", "Buenos Aires", "Tokyo" };
            _clients = Enumerable.Repeat(0, 20)
                .Select(x => GetRandomClient())
                .ToList();
        }

        public Task<ClientRepo[]> GetClients(int limit)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                return _clients.Take(limit).ToArray();
            });
        }

        public Task<ClientRepo> AddClient(ClientRepo newClient)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                newClient.ClientId = Guid.NewGuid();
                _clients.Add(newClient);
                return newClient;
            });
        }

        public Task<bool> RemoveClient(Guid clientId)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);

                var existingClient = _clients.FirstOrDefault(x => x.ClientId == clientId);
                if (existingClient == null)
                    return false;
                var index = _clients
                    .IndexOf(existingClient);
                _clients.RemoveAt(index);
                return true;
            });
        }

        public Task<ClientRepo> UpdateClient(ClientRepo newClient)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);

                var existingClient = _clients.FirstOrDefault(x => x.ClientId == newClient.ClientId);
                if (existingClient == null)
                    return null;
                var index = _clients
                    .IndexOf(existingClient);
                _clients[index] = newClient;
                return newClient;
            });
        }


        private static ClientRepo GetRandomClient()
        {
            return new ClientRepo
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

        private static AddressRepo GetRandomAddress()
        {
            return new AddressRepo
            {
                Country = RandomCountry(),
                City = RandomCity(),
                PostCode = _rand.Next(10000, 99999).ToString(),
                StreetName = RandomString(10),
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

        private static ClientTypeRepoEnum GetClientType()
        {
            return RandomBoolean()
                ? ClientTypeRepoEnum.Εταιρικός
                : ClientTypeRepoEnum.Ιδιώτης;
        }
    }
}
