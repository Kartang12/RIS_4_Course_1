using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        TreesService service;

        List<Tree> treeList = new List<Tree>();
        public Form1()
        {
            service = new TreesService();
            InitializeComponent();

            //dataGridView1.AutoGenerateColumns = false;

            //DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            //col1.DataPropertyName = "District";
            //col1.HeaderText = "District";
            //col1.Name = "districtCol";
            //dataGridView1.Columns.Add(col1);

            //DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            //col1.DataPropertyName = "Type";
            //col1.HeaderText = "Type";
            //col1.Name = "typeCol";
            //dataGridView1.Columns.Add(col2);

            //DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            //col1.DataPropertyName = "Amount";
            //col1.HeaderText = "Amount";
            //col1.Name = "amountCol";
            //dataGridView1.Columns.Add(col3);

            BidndData();
            //dataGridView1.DataSource = list;
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            BidndData();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            service.AddTree(new Tree(DistrictField.Text, typeBox.Text, (int)AmountField.Value));
            BidndData();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string district = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string type = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            service.DeletTree(type, district);
            BidndData();
        }
        private void BidndData()
        {
            treeList = service.GetTrees();
            var bindingList = new BindingList<Tree>(treeList);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            string district = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string type = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            service.DeletTree(type, district);

            service.AddTree(new Tree(DistrictField.Text, typeBox.Text, int.Parse(AmountField.Text)));
            BidndData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DistrictField.Text =  dataGridView1.CurrentRow.Cells[0].Value.ToString();
            typeBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            AmountField.Value = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
        }
    }
}
