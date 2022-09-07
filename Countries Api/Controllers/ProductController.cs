using AutoMapper;
using Countries_Api.Dtos.productdto;
using Countries_Api.Extentions;
using Countries_Api.Models;
using Countries_Api.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Countries_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepo<product> _IRepo;
        private readonly IMapper _mapper;
      
        public ProductController(IRepo<product> IRepo, IMapper mapper)
        {
            _IRepo = IRepo;
            _mapper = mapper;
          
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var cat = _IRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<productgetdto>>(cat));
        }
        [HttpGet("id")]
        public IActionResult GetbyId(int? id)
        {
            product cat = _IRepo.GetbyId(id);
            if (cat == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<productgetdto>(cat));
        }
        [HttpPost]
        public async Task<IActionResult> Create(productcreatedto productcreatedto)
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
                        productcreatedto.Image = filename;
                    }
                }
                var promodel = _mapper.Map<product>(productcreatedto);
                _IRepo.Create(promodel);

                var proread = _mapper.Map<productgetdto>(promodel);
                return CreatedAtRoute(nameof(GetbyId), new { id = proread.Id }, proread);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(int? id, productcreatedto productcreatedto)
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
                        productcreatedto.Image = filename;
                    }
                }
                var catmodel = _mapper.Map<product>(productcreatedto);
                _IRepo.Update(id, catmodel);

                var catread = _mapper.Map<productgetdto>(catmodel);
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
