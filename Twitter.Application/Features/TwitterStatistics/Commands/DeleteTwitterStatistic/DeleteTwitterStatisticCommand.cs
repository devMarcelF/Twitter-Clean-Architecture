using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Features.TwitterStatistics.Commands.DeleteTwitterStatistic
{
    public class DeleteTwitterStatisticCommand: IRequest
    {
        public int Id { get; set; }
    }
}
