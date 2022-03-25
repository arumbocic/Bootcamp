using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
