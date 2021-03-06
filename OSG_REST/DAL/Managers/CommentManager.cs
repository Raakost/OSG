﻿using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.DomainModel;
using DAL.Managers.IManager;

namespace DAL.Managers
{
    public class CommentManager : IManager<Comment>
    {
        public Comment Create(Comment model)
        {
            using (var ctx = new OSGContext())
            {
                ctx.Comment.Attach(model);
                var commentToReturn = ctx.Comment.Add(model);
                ctx.SaveChanges();
                return commentToReturn;
            }
        }

        public bool Delete(Comment model)
        {
            using (var ctx = new OSGContext())
            {
                var commentToDelete = ctx.Comment.FirstOrDefault(comment => comment.Id == model.Id);
                if (commentToDelete != null)
                {
                    ctx.Comment.Remove(commentToDelete);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<Comment> ReadAll()
        {
            using (var ctx = new OSGContext())
            {
                return ctx.Comment.Include("News").ToList();
            }
        }

        public Comment ReadByID(int Id)
        {
            using (var ctx = new OSGContext())
            {
                return ctx.Comment.Include("News").FirstOrDefault(comment => comment.Id == Id);
            }
        }

        //Update a comments name and text. (This is not used, but avaliable for use later)
        public Comment Update(Comment model)
        {
            using (var ctx = new OSGContext())
            {
                var commentToUpdate = ctx.Comment.FirstOrDefault(comment => comment.Id == model.Id);
                if (commentToUpdate != null)
                {
                    commentToUpdate.Name = model.Name;
                    commentToUpdate.CommentText = model.CommentText;
                    //There is no need to update the news which a comment is linked to, since you can't move 
                    //comments from one news to another..
                    //
                    ctx.SaveChanges();
                    return commentToUpdate;
                }
                return model;
            }
        }
    }
}
