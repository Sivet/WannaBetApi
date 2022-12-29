using AutoMapper;
using WannaBetApi.Dtos;
using WannaBetApi.Models;

namespace WannaBetApi.MappingProfiles;

//Rename to WannaBetApiProfiles?
//It can contain maps for multiple things --> see Fablab project
public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        CreateMap<Character, CharacterOutputDto>();
    }
}