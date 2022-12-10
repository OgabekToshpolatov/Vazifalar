using BlogMvc.Entities;
using BlogMvc.Models;

namespace BlogMvc.Mapper;

public static class ModelEntityMapper
{
    public static AppUser ToEntity(this RegisterViewModel model)
        => new AppUser()
        {
            UserName = model.Username,
            Avatar = ToBase64String(model.Avatar)
        };

    public static Post ToEntity(this CreateOrUpdateViewModel model)
        => new()
        {
            Name = model.Name,
            Address = model.Address,
            PhoneNumber = model.PhoneNumber,
            Description = model.Description,
            Image = ToBase64String(model.Image)
        };

    public static PostViewModel ToModel(this Post entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Address = entity.Address,
            PhoneNumber = entity.PhoneNumber,
            Description = entity.Description,
            Image = entity.Image,
            AppUserId = entity.AppUserId,
            CreatedDate = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate,
            IsEdited = entity.IsEdited
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