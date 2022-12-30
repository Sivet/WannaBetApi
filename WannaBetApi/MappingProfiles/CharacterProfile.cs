using AutoMapper;
using WannaBetApi.Dtos;
using WannaBetApi.Models;

namespace WannaBetApi.MappingProfiles;

//Rename to WannaBetApiProfiles?
//It can contain maps for multiple things --> see Fablab project
//Les Jackson sayes you should do one for each "domain object"
public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        // Internal Model --> Target
        CreateMap<Character, CharacterOutputDto>();

        // Target --> Internal Model
        CreateMap<CharacterInputDto, Character>();
    }
}