using System;
using System.Web.Mvc;
using SmartExamples.Models;

namespace SmartExamples.Controllers
{
    public class RateController : Controller
    {
        public readonly IRate Rater = null;

        public RateController(IRate tmpRater)
        {
            Rater = tmpRater;
        }
        // GET: Rate
        public string Index()
        {
            var currentRate = Rater.GetInterestRate();
            var result = String.Format("Current bank interest rate is {0}", currentRate);
            return result;
        }
    }
}