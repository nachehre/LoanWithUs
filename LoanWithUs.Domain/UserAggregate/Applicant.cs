﻿using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Exceptions;

namespace LoanWithUs.Domain.UserAggregate
{
    /// <summary>
    /// درخواستگر
    /// </summary>
    public class Applicant : User
    {
        protected Applicant() { }

        //ToDo:Remove Imediatelyyy
        public Applicant(MobileNumber mobileNumber, string nationalCode)
        {
            var isAvailable = false;// domainService.IsMobileReservedWithOtherUserType(mobileNumber).Result;
            if (isAvailable)
            {
                throw new InvalidDomainInputException("امکان ثبت نام شماره تلفن به عنوان درخواستگر فراهم نمی باشد.لطفن با مدیر سامانه تماس بگیرید.");
            }
            this.IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
            //this.UserLogins = this.UserLogins ?? new List<UserLogin>();
            //this.UserLogins.Add(new UserLogin(DateTime.Now.AddMinutes(2)));
            this.RegisterationDate = DateTime.Now;
        }

        /// <summary>
        ///It should be Internal beacuse of client can not create new instance of Applicant
        ///And Only Supporter can register new Applicant
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <param name="domainService"></param>
        /// <exception cref="InvalidDomainInputException"></exception>
        internal Applicant(MobileNumber mobileNumber, string nationalCode, string firstName, string lastName, IApplicantDomainService domainService)
        {
            var isMobileAvailable = domainService.IsMobileReservedWithAllUserType(this.Id, mobileNumber).Result;
            if (isMobileAvailable)
            {
                throw new InvalidDomainInputException("امکان ثبت نام شماره تلفن به عنوان درخواستگر فراهم نمی باشد.لطفن با مدیر سامانه تماس بگیرید.");
            }
            var isNationalCodeAvailable = domainService.IsNationalReservedWithAllUserType(this.Id, nationalCode).Result;
            if (isNationalCodeAvailable)
            {
                throw new InvalidDomainInputException("to do.");
            }
            this.IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
            this.PersonalInformation = new PersonalInformation(firstName, lastName);
            this.RegisterationDate = DateTime.Now;
        }



        public void UpdateEducationalInformation(EducationLevel educationallevel, string educationalSubject)
        {
            if (this.EducationalInformation == null)
            {
                this.EducationalInformation = new EducationalInformation(educationallevel, educationalSubject);
            }
            else
            {
                this.EducationalInformation.UpdateInformation(educationallevel, educationalSubject);
            }
        }

        public void UpdateBankInformation(string shabaNumber, string cardNumber, BankType bankType)
        {
            var bankIformation = new BankAccountInformation(shabaNumber, cardNumber, bankType);
            if (this.BankAccountInformations == null)
            {
                BankAccountInformations = new List<BankAccountInformation>();
            }
            this.BankAccountInformations.Add(bankIformation);

        }
    }

}