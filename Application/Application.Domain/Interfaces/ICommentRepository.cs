using MyApplication.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Interfaces
{
    public interface ICommentRepository : ICreateUpdateDelete<Comment>
    {
        List<Comment> ReadAllComments(int recipe);
    }
}
