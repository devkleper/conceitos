Criar estrutura de camadas para organização e disponibilização de arquivos.

Exemplo:

	+ __Presentation__/Program.cs
	+ 	> __Presentation__/Cadastro.cs (*Montar lógica de cadastro apenas da console view*)
	+ 	> __Presentation__/Menu.cs (*Inserir apenas lógica de menu*)
	+ __Services__/LanguageService.cs
	+ __DTOs__/LanguageDto.cs
	+ __Infra__/__Data__/LanguageData.cs
	+ __Infra__/__Repositories__/LanguageRepository.cs

Renomear classe *Linguagem* para *__LanguageDto__*
```c#
 public class LanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nivel { get; set; }
    }
```

Analisar lógica abaixo para uma implementação no programa. A validação apenas aborda o campo *__Name__*.
> Obs: Necessário também validar os demais campos (*__Id__*, *__Nivel__*).
```c#

bool status = true
int attempts = 0
string labelField = "Informe um nome"

while(status){

	if(attempts > 3){
		
		int total = 0;
		string label = "Você excedeu o número de tentativas para esta operação. Você deseja continuar (S/N)?"
		
		while(true){
			
			if(total > 3){
				status = false
				break;
			}

			Console.Write($"Tentativas:{total} | {label}:_");

			string answer = Console.ReadLine()?.Trim().ToLower();

			if (answer == "s" || answer == "y"){
				attempts = 0;
				break;

			}else if(answer == "n" || answer == "c"){
				status = false
				break;

			} else{

				label = ">> Entrada inválida! Para continuar ou cancelar a operação informe apenas (S/N).";
				total++;
			}
		}
	}

	Console.Write($"Tentativas:{attempts} | {labelField}:_");

	string name = Console.ReadLine()?.Trim();

	if(name.IsNullOrEmpty()){
	
		labelField = "Nome necessário";
		attempts++
		continue;
	}

	if(name.Length < 3){
	
		labelField = "Informe no mínimo três caracteres para nome";
		attempts++		
		continue;
	}

	break;
}

```