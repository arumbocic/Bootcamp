using System.Collections.Generic;
using TractorShop.Model;
using TractorShop.Repository;
using TractorShop.Service.Common;
using System.Threading.Tasks;
using TractorShop.Repository.Common;
using TractorShop.Model.Common;
using TractorModel.Common;

namespace TractorShop.Service
{
    public class TractorModelService : ITractorModelService
    {
        private readonly ITractorModelRepository TractorModelRepository;
        public TractorModelService(ITractorModelRepository tractorModelRepository)
        {
            TractorModelRepository = tractorModelRepository;
        }
        public async Task<List<ITractorModelEntity>> GetAllAsync(ISorting sorting, IPaging paging, IFilterTractorModel filtering)
        {
            List<ITractorModelEntity> tractorModels = await TractorModelRepository.GetAllAsync(sorting, paging, filtering);
            return tractorModels;
        }

        public async Task<ITractorModelEntity> GetByIdAsync(int Id)
        {
            ITractorModelEntity tractorModelEntity = await TractorModelRepository.GetByIdAsync(Id);
            return tractorModelEntity;
        }

        public async Task PostAsync(ITractorModelEntity postModel)
        {
            await TractorModelRepository.PostAsync(postModel);
        }

        public async Task UpdateByIdAsync(int Id, ITractorModelEntity updateModel)
        {
            await TractorModelRepository.UpdateByIdAsync(Id, updateModel);
        }

        public async Task DeleteByIdAsync(int Id)
        {
            await TractorModelRepository.DeleteByIdAsync(Id);
        }
    }
}
