using TWJobs.Core.Models;

namespace TWJobs.Api.Jobs.Services;

public interface IJobService
{
    ICollection<Job> FindAll();
    Job FindById(int id);
}