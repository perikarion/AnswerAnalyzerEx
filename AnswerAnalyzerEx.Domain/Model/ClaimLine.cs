using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnswerAnalyzerEx.Domain.Model
{
    public class ClaimLine
    {
        public readonly decimal GrantedAmount;
        public readonly decimal TotalAmount;
        public readonly RejectionType Status;
        public readonly string IRCCode;
    }
}
