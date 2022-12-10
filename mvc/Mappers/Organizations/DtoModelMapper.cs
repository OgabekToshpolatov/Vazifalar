using mvc.Dtos;
using mvc.Models;

namespace mvc.Mappers.Organizations;

public static class DtoModelMapper
{
    public static CreateOrganizationModel ToModel(this CreateOrganizationDto dtoModel)
        => new()
        {
            Name = dtoModel.Name,
            ImagePath  = ToBase64String(dtoModel.Image),
            Address = dtoModel.Address,
            PhoneNumber = dtoModel.PhoneNumber
        };

    public static string ToBase64String(IFormFile image)
    {
        var memoryStream = new MemoryStream();
        image.CopyToAsync(memoryStream);
        var result = memoryStream.ToArray();
        while(result.Count() == 0) result = memoryStream.ToArray();
        var str = Convert.ToBase64String(result);
        return "data:image/jpeg;base64,"+str;
    }
}