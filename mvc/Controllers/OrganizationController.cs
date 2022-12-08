using Microsoft.AspNetCore.Mvc;
using mvc.Services;

namespace mvc.Controllers;

public class OrganizationController:Controller
{
    private readonly IOrganizationService _organizationService;

    public OrganizationController(IOrganizationService organizationService)
    {
        _organizationService = organizationService ;
    }
}