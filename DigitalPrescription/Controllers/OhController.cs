using System;
using Microsoft.AspNetCore.Mvc;
using DigitalPrescription.Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DigitalPrescriptionModels;

namespace DigitalPrescription.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OhController : ControllerBase
    {
        protected readonly IOhRepo ohRepo;
        public OhController(IOhRepo ohRepo)
        {
            this.ohRepo = ohRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            try{
                return  Ok(await ohRepo.GetAll());
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,"error retriving from database");
            }
        }
        [HttpGet("{id:int}")]
         public  async Task<ActionResult<Oh>> Get(int id){
                    try{
                        var result=await ohRepo.GetById(id);
                        if(result==null)
                            return NotFound();
                        return result;    
                    }
                    catch(Exception){
                        return StatusCode(StatusCodes.Status500InternalServerError,"Error Retriving Data From Database");

                    }
                }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Oh oh){
           try
           {
                if(oh == null){
                return BadRequest();
            }
            var created= await ohRepo.Create(oh);
            return CreatedAtAction(nameof(Get),new{id=created.Id},created);

            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,"Error Creating new EMployee Record");
                }

        }
    
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Oh>> Update(int id, Oh oh){
           try
           {    
                if(id != oh.Id){
                    return BadRequest("Id dismatch");
            }
            var cm=await ohRepo.GetById(id);
            if (cm==null)
            {
                return NotFound("C F not found");
            }

           return await ohRepo.Update(oh,id);
            
            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,$"Error upadate {oh.Id} Record");
                }

        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Oh>> Delete(int id)
        {
           try
           {
             var oh= await ohRepo.GetById(id);
           if (oh==null)
           {
               return NotFound($"C F with id={id} Not Found");
           }
            
            return await ohRepo.Delete(id);
  
           }
           catch (System.Exception)
           {
               
               return StatusCode(StatusCodes.Status500InternalServerError,"Error Deleting Data");
           }
           
           
        }
        
    
    }
}