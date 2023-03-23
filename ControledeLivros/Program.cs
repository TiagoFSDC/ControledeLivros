using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using ControledeLivros;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"C:\\Users\\" + System.Environment.UserName + "\\";

        List<Book> bookslist = new List<Book>();
        List<Book> borrowbooks = new List<Book>();
        List<Book> readbooks = new List<Book>();

        if (File.Exists(@"C:\\Users\\" + System.Environment.UserName + "\\posselivros.txt") == false)
        {
            using (var file = new StreamWriter(path + "posselivros.txt"))
            {
                var text = new StringBuilder();
                file.Write(text);
            }
        }
        if (File.Exists(@"C:\\Users\\" + System.Environment.UserName + "\\livrosemprestados.txt") == false)
        {
            using (var file2 = new StreamWriter(path + "livrosemprestados.txt"))
            {
                var text = new StringBuilder();
                file2.Write(text);
            }
        }

        if (File.Exists(@"C:\\Users\\" + System.Environment.UserName + "\\lendolivros.txt") == false)
        {
            using (var file3 = new StreamWriter(path + "lendolivros.txt"))
            {
                var text = new StringBuilder();
                file3.Write(text);
            }
        }

        int op;
        do
        {
            op = Menu();
            switch (op)
            {
                case 1:
                    CreateBook();
                    break;
                case 2:
                    bookslist.Remove(RemoveBooks(bookslist));
                    var temp = ReadFile(path + "posselivros.txt");
                    StreamWriter sw = new(path + "posselivros.txt");
                    foreach (var item in bookslist)
                    {
                        sw.WriteLine(item);
                    }
                    sw.Close();
                    break;
                case 3:
                    BorrowBook(bookslist);
                    break;
                case 4:
                    ReadBooks(bookslist);
                    break;
                case 5:
                    //PrintBooks();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        } while (op != 6);


        int Menu()
        {
            Console.WriteLine("MENU DE OPÇÕES\n1- Adicionar livro\n2- Remover livro\n" +
                "3- Livro que será emprestado\n4- Livro sendo lido\n" +
                "5- Imprimir livros\n" +
                "6- Sair");
            Console.Write("Escolha uma opção: ");
            var xpto = int.Parse(Console.ReadLine());
            return xpto;
        }

        Book CreateBook()
        {
            Console.Write("Digite o nome do livro: ");
            string n = Console.ReadLine();
            Console.Write("Digite o ISBN do livro: ");
            string i = Console.ReadLine();
            Console.Write("Digite a edição do livro: ");
            string e = Console.ReadLine();
            Console.Write("Digite o(s) autor(es) do livro: ");
            string a = Console.ReadLine();

            Book book = new(n, i, e, a);
            bookslist.Add(book);

            using var file = File.AppendText(@"C:\\Users\\" + System.Environment.UserName + "\\posselivros.txt");
            file.Write(book);
            file.Close();

            return book;
        }

        Book RemoveBooks(List<Book> book)
        {
            Console.WriteLine("Digite o nome do livro que será excluído: ");
            string name = Console.ReadLine();

            foreach (var item in book)
            {
                if (item.Name.Equals(name))
                {
                    return item;
                }
            }
            return null;
        }

        void BorrowBook(List<Book> book)
        {
            Console.WriteLine("Digite o nome do livro que será emprestado: ");
            string name = Console.ReadLine();
            foreach (var item in book)
            {
                if (item.Name.Equals(name))
                {
                    using var file2 = File.AppendText(@"C:\\Users\\" + System.Environment.UserName + "\\livrosemprestados.txt");
                    file2.Write(item);
                    file2.Close();
                    borrowbooks.Add(item);
                }
            }
        }

        Book ReadBooks(List<Book> books)
        {
            Console.WriteLine("Digite o nome do livro você está lendo: ");
            string name = Console.ReadLine();
            foreach (var item in books)
            {
                if (item.Name.Equals(name))
                {
                    using var file3 = File.AppendText(@"C:\\Users\\" + System.Environment.UserName + "\\lendolivros.txt");
                    file3.Write(item);
                    file3.Close();
                    readbooks.Add(item);
                    return item;
                }
            }
            return null;
        }

        string ReadFile(string f)
        {
            StreamReader sr = new StreamReader(f);

            string text = " ";
            try
            {
                text = sr.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sr.Close();
            }
            return text;
        }
    }
}