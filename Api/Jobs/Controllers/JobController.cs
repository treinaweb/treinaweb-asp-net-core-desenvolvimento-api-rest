using Microsoft.AspNetCore.Mvc;
using TWJobs.Api.Jobs.Services;
using TWJobs.Core.Exceptions;

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
}