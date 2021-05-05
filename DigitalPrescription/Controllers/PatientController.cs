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
    public class PatientController : ControllerBase
    {
        protected readonly IPatientRepo patientRepo;
        public PatientController(IPatientRepo patientRepo)
        {
            this.patientRepo = patientRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            try{
                return  Ok(await patientRepo.GetAll());
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,"error retriving from database");
            }
        }
        [HttpGet("{id:int}")]
         public  async Task<ActionResult<Patient>> Get(int id){
                    try{
                        var result=await patientRepo.GetById(id);
                        if(result==null)
                            return NotFound();
                        return result;    
                    }
                    catch(Exception){
                        return StatusCode(StatusCodes.Status500InternalServerError,"Error Retriving Data From Database");

                    }
                }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Patient patient){
           try
           {
                if(patient == null){
                return BadRequest();
            }
            var created= await patientRepo.Create(patient);
            return CreatedAtAction(nameof(Get),new{id=created.Id},created);

            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,"Error Creating new patient Record");
                }

        }
    
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Patient>> Update(int id, Patient patient){
           try
           {    
                if(id != patient.Id){
                    return BadRequest("Id dismatch");
            }
            var cm=await patientRepo.GetById(id);
            if (cm==null)
            {
                return NotFound("Patient not found");
            }

           return await patientRepo.Update(patient,id);
            
            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,$"Error upadate {patient.Id} Record");
                }

        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Patient>> Delete(int id)
        {
           try
           {
             var patient= await patientRepo.GetById(id);
           if (patient==null)
           {
               return NotFound($"C F with id={id} Not Found");
           }
            
            return await patientRepo.Delete(id);
  
           }
           catch (System.Exception)
           {
               
               return StatusCode(StatusCodes.Status500InternalServerError,"Error Deleting Data");
           }
           
           
        }
        
    
    }
}