using FluentValidation;
using SocialHeroes.Domain.Commands.AccountCommand;
using System;

namespace SocialHeroes.Domain.Validations.AccountValidation
{
    public class DonatorAccountValidation<T> : AccountValidation<T> where T : DonatorAccountCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor informe o nome.");
        }

        protected void ValidateGenre()
        {
            RuleFor(c => c.Genre)
                .NotEmpty().WithMessage("Por favor informe o gênero.");
        }

        protected void ValidateDateBirth()
        {
            RuleFor(c => c.DateBirth)
                .NotEmpty().WithMessage("Por favor informe a data de nascimento.")
                .Must(HaveMinimumAge).WithMessage("O doador deve ter 18 anos ou mais.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento é maior do que a data atual.");
        }

        protected void ValidateLastDonation()
        {
            RuleFor(c => c.LastDonation)              
                .GreaterThan(DateTime.Now).WithMessage("A data da ultima doação é maior do que a data atual.");
        }

        private bool HaveMinimumAge(DateTime birthDate)
            => birthDate <= DateTime.Now.AddYears(-18);
        
        private bool IsValidCPF(string cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cpf.EndsWith(digit);
        }
    }
}
