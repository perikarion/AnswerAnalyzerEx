using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnswerAnalyzerEx.Messages.Commands
{
    public interface IDomainCommand
    {
        Guid AggregateId { get; set; }
        int Version { get; set; }
    }
}
