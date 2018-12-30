using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VideoPlayerBackEnd.Data;
using VideoPlayerBackEnd.Models;

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

        [HttpGet]
        public IHttpActionResult GetVideo(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var video = context.Videos.FirstOrDefault(v => v.Id == id);

                    if (id != video.Id)
                    {
                        return BadRequest();
                    }
                    if (video == null)
                    {
                        return NotFound();
                    }
                    return Ok(video);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult PostVideo([FromBody]Video video)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Videos.Add(video);
                    context.SaveChanges();

                    return Ok("Video was created!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public IHttpActionResult PutVideo(int id, [FromBody]Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != video.Id)
            {
                return BadRequest();
            }
            try
            {
                using (var context = new AppDbContext())
                {
                    var oldvideo = context.Videos.FirstOrDefault(v => v.Id == id);
                    if (oldvideo == null)
                    {
                        return NotFound();
                    }

                    oldvideo.Title = video.Title;
                    oldvideo.Url = video.Url;
                    oldvideo.Descreption = video.Descreption;

                    context.SaveChanges();

                    return Ok("Video was updated!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteVideo(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var video = context.Videos.FirstOrDefault(v => v.Id == id);
                    if (video == null)
                    {
                        return NotFound();
                    }

                    context.Videos.Remove(video);
                    context.SaveChanges();

                    return Ok("Video was updated!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
