using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TractorShop.Model;
using TractorShop.Service;

namespace TractorShopWebApi.Controllers
{
    public class TractorModelController : ApiController
    {
        #region GetAll 

        // GET api/values
        [HttpGet]
        [Route("tractormodel/getall")]
        public HttpResponseMessage GetAll()
        {
            TractorModelService tractorModelService = new TractorModelService();
            List<TractorModelEntity> tractorModels = tractorModelService.GetAll();

            if (tractorModels.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, tractorModels);
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
        public HttpResponseMessage GetById(int Id)
        {
            if (Id > 0)
            {
                TractorModelService tractorModelService = new TractorModelService();
                TractorModelEntity tractorModelEntity = tractorModelService.GetById(Id);

                if (tractorModelEntity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, tractorModelEntity);
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
        public HttpResponseMessage Post(TractorModelEntity postModel)
        {
            if (postModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an empty object!");
            }
            else
            {
                //TODO: Dodati provjeru postoji li BrandId u tablici s brandovima
                if (string.IsNullOrEmpty(postModel.Model) || postModel.BrandId == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Check if you provided all required properties for an object.");
                }
                else
                {
                    TractorModelService tractorModelService = new TractorModelService();
                    tractorModelService.Post(postModel);
                    return Request.CreateResponse(HttpStatusCode.OK);
                    //TODO: provjeriti zašto ne pospremi u bazu kad u Response proslijedim "postModel" objekt
                }
            }
        }
        #endregion

        #region Update
        // PUT api/values/5
        //TODO: napraviti handleanje situacija kad ne pošaljem određenu vrijednost propertyja (npr. nisam poslao vrijednost za "Model"
        [HttpPut]
        [Route("tractormodel/update/{id}")]
        public HttpResponseMessage UpdateById(int Id, TractorModelEntity updateModel)
        {
            if (Id > 0 && updateModel != null)
            {
                TractorModelService tractorModelService = new TractorModelService();
                TractorModelEntity tractorModelHelp = tractorModelService.GetById(Id);

                if (tractorModelHelp != null)
                {
                    tractorModelService.UpdateById(Id, updateModel);
                    return Request.CreateResponse(HttpStatusCode.OK);
                    //TODO: provjeriti zašto ne pospremi u bazu kad u Response proslijedim "postModel" objekt
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no Tractor Model with id: {Id}");
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
        public HttpResponseMessage DeleteById(int Id)
        {
            if (Id > 0)
            {
                TractorModelService tractorModelService = new TractorModelService();
                tractorModelService.DeleteById(Id);
                return Request.CreateResponse(HttpStatusCode.OK);
                //TODO: provjeriti zašto ne pospremi u bazu kad u Response proslijedim "postModel" objekt
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an empty object!");
            }
        }
        #endregion
    }
}
