using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Models
{
    public class PostRepository : IPostRepository
    {
        private List<Post> _postList;
        private readonly TableDataContext _db;

        public PostRepository(TableDataContext db)
        {
            _db = db;
        }

        // All methods defined in the interface must be implemented
        public IEnumerable<Post> listPost()
        {
            _postList = _db.post.ToList<Post>();
            
            return _postList;
        }
    }
}
