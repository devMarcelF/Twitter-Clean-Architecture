using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.Responses;

namespace Twitter.Application.Features.TwitterStatistics.Commands.CreateTwitterStatistic
{
    public class CreateTwitterStatisticCommandResponse : BaseResponse
    {
        public CreateTwitterStatisticCommandResponse() : base()
        {

        }

        public CreateTwitterStatisticDto TwitterStatistic { get; set; } = default!;
    }

    
}
