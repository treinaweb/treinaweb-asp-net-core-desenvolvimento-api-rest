using TWJobs.Api.Jobs.Dtos;
using TWJobs.Core.Models;

namespace TWJobs.Api.Jobs.Mappers;

public class JobMapper : IJobMapper
{
    public JobDetailResponse ToDetailResponse(Job job)
    {
        return new JobDetailResponse
        {
            Id = job.Id,
            Title = job.Title,
            Salary = job.Salary,
            Requirements = job.Requirements.Split(";")
        };
    }

    public Job ToModel(JobRequest jobRequest)
    {
        return new Job
        {
            Title = jobRequest.Title,
            Salary = jobRequest.Salary,
            Requirements = String.Join(";", jobRequest.Requirements)
        };
    }

    public JobSummaryResponse ToSummaryResponse(Job job)
    {
        return new JobSummaryResponse
        {
            Id = job.Id,
            Title = job.Title
        };
    }
}