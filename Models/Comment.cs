using JSON_DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PhotosManager.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int PhotoId { get; set; }
        public int ParentId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Text { get; set; }

        [JsonIgnore]
        public User Owner
        {
            get
            {
                return DB.Users.Get(OwnerId);
            }
        }

        [JsonIgnore]
        public List<Like> Likes => DB.Likes.ToList().Where(l => l.PhotoId == Id).ToList();

        [JsonIgnore]
        public string UsersLikesList
        {
            get
            {
                string UsersLikesList = "";
                foreach (var like in Likes)
                {
                    UsersLikesList += DB.Users.Get(like.UserId).Name + "\n";
                }
                return UsersLikesList;
            }
        }

        public Comment()
        {
            Id = 0;
            CreationDate = DateTime.Now;

            //if(OwnerId != 0)
            //    Owner = DB.Users.Get(OwnerId);
        }


    }
}

