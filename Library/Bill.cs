using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Drawing.Printing;
using Microsoft.Win32;
namespace Library
{

    public partial class Bill : Form
    {
        private Button printButton = new Button();
        private PrintDocument printDocuments1 = new PrintDocument();

        /*private Rectangle buttonOriginalRectangle;
        private Rectangle originalFormSize;*/
        public Bill()
        {
            InitializeComponent();
            printButton.Click += new EventHandler(Bill_Load);
            printDocuments1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        public Bill(string message, string message2, string message3, string message4, string message5) : this()
        {
            lblBorrowID.Text = message;
            lblBookName.Text = message2;
            lblBorrowDate.Text = message3;
            lblReturnDate.Text = message4;
            lblStaffID.Text = message5;
        }
        private void Bill_Load(object sender, EventArgs e)
        {
        }

        Bitmap memoryImages;

        private void CaptureScreens()
        {

            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            int a = s.Width - 20;
            int b = s.Height - 50;
            memoryImages = new Bitmap(a, b, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImages);
            memoryGraphics.CopyFromScreen(this.Location.X + 10, this.Location.Y + 40, 0, 0, s);

        }
        private void printDocument1_PrintPage(System.Object sender,
                       System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImages, 0, 0);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            btnPrint.Visible = false;
            btnCancel.Visible = false;
            CaptureScreens();
            printDocuments1.Print();
            this.Hide();
            BorrowReturn borrowReturn = new BorrowReturn();
            borrowReturn.Show();
        }

        private void Bill_Resize(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            BorrowReturn borrowReturn = new BorrowReturn();
            borrowReturn.Show();
        }
    }
}
