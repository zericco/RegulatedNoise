﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elite.Insight.Core.DomainModel;
using RegulatedNoise.Enums_and_Utility_Classes;

namespace RegulatedNoise
{
    public partial class EditPriceData : RNBaseForm
    {
        public MarketDataRow RowToEdit;

        public EditPriceData(MarketDataRow marketDataRow, IEnumerable<string> commodities)
        {
            InitializeComponent();

            RowToEdit = marketDataRow;

            tbEditSystem.Text        = RowToEdit.SystemName;
            tbEditStation.Text       = RowToEdit.StationFullName;
            cbEditCommodityName.Text = RowToEdit.CommodityName;
            nEditSell.Value          = RowToEdit.SellPrice;
            nEditBuy.Value           = RowToEdit.BuyPrice;
            nEditDemand.Value        = RowToEdit.Demand;
            nEditSupply.Value        = RowToEdit.Supply;
            tbEditDemandLevel.Text   = RowToEdit.DemandLevel.Display();
            tbEditSupplyLevel.Text   = RowToEdit.SupplyLevel.Display();
            dtpEditSampleDate.Value  = RowToEdit.SampleDate;
            tbEditFilename.Text      = RowToEdit.Source;

            foreach (var x in commodities.OrderBy(y => y))
                cbEditCommodityName.Items.Add(x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            var returnValue = new MarketDataRow
            {
                SystemName = tbEditSystem.Text,
                CommodityName = cbEditCommodityName.Text,
                SellPrice = (int)nEditSell.Value,
                BuyPrice = (int)nEditBuy.Value,
                Demand = (int)nEditDemand.Value,
                Supply = (int)nEditSupply.Value,
                DemandLevel = tbEditDemandLevel.Text.ToProposalLevel(),
                SupplyLevel = tbEditSupplyLevel.Text.ToProposalLevel(),
                SampleDate = dtpEditSampleDate.Value,
                Source = tbEditFilename.Text
            };

            RowToEdit = returnValue;

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
