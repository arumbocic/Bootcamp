using System.Collections.Generic;
using TractorShop.Model;
using TractorShop.Repository;
using TractorShop.Service.Common;
using System.Threading.Tasks;
using TractorShop.Repository.Common;

namespace TractorShop.Service
{
    public class TractorModelService : ITractorModelService
    {
        private readonly ITractorModelRepository TractorModelRepository;
        public TractorModelService(ITractorModelRepository tractorModelRepository)
        {
            TractorModelRepository = tractorModelRepository;
        }
        public async Task<List<TractorModelEntity>> GetAllAsync()
        {
            List<TractorModelEntity> tractorModels = await TractorModelRepository.GetAllAsync();
            return tractorModels;
        }

        public async Task<TractorModelEntity> GetByIdAsync(int Id)
        {
            TractorModelEntity tractorModelEntity = await TractorModelRepository.GetByIdAsync(Id);
            return tractorModelEntity;
        }

        public async Task PostAsync(TractorModelEntity postModel)
        {
            await TractorModelRepository.PostAsync(postModel);
        }

        public async Task UpdateByIdAsync(int Id, TractorModelEntity updateModel)
        {
            await TractorModelRepository.UpdateByIdAsync(Id, updateModel);
        }

        public async Task DeleteByIdAsync(int Id)
        {
            await TractorModelRepository.DeleteByIdAsync(Id);
        }
    }
}
