using AutoMapper;
using WebApi.Impl.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookResponseModel, CreateBookModel>();
        
        CreateMap<CreateBookModel, BookResponseModel>();
    }
}
