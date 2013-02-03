using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;

namespace AnswerAnalyzerEx.Domain.Model
{
    public class Claim : AggregateBase
    {
        public readonly List<ClaimLine> Lines;
    }
}
