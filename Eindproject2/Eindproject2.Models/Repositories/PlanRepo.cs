using Eindproject2.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject2.Models.Repositories
{
    public class PlanRepo : GenericRepo<Plans>, IPlanRepo
    {
        private Eindproject2APIContext context;

        public PlanRepo(Eindproject2APIContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Plans>> GetAllPlans()
        {
            var plans = await context.Plans
                .Include(up => up.Userplans)
                .AsNoTracking()
                .ToListAsync();

            return plans;
        }
    }
}
