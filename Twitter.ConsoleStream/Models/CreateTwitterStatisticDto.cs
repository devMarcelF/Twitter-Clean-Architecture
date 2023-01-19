using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.ConsoleStream.Models
{
    public class CreateTwitterStatisticDto
    {
        public int NumberOfTweets { get; set; }
        public string HashTag { get; set; }
    }
}
