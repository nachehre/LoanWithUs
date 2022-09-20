﻿using LoanWithUs.Domain.UserAggregate;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Domain.Test.Utility
{
    internal class ApplicantBuilder
    {
        private string mobile = "09124804347";
        private IApplicantDomainService applicantDomainService;

        public ApplicantBuilder()
        {
            var _applicantDomainService = Substitute.For<IApplicantDomainService>();
            _applicantDomainService.IsMobileReservedWithOtherUserType(default).ReturnsForAnyArgs(false);
            applicantDomainService = _applicantDomainService;
        }

        public ApplicantBuilder WithmobileNumber(string mobile)
        {
            this.mobile = mobile;
            return this;
        }

        public ApplicantBuilder WithApplicantDomainService(IApplicantDomainService domainService)
        {
            this.applicantDomainService = domainService;
            return this;
        }

        public Applicant Build()
        {
            return new Applicant(mobile, applicantDomainService);
        }
    }
}
