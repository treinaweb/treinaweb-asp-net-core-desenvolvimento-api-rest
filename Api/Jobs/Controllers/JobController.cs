using Microsoft.AspNetCore.Mvc;
using TWJobs.Api.Jobs.Services;
using TWJobs.Core.Models;

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
    public IActionResult Create([FromBody] Job job)
    {
        var body = _jobService.Create(job);
        return CreatedAtAction(nameof(FindById), new { Id = job.Id }, body);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] Job job)
    {
        return Ok(_jobService.UpdateById(id, job));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _jobService.DeleteById(id);
        return NoContent();
    }
}