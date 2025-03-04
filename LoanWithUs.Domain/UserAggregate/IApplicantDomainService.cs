﻿using LoanWithUs.Common.DefinedType;

namespace LoanWithUs.Domain.UserAggregate
{
    public interface IApplicantDomainService
    {
        Task<bool> IsMobileReservedWithAllUserType(int currentUser, MobileNumber mobileNumber);
        Task<bool> IsNationalReservedWithAllUserType(int currentUser, string nationalCode);
    }

}