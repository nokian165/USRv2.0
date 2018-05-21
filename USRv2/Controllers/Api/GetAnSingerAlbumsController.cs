using System.Linq;
using System.Web.Http;
using USRv2.Models;
using System.Data.Entity;

namespace USRv2.Controllers.Api
{
    public class GetAnSingerAlbumsController : ApiController
    {
        private ApplicationDbContext _context;

        public GetAnSingerAlbumsController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetAlbums(string singerName)
        {
            var result = _context.Albums
                .Include(c => c.Singer)
                .Where(p => p.Singer.Name == singerName)
                .ToList();
            
            return Ok(result);
        }
    }
}
