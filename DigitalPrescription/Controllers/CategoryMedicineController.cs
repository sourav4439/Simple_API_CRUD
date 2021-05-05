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
    public class CategoryMedicineController : ControllerBase
    {
        protected readonly ICategorymedRepo CategorymedRepo;
        public CategoryMedicineController(ICategorymedRepo CategorymedRepo)
        {
            this.CategorymedRepo = CategorymedRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            try{
                return  Ok(await CategorymedRepo.GetAll());
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,"error retriving from database");
            }
        }
        [HttpGet("{id:int}")]
         public  async Task<ActionResult<CategoryOfMedicine>> Get(int id){
                    try{
                        var result=await CategorymedRepo.GetById(id);
                        if(result==null)
                            return NotFound();
                        return result;    
                    }
                    catch(Exception){
                        return StatusCode(StatusCodes.Status500InternalServerError,"Error Retriving Data From Database");

                    }
                }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoryOfMedicine CategoryOfMedicine){
           try
           {
                if(CategoryOfMedicine == null){
                return BadRequest();
            }
            var createdAdvice= await CategorymedRepo.Create(CategoryOfMedicine);
            return CreatedAtAction(nameof(Get),new{id=createdAdvice.Id},createdAdvice);

            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,"Error Creating new EMployee Record");
                }

        }
    
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryOfMedicine>> Update(int id, CategoryOfMedicine categoryOfMedicine){
           try
           {    
                if(id != categoryOfMedicine.Id){
                    return BadRequest("Id dismatch");
            }
            var cm=await CategorymedRepo.GetById(id);
            if (cm==null)
            {
                return NotFound("category not found");
            }

           return await CategorymedRepo.Update(categoryOfMedicine,id);
            
            }
            catch(Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,$"Error upadate {categoryOfMedicine.Id} Record");
                }

        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryOfMedicine>> Delete(int id)
        {
           try
           {
             var cat= await CategorymedRepo.GetById(id);
           if (cat==null)
           {
               return NotFound($"CategoryOfMedicine with id={id} Not Found");
           }
            
            return await CategorymedRepo.Delete(id);
  
           }
           catch (System.Exception)
           {
               
               return StatusCode(StatusCodes.Status500InternalServerError,"Error Deleting Data");
           }
           
           
        }
        
    
    }
}