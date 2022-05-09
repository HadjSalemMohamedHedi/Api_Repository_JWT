using AutoMapper;
using BoookStore.API.Data;
using BoookStore.API.Models;

namespace BoookStore.API.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        } 
        
    }
}
