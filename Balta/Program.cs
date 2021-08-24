using System;
using System.Collections.Generic;
using System.Linq;
using Balta.ContentContext;
using Balta.NotificationContext;
using Balta.SubscriptionContext;

// https://github.com/andrebaltiere/flunt
// dotnet add package flunt

namespace Balta
{
    class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();

            articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
            articles.Add(new Article("Artigo sobre C#", "csharp"));
            articles.Add(new Article("Artigo sobre .NET", "dotnet"));

            // foreach (var article in articles)
            // {
            //     Console.WriteLine(article.Id);
            //     Console.WriteLine(article.Title);
            //     Console.WriteLine(article.Url);
            // }

            var courses = new List<Course>();

            var courseOOP = new Course("Fundamentos OOP", "fundamento-oop");
            var courseCsharp = new Course("Fundamentos c#", "csharp");
            var courseAspNet = new Course("Fundamentos ASP.NET", "aspnet");

            courses.Add(courseOOP);
            courses.Add(courseCsharp);
            courses.Add(courseAspNet);

            var carerrs = new List<Carrer>();
            var careerDotnet = new Carrer("Especialista dotnet", "especialista-dotnet");
            var careerItem2 = new CarerrItem(2, "Aprenda OOP", "", null);
            var careerItem = new CarerrItem(1, "Comece por aqui", "", courseCsharp);
            var careerItem3 = new CarerrItem(3, "Aprenda .NET", "", courseAspNet);

            careerDotnet.Items.Add(careerItem);
            careerDotnet.Items.Add(careerItem2);
            careerDotnet.Items.Add(careerItem3);
            carerrs.Add(careerDotnet);

            foreach (var career in carerrs)
            {
                Console.WriteLine(career.Title);

                foreach (var item in career.Items.OrderBy(x => x.Order))
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    Console.WriteLine(item.Course?.Title);
                    Console.WriteLine(item.Course?.Level);

                    foreach (var notification in item.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }
            }

            var payPalSubscription = new PayPalSubscription();
            var student = new Student();

            student.CreateSubscription(payPalSubscription);

        }
    }
}
