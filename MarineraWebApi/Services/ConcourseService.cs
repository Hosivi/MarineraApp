using Ardalis.GuardClauses;
using Domain.Aggregates;
using Infrastructure.Repositories;
using SharedKernel;

namespace MarineraWebApi.Services;

public class ConcourseService
{
    private readonly RepositoryAsync<Concourse> _repository;

    private readonly AuthService _authService;
    public ConcourseService(RepositoryAsync<Concourse> repository, AuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }
    public async Task<Concourse> CreateConcourse(Concourse concourse)
    {
        Guard.Against.Null(concourse.Name, nameof(concourse.Name));
        var organization = await _authService.GetDefaultOrganization();
        Guard.Against.Null(organization?.Id, nameof(organization.Id), $"El parámeter {organization} does not should be null");
            concourse.OrganizationId = organization.Id;
        concourse.CreateRegisterOffice(concourse);
        concourse.CreateTicketOffice(concourse);
        var savedConcourse = await _repository.AddAsync(concourse);
        return savedConcourse;
    }
    public async Task<List<Concourse>> GetConcourses()
    {
        var s = new Specification<Concourse>();
        s.Includes.Add(x => x.RegisterOffice);
        s.Includes.Add(x => x.TicketOffice);
        return _repository.GetAllAsync(s).Result.ToList();
    }

    public async Task UpdateConcourse(Concourse concourse)
    {
        await _repository.UpdateAsync(concourse);
    }
}