using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VideoPlayerBackEnd.Data;

namespace VideoPlayerBackEnd.Controllers
{
    [EnableCors("http://localhost:4200", "*", "*")]
    public class VideosController : ApiController
    {
        public IHttpActionResult GetVideos()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var videos = context.Videos.ToList();

                    return Ok(videos);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
