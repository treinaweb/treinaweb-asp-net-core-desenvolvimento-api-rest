using Microsoft.AspNetCore.Mvc;
using TWJobs.Api.Common.Dtos;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Api.Jobs.Services;

namespace TWJobs.Api.Jobs.Controllers;

[ApiController]
[Route("/api/jobs")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly LinkGenerator _linkGenerator;

    public JobController(IJobService jobService, LinkGenerator linkGenerator)
    {
        _jobService = jobService;
        _linkGenerator = linkGenerator;
    }

    [HttpGet(Name = "FindAllJobs")]
    public IActionResult FindAll()
    {
        var body = _jobService.FindAll();
        foreach (var resource in body)
        {
            var selfLink = new LinkResponse(
                _linkGenerator.GetUriByName(HttpContext, "FindJobById", new { Id = resource.Id }),
                "GET",
                "self"
            );
            var updateLink = new LinkResponse($"/api/jobs/{resource.Id}", "PUT", "update");
            var deleteLink = new LinkResponse($"/api/jobs/{resource.Id}", "DELETE", "delete");
            resource.AddLinks(selfLink, updateLink, deleteLink);
        }
        return Ok(body);
    }

    [HttpGet("{id}", Name = "FindJobById")]
    public IActionResult FindById([FromRoute] int id)
    {
        var body = _jobService.FindById(id);
        body.AddLink(new LinkResponse($"/api/jobs/{body.Id}", "GET", "self"));
        body.AddLink(new LinkResponse($"/api/jobs/{body.Id}", "PUT", "update"));
        body.AddLink(new LinkResponse($"/api/jobs/{body.Id}", "DELETE", "delete"));
        return Ok(body);
    }

    [HttpPost(Name = "CreateJob")]
    public IActionResult Create([FromBody] JobRequest jobRequest)
    {
        var body = _jobService.Create(jobRequest);
        body.AddLink(new LinkResponse($"/api/jobs/{body.Id}", "GET", "self"));
        body.AddLink(new LinkResponse($"/api/jobs/{body.Id}", "PUT", "update"));
        body.AddLink(new LinkResponse($"/api/jobs/{body.Id}", "DELETE", "delete"));
        return CreatedAtAction(nameof(FindById), new { Id = body.Id }, body);
    }

    [HttpPut("{id}", Name = "UpdateJobById")]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] JobRequest jobRequest)
    {
        var body = _jobService.UpdateById(id, jobRequest);
        body.AddLink(new LinkResponse($"/api/jobs/{body.Id}", "GET", "self"));
        body.AddLink(new LinkResponse($"/api/jobs/{body.Id}", "PUT", "update"));
        body.AddLink(new LinkResponse($"/api/jobs/{body.Id}", "DELETE", "delete"));
        return Ok(body);
    }

    [HttpDelete("{id}", Name = "DeleteJobById")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _jobService.DeleteById(id);
        return NoContent();
    }
}