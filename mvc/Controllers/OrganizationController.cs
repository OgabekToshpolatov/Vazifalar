using Microsoft.AspNetCore.Mvc;
using mvc.Dtos;
using mvc.Mappers.Organizations;
using mvc.Services;
using mvc.ViewModel;

namespace mvc.Controllers;

public class OrganizationController:Controller
{
    private readonly IOrganizationService _organizationService;

    public OrganizationController(IOrganizationService organizationService)
    {
        _organizationService = organizationService ;
    }


    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrganizationDto organizationDto)
    {
        if(!ModelState.IsValid) return View();
        var organization =  _organizationService.AddOrganization(User, organizationDto.ToModel());
        return LocalRedirect($"/Organization/Article/{organization.Id}");

    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }



    public IActionResult GetOrganization() => View();
    [HttpPost]
    public async Task<IActionResult> GetOrganization(GetOrganizationByIdDto dto)
    {
       var organization =await _organizationService.GetOrganizationByIdAsync(Guid.Parse(dto.Id));
       if(organization is null) return View();
       return LocalRedirect($"/Organization/Article/{organization.Id}");


    }


    [ActionName("Article")]
    public async Task<ActionResult<OrganizationView>> GetOrganizationById(Guid organizationId)
    {
        var organization =await _organizationService.GetOrganizationByIdAsync(organizationId);
        if(organization is null) return  LocalRedirect("/Organization/GetOrganization");
        return View(organization);
    }
       
}