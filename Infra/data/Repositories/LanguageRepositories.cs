using conceitos.DTOs;
using conceitos.Infra.data;
namespace conceitos.Infra.Repositories;

public class LanguageRepository
{
    public List<LanguageData> Languages {get; set;}
    public LanguageData languageData {get; set;}
    public LanguageRepository()
    {
        //instancia
       languageData = new LanguageData();
       
    }
    public void Criar(LanguageDto linguagem)
    {
        languageData.languages.Add(linguagem);
    }
    public List<LanguageDto> Lista()
    {
        return languageData.languages;
    }
    // um teste
    public void Atualizar(int id, LanguageDto linguagem)
    {

        LanguageDto obj = languageData.languages.Find(x => x.Id == id);

        if (obj != null)
        {
            obj.Id = linguagem.Id;
            obj.Nome = linguagem.Nome;
            obj.Nivel = linguagem.Nivel;
        }
        else
        {
            Console.WriteLine("Linguagem nao encontrada ");
        }
    }

    public bool Deletar(LanguageDto languagedto)
    {
        return languageData.languages.Remove(languagedto);
    }

    public LanguageDto FindbyId(int id)
    {
        return languageData.languages.Find(x => x.Id == id);
    }
}