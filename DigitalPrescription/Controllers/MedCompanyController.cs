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
    public class MedCompanyController : ControllerBase
    {
        protected readonly IMedCompanyRepo medcompany;
        public MedCompanyController(IMedCompanyRepo medcompany)
        {
            this.medcompany = medcompany;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            try{
                return  Ok(await medcompany.GetAll());
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,"error retriving from database");
            }
        }
        [HttpGet("{id:int}")]
         public  async Task<ActionResult<MedCompany>> Get(int id){
                    try{
                        var result=await medcompany.GetById(id);
                        if(result==null)
                            return NotFound();
                        return result;    
                    }
                    catch(Exception){
                        return StatusCode(StatusCodes.Status500InternalServerError,"Error Retriving Data From Database");

                    }
                }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MedCompany mc){
           try
           {
                if(mc == null){
                return BadRequest();
            }
            var created= await medcompany.Create(mc);
            return CreatedAtAction(nameof(Get),new{id=created.Id},created);

            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,"Error Creating new  Record");
                }

        }
    
        [HttpPut("{id:int}")]
        public async Task<ActionResult<MedCompany>> Update(int id, MedCompany mc){
           try
           {    
                if(id != mc.Id){
                    return BadRequest("Id dismatch");
            }
            var cm=await medcompany.GetById(id);
            if (cm==null)
            {
                return NotFound("Medical Company not found");
            }

           return await medcompany.Update(mc,id);
            
            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,$"Error upadate {mc.Id} Record");
                }

        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MedCompany>> Delete(int id)
        {
           try
           {
             var mc= await medcompany.GetById(id);
           if (mc==null)
           {
               return NotFound($"Medical Company with id={id} Not Found");
           }
            
            return await medcompany.Delete(id);
  
           }
           catch (System.Exception)
           {
               
               return StatusCode(StatusCodes.Status500InternalServerError,"Error Deleting Data");
           }
           
           
        }
        
    
    }
}