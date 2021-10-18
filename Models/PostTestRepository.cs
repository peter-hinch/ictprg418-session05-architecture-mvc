using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Models
{
    public class PostTestRepository : IPostTestRepository
    {
        List<Post> _postList;

        public PostTestRepository()
        {
            _postList = new List<Post>
            {
                new Post{
                    Id = 12,
                    newsContent = "",
                    publishedBy = "",
                    publishedOn = DateTime.Now,
                    title = ""
                },
                new Post{
                    Id = 13,
                    newsContent = "",
                    publishedBy = "",
                    publishedOn = DateTime.Now,
                    title = ""
                },
                new Post{
                    Id = 14,
                    newsContent = "",
                    publishedBy = "",
                    publishedOn = DateTime.Now,
                    title = ""
                }
            };
        }

        public Post Add(Post p)
        {
            _postList.Add(p);
            return p;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postList;
        }

        public int GetCount()
        {
            return _postList.Count();
        }
    }
}
