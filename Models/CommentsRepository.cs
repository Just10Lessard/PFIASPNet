using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JSON_DAL;

namespace PhotosManager.Models
{
    public class CommentsRepository : Repository<Comment>
    {
        public void DeleteCommentAndBelow(int idComment)
        {

            var commentsChilds = DB.Comments.ToList().Where(c => c.ParentId == idComment).ToList();

            foreach (var child in commentsChilds)
            {
                DeleteCommentAndBelow(child.Id);
            }

            var deleteComment = DB.Comments.Get(idComment);
            if (deleteComment != null)
            {
                DB.Comments.Delete(idComment);
            }
        }
    }
}