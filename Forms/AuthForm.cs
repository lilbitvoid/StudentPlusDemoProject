using StudentPlusDemoProject.Context;

namespace StudentPlusDemoProject
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2ButtonAuth_Click(object sender, EventArgs e)
        {
            try 
            {
                using var context = new StudentContext();
                var username = context
                    .Users
                    .Single(user => user.Username.Equals(guna2TextBox1.Text)
                    && user.Password.Equals(int.Parse(guna2TextBox2.Text)));
                guna2ButtonAuth.Text = "DASDASD";
            }
            catch(Exception ex)
            {
                //show here gunamessbox
            }
            
        }
    }
}