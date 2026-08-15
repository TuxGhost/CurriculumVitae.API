using CurriculumVitae.common.Services;
using CurriculumVitaeRepository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data.Common;
using CurriculumVitae.common.DTOs;

namespace CurriculumVitae.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CurriculumVitaeController : ControllerBase
{
    ICurriculumVitaeServices cvService { get; set; }
    ICurriculumVitaeService cvService2 { get; set; }
    public CurriculumVitaeController(ICurriculumVitaeServices cvService,ICurriculumVitaeService cvService2)
    {
        this.cvService = cvService;
        this.cvService2 = cvService2;
    }
    [HttpGet("all")]
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
        } catch(DbException ex)
        {
            return TypedResults.BadRequest($"Problem with database: {ex.Message}");        
        } catch(Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        } finally
        {
            
        }                        
    }
    [HttpGet("current")]
    public async Task<Results<Ok<CvDto>, BadRequest<string>>> GetCv()
    {
        try
        {
            var data = await cvService2.GetAsync();
            if (data == null)
            {
                return TypedResults.BadRequest("Null pointer");
            }
            return TypedResults.Ok(data);
        }
        catch (DbException ex)
        {
            return TypedResults.BadRequest($"Problem with database: {ex.Message}");
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

}
