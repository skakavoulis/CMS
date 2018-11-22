using CMS.Models;
using CMS.Repositories.Models;
using System;

namespace CMS.WCF.Services.Extentions
{
    public static class Mappers
    {
        public static Client ToModel(this ClientRepo repoModel)
        {
            return new Client
            {
                ClientId = repoModel.ClientId,
                Address = new Address
                {
                    City = repoModel.Address.City,
                    Country = repoModel.Address.Country,
                    PostCode = repoModel.Address.PostCode,
                    StreetName = repoModel.Address.StreetName,
                    StreetNumber = repoModel.Address.StreetNumber
                },
                Name = repoModel.Name,
                Birthday = repoModel.Birthday,
                ClientSince = repoModel.ClientSince,
                Lastname = repoModel.Lastname,
                TACAccepted = repoModel.TACAccepted,
                Type = (ClientTypeEnum)Enum.Parse(typeof(ClientTypeEnum), repoModel.Type.ToString())

            };
        }

        public static ClientRepo ToRepoModel(this Client model)
        {
            return new ClientRepo
            {
                ClientId = model.ClientId,
                Address = new AddressRepo
                {
                    City = model.Address.City,
                    Country = model.Address.Country,
                    PostCode = model.Address.PostCode,
                    StreetName = model.Address.StreetName,
                    StreetNumber = model.Address.StreetNumber
                },
                Name = model.Name,
                Birthday = model.Birthday,
                ClientSince = model.ClientSince,
                Lastname = model.Lastname,
                TACAccepted = model.TACAccepted,
                Type = (ClientTypeRepoEnum)Enum.Parse(typeof(ClientTypeRepoEnum), model.Type.ToString())

            };
        }
    }
}