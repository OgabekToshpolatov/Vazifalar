using System.Security.Claims;
using Mapster;
using mvc.Data;
using mvc.Entities;
using mvc.Models;
using mvc.ViewModel;

namespace mvc.Services;

public class OrganizationService : IOrganizationService
{
    private readonly AppDbContext _context;
    private readonly ILogger<OrganizationService> _logger;

    public OrganizationService(AppDbContext context,ILogger<OrganizationService> logger)
    {
        _context = context ;
        _logger = logger ;
    }
    public async Task AddOrganization(ClaimsPrincipal claims, CreateOrganizationModel createOrganizationModel)
    {
        _logger.LogInformation("User kirib keldi service ga ");
        var organization = createOrganizationModel.Adapt<Organization>();
        var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        organization.Users = new List<OrganizationUser>()
        {
             new OrganizationUser()
             {
                Role = ERole.Owner,
                UserId = userId
             }
        };
        _logger.LogInformation("Hammasi yaxshi akasi ");
        await _context.Organizations!.AddAsync(organization);
        await _context.SaveChangesAsync();
    }

    public async Task<OrganizationModel> GetOrganizationByIdAsync(Guid organizationId)
    {
        var organization = await _context.Organizations!.FindAsync(organizationId);
         
        return organization.Adapt<OrganizationModel>();
    }
}