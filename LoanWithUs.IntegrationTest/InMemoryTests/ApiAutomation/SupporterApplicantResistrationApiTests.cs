﻿using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.ViewModel;
using System.Net;

namespace LoanWithUs.IntegrationTest.InMemoryTests.ApiAutomation
{
    public class SupporterApplicantResistrationApiTests : IClassFixture<ToMemoryTesting>
    {
        private readonly ToMemoryTesting _toMemoryTesting;

        public SupporterApplicantResistrationApiTests(ToMemoryTesting toMemoryTesting)
        {
            _toMemoryTesting = toMemoryTesting;
        }

        [Fact]
        public async Task Supporter_Register_Applicatn_with_correct_information()
        {
            //var supporter = await _toMemoryTesting.WithMockSupporter();

            //Exersice
            var result = await _toMemoryTesting.SendAsync(new SupporterRegistereApplicantCommand()
            {
                FirstName="",
                LastName="",
                MobileNo="",
                NationalCode=""
            });

            //Verification
            result.ApplicantId.Should().NotBe(0);

        }

        //[Fact]
        //public async Task Supporter_Register_Applicatn_with_correct_information()
        //{
        //    //Setup         
        //    var vm = new AdminRegisterSupporterVm()
        //    {
        //        MobileNo = "09124566547",
        //        NationalCode = "1234567899"
        //    };

        //    //Exersice
        //    var response = await _toMemoryTesting.CallPostApi<AdminRegisterSupporterVm>(vm, "/RgisterSupporter");

        //    //Verification
        //    response.StatusCode.Should().Be(HttpStatusCode.OK);
        //    var responseText = await response.Content.ReadAsStringAsync();

        //}

    }
}
