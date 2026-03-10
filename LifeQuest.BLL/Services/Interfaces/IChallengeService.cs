using LifeQuest.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifeQuest.BLL.Services.Interfaces
{
    public interface IChallengeService
    {
        Task CreateChallengeAsync(CreateChallengeDto dto);
        Task<List<ChallengeDto>> GetAllChallengesAsync();
    }
}
