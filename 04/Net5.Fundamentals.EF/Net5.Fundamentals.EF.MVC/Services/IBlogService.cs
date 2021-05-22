using Net5.Fundamentals.EF.MVC.Models;
using System.Collections.Generic;

namespace Net5.Fundamentals.EF.MVC.Services
{
    public interface IBlogService
    {
        void DeletePost(int postId);
        PostViewModel GetPostById(int postId);
        void InsertComment(ComentarioViewModel comentarioViewModel);
        void InsertPost(PostViewModel postViewModel);
        List<PostViewModel> ListPosts();
        bool PostExists(int postId);
        void UpdatePost(PostViewModel postViewModel);
    }
}