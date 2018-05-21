using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using USRv2.Models;

namespace USRv2.Controllers.Api
{
    public class TitlesController : ApiController
    {

        private ApplicationDbContext _context;
        public TitlesController()
        {
            _context = new ApplicationDbContext();
        }

        //DELETE /api/titles/1
        [HttpDelete]
        public void DeleteTitle(int id)
        {
            var titleInDb = _context.Titles.SingleOrDefault(c => c.Id == id);

            if (titleInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Titles.Remove(titleInDb);
            _context.SaveChanges();
        }
    }
}
