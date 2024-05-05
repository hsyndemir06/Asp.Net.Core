using CoreDemoYenii.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoYenii.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    UserName="murat"
                },
                new UserComment
                {
                    ID= 2,
                    UserName="mesut"
                },
                new UserComment
                {
                    ID=3,
                    UserName="merve"
                }
            };
            return View(commentvalues);
        }
    }
}
