using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnswerAnalyzerEx.Messages.Commands;
using NServiceBus;
using CommonDomain.Persistence;
using AnswerAnalyzerEx.Domain.Model;

namespace AnswerAnalyzerEx.Domain.CommandHandlers
{
    public class ValidateClaimCommandHandler : IHandleMessages<ValidateClaim>
    {
        private readonly Func<IRepository> _repository;

        public ValidateClaimCommandHandler(Func<IRepository> reposistory)
        {
            if (reposistory == null)
                throw new ArgumentNullException("reposistory");
            _repository = reposistory;
        }


        public void Handle(ValidateClaim command)
        {
            var repo = _repository();
            const int version = 0;
            var claim = repo.GetById<Claim>(command.AggregateId, version);
            claim.RelocateCustomer(command.Street, command.Streetnumber, command.PostalCode, command.City);
            repo.Save(claim, Guid.NewGuid(), null);

        }
    }
}
