using TWJobs.Core.Exceptions;
using TWJobs.Core.Models;
using TWJobs.Core.Repositories.Jobs;

namespace TWJobs.Api.Jobs.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public ICollection<Job> FindAll()
    {
        return _jobRepository.FindAll();
    }

    public Job FindById(int id)
    {
        var job = _jobRepository.FindById(id);
        if (job is null)
        {
            throw new ModelNotFoundException($"Job with id {id} not found");
        }
        return job;
    }
}