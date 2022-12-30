using Question2library.Repositories;
using Question2library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Question2library.DbcontextCLASS;
using Question2library.Dbmodel;
using System.Xml.Linq;

namespace API.Controllers
{
    public class HomeApiController : ApiController
    {
        DefaultDbcontext db = new DefaultDbcontext();
        Istudent istudent = new StudentRepo();
        [Route("~/api/HomeApi/ReadAllStud")]
        [HttpGet]
        //api/HomeApi/ReadAllStud
        public IHttpActionResult ReadAllStud()
        {

            var _data = istudent.ReadAll();
            return Ok(_data);
        }
      


        //api/HomeApi/Create
        [HttpPost]
        public IHttpActionResult Create(StudentViewModels model)
        {
            istudent=new StudentRepo();
            var _data = istudent.Create(model);
            return Ok();

        }
        //api/HomeApi/Update
  
        [HttpGet]
        public IHttpActionResult Update(long id)
        {
            var std = db._studentDbModels.Where(x => x.Id == id).FirstOrDefault();
            return Ok(std);
        }
        [HttpPut]
        public IHttpActionResult Update(StudentViewModels model)
        {
            var data = istudent.Update(model.Id, model);
            return Ok(data);
        }


        //api/HomeApi/Delete
        [HttpDelete]
        public IHttpActionResult Delete(long ID)
        {
            Istudent istudent = new StudentRepo();
            var data = db._studentDbModels.Where(x => x.Id == ID).FirstOrDefault();
            istudent.Delete(data.Id);
            return Ok();
        }
    }
}