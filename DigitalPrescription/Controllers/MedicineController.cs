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
    public class MedicineController : ControllerBase
    {
        protected readonly IMedicineRepo medicinerepo;
        public MedicineController(IMedicineRepo medicinerepo)
        {
            this.medicinerepo = medicinerepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            try{
                return  Ok(await medicinerepo.GetAll());
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,"error retriving from database");
            }
        }
        [HttpGet("{id:int}")]
         public  async Task<ActionResult<Medicine>> Get(int id){
                    try{
                        var result=await medicinerepo.GetById(id);
                        if(result==null)
                            return NotFound();
                        return result;    
                    }
                    catch(Exception){
                        return StatusCode(StatusCodes.Status500InternalServerError,"Error Retriving Data From Database");

                    }
                }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Medicine mf){
           try
           {
                if(mf == null){
                return BadRequest();
            }
            var created= await medicinerepo.Create(mf);
            return CreatedAtAction(nameof(Get),new{id=created.Id},created);

            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,"Error Creating new Record");
                }

        }
    
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Medicine>> Update(int id, Medicine mf){
           try
           {    
                if(id != mf.Id){
                    return BadRequest("Id dismatch");
            }
            var cm=await medicinerepo.GetById(id);
            if (cm==null)
            {
                return NotFound("Medicine not found");
            }

           return await medicinerepo.Update(mf,id);
            
            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,$"Error upadate {mf.Id} Record");
                }

        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Medicine>> Delete(int id)
        {
           try
           {
             var mf= await medicinerepo.GetById(id);
           if (mf==null)
           {
               return NotFound($"Medicine with id={id} Not Found");
           }
            
            return await medicinerepo.Delete(id);
  
           }
           catch (System.Exception)
           {
               
               return StatusCode(StatusCodes.Status500InternalServerError,"Error Deleting Data");
           }
           
           
        }
        
    
    }
}