using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnswerAnalyzerEx.Messages.Commands
{
    public class ValidateClaim : IDomainCommand
    {
        public Guid AggregateId { get; set; }
        public int Version { get; set; }
    }
}
