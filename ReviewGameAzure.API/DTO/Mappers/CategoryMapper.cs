using ReviewGameAzure.DAL.Entities;

namespace ReviewGameAzure.API.DTO.Mappers
{
    public static class CategoryMapper
    {

        public static CategoryDTO ToModelDTO(this CategoryEntity entity)
        {
            return new CategoryDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }



        public static CategoryEntity ToEntity(this CategoryDataDTO data)
        {
            return new CategoryEntity()
            {
                Name = data.Name,
                Description = data.Description
            };
        }
    }
}
