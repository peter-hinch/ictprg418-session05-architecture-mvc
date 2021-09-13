using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> listPost();
    }
}
