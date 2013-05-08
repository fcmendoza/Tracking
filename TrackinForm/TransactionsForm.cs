using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrackinForm {
    public partial class TransactionsForm : Form {
        public TransactionsForm(ITransactionRepository repo) {
            _repo = repo;
            InitializeComponent();
        }
        public TransactionsForm() {
            InitializeComponent();
        }

        private void TransactionsForm_Load(object sender, EventArgs e) {
            cboDateRange.Items.Clear();
            cboDateRange.Items.AddRange(new object[] {
            "Last Month",
            "This Month (default)",
            "This Year",
            "Last Two Years",
            "All Transactions"});
        }

        private void TransactionsForm_Shown(object sender, EventArgs e) {
            cboDateRange.SelectedIndex = (int)DateRange.ThisMonth;
        }

        private void cboDateRange_SelectedIndexChanged(object sender, EventArgs e) {
            var option = (DateRange)cboDateRange.SelectedIndex;
            var now = DateTime.Now;
            var lastMonth = DateTime.Now.AddMonths(-1);
            var nextMonth = DateTime.Now.AddMonths(1);

            switch (option) {
                case DateRange.LastMonth:
                    FillTransactionsList(new DateTime(lastMonth.Year, lastMonth.Month, 01), new DateTime(now.Year, now.Month, 01));
                    break;
                case DateRange.ThisMonth:
                    FillTransactionsList(new DateTime(now.Year, now.Month, 01), new DateTime(nextMonth.Year, nextMonth.Month, 01));
                    break;
                case DateRange.ThisYear:
                    FillTransactionsList(new DateTime(now.Year, 01, 01), new DateTime(now.Year, 12, 31));
                    break;
                case DateRange.LastTwoYears:
                    FillTransactionsList(new DateTime(now.AddYears(-1).Year, 01, 01), new DateTime(now.Year, 12, 31));
                    break;
                case DateRange.AllTransactions:
                    FillTransactionsList(new DateTime(2007, 01, 01), new DateTime(now.Year, 12, 31));
                    break;
                default:
                    break;
            }
        }

        private void FillTransactionsList(DateTime from, DateTime to) {
            LogInfo(String.Format("Retrieving transactions from web server (from {0:yyyy-MM-dd} to {1:yyyy-MM-dd}) ...", from, to));

            var transactions = _repo.GetTransactions(from, to);
            transactions = transactions.OrderBy(t => t.Date).ThenBy(t => t.ID);

            lstvTransactions.Items.Clear();

            foreach (var tran in transactions) {
                var item = lstvTransactions.Items.Add(tran.Description);
                item.SubItems.Add(String.Format("{0:N}", tran.Amount));
                item.SubItems.Add(String.Format("{0:yyyy-MM-dd}", tran.Date));
                item.SubItems.Add(String.Join(" ", tran.Tags));
            }

            LogInfo(String.Format("{0} transactions were retrieved.", transactions.Count()));
        }

        private void LogInfo(string message) {
            txtLog.AppendText(txtLog.Text.Length > 0 ? "\r\n\r" : string.Empty);
            txtLog.AppendText(String.Format("{0:yyyy-MM-dd hh:mm:ss}: {1}", DateTime.Now, message));
        }

        private enum DateRange {
            LastMonth = 0,
            ThisMonth = 1,
            ThisYear = 2,
            LastTwoYears = 3,
            AllTransactions = 4,
        }

        ITransactionRepository _repo;
    }
}
