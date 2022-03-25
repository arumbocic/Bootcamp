using System.Collections.Generic;
using TractorShop.Model;
using TractorShop.Repository;
using TractorShop.Service.Common;

namespace TractorShop.Service
{
    public class TractorModelService : ITractorModelService
    {
        public List<TractorModelEntity> GetAll()
        {
            TractorModelRepository tractorModelRepository = new TractorModelRepository();
            List<TractorModelEntity> tractorModels = tractorModelRepository.GetAll();
            return tractorModels;
        }

        public TractorModelEntity GetById(int Id)
        {
            TractorModelRepository tractorModelRepository = new TractorModelRepository();
            TractorModelEntity tractorModelEntity = tractorModelRepository.GetById(Id);
            return tractorModelEntity;
        }

        public void Post(TractorModelEntity postModel)
        {
            TractorModelRepository tractorModelRepository = new TractorModelRepository();
            tractorModelRepository.Post(postModel);
        }

        public void UpdateById(int Id, TractorModelEntity updateModel)
        {
            TractorModelRepository tractorModelRepository = new TractorModelRepository();
            tractorModelRepository.UpdateById(Id, updateModel);
        }

        public void DeleteById(int Id)
        {
            TractorModelRepository tractorModelRepository = new TractorModelRepository();
            tractorModelRepository.DeleteById(Id);
        }
    }
}
