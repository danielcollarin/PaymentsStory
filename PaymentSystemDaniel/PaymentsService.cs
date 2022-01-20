using Microsoft.EntityFrameworkCore;
using PaymentSystemDaniel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystemDaniel
{
    #region Interface
    public interface IPaymentsService
    {
        Task<List<Payments>> CreatePayments(List<Payments> payments);
        Task<Balance> CreateBalance(Balance balance);
        Task<TableHeaders> CreateTableHeaders(TableHeaders tableHeaders);
        List<Payments> GetPayments();
        List<Balance> GetBalance();
        List<TableHeaders> GetTableHeaders();
    }
    #endregion
    public class PaymentsService : IPaymentsService
    {
        private readonly PaymentContext _context;
        public PaymentsService(PaymentContext context)
        {
            _context = context;
            //_context.Database.EnsureDeleted();
        }

        public async Task<List<Payments>> CreatePayments(List<Payments> payments)
        {
            foreach (var payment in payments)
            {
                _context.Payments.Add(payment);
            }
            await _context.SaveChangesAsync();
            return payments;
        }

        public async Task<Balance> CreateBalance(Balance balance)
        {
            _context.Balance.Add(balance);
            await _context.SaveChangesAsync();
            return balance;
        }

        public async Task<TableHeaders> CreateTableHeaders(TableHeaders tableHeaders)
        {
            _context.TableHeaders.Add(tableHeaders);
            await _context.SaveChangesAsync();
            return tableHeaders;
        }

        public List<Payments> GetPayments()
        {
            return _context.Payments.ToList();
        }

        public List<Balance> GetBalance()
        {
            return _context.Balance.ToList();
        }

        public List<TableHeaders> GetTableHeaders()
        {
            return  _context.TableHeaders.ToList();
        }

    }
}
