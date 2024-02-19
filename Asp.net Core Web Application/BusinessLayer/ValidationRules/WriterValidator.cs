using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator : AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş geçilemez"); 
			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi boş geçilemez");
			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");

			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriş yapın");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriş yapın");

			// En az 1 küçük , 1 büyük , 1 sayı , 1 özel karakter
			RuleFor(x => x.WriterPassword).NotNull().Must(isContainLowerCase).WithMessage("Şifre de en az 1 tane küçük harf olmalı ");
			RuleFor(x => x.WriterPassword).NotNull().Must(isContainUpperCase).WithMessage("Şifre de en az 1 tane büyük harf olmalı");
			//RuleFor(x => x.WriterPassword).NotNull().Must(isContainSpecialChracter).WithMessage("Şifre de en az 1 tane özel karakter olmalı");

			RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Lütfen e posta formatında giriniz");

		}
		private bool isContainLowerCase(string input)
		{
			if (input!=null)
			{
				for (var i = 0; i < input.Length; i++)
				{
					if (Char.IsLower(input[i]))
					{
						return true;
					}
				}
			}
			
			return false;
		}

		private bool isContainUpperCase(string input)
		{
			if (input != null)
			{
				for (var i = 0; i < input.Length; i++)
				{
					if (Char.IsUpper(input[i]))
					{
						return true;
					}
				}
			}
			
			return false;
		}

		private bool isContainSpecialChracter(string input)
		{
			if (input!=null)
			{
				for (var i = 0; i < input.Length; i++)
				{
					if (Char.IsSymbol(input[i]))
					{
						return true;
					}
				}
			}
			
			return false;
		}
	}
}
