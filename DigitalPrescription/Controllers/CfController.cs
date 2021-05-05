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
    public class CfController : ControllerBase
    {
        protected readonly ICfRepo cfRepo;
        public CfController(ICfRepo cfRepo)
        {
            this.cfRepo = cfRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            try{
                return  Ok(await cfRepo.GetAll());
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,"error retriving from database");
            }
        }
        [HttpGet("{id:int}")]
         public  async Task<ActionResult<Cf>> Get(int id){
                    try{
                        var result=await cfRepo.GetById(id);
                        if(result==null)
                            return NotFound();
                        return result;    
                    }
                    catch(Exception){
                        return StatusCode(StatusCodes.Status500InternalServerError,"Error Retriving Data From Database");

                    }
                }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Cf cf){
           try
           {
                if(cf == null){
                return BadRequest();
            }
            var created= await cfRepo.Create(cf);
            return CreatedAtAction(nameof(Get),new{id=created.Id},created);

            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,"Error Creating new EMployee Record");
                }

        }
    
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Cf>> Update(int id, Cf cf){
           try
           {    
                if(id != cf.Id){
                    return BadRequest("Id dismatch");
            }
            var cm=await cfRepo.GetById(id);
            if (cm==null)
            {
                return NotFound("C F not found");
            }

           return await cfRepo.Update(cf,id);
            
            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,$"Error upadate {cf.Id} Record");
                }

        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Cf>> Delete(int id)
        {
           try
           {
             var cf= await cfRepo.GetById(id);
           if (cf==null)
           {
               return NotFound($"C F with id={id} Not Found");
           }
            
            return await cfRepo.Delete(id);
  
           }
           catch (System.Exception)
           {
               
               return StatusCode(StatusCodes.Status500InternalServerError,"Error Deleting Data");
           }
           
           
        }
        
    
    }
}