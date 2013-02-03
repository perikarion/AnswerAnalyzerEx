using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnswerAnalyzerEx.Messages.Events
{
    public class IAClaimAnalyzed : IDomainEvent
    {
        public Guid AggregateId { get; private set; }
        public int Version { get; set; }
    }
}
