using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services
{
    public class CourtService : ICourtService
    {
        private readonly ICourtRepository courtRepository;

        private readonly ICourtGroupRepository courtGroupRepository;

        private readonly IJwtService jwtService;

        private readonly IMapper mapper;

        public CourtService(ICourtRepository courtRepository, IMapper mapper, ICourtGroupRepository courtGroupRepository, IJwtService jwtService)
        {
            this.courtRepository = courtRepository;
            this.mapper = mapper;
            this.courtGroupRepository = courtGroupRepository;
            this.jwtService = jwtService;
        }

        public async Task<bool> DeleteCourt(int id)
        {
            var result = false;
            try
            {
                var court = await courtRepository.FindCourt(id);
                if (court == null)
                {
                    throw new Exception($"Court with id {id} not found in delete court.");
                }
                var courtModel = mapper.Map<CourtModel>(court);
                courtModel.Status = CourtModelStatus.Closed;
                var userId = await jwtService.GetUserId();
                courtModel.ModifiedBy = userId;
                courtModel.ModifiedDate = DateTime.UtcNow;
                court = mapper.Map<Court>(courtModel);
                result = await courtRepository.UpdateCourt(court);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<CourtModel> GetCourtById(int id)
        {
            try
            {
                var court = await courtRepository.GetCourtById(id);
                var courtModel = mapper.Map<CourtModel>(court);
                return courtModel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PagedList<CourtModel>> GetCourts(int pageNumber, int pageSize)
        {
            var courts = new PagedList<Court>();
            courts = await courtRepository.GetCourts(pageNumber, pageSize);
            var courtModels = mapper.Map<PagedList<CourtModel>>(courts);
            
            return new PagedList<CourtModel>(courtModels, courts.TotalCount, courts.CurrentPage, courts.PageSize);
        }

        public async Task<List<CourtModel>> GetCourtsByCourtGroupId(int courtGroupId)
        {
            try
            {
                var courts = await courtRepository.GetCourtsByCourtGroupId(courtGroupId);
                var courtModels = mapper.Map<List<CourtModel>>(courts);
                return courtModels;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SaveCourt(CourtModel model)
        {
            var result = false;
            try
            {
                if(await courtGroupRepository.FindCourtGroup(model.CourtGroupId) == null)
                {
                    throw new Exception("Court group with id " + model.CourtGroupId + " is not existed.");
                }
                model.Name = await GetCourtNameForNewCourt(model.CourtGroupId);
                var court = mapper.Map<Court>(model);
                result = await courtRepository.SaveCourt(court);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<bool> UpdateCourtStatus(int id, CourtModelStatus status)
        {
            var result = false;
            try
            {
                var court = await courtRepository.FindCourt(id);
                if( court == null )
                {
                    throw new Exception($"Court with id {id} not found in update court.");
                }
                var courtModel = mapper.Map<CourtModel>(court);
                courtModel.Status = status;
                var userId = await jwtService.GetUserId();
                courtModel.ModifiedBy = userId;
                courtModel.ModifiedDate = DateTime.UtcNow;
                court = mapper.Map<Court>(courtModel);
                result = await courtRepository.UpdateCourt(court);
            }
            catch
            {
                throw;
            }
            return result;
        }

        private async Task<string> GetCourtNameForNewCourt(int courtGroupId)
        {
            var courtNames = await courtRepository.GetAvailableCourtNamesByCourtGroupId(courtGroupId);
            if (courtNames.IsNullOrEmpty())
                return "1";
            var courtNameInts = courtNames.Select(x => Int32.Parse(x)).Order().ToList();
            for(int i = 1; i <= courtNameInts.Count(); i++)
            {
                if ( i != courtNameInts[i - 1])
                {
                    return i.ToString();
                }
            }
            return (courtNameInts.Count() + 1).ToString();
        }
    }
}
