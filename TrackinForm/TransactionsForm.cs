using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            LoadAndFillTransactionsList();
        }
        private void LoadAndFillTransactionsList() {
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

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            FilterTransactions();
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e) {
            if ((sender as RadioButton).Checked) {
                FilterTransactions();
            }
        }
        private void rdoDescription_CheckedChanged(object sender, EventArgs e) {
            if ((sender as RadioButton).Checked) {
                FilterTransactions();
            }
        }
        private void rdoTags_CheckedChanged(object sender, EventArgs e) {
            if ((sender as RadioButton).Checked) {
                FilterTransactions();
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e) {
            txtLog.Clear();
        }

        private void lstvTransactions_DoubleClick(object sender, EventArgs e) {
            ListViewItem item = lstvTransactions.SelectedItems[0];
            EditTransaction(item);
        }
        private void lstvTransactions_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ListViewItem item = lstvTransactions.SelectedItems[0];
                EditTransaction(item);
            }
        }
        private void EditTransaction(ListViewItem item) {
            var transaction = new Transaction {
                ID = long.Parse(item.SubItems[0].Text),
                Description = item.SubItems[1].Text,
                Amount = decimal.Parse(item.SubItems[2].Text),
                Date = DateTime.Parse(item.SubItems[3].Text),
                Tags = item.SubItems[4].Text.Split(' ')
            };

            var editForm = new TransactionForm(transaction);
            editForm.ShowDialog();
        }

        private void removeTransactionToolStripMenuItem_Click(object sender, EventArgs e) {
            LogInfo("Deleting transaction...");
            ListViewItem item = lstvTransactions.SelectedItems[0];

            var transaction = new Transaction {
                ID = long.Parse(item.SubItems[0].Text),
                Description = item.SubItems[1].Text,
                Amount = decimal.Parse(item.SubItems[2].Text),
                Date = DateTime.Parse(item.SubItems[3].Text),
                Tags = item.SubItems[4].Text.Split(' ')
            };

            string errorMessage = null;

            try {
                bool success = _repo.DeleteTransaction(transaction.ID, out errorMessage);

                string parameters = String.Format("'{0}', {1:N}, {2:yyyy-MM-dd}, '{3}'", transaction.Description, transaction.Amount, transaction.Date, transaction.TagsJoined);
                LogInfo(success
                        ? String.Format("Transaction successfully deleted ({0}).", parameters)
                        : String.Format("Transaction failed ({0}). Error message: {1}", parameters, errorMessage));

                LoadAndFillTransactionsList();
            }
            catch (Exception ex) {
                LogInfo("An unexpected error ocurred. Exception Message: " + ex.Message);
            }
        }
        private void cmsPopupMenu_Opened(object sender, EventArgs e) {
            editTransactionToolStripMenuItem.Enabled = lstvTransactions.SelectedItems.Count > 0;
            removeTransactionToolStripMenuItem.Enabled = lstvTransactions.SelectedItems.Count > 0;
        }

        private void FillTransactionsList(DateTime from, DateTime to) {
            LogInfo(String.Format("Retrieving transactions from web server (from {0:yyyy-MM-dd} to {1:yyyy-MM-dd}) ...", from, to));

            try {
                _transactions = _repo.GetTransactions(from, to);
                _transactions = _transactions.OrderBy(t => t.Date).ThenBy(t => t.ID);

                FillTransactionsList(_transactions);

                LogInfo(String.Format("{0} transactions were retrieved.", _transactions.Count()));

                if (!String.IsNullOrWhiteSpace(txtSearch.Text)) {
                    FilterTransactions();
                }
                else {
                    CalculateTotalAmount(_transactions);
                    FillChartData(_transactions);
                }
            }
            catch (Exception ex) {
                LogInfo("An unexpected error ocurred. Exception Message: " + ex.Message);
            }
        }

        private void FilterTransactions() {
            string term = txtSearch.Text;

            string by = rdoDescription.Checked
                ? " (Description only)"
                : (rdoTags.Checked ? " (Tags only)" : String.Empty);

            LogInfo(String.Format("Searching for term '{0}'{1}...", term, by));

            var transactions = _transactions != null
                ? _transactions.Where(t => t.Description.ToLower().Contains(term.ToLower()) || String.Join(",", t.Tags).ToLower().Contains(term.ToLower()))
                : new List<Transaction>();

            transactions = rdoDescription.Checked
                ? transactions.Where(t => t.Description.ToLower().Contains(term.ToLower()))
                : transactions;

            transactions = rdoTags.Checked
                ? transactions.Where(t => String.Join(",", t.Tags).ToLower().Contains(term.ToLower()))
                : transactions;

            FillTransactionsList(transactions);

            LogInfo(String.Format("{0} results were found for term '{1}'{2}.", transactions.Count(), term, by));

            CalculateTotalAmount(transactions);
            FillChartData(transactions);
        }

        private void FillTransactionsList(IEnumerable<Transaction> transactions) {
            lstvTransactions.Items.Clear();
            foreach (var tran in transactions) {
                var item = lstvTransactions.Items.Add(tran.ID.ToString());
                item.SubItems.Add(String.Format("{0}", tran.Description));
                item.SubItems.Add(String.Format("{0:N}", tran.Amount));
                item.SubItems.Add(String.Format("{0:yyyy-MM-dd}", tran.Date));
                item.SubItems.Add(String.Join(" ", tran.Tags));
            }
        }

        private void CalculateTotalAmount(IEnumerable<Transaction> transactions) {
            decimal total = transactions != null && transactions.Any()
                ? transactions.Sum(t => t.Amount)
                : 0;

            txtTotalAmount.Text = String.Format("{0:N}", total);
            LogInfo(String.Format("Transaction's total amount ({1} transactions): {0:N}", total, transactions.Count()));
        }

        private void FillChartData(IEnumerable<Transaction> transactions) {
            // Data arrays.
            string[] seriesArray = { "Expenses" };
            double[] pointsArray = transactions.Where(t => t.Amount < 0).Select(t => (double)(t.Amount * -1)).ToArray();

            // Set palette.
            //this.chart1.Palette = ChartColorPalette.SeaGreen;

            // Set title.
            chart1.Titles.Clear();
            chart1.Titles.Add(!String.IsNullOrWhiteSpace(txtSearch.Text) ? String.Format("Transactions ({0})", txtSearch.Text) : "Transactions");

            // Add series.
            chart1.Series.Clear();
            Series series = this.chart1.Series.Add(seriesArray[0]);
            series.ChartType = SeriesChartType.SplineArea;
            series.Color = Color.SteelBlue;

            // Add series.
            for (int i = 0; i < pointsArray.Length; i++) {
                // Add point.
                series.Points.Add(pointsArray[i]);
            }
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

        // TODO: The grid/listview itself should be the one of updating the Total Amount value (both in the label/textbox and in 
        // the transactions log) when the grid is reloaded/filtered. This way we avoid having to think to much how 
        // the diferent events that couse the grid/listview to reload are related and when and how should be the one 
        // of updating the Total Amount. If we concentrate this in a grid/list view event then things get easier, and we can
        // be confident that the amount value is correct.

        // TODO: Create a way to cache transaction results based on the date range and search criteria (search term and where we're searching on (description, tags, all)).
        // By doing this, we wouldn't have to call the webservice everytime we're searching for transactions. 
        // Cache results for 30 seconds or so, and maybe include a 'Refresh' button which invalidates the cache (either completely or on a cache item basis) and forces 
        // the application to call the webserver to retrieve transactions.
        IEnumerable<Transaction> _transactions;
        ITransactionRepository _repo;
    }
}
