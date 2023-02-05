using StudentPlusDemoProject.Contexts;

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
            try //incapsulate this in object
            {
                using var context = new StudentContext();
                var username = context
                    .Users
                    .Single(user => user.Username.Equals(guna2TextBox1.Text)
                    && user.Password.Equals(int.Parse(guna2TextBox2.Text)));                
            }
            catch(Exception ex)
            {
                guna2MessageDialog1.Show();
            }
            
        }
    }
}