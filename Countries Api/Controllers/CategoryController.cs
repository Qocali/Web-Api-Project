using AutoMapper;
using Countries_Api.Dtos.categorydto;
using Countries_Api.Extentions;
using Countries_Api.Models;
using Countries_Api.repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using static System.Collections.Specialized.BitVector32;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Countries_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepo<category> _IRepo;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _host;
        public CategoryController(IRepo<category> IRepo,IMapper mapper,IHostingEnvironment host)
        {
            _IRepo = IRepo;
            _mapper = mapper;
            _host = host;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var cat = _IRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<categorygetdto>>(cat));
        }
        [HttpGet("id")]
        public IActionResult GetbyId(int? id)
        {
            category cat = _IRepo.GetbyId(id);
            if(cat == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<categorygetdto>(cat));
        }
        [HttpPost]
        public async Task<IActionResult> Create( categorycreatedto categorycreatedto)
        {
            try
            {
                var files=HttpContext.Request.Form.Files;
                if(files != null && files.Count > 0)
                {
                    foreach ( var file in files)
                    {
                        string folder = Path.Combine("public","img");
                       string filename= await file.savefileAsync(folder);
                        categorycreatedto.Image=filename;
                    }
                }
                var catmodel = _mapper.Map<category>(categorycreatedto);
                _IRepo.Create(catmodel);

                var catread = _mapper.Map<categorygetdto>(catmodel);
                return CreatedAtRoute(nameof(GetbyId), new { id = catread.Id }, catread);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(int? id,categorycreatedto categorycreatedto)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        string folder = Path.Combine("public", "img");
                        string filename = await file.savefileAsync(folder);
                        categorycreatedto.Image = filename;
                    }
                }
                var catmodel = _mapper.Map<category>(categorycreatedto);
                _IRepo.Update(id,catmodel);

                var catread = _mapper.Map<categorygetdto>(catmodel);
                return CreatedAtRoute(nameof(GetbyId), new { id = catread.Id }, catread);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int? id)
        {
            _IRepo.Delate(id);
            return Ok();
        }


    }

}

