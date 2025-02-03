
using Domain.Aggregates;
using Mapster;
using MarineraWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedEntities.DTOs;

namespace MarineraWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ConcoursesController : Controller
{
    private readonly ILogger<ConcoursesController> _logger;
    private readonly ConcourseService _concourseService;
 
    public ConcoursesController(ILogger<ConcoursesController> logger, ConcourseService concourseService)
    {
        _logger = logger;
        _concourseService = concourseService;
 
    }

    [HttpGet(Name = "GetConcourse")]
    public async Task<IEnumerable<Concourse>> Get()
    {
        return await _concourseService.GetConcourses();
    }

    [HttpPost(Name = "CreateConcourse")]
    public async Task<IActionResult> CreateConcourse([FromBody]ConcourseDto concourseDto)
    {
        var concourse=concourseDto.Adapt<Concourse>();
        try
        {
            await _concourseService.CreateConcourse(concourse);
            return Ok(concourse);

        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut(Name = "UpdateConcourse")]
    public async Task<IActionResult> UpdateConcourse([FromBody]ConcourseDto concourseDto)
    {
        var concourse=concourseDto.Adapt<Concourse>();
        try
        {
            await _concourseService.UpdateConcourse(concourse);
            return Ok(concourse);

        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
    }


}