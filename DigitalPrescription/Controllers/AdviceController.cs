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
    public class AdviceController : ControllerBase
    {
        protected readonly IAdviceRepo AdviceRepo;
        public AdviceController(IAdviceRepo AdviceRepo)
        {
            this.AdviceRepo = AdviceRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            try{
                return  Ok(await AdviceRepo.GetAll());
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,"error retriving from database");
            }
        }
        [HttpGet("{id:int}")]
         public  async Task<ActionResult<Advice>> Get(int id){
                    try{
                        var result=await AdviceRepo.GetById(id);
                        if(result==null)
                            return NotFound();
                        return result;    
                    }
                    catch(Exception){
                        return StatusCode(StatusCodes.Status500InternalServerError,"Error Retriving Data From Database");

                    }
                }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Advice advice){
           try
           {
                if(advice == null){
                return BadRequest();
            }
            var createdAdvice= await AdviceRepo.Create(advice);
            return CreatedAtAction(nameof(Get),new{id=createdAdvice.Id},createdAdvice);

            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,"Error Creating new EMployee Record");
                }

        }
    
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Advice>> Update(int id,Advice advice){
           try
           {    
                if(id != advice.Id){
                    return BadRequest("Id dismatch");
            }
            var ad=await AdviceRepo.GetById(id);
            if (ad==null)
            {
                return NotFound("Advice not found");
            }

           return await AdviceRepo.Update(advice,id);
            
            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,$"Error upadate {advice.Id} Record");
                }

        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Advice>> Delete(int id)
        {
           try
           {
             var advice= await AdviceRepo.GetById(id);
           if (advice==null)
           {
               return NotFound($"Advice with id={id} Not Found");
           }
            
            return await AdviceRepo.Delete(id);
  
           }
           catch (System.Exception)
           {
               
               return StatusCode(StatusCodes.Status500InternalServerError,"Error Deleting Data");
           }
           
           
        }
        
    
    }
}