﻿using VisiitorSecurityManagement.CosmosDB;
using VisiitorSecurityManagement.DTO;
using VisiitorSecurityManagement.Entities;

namespace VisiitorSecurityManagement.Services
{
    public class SecurityService
    {
        private readonly ICosmosDBService cosmosDBService;

        public SecurityService(ICosmosDBService cosmosDBService)
        {
            cosmosDBService = cosmosDBService ?? throw new ArgumentNullException(nameof(cosmosDBService));
        }

        public async Task<SecurityDTO> AddSecurity(SecurityDTO securityDto)
        {
            if (securityDto == null)
            {
                throw new ArgumentNullException(nameof(securityDto), "Security DTO cannot be null.");
            }

            var securityEntity = new SecurityEntity
            {
                Id = securityDto.Id,
                Name = securityDto.Name,
                Email = securityDto.Email,
                Phone = securityDto.PhoneNumber,
                Shift = "Default Shift",
                AssignedLocation = "Default Location"
            };

            var response = await cosmosDBService.AddSecurity(securityEntity);

            var responseModel = new SecurityDTO
            {
                Id = response.Id,
                Name = response.Name,
                Email = response.Email,
                PhoneNumber = response.Phone
            };

            return responseModel;
        }

        public async Task<SecurityDTO> GetSecurityById(string id)
        {
            var security = await cosmosDBService.GetSecurityById(id);

            if (security == null)
            {
                return null;
            }

            var securityDto = new SecurityDTO
            {
                Id = security.Id,
                Name = security.Name,
                Email = security.Email,
                PhoneNumber = security.Phone
            };

            return securityDto;
        }

        public async Task<IEnumerable<SecurityDTO>> GetAllSecurity()
        {
            var securities = await cosmosDBService.GetAllSecurities();

            var securityDtos = new List<SecurityDTO>();
            foreach (var security in securities)
            {
                var securityDto = new SecurityDTO
                {
                    Id = security.Id,
                    Name = security.Name,
                    Email = security.Email,
                    PhoneNumber = security.Phone
                };
                securityDtos.Add(securityDto);
            }

            return securityDtos;
        }

        public async Task<SecurityDTO> UpdateSecurity(SecurityDTO securityDto)
        {
            if (securityDto == null)
            {
                throw new ArgumentNullException(nameof(securityDto), "Security DTO cannot be null.");
            }

            var securityEntity = new SecurityEntity
            {
                Id = securityDto.Id,
                Name = securityDto.Name,
                Email = securityDto.Email,
                Phone = securityDto.PhoneNumber,
                Shift = "Updated Shift",
                AssignedLocation = "Updated Location"
            };

            var response = await cosmosDBService.UpdateSecurity(securityEntity);

            var responseModel = new SecurityDTO
            {
                Id = response.Id,
                Name = response.Name,
                Email = response.Email,
                PhoneNumber = response.Phone
            };

            return responseModel;
        }

        public async Task DeleteSecurity(string id)
        {
            await cosmosDBService.DeleteSecurity(id);
        }
    }
}
