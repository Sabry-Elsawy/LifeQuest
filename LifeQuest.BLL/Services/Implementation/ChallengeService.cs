using LifeQuest.BLL.Models;
using LifeQuest.BLL.Services.Interfaces;
using LifeQuest.DAL.Models;
using LifeQuest.DAL.UOW.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeQuest.BLL.Services.Implementation
{
    public class ChallengeService : IChallengeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChallengeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateChallengeAsync(CreateChallengeDto dto)
        {
            var challenge = new Challenge
            {
                Title = dto.Title,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Points = dto.Points,
                CategoryId = dto.CategoryId == 0 ? 1 : dto.CategoryId, // Default to 1 for now
                IsPublic = dto.IsPublic,
                Difficulty = dto.Difficulty,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Duration = (dto.EndDate - dto.StartDate).Days
            };

            await _unitOfWork.Repository<Challenge>().AddAsync(challenge);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<ChallengeDto>> GetAllChallengesAsync()
        {
            var challenges = await _unitOfWork.Repository<Challenge>().GetAllAsync(new Challenge()); // The repository requires an entity but doesn't use it?

            return challenges.Select(c => new ChallengeDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Points = c.Points,
                Duration = c.Duration,
                IsPublic = c.IsPublic,
                Difficulty = c.Difficulty,
                CreatedAt = c.CreateAt
            }).ToList();
        }
    }
}
