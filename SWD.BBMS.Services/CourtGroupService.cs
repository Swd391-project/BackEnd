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
    public class CourtGroupService : ICourtGroupService
    {
        private readonly ICourtGroupRepository courtGroupRepository;

        private readonly IWeekdayActivityRepository weekdayActivityRepository;

        private readonly ICompanyRepository companyRepository;

        private readonly IMapper mapper;

        public CourtGroupService(ICourtGroupRepository courtGroupRepository, IMapper mapper, IWeekdayActivityRepository weekdayActivityRepository, ICompanyRepository companyRepository)
        {
            this.courtGroupRepository = courtGroupRepository;
            this.mapper = mapper;
            this.weekdayActivityRepository = weekdayActivityRepository;
            this.companyRepository = companyRepository;
        }

        public async Task<CourtGroupModel> GetCourtGroupById(int id)
        {
            try
            {
                var courtGroup = await courtGroupRepository.GetCourtGroupById(id);
                var courtGroupModel = mapper.Map<CourtGroupModel>(courtGroup);   
                return courtGroupModel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PagedList<CourtGroupModel>> GetCourtGroups(int pageNumber, int pageSize)
        {
            var courtGroups = await courtGroupRepository.GetCourtGroups(pageNumber, pageSize);
            var courtGroupModels = mapper.Map<PagedList<CourtGroupModel>>(courtGroups);
            return new PagedList<CourtGroupModel>(courtGroupModels, courtGroups.TotalCount, courtGroups.CurrentPage, courtGroups.PageSize);
        }

        public async Task<bool> SaveCourtGroup(CourtGroupModel courtGroupModel)
        {
            var result = false;
            try
            {
                var courtGroup = mapper.Map<CourtGroup>(courtGroupModel);
                var weekdayActivities = await weekdayActivityRepository.GetWeekdayActivities();
                courtGroup.CourtGroupActivities = new List<CourtGroupActivity>();
                foreach (var weekdayActivity in weekdayActivities)
                {
                    var courtGroupActivity = new CourtGroupActivity
                    {
                        CourtGroup = courtGroup, WeekdayActivityId = weekdayActivity.Id, ActivityStatus = ActivityStatus.Open
                    };
                    courtGroup.CourtGroupActivities.Add(courtGroupActivity);
                }
                var companies = await companyRepository.GetCompanies();
                courtGroup.CompanyId = companies.First().Id;
                result = await courtGroupRepository.SaveCourtGroup(courtGroup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
