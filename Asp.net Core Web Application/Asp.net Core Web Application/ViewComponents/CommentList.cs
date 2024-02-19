using Asp.net_Core_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.ViewComponents
{
	public class CommentList: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var comment = new List<UserComment>
			{
				new UserComment
				{
					ID = 1,
					UserName="Muhammet"
				},  new UserComment
				{
					ID = 2,
					UserName="Hasan"
				},  new UserComment
				{
					ID = 3,
					UserName="Kaan"
				},
			};
			return View(comment);
		}
	}
}
