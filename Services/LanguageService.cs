using System.Globalization;

namespace conceitos.Services;


// namespace MyApp.Services;

// class Greeter
// {
//     public string Greet(string name)
//     {
//         var culture = CultureInfo.CurrentCulture;
//         return $"Hello, {name}! Culture: {culture.Name}";
//     }
// }
// =============================================================
public class LanguageService
{

    public LanguageService()
    {

    }

    public bool ValidationName(string nome)
    {
        if (string.IsNullOrEmpty(nome))
        {
            return false;
        }
        return true;
    }

    public bool ValidationNivel(string nivel)
    {
        if (string.IsNullOrEmpty(nivel))
        {
            return false;
        }
        return true;
    }

    public int CheckId(string id)
    {
        if (int.TryParse(id, out int result))
        {
            return result;
        }
        else
        {
            throw new InvalidCastException("Informe apenas numeros para campo Id.");
        }
    }
}

