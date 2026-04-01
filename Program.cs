using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Data.Common;


public class Linguagem
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Nivel { get; set; }
}



class Program
{
    static List<Linguagem> linguagens = [];
    static void Main()
    {
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
                    Criar(new Linguagem { Id = count, Nome = nome, Nivel = nivel });
                    break;
                case '2':
                    Lista().ForEach(x =>
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
                    Atualizar(id, new Linguagem { Id = id, Nome = nome, Nivel = nivel });
                    break;
                case '4':
                    id = int.Parse(Console.ReadLine());
                    Deletar(FindbyId(id));
                    break;
                case '5':
                    break;
            }
        }

    }
    static void Criar(Linguagem linguagem)
    {
        linguagens.Add(linguagem);
    }
    static List<Linguagem> Lista()
    {
        return linguagens;
    }

    static void Atualizar(int id, Linguagem linguagem)
    {

        Linguagem obj = linguagens.Find(x => x.Id == id);

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

    static bool Deletar(Linguagem linguagem)
    {
        return linguagens.Remove(linguagem);
    }

    static Linguagem FindbyId(int id)
    {
        return linguagens.Find(x => x.Id == id);
    }

}
