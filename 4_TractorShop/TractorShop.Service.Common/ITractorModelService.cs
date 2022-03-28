using System.Collections.Generic;
using TractorShop.Model;
using System.Threading.Tasks;

namespace TractorShop.Service.Common
{
    public interface ITractorModelService
    {
        Task<List<TractorModelEntity>> GetAllAsync();
        Task<TractorModelEntity> GetByIdAsync(int Id);
        Task PostAsync(TractorModelEntity postModel);
        Task UpdateByIdAsync(int Id, TractorModelEntity updateModel);
        Task DeleteByIdAsync(int Id);
    }
}
