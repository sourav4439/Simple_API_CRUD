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
    public class CcController : ControllerBase
    {
        protected readonly ICcRepo ccRepo;
        public CcController(ICcRepo ccRepo)
        {
            this.ccRepo = ccRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            try{
                return  Ok(await ccRepo.GetAll());
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,"error retriving from database");
            }
        }
        [HttpGet("{id:int}")]
         public  async Task<ActionResult<Cc>> Get(int id){
                    try{
                        var result=await ccRepo.GetById(id);
                        if(result==null)
                            return NotFound();
                        return result;    
                    }
                    catch(Exception){
                        return StatusCode(StatusCodes.Status500InternalServerError,"Error Retriving Data From Database");

                    }
                }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Cc cc){
           try
           {
                if(cc == null){
                return BadRequest();
            }
            var created= await ccRepo.Create(cc);
            return CreatedAtAction(nameof(Get),new{id=created.Id},created);

            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,"Error Creating new EMployee Record");
                }

        }
    
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Cc>> Update(int id, Cc cc){
           try
           {    
                if(id != cc.Id){
                    return BadRequest("Id dismatch");
            }
            var cm=await ccRepo.GetById(id);
            if (cm==null)
            {
                return NotFound("category not found");
            }

           return await ccRepo.Update(cc,id);
            
            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,$"Error upadate {cc.Id} Record");
                }

        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Cc>> Delete(int id)
        {
           try
           {
             var cc= await ccRepo.GetById(id);
           if (cc==null)
           {
               return NotFound($"Clinical Condition with id={id} Not Found");
           }
            
            return await ccRepo.Delete(id);
  
           }
           catch (System.Exception)
           {
               
               return StatusCode(StatusCodes.Status500InternalServerError,"Error Deleting Data");
           }
           
           
        }
        
    
    }
}