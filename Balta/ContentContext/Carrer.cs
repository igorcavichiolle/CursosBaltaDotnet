using System.Collections.Generic;

namespace Balta.ContentContext
{
    public class Carrer : Content
    {
        public Carrer(string title, string url)
            : base(title, url)
        {
            Items = new List<CarerrItem>();
        }
        public IList<CarerrItem> Items { get; set; }

        //Contando todos todos os cursos que temos na lista Items
        //Utilizando Expression Body TotalCourses => Items.Count
        public int TotalCourses => Items.Count;


        // public int TotalCourses
        // {
        //     get
        //     {
        //         return Items.Count;
        //     }
        // }
    }
}