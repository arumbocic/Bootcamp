using System.Collections.Generic;
using TractorShop.Model;
using TractorShop.Repository;
using TractorShop.Service.Common;
using System.Threading.Tasks;

namespace TractorShop.Service
{
    public class TractorModelService : ITractorModelService
    {
        public async Task<List<TractorModelEntity>> GetAllAsync()
        {
            TractorModelRepository tractorModelRepository = new TractorModelRepository();
            List<TractorModelEntity> tractorModels = await tractorModelRepository.GetAllAsync();
            return tractorModels;
        }

        public async Task<TractorModelEntity> GetByIdAsync(int Id)
        {
            TractorModelRepository tractorModelRepository = new TractorModelRepository();
            TractorModelEntity tractorModelEntity = await tractorModelRepository.GetByIdAsync(Id);
            return tractorModelEntity;
        }

        public async Task PostAsync(TractorModelEntity postModel)
        {
            TractorModelRepository tractorModelRepository = new TractorModelRepository();
            await tractorModelRepository.PostAsync(postModel);
        }

        public async Task UpdateByIdAsync(int Id, TractorModelEntity updateModel)
        {
            TractorModelRepository tractorModelRepository = new TractorModelRepository();
            await tractorModelRepository.UpdateByIdAsync(Id, updateModel);
        }

        public async Task DeleteByIdAsync(int Id)
        {
            TractorModelRepository tractorModelRepository = new TractorModelRepository();
            await tractorModelRepository.DeleteByIdAsync(Id);
        }
    }
}
