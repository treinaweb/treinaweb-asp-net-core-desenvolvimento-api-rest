using Microsoft.AspNetCore.Mvc;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Api.Jobs.Services;

namespace TWJobs.Api.Jobs.Controllers;

[ApiController]
[Route("/api/jobs")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_jobService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] int id)
    {
        return Ok(_jobService.FindById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] JobRequest jobRequest)
    {
        var body = _jobService.Create(jobRequest);
        return CreatedAtAction(nameof(FindById), new { Id = body.Id }, body);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] JobRequest jobRequest)
    {
        return Ok(_jobService.UpdateById(id, jobRequest));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _jobService.DeleteById(id);
        return NoContent();
    }
}