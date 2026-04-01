using conceitos.DTOs;
namespace conceitos.Infra.data;

//Sempre que eu instanciar ela vai resetar a lista!!!

public class LanguageData
{
    public List<LanguageDto> languages{get; set;}
    public LanguageData()
    {
       languages = [];
    }

}