﻿using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface ICourtGroupRepository
    {
        Task<PagedList<CourtGroup>> GetCourtGroups(int pageNumber, int pageSize);
    }
}
