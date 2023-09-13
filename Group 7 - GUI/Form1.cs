using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Group_7___GUI
{
    public partial class Form1 : Form
    {
        int index;
        string gender = "", skills = "";
        byte[] img;

        public Form1()
        {
            InitializeComponent();

            dtgView.ColumnCount = 18;
            dtgView.Columns[0].Name = "Student ID";
            dtgView.Columns[1].Name = "First Name";
            dtgView.Columns[2].Name = "Middle Name";
            dtgView.Columns[3].Name = "Last Name";
            dtgView.Columns[4].Name = "Street Name";
            dtgView.Columns[5].Name = "Barangay";
            dtgView.Columns[6].Name = "City";
            dtgView.Columns[7].Name = "Province";
            dtgView.Columns[8].Name = "Postal Code";
            dtgView.Columns[9].Name = "Age";
            dtgView.Columns[10].Name = "Birthday";
            dtgView.Columns[11].Name = "Sex";
            dtgView.Columns[12].Name = "Civil Status";
            dtgView.Columns[13].Name = "Year Level";
            dtgView.Columns[14].Name = "Course";
            dtgView.Columns[15].Name = "Email";
            dtgView.Columns[16].Name = "Contact No.";
            dtgView.Columns[17].Name = "Skills";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RDB();
            ChkBox();
            PictureBox();

            dtgView.Rows.Add(txtID.Text, txtFirst.Text, txtMiddle.Text, txtLast.Text, txtAdd.Text, txtBrgy.Text, 
                            txtCity.Text, txtProvince.Text, txtPostal.Text, numAge.Value, dateBday.Value, gender, 
                            cmbStatus.SelectedItem, cmbYear.SelectedItem, cmbCourse.SelectedItem, txtEmail.Text, 
                            txtNum.Text, skills, img);

            btnReset.PerformClick();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Choose image(*.jpg;*.png;*.gif) | *.jpg; *.png; *.gif";

            if (openfile.ShowDialog() == DialogResult.OK)
                picMe.Image = Image.FromFile(openfile.FileName);

            btnSave.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewImageColumn dgvImage = new DataGridViewImageColumn();
            dgvImage.HeaderText = "Image";
            dgvImage.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dtgView.Columns.Add(dgvImage);

            cmbStatus.SelectedIndex = 0;
            cmbCourse.SelectedIndex = 0;
            cmbYear.SelectedIndex = 0;

            picMe.Image = picMe.InitialImage;

            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
        }

        private void txtID_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtID.Text))
            {
                e.Cancel = true;
                txtID.Focus();
                error.SetError(txtID, "Student ID should not be left blank");
            }else{
                e.Cancel = false;
                error.SetError(txtID, "");
            }
        }

        private void txtFirst_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirst.Text))
            {
                e.Cancel = true;
                txtFirst.Focus();
                error.SetError(txtFirst, "First Name should not be left blank");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtFirst, "");
            }
        }

        private void txtMiddle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMiddle.Text))
            {
                e.Cancel = true;
                txtMiddle.Focus();
                error.SetError(txtMiddle, "Middle Name should not be left blank");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtMiddle, "");
            }
        }

        private void txtLast_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLast.Text))
            {
                e.Cancel = true;
                txtLast.Focus();
                error.SetError(txtLast, "Last Name should not be left blank");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtLast, "");
            }
        }

        private void txtAdd_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdd.Text))
            {
                e.Cancel = true;
                txtAdd.Focus();
                error.SetError(txtAdd, "Street Name should not be left blank");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtAdd, "");
            }
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                e.Cancel = true;
                txtCity.Focus();
                error.SetError(txtCity, "City should not be left blank");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtCity, "");
            }
        }

        private void txtProvince_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProvince.Text))
            {
                e.Cancel = true;
                txtProvince.Focus();
                error.SetError(txtProvince, "Province should not be left blank");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtProvince, "");
            }
        }

        private void txtPostal_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPostal.Text))
            {
                e.Cancel = true;
                txtPostal.Focus();
                error.SetError(txtPostal, "Postal Code should not be left blank");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtPostal, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                error.SetError(txtEmail, "Email Address should not be left blank");    
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtEmail, "");
            }
        }

        private void txtNum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNum.Text))
            {
                e.Cancel = true;
                txtNum.Focus();
                error.SetError(txtNum, "Contact Number should not be left blank");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtNum, "");
            }
        }

        private void cmbStatus_Validating(object sender, CancelEventArgs e)
        {
            if (cmbStatus.SelectedIndex == 0)
            {
                e.Cancel = true;
                cmbStatus.Focus();
                error.SetError(cmbStatus, "Please select a Civil Status");
            }
            else
            {
                e.Cancel = false;
                error.SetError(cmbStatus, "");
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }    
        }

        private void txtFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtMiddle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtLast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtBrgy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtProvince_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '@')
            {
                e.Handled = true;

            }
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;

            }
        }

        private void txtBrgy_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrgy.Text))
            {
                e.Cancel = true;
                txtBrgy.Focus();
                error.SetError(txtBrgy, "Barangay should not be left blank");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtBrgy, "");
            }
        }

        private void cmbYear_Validating(object sender, CancelEventArgs e)
        {
            if (cmbYear.SelectedIndex == 0)
            {
                e.Cancel = true;
                cmbYear.Focus();
                error.SetError(cmbYear, "Please select a Year Level");
            }
            else
            {
                e.Cancel = false;
                error.SetError(cmbYear, "");
            }
        }

        private void cmbCourse_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCourse.SelectedIndex == 0)
            {
                e.Cancel = true;
                cmbCourse.Focus();
                error.SetError(cmbCourse, "Please select a Course");
            }
            else
            {
                e.Cancel = false;
                error.SetError(cmbCourse, "");
            }
        }

        private void numAge_Validating(object sender, CancelEventArgs e)
        {
            if (numAge.Value < 16)
            {
                e.Cancel = true;
                numAge.Focus();
                error.SetError(numAge, "Please enter Age");
            }
            else
            {
                e.Cancel = false;
                error.SetError(numAge, "");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void dateBday_Validating(object sender, CancelEventArgs e)
        {
            if (dateBday.Value ==  DateTime.Parse( "12/31/2007"))
            {
                e.Cancel = true;
                dateBday.Focus();
                error.SetError(dateBday, "Date should not be default");
            }
            else
            {
                e.Cancel = false;
                error.SetError(dateBday, "");
            }
        }

        private void numAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void dateBday_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;

            }
        }

        public void ClearAll()
        {
            txtID.Clear();
            txtFirst.Clear();
            txtMiddle.Clear();
            txtLast.Clear();
            txtAdd.Clear();
            txtBrgy.Clear();
            txtCity.Clear();
            txtProvince.Clear();
            txtPostal.Clear();
            txtEmail.Clear();
            txtNum.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            chkCpp.Checked = false;
            chkCS.Checked = false;
            chkJava.Checked = false;
            chkNet.Checked = false;
            chkPhp.Checked = false;
            chkPython.Checked = false;
            cmbYear.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbCourse.SelectedIndex = 0;
            numAge.Value = 1;
            dateBday.Value = DateTime.Parse("12/31/2007");
            picMe.Image = picMe.InitialImage;

            btnSave.Enabled = false;
        }

        public void RDB()
        {
            if (rbMale.Checked)
                gender = "Male";
            else if (rbFemale.Checked)
                gender = "Female";
        }

        public void ChkBox()
        {
            if (chkCpp.Checked)
                skills += "C++ ";

            if (chkCS.Checked)
                skills += "C# ";

            if (chkPhp.Checked)
                skills += "PHP ";

            if (chkJava.Checked)
                skills += "Java ";

            if (chkNet.Checked)
                skills += "VB.Net ";

            if (chkPython.Checked)
                skills += "Python ";
        }

        private void dtgView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sex;

            if (rbFemale.Checked == true)
            {
                sex = rbFemale.Text;
            }else if(rbMale.Checked == true)
            {
                sex = rbMale.Text;
            }


            index = e.RowIndex;
            DataGridViewRow row = dtgView.Rows[index];
            txtID.Text = row.Cells[0].Value.ToString();
            txtFirst.Text = row.Cells[1].Value.ToString();
            txtMiddle.Text = row.Cells[2].Value.ToString();
            txtLast.Text = row.Cells[3].Value.ToString();
            txtAdd.Text = row.Cells[4].Value.ToString();
            txtBrgy.Text = row.Cells[5].Value.ToString();
            txtCity.Text = row.Cells[6].Value.ToString();
            txtProvince.Text = row.Cells[7].Value.ToString();
            txtPostal.Text = row.Cells[8].Value.ToString();
            numAge.Value = Convert.ToDecimal(row.Cells[9].Value.ToString());
            dateBday.Value = DateTime.Parse(row.Cells[10].Value.ToString());
            sex = row.Cells[11].Value.ToString();
            cmbStatus.SelectedItem = row.Cells[12].Value.ToString();
            cmbYear.SelectedItem = row.Cells[13].Value.ToString();
            cmbCourse.SelectedItem = row.Cells[14].Value.ToString();
            txtEmail.Text = row.Cells[15].Value.ToString();
            txtNum.Text = row.Cells[16].Value.ToString();
            skills = row.Cells[17].Value.ToString();

            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to update this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                ChkBox();
                PictureBox();
                DataGridViewRow rowz = dtgView.Rows[index];
                rowz.Cells[3].Value = txtLast.Text;
                rowz.Cells[4].Value = txtAdd.Text;
                rowz.Cells[5].Value = txtBrgy.Text;
                rowz.Cells[6].Value = txtCity.Text;
                rowz.Cells[7].Value = txtProvince.Text;
                rowz.Cells[8].Value = txtPostal.Text;
                rowz.Cells[9].Value = numAge.Value;
                rowz.Cells[12].Value = cmbStatus.SelectedItem;
                rowz.Cells[13].Value = cmbYear.SelectedItem;
                rowz.Cells[14].Value = cmbCourse.SelectedItem;
                rowz.Cells[15].Value = txtEmail.Text;
                rowz.Cells[16].Value = txtNum.Text;
                rowz.Cells[17].Value = skills;
                rowz.Cells[18].Value = img;

                btnReset.PerformClick();

            }
            else
            {
                MessageBox.Show("Record not updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to delete this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow rowz1 = dtgView.Rows[index];
                dtgView.Rows.RemoveAt(rowz1.Index);

            }
            else
            {
                MessageBox.Show("Record not deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PictureBox()
        {

            MemoryStream ms = new MemoryStream();
            picMe.Image.Save(ms, picMe.Image.RawFormat);
            img = ms.ToArray();
        }
    }
}
