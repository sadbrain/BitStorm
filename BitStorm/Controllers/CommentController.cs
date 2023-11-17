﻿using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics;

namespace BitStorm.Controllers;

public class CommentController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public CommentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult GetComments(int postId)    
    {
        var comments = _unitOfWork.Comment.GetAllByPostId(postId);
        foreach (var item in comments)
        {
            item.User = _unitOfWork.User.Get(u => u.Id == item.UserId);

        }
        return PartialView("_GetComments",comments);
    }
    public IActionResult Create(int? idPost, int? idUser, string content)
    {
        //check user have login 
        //sai chuyển hướng đến form đăng nhập

        //đúng tạo comment
        if (idPost == null || idUser == null)
        {

            return BadRequest();
        }

        else
        {
            //cập nhật post
            var post = _unitOfWork.Post.Get(p => p.Id == idPost);
            var user = _unitOfWork.User.Get(u => u.Id == idUser);

            post.CommentCount += 1;
            _unitOfWork.Post.Update(post);
            //tạo một commemt
            Comment comment = new Comment
            {
                Content = content,
                PostId = idPost.Value,
                UserId = idUser.Value,
                CreateAt = DateTime.Now,
                Post = post,
                User = user,
                IsAnonymous = false
            };
            if (post.UserId == idUser && post.IsAnonymous)
            {
                comment.IsAnonymous = true;
            }
            _unitOfWork.Comment.Add(comment);
        }
        _unitOfWork.Save();
        return RedirectToAction("Index", "Post");
    }
}
