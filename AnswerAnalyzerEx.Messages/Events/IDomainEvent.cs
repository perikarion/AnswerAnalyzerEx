using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnswerAnalyzerEx.Messages.Events
{
    public interface IDomainEvent
    {
        Guid AggregateId { get; }
        int Version { get; set; }

    }
}
