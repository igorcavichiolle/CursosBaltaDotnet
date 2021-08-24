using System;
using Balta.SharedContext;

namespace Balta.ContentContext
{
    //Classe content herda de base, logo todos os métodos de base vao existir em content
    public abstract class Content : Base
    {
        public Content(string title, string url)
        {
            Title = title;
            Url = url;
        }

        public string Title { get; set; }
        public string Url { get; set; }
    }
}