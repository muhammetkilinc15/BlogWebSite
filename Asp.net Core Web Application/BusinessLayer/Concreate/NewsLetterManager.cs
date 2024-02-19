using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
	public class NewsLetterManager : INewsLetter
	{
		INewsLetterDal _newsLetter;

		public NewsLetterManager(INewsLetterDal newsLetter)
		{
			_newsLetter = newsLetter;
		}

		public void AddNewsLetter(NewsLetter newsLetter)
		{
			_newsLetter.Add(newsLetter);
		}
	}
}
