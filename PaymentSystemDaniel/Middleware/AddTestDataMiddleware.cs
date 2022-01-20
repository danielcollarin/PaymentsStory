using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using PaymentSystemDaniel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystemDaniel.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AddTestDataMiddleware
    {
        private readonly RequestDelegate _next;
        private IPaymentsService _paymentsSvc;

        public AddTestDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IPaymentsService paymentSvc)
        {
            _paymentsSvc = paymentSvc;
            var payments = new List<Payments>();

            try
            {
                // Current balance
                var balance = new Balance
                {
                    AccountBalance = 10000
                };

                // Table headers
                var tableHeaders = new TableHeaders
                {
                    Amount = "Amount",
                    Date = "Date",
                    Status = "Status",
                    ClosedReason = "Reason"
                };

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

                //await _paymentsSvc.CreatePayments(payments);
                //await _paymentsSvc.CreateBalance(balance);
                //await _paymentsSvc.CreateTableHeaders(tableHeaders);

                await _next(httpContext);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AddTestDataMiddleware>();
        }
    }
}
