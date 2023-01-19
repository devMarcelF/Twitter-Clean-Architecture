using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Features.TwitterStatistics.Commands.CreateTwitterStatistic
{
    public class CreateTwitterStatisticCommand :  IRequest<CreateTwitterStatisticCommandResponse>  // IRequest<int> 
    {
        public int NumberOfTweets { get; set; }

        public string? Hashtag { get; set; }

        public override string ToString()
        {
            return $"Twitter Statistic Added";
        }
    }
}
