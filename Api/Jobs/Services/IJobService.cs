using TWJobs.Api.Jobs.Dtos;
using TWJobs.Core.Models;

namespace TWJobs.Api.Jobs.Services;

public interface IJobService
{
    ICollection<JobSummaryResponse> FindAll();
    JobDetailResponse FindById(int id);
    JobDetailResponse Create(JobRequest jobRequest);
    JobDetailResponse UpdateById(int id, JobRequest jobRequest);
    void DeleteById(int id);
}