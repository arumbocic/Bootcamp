using System.Collections.Generic;
using TractorShop.Model;
using System.Threading.Tasks;
using TractorShop.Model.Common;
using TractorModel.Common;

namespace TractorShop.Service.Common
{
    public interface ITractorModelService
    {
        Task<List<ITractorModelEntity>> GetAllAsync(ISorting sorting, IPaging paging, IFilterTractorModel filtering);
        Task<ITractorModelEntity> GetByIdAsync(int Id);
        Task PostAsync(ITractorModelEntity postModel);
        Task UpdateByIdAsync(int Id, ITractorModelEntity updateModel);
        Task DeleteByIdAsync(int Id);
    }
}
