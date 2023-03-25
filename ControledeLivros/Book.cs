using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControledeLivros
{
    internal class Book
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Edition { get; set; }
        public string Authors { get; set; }

        public Book(string n, string i, string e, string a)
        {
            this.Name = n;
            this.ISBN = i;
            this.Edition = e;
            this.Authors = a;
        }

        public override string ToString()
        {
            return "Nome: " + Name + ", ISBN: " + ISBN + ", Edição: " + Edition+ ", Autores: " + Authors + "\n";
        }

        public string ToUser()
        {
            return this.Name + "," + this.ISBN + "," + this.Edition + "," + this.Authors + "\n";
        }
    }
}
