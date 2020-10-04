using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using SchoolServiceInterfaces;

namespace SchoolServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;

            using (ChannelFactory<IStudentEnrollmentService> schoolServiceProxy =
            new ChannelFactory<IStudentEnrollmentService>("MyStudentEnrollmentServiceEndpoint"))
            {
                schoolServiceProxy.Open();
                IStudentEnrollmentService schoolEnrollmentService = schoolServiceProxy.CreateChannel();
                Student s = new Student();
                s.StudentName = textBox1.Text;
                schoolEnrollmentService.EnrollStudent(s);
                schoolServiceProxy.Close();
            }

            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            using (ChannelFactory<IStudentEnrollmentService> schoolServiceProxy =
            new ChannelFactory<IStudentEnrollmentService>("MyStudentEnrollmentServiceEndpoint"))
            {
                schoolServiceProxy.Open();
                IStudentEnrollmentService schoolEnrollmentService = schoolServiceProxy.CreateChannel();
                Student[] enrolledStudents = schoolEnrollmentService.GetEnrolledStudents();
                foreach (Student s in enrolledStudents)
                {
                    richTextBox1.AppendText(s.StudentName + "\n");
                }
                schoolServiceProxy.Close();
            }
        }
    }
}
