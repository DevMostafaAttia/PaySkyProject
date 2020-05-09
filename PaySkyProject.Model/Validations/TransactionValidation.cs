using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paysky.Model
{
    public class TransactionValidation : AbstractValidator<Transaction>
    {
        public TransactionValidation()
        {
            RuleFor(t => t.ProcessingCode).NotEmpty();
            RuleFor(t => t.CardHolder).MaximumLength(500);
            /*
             * rest 
             * validations
             * rules
             * goes
             * here
             */
        }
    }
}
