using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eindproject2.Models.Repositories
{
    public interface IPlanRepo
    {
        Task<IEnumerable<Plans>> GetAllPlans();
    }
}