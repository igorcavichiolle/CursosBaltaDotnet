using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class LinkPostToTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Digite o id do post");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var pstId = Console.ReadLine();

            var post = GetPostById(int.Parse(pstId));

            if (post != null)
            {
                Console.WriteLine("Digite o id da tag para vincular");
                Console.Write("Id: ");
                var tagId = Console.ReadLine();

                var tag = GetTagById(int.Parse(tagId));

                if (tag != null)
                {
                    Create(new PostTag
                    {
                        PostId = post.Id,
                        TagId = tag.Id
                    });
                }
                else
                {
                    Console.WriteLine("Tag não encontrado na base de dados");
                }
            }
            else
            {
                Console.WriteLine("Post não encontrado na base de dados");
            }


            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Create(PostTag postTag)
        {
            try
            {
                var repository = new Repository<PostTag>(Database.Connection);
                repository.Create(postTag);
                Console.WriteLine("Post vinculado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular o post");
                Console.WriteLine(ex.Message);
            }
        }

        public static Post GetPostById(int id)
        {
            var repository = new Repository<Post>(Database.Connection);
            return repository.Get(id);
        }

        public static Tag GetTagById(int id)
        {
            var repository = new Repository<Tag>(Database.Connection);
            return repository.Get(id);
        }
    }
}