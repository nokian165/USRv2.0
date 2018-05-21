using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using USRv2.Models;
using USRv2.Dtos;

namespace USRv2.Controllers.Api
{
    public class PlcsController : ApiController
    {

        private ApplicationDbContext _context;
        public PlcsController()
        {
            _context = new ApplicationDbContext();
        }

        //DELETE /api/plcs/1
        [HttpDelete]
        public void DeletePlc(int id)
        {
            var plcInDb = _context.Plcs.SingleOrDefault(c => c.Id == id);

            if (plcInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Plcs.Remove(plcInDb);
            _context.SaveChanges();
        }

        //PUT /api/plcs/1
        [HttpPut]
        public void ChangeCheckboxState(int id, ChangeCheckboxStateDto changeCheckboxStateDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var plcInDb = _context.Plcs.SingleOrDefault(c => c.Id == id);

            if (plcInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            plcInDb.IsVisibleInMenu = changeCheckboxStateDto.IsVisibleInMenu;

            _context.SaveChanges();

        }
    }
}
