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

        private readonly IMapper mapper;

        public CourtService(ICourtRepository courtRepository, IMapper mapper)
        {
            this.courtRepository = courtRepository;
            this.mapper = mapper;
        }

        public async Task<PagedList<CourtModel>> GetCourts(int pageNumber, int pageSize)
        {
            var courts = new PagedList<Court>();
            courts = await courtRepository.GetCourts(pageNumber, pageSize);
            var courtModels = mapper.Map<PagedList<CourtModel>>(courts);
            
            return new PagedList<CourtModel>(courtModels, courts.TotalCount, courts.CurrentPage, courts.PageSize);
        }
    }
}
