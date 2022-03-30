using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TractorShop.Model;
using TractorShop.Model.Common;
using TractorShop.Service;
using TractorShop.Service.Common;
using TractorShopWebApi.Models;

namespace TractorShopWebApi.Controllers
{
    public class TractorModelController : ApiController
    {
        private readonly ITractorModelService TractorModelService;
        public TractorModelController(ITractorModelService tractorModelService)
        {
            TractorModelService = tractorModelService;
        }

        #region GetAll 

        // GET api/values
        [HttpGet]
        [Route("tractormodel/getall")]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            List<ITractorModelEntity> tractorModels = await TractorModelService.GetAllAsync();
            List<ITractorModelRest> tractorModelsRest = new List<ITractorModelRest>();

            foreach (var model in tractorModels)
            {
                ITractorModelRest tractorModelRest = new TractorModelRest();

                tractorModelRest.Model = model.Model;
                tractorModelRest.CatalogueCode = model.CatalogueCode;
                tractorModelRest.BrandId = model.BrandId;

                tractorModelsRest.Add(tractorModelRest);
            }

            if (tractorModelsRest.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, tractorModelsRest);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The list is empty!");
            }
        }
        #endregion

        #region GetById
        // GET api/values/5
        //TODO: Postavi stupac Model na Unique values

        [HttpGet]
        [Route("tractormodel/get/{id}")]
        public async Task<HttpResponseMessage> GetByIdAsync(int Id)
        {
            if (Id > 0)
            {
                ITractorModelEntity tractorModelEntity = await TractorModelService.GetByIdAsync(Id);                

                if (tractorModelEntity != null)
                {
                    ITractorModelRest tractorModelRest = new TractorModelRest();

                    tractorModelRest.Model = tractorModelEntity.Model;
                    tractorModelRest.CatalogueCode = tractorModelEntity.CatalogueCode;
                    tractorModelRest.BrandId = tractorModelEntity.BrandId;

                    return Request.CreateResponse(HttpStatusCode.OK, tractorModelRest);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no Tractor Model with id: {Id}");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Id is not valid.");
            }
        }
        #endregion

        #region Create
        // POST api/values
        [HttpPost]
        [Route("tractormodel/set")]
        public async Task<HttpResponseMessage> PostAsync(ITractorModelRest postModel)
        {
            if (postModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an empty object!");
            }
            else
            {
                //TODO: Dodati provjeru postoji li BrandId u tablici s brandovima.
                //Ovo je vjerojatno rješivo koristeći dropdown meni na frontendu, ali bilo bi kul pronaći način za provjeru ovoga.
                //Caka je u tom što je taj podatak u drugoj tablici.

                if (string.IsNullOrEmpty(postModel.Model) || postModel.BrandId == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Check if you provided all required properties for an object.");
                }
                else
                {
                    ITractorModelEntity tractorModelEntity = new TractorModelEntity();

                    tractorModelEntity.Model = postModel.Model;
                    tractorModelEntity.BrandId = postModel.BrandId;

                    await TractorModelService.PostAsync(tractorModelEntity);
                    return Request.CreateResponse(HttpStatusCode.OK, "Tractor model is created.");

                    //TODO: provjeriti kako dohvatiti ubačeni podatak iz baze.
                    //U slučaju kada samo "tractorModelEntity ubacim kao parametar za vraćanje,
                    //vrati mi objekt s neispravnim Id i Catalogue kodom.
                }
            }
        }
        #endregion

        #region Update
        // PUT api/values/5
        //TODO: napraviti handleanje situacija kad ne pošaljem određenu vrijednost propertyja
        //(npr. nisam poslao vrijednost za "Model")

        [HttpPut]
        [Route("tractormodel/update/{id}")]
        public async Task<HttpResponseMessage> UpdateByIdAsync(int Id, ITractorModelRest updateModel)
        {
            if (Id > 0 && updateModel != null)
            {
                ITractorModelEntity tractorModelEntity = await TractorModelService.GetByIdAsync(Id);

                if (tractorModelEntity != null)
                {
                    if (!string.IsNullOrEmpty(updateModel.Model))
                    {
                        tractorModelEntity.Model = updateModel.Model;
                    }
                    if (updateModel.BrandId > 0) 
                    { 
                        tractorModelEntity.BrandId = updateModel.BrandId;
                    }

                    await TractorModelService.UpdateByIdAsync(Id, tractorModelEntity);
                    return Request.CreateResponse(HttpStatusCode.OK, "Tractor model is updated!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no Tractor model with id: {Id}");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Id is not valid and/or object is not provided.");
            }
        }
        #endregion

        #region Delete
        // DELETE api/values/5
        [HttpDelete]
        [Route("tractormodel/delete/{id}")]
        public async Task<HttpResponseMessage> DeleteByIdAsync(int Id)
        {
            if (Id > 0)
            {
                ITractorModelEntity tractorModelEntity = await TractorModelService.GetByIdAsync(Id);

                if (tractorModelEntity.Id > 0)
                {
                    await TractorModelService.DeleteByIdAsync(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Tractor model is deleted!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Tractor model with id: {Id} doesn't exist!");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Didn't provide a valid Id!");
            }
        }
        #endregion
    }
}
