using CurriculumVitae.common.Services;
using CurriculumVitaeRepository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CurriculumVitae.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CurriculumVitaeController : ControllerBase
{
    ICurriculumVitaeServices cvService { get; set; }
    public CurriculumVitaeController(ICurriculumVitaeServices cvService)
    {
        this.cvService = cvService;
    }
    [HttpGet]
    public async Task<Results<Ok<IEnumerable<Profiel>>, BadRequest<string>>> GetAllProfiles()
    {        
        try
        {
            var data = await cvService.GetAllProfiles();
            if (data == null)
            {
                return TypedResults.BadRequest("Null pointer");
            }
            return TypedResults.Ok(data);
        } catch(Exception ex)
        {
            return TypedResults.BadRequest("Could not execute internal code");
        } finally
        {
            
        }
        
        
        
    }
}
