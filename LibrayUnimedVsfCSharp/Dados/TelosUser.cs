namespace Dados
{
    public class TelosUser
    {
        private string _code;
        private string _name;
        private string _uPwd;
        private string _email;
        private bool _locked;

        public TelosUser()
        {
        }

        public virtual string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string UPwd
        {
            get { return _uPwd; }
            set { _uPwd = value; }
        }

        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public virtual bool Locked
        {
            get { return _locked; }
            set { _locked = value; }
        }
    }
}