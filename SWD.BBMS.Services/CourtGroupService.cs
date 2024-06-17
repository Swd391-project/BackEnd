using AutoMapper;
using SWD.BBMS.Repositories;
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
    public class CourtGroupService : ICourtGroupService
    {
        private readonly ICourtGroupRepository courtGroupRepository;

        private readonly IMapper mapper;

        public CourtGroupService(ICourtGroupRepository courtGroupRepository, IMapper mapper)
        {
            this.courtGroupRepository = courtGroupRepository;
            this.mapper = mapper;
        }

        public async Task<PagedList<CourtGroupModel>> GetCourtGroups(int pageNumber, int pageSize)
        {
            var courtGroups = await courtGroupRepository.GetCourtGroups(pageNumber, pageSize);
            var courtGroupModels = mapper.Map<PagedList<CourtGroupModel>>(courtGroups);
            return new PagedList<CourtGroupModel>(courtGroupModels, courtGroups.TotalCount, courtGroups.CurrentPage, courtGroups.PageSize);
        }
    }
}
