﻿using LoanWithUs.Common.DefinedType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Domain.UserAggregate
{
    public interface IApplicantRepository
    {
        Task CreateApplicant(Applicant applicant);
        void Update(Applicant applicant);
    }

    public interface IApplicantReadRepository
    {
        Task<bool> CheckUserActivationCode(MobileNumber mobileNumber, string code,string userAgent);
        Task<bool> CheckUserMobileAvailibilityWithAllUserType(int currentUserId, MobileNumber mobileNumber);
        Task<bool> CheckUserNationalCodeAvailibilityWithAllUserType(int currentUserId, string nationalCode);
        Task<Applicant> FindApplicantByMobile(MobileNumber mobileNumber);
        Task<Applicant> FindApplicantById(int id);
        Task<Applicant> FindFullApplicantAggregateById(int id);
        Task<Applicant> FindApplicantByIdIncludeEducationalInformation(int id);
    }

}
