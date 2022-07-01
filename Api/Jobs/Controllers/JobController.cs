using Microsoft.AspNetCore.Mvc;
using TWJobs.Api.Common.Assemblers;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Api.Jobs.Services;

namespace TWJobs.Api.Jobs.Controllers;

[ApiController]
[Route("/api/jobs")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly IAssembler<JobSummaryResponse> _jobSummaryAssembler;
    private readonly IAssembler<JobDetailResponse> _jobDetailAssembler;

    public JobController(
        IJobService jobService,
        IAssembler<JobSummaryResponse> jobSummaryAssembler,
        IAssembler<JobDetailResponse> jobDetailAssembler)
    {
        _jobService = jobService;
        _jobSummaryAssembler = jobSummaryAssembler;
        _jobDetailAssembler = jobDetailAssembler;
    }

    [HttpGet(Name = "FindAllJobs")]
    public IActionResult FindAll([FromQuery] int page, [FromQuery] int size)
    {
        var body = _jobService.FindAll(page, size);
        return Ok(body);
    }

    [HttpGet("{id}", Name = "FindJobById")]
    public IActionResult FindById([FromRoute] int id)
    {
        var body = _jobService.FindById(id);
        return Ok(_jobDetailAssembler.ToResource(body, HttpContext));
    }

    [HttpPost(Name = "CreateJob")]
    public IActionResult Create([FromBody] JobRequest jobRequest)
    {
        var body = _jobService.Create(jobRequest);
        return CreatedAtAction(
            nameof(FindById),
            new { Id = body.Id },
            _jobDetailAssembler.ToResource(body, HttpContext)
        );
    }

    [HttpPut("{id}", Name = "UpdateJobById")]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] JobRequest jobRequest)
    {
        var body = _jobService.UpdateById(id, jobRequest);
        return Ok(_jobDetailAssembler.ToResource(body, HttpContext));
    }

    [HttpDelete("{id}", Name = "DeleteJobById")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _jobService.DeleteById(id);
        return NoContent();
    }
}