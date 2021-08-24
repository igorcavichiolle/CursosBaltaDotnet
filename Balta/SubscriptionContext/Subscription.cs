using System;
using Balta.SharedContext;

namespace Balta.SubscriptionContext
{
    public class Subscription : Base
    {
        public Plan Plan { get; set; }

        public DateTime? EndDate { get; set; }

        //Expression body
        public bool IsInactive => EndDate <= DateTime.Now;

    }
}