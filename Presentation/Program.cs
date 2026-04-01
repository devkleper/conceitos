using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Data.Common;
using conceitos.DTOs;
using conceitos.Infra.Repositories;
namespace conceitos.Presetation;


class Program
{
    
    static void Main()
    {
        LanguageRepository repository = new();
        string nome;
        string nivel;
        int id = 0;
        int count = 0;
        while (true)
        {

            Console.WriteLine("==============MENU==========");
            Console.WriteLine("1 - Criar");
            Console.WriteLine("2 - Lista");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Deletar");
            Console.WriteLine("5 - Sair");

            Console.Write("Escolha: ");
            string option = Console.ReadLine();

            switch (option[0])
            {
                case '1':
                    count++;
                    Console.Write("Nome: ");
                    nome = Console.ReadLine();
                    Console.Write("Nivel: ");
                    nivel = Console.ReadLine();
                    repository.Criar(new LanguageDto { Id = count, Nome = nome, Nivel = nivel });
                    break;
                case '2':
                    repository.Lista().ForEach(x =>
                    {
                        Console.WriteLine(x.Id);
                        Console.WriteLine(x.Nome);
                        Console.WriteLine(x.Nivel);
                    });
                    break;
                case '3':
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Nome: ");
                    nome = Console.ReadLine();
                    Console.Write("Nivel: ");
                    nivel = Console.ReadLine();
                    repository.Atualizar(id, new LanguageDto { Id = id, Nome = nome, Nivel = nivel });
                    break;
                case '4':
                    id = int.Parse(Console.ReadLine());
                    repository.Deletar(repository.FindbyId(id));
                    break;
                case '5':
                    break;
            }
        }

    }
}
