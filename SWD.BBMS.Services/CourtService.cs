using AutoMapper;
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

        private readonly IMapper mapper;

        public CourtService(ICourtRepository courtRepository, IMapper mapper, ICourtGroupRepository courtGroupRepository)
        {
            this.courtRepository = courtRepository;
            this.mapper = mapper;
            this.courtGroupRepository = courtGroupRepository;
        }

        public async Task<PagedList<CourtModel>> GetCourts(int pageNumber, int pageSize)
        {
            var courts = new PagedList<Court>();
            courts = await courtRepository.GetCourts(pageNumber, pageSize);
            var courtModels = mapper.Map<PagedList<CourtModel>>(courts);
            
            return new PagedList<CourtModel>(courtModels, courts.TotalCount, courts.CurrentPage, courts.PageSize);
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
                var court = mapper.Map<Court>(model);
                result = await courtRepository.SaveCourt(court);
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
