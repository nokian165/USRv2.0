using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using USRv2.Models;

namespace USRv2.Controllers.Api
{
    public class UnitsController : ApiController
    {
        private ApplicationDbContext _context;
        public UnitsController()
        {
            _context = new ApplicationDbContext();
        }

        //DELETE /api/units/1
        [HttpDelete]
        public void DeleteUnit(int id)
        {
            var unitInDb = _context.Units.SingleOrDefault(c => c.Id == id);

            if (unitInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Units.Remove(unitInDb);
            _context.SaveChanges();
        }





    }

}
