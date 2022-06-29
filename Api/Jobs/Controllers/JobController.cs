using Microsoft.AspNetCore.Mvc;
using TWJobs.Api.Jobs.Services;
using TWJobs.Core.Exceptions;
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
}