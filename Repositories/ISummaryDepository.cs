﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace ThreeApi.Repositories
{
    public interface ISummaryDepository
    {
        Task<CompanySummary> GetCompanySummary();
    }
}
