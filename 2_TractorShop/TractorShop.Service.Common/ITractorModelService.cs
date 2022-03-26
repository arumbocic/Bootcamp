using System.Collections.Generic;
using TractorShop.Model;

namespace TractorShop.Service.Common
{
    public interface ITractorModelService
    {
        List<TractorModelEntity> GetAll();
        TractorModelEntity GetById(int Id);
        void Post(TractorModelEntity postModel);
        void UpdateById(int Id, TractorModelEntity updateModel);
        void DeleteById(int Id);
    }
}
