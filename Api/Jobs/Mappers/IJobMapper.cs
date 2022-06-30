using TWJobs.Api.Jobs.Dtos;
using TWJobs.Core.Models;

namespace TWJobs.Api.Jobs.Mappers;

public interface IJobMapper
{
    JobSummaryResponse ToSummaryResponse(Job job);
    JobDetailResponse ToDetailResponse(Job job);
    Job ToModel(JobRequest jobRequest);
}