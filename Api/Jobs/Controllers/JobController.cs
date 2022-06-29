using Microsoft.AspNetCore.Mvc;
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
}