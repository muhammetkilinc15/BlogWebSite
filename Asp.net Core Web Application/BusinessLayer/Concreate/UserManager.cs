﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public List<AppUser> GetList()
		{
			return _userDal.GetListAll();
		}

		public void TAdd(AppUser entity)
		{
			_userDal.Add(entity);
		}

		public void TDelete(AppUser entity)
		{
		_userDal.Delete(entity);
		}

		public AppUser TGetById(int id)
		{
			return _userDal.GetByID(id);
		}

		public void TUpdate(AppUser entity)
		{
			_userDal.Update(entity);
		}
	}
}
