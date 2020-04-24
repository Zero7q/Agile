using Agile.Core;
using Agile.Data;
using Agile.Plugin.Blog.Domain;
using Agile.Plugin.Blog.Models;
using Agile.Web.Framework;
using Agile.Web.Framework.Attributes;
using Agile.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using Plugin.Blog.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Plugin.Blog.Controllers
{
    //[MenuAttribute("插件系统|博客首页", "layui-icon layui-icon-home", "/admin/blog/index")]
    public class BlogController : BasePluginController
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<UserInfo> _userRepository;

        private readonly IDataProviderManager _dataProviderManager;

        //public BlogController(IRepository<Article> articleRepository, IRepository<UserInfo> userRepository,
        //    IRepository<Role> roleRepository, IRepository<Category> categoryRepository, IDataProviderManager dataProviderManager)
        //{
        //    _articleRepository = articleRepository;
        //    _userRepository = userRepository;
        //    _roleRepository = roleRepository;
        //    _categoryRepository = categoryRepository;
        //    _dataProviderManager = dataProviderManager;
        //}

        //private readonly IRepository<Category> _repositoryDemo;
        //private readonly IRepository<Article> _repositoryDemo2;
        //public BlogController(IRepository<Category> repositoryDemo, IRepository<Article> repositoryDemo2)
        //{
        //    _repositoryDemo = repositoryDemo;
        //    _repositoryDemo2 = repositoryDemo2;
        //}

        public BlogController(IRepository<Category> categoryRepository, IRepository<Article> articleRepository)
        {
            _categoryRepository = categoryRepository;

            _articleRepository = articleRepository;
        }

        public IActionResult Index(string type)
        {

            Category category = new Category();
            category.Name = "类别啊";

            Article article = new Article();
            article.Title = "标题啊";
            article.Content = "内容啊";

            _categoryRepository.Insert(category);

            article.CategoryId = category.Id;

            _articleRepository.Insert(article);


            string sql = "select * from article t1 join category t2 on t1.categoryid = t2.id";

            var querys = _categoryRepository.ExecuteSql<ArticleViewModel>(sql);

            //article.CategoryId = category.Id;

            //_categoryRepository.BeginTransaction();
            //_categoryRepository.Insert(article);
            //_categoryRepository.Commit();
            //_categoryRepository.Dispose();

            //_categoryRepository.Rollback();
            //_categoryRepository.Dispose();


            //Task.Factory.StartNew(() =>
            //{
            //    for (int i = 0; i < 1; i++)
            //    {
            //        _categoryRepository.BeginTransaction();
            //        _categoryRepository.Insert(category);
            //        _categoryRepository.Commit();
            //        _categoryRepository.Dispose();

            //        //article.CategoryId = category.Id;

            //        //_categoryRepository.BeginTransaction();
            //        //_categoryRepository.Insert(article);
            //        //_categoryRepository.Commit();
            //        //_categoryRepository.Dispose();

            //        //_categoryRepository.Rollback();
            //        //_categoryRepository.Dispose();
            //    }
            //});

            return View("~/Plugins/Blog/Views/Blog/Index.cshtml");
        }
    }
}
