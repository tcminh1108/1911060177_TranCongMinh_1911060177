﻿using _1911060177_TranCongMinh_1911060177.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using _1911060177_TranCongMinh_1911060177.ViewModels;
using Microsoft.AspNet.Identity;
namespace _1911060177_TranCongMinh_1911060177.Controllers
{
    public class HomeController : Controller
    {
        //commit nộp bài ngày 28/03/2022
        private ApplicationDbContext _dbContext;
        //commit
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var upcommingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now && c.IsCanceled == false).ToList();
            var isFollowCourses = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Include(c => c.Course);
            var isFollowLecturers = _dbContext.Followings
                .Where(a => a.FollowerId == userId)
                .Include(c => c.Followee);
            var viewModel = new CoursesViewModel()
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated,
                IsFollowCourses = isFollowCourses,
                IsFollowLecturers = isFollowLecturers,

            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}