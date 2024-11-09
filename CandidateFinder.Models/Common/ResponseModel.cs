using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateFinder.Models
{
    public class ResponseModel<TResult>
    {
        public ErrorModel? Error { get; set; }
        public TResult? Result { get; set; }
    }
}
