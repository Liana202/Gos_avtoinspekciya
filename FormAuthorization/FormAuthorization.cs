using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos_avtoinspekciya
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private void UserBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gos_avtoinspekciyaDataSet);

        }

        private void FormAuthorization_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "gos_avtoinspekciyaDataSet.User". При необходимости она может быть перемещена или удалена.
            this.userTableAdapter.Fill(this.gos_avtoinspekciyaDataSet.User);

        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void EnterBut_Click(object sender, EventArgs e)
        {
            try
            {

                string loginUser = txtboxlog.Text;
                string passUser = txtboxpas.Text;
                ClassDB db = new ClassDB();

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand commandGos_avtoinspekciya = new SqlCommand("SELECT * FROM [User] WHERE Login = @uL AND Password = @uP AND Role= 'inspector", db.GetConnection());
                commandGos_avtoinspekciya.Parameters.Add("@uL", SqlDbType.VarChar).Value = loginUser;
                commandGos_avtoinspekciya.Parameters.Add("@uP", SqlDbType.VarChar).Value = passUser;
                adapter.SelectCommand = commandGos_avtoinspekciya;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    Form ifrm = new FormInspector();
                    ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                    ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                    ifrm.Show(); // отображаем Form2
                    this.Hide(); // скрываем Form1 (this - текущая форма)
                }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                        txtboxlog.Clear();
                        txtboxpas.Clear();
                        a++;
                        if (a == 3)
                        {
                            a = 0;
                            timer1.Enabled = true;
                            buttEnter.Enabled = false;
                            label2.Visible = true;
                            buttExit.Enabled = false;
                            txtboxlog.Enabled = false;
                            txtboxpas.Enabled = false;
                        }
                    }
                

            }
            finally { }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        int a = 0, b = 15, s = 0, d = 15;

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            if (b > 0)
            {
                b--;
                label1.Text = ("Вы заблокированы. Пожалуйста подождите: " + b);
                if (b == 0)
                {
                    b = d;
                    d += 5;
                    this.timer1.Enabled = false;
                    buttEnter.Enabled = true;
                    label1.Visible = false;
                    buttExit.Enabled = true;
                    label1.Text = "";
                    txtboxlog.Enabled = true;
                    txtboxpas.Enabled = true;
                }
            }
            s++;
        }
    }
}
 
