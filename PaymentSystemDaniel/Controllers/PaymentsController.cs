using Microsoft.AspNetCore.Mvc;
using PaymentSystemDaniel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentSystemDaniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsSvc;

        public PaymentsController(IPaymentsService paymentSvc)
        {
            _paymentsSvc = paymentSvc;
        }

        // GET: api/<WebApiController>
        [HttpGet]
        [Route("GetPayments")]
        public async Task<IActionResult> GetPayments()
        {
            List<Payments> list = _paymentsSvc.GetPayments();
            var sorted = list.OrderByDescending(x => x.Date).ToList();
            return Ok(sorted);
        }

        [HttpGet]
        [Route("GetBalance")]
        public async Task<IActionResult> GetBalance()
        {
            List<Balance> list = _paymentsSvc.GetBalance();
            return Ok(list);
        }

        [HttpGet]
        [Route("GetTableHeaders")]
        public async Task<IActionResult> GetTableHeaders()
        {
            List<TableHeaders> list = _paymentsSvc.GetTableHeaders();
            return Ok(list);
        }

        [HttpGet]
        [Route("CreatePayments")]
        public async Task<IActionResult> CreatePayments()
        {
            var payments = new List<Payments>();
            // Adding test data for list of payments
            payments.Add(new Payments()
            {
                Amount = 500,
                Date = DateTime.Parse("29 December 2021").Date,
                Status = "Closed",
                ClosedReason = "Paid"
            });

            payments.Add(new Payments()
            {
                Amount = 100,
                Date = DateTime.Parse("26 January 2022"),
                Status = "Open"
            });

            payments.Add(new Payments()
            {
                Amount = 100,
                Date = DateTime.Parse("1 December 2021"),
                Status = "Closed",
                ClosedReason = "Paid"
            });

            payments.Add(new Payments()
            {
                Amount = 500,
                Date = DateTime.Parse("3 June 2021"),
                Status = "Closed",
                ClosedReason = "Paid"
            });

            payments.Add(new Payments()
            {
                Amount = 100,
                Date = DateTime.Parse("14 February 2022"),
                Status = "Open"
            });

            payments.Add(new Payments()
            {
                Amount = 100,
                Date = DateTime.Parse("3 March 2021"),
                Status = "Closed",
                ClosedReason = "Paid"
            });

            payments.Add(new Payments()
            {
                Amount = 500,
                Date = DateTime.Parse("16 October 2021"),
                Status = "Closed",
                ClosedReason = "Paid"
            });

            payments.Add(new Payments()
            {
                Amount = 100,
                Date = DateTime.Parse("20 April 2022"),
                Status = "Open"
            });

            payments.Add(new Payments()
            {
                Amount = 100,
                Date = DateTime.Parse("1 November 2021"),
                Status = "Closed",
                ClosedReason = "Paid"
            });

            await _paymentsSvc.CreatePayments(payments);
            return Ok();
        }

        [HttpGet]
        [Route("CreateBalance")]
        public async Task<IActionResult> CreateBalance()
        {
            var balance = new Balance
            {
                AccountBalance = 10000
            };

            await _paymentsSvc.CreateBalance(balance);
            return Ok();
        }

        [HttpGet]
        [Route("CreateTableHeaders")]
        public async Task<IActionResult> CreateTableHeaders()
        {
            var tableHeaders = new TableHeaders
            {
                Amount = "Amount",
                Date = "Date",
                Status = "Status",
                ClosedReason = "Reason"
            };

            await _paymentsSvc.CreateTableHeaders(tableHeaders);
            return Ok();
        }

    }
}
