using System.Collections.Generic;
using System.Threading.Tasks;
using VisiitorSecurityManagement.Entities;

namespace VisiitorSecurityManagement.Interface
{
    public interface IManagerService
    {
        Task<ManagerEntity> AddManager(ManagerEntity manager);
        Task<ManagerEntity> GetManagerById(string id);
        Task<IEnumerable<ManagerEntity>> GetAllManagers();
        Task<ManagerEntity> UpdateManager(ManagerEntity manager);
        Task DeleteManager(string id);
    }
}
