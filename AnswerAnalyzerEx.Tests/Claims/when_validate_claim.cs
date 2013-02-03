using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnswerAnalyzerEx.Messages.Commands;
using AnswerAnalyzerEx.Domain.Model;
using AnswerAnalyzerEx.Domain.CommandHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnswerAnalyzerEx.Messages.Events;

namespace AnswerAnalyzerEx.Tests.Claims
{
    [TestClass]
    public class when_validate_claim :
        CommandTestFixture<ValidateClaim, ValidateClaimCommandHandler, Claim>
    {
        protected override ValidateClaim When()
        {
            throw new NotImplementedException();
        }


        [TestMethod]
        public void Then_MemberCreatedEvent_will_be_published()
        {
            Assert.AreEqual(typeof(VAClaimAnayzed), PublishedEvents.Last().GetType());
        }

    }
}
