using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Data.Common;
using conceitos.DTOs;
using conceitos.Infra.Repositories;
using conceitos.Services;
using conceitos.Presentation;
namespace conceitos.Presetation;


class Program
{

    static void Main()
    {
        LanguageRepository repository = new();
        LanguageService service = new();
        ConsolePresetation console = new();
        string nome;
        string nivel = "";
        int id;
        int count = 0;
        console.status = true;
        int erros = 0;
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
            id = 0;
            nome = "";

            switch (option[0])
            {
                case '1':
                    count++;

                    while (console.status)
                    {
                        if (nome.Length == 0)
                        {

                            Console.Write("Nome: ");
                            nome = Console.ReadLine();
                            if (service.ValidationName(nome) == false)
                            {
                                erros++;
                                console.Tentativas(erros);
                                if (console.status == false)
                                    break;
                                Console.WriteLine("Necessario informar o Nome ");
                                continue;
                            }
                        }
                        Console.Write("Nivel: ");
                        nivel = Console.ReadLine();
                        if (service.ValidationNivel(nivel) == false)
                        {
                            erros++;
                            console.Tentativas(erros);
                            if (console.status == false)
                                break;
                            Console.WriteLine("Necessario informar o Nivel");
                            continue;
                        }
                        break;
                    }

                    repository.Criar(new LanguageDto { Id = count, Nome = nome, Nivel = nivel });
                    break;

                case '2':
                    repository.Lista().ForEach(x =>
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine($"{x.Id} - {x.Nome} - {x.Nivel}");


                    });
                    break;
                case '3':
                    while (true)
                    {
                        if (id < 1)
                        {
                            Console.Write("Informe um Id: ");
                            try
                            {
                                id = service.CheckId(Console.ReadLine());
                            }
                            catch (InvalidCastException ex)
                            {
                                Console.WriteLine($"Cast error: {ex.Message}");
                            }
                        }
                        if (nome.Length == 0)
                        {

                            Console.Write("Nome: ");
                            nome = Console.ReadLine();
                            if (service.ValidationName(nome) == false)
                            {
                                Console.WriteLine("Necessario informar o Nome ");
                                continue;
                            }
                        }
                        Console.Write("Nivel: ");
                        nivel = Console.ReadLine();
                        if (service.ValidationNivel(nivel) == false)
                        {
                            Console.WriteLine("Necessario informar o Nivel");
                            continue;
                        }
                        break;
                    }

                    repository.Atualizar(id, new LanguageDto { Id = id, Nome = nome, Nivel = nivel });
                    break;
                case '4':
                    while (true)
                    {
                        Console.Write("Informe um Id: ");
                        try
                        {
                            id = service.CheckId(Console.ReadLine());
                        }
                        catch (InvalidCastException ex)
                        {
                            Console.WriteLine($"Cast error: {ex.Message}");
                        }
                        break;
                    }

                    repository.Deletar(repository.FindbyId(id));
                    break;
                case '5':
                    break;
            }
        }

    }
}
