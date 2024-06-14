using VisiitorSecurityManagement.DTO;

namespace VisiitorSecurityManagement.Interface
{
    public class ISecurityService
    {
        Task<SecurityDTO> AddSecurity(SecurityDTO securityDto);
        Task<SecurityDTO> GetSecurityById(string id);
        Task<IEnumerable<SecurityDTO>> GetAllSecurity();
        Task<SecurityDTO> UpdateSecurity(SecurityDTO securityDto);
        Task DeleteSecurity(string id);
    }
}
