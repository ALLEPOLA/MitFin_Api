using MitFin_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MitFin_Api.Inventory
{
    public interface CommittedMaterialInterface
    {
        // Method to get all committed materials
        Task<IEnumerable<CommittedMaterial>> GetAllAsync();
    }
}
