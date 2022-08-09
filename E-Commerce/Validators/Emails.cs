namespace ECommerce
{
    public class Emails
    {
        private Emails(string value) { Value = value; }

        public string Value { get; private set; }

        public static Emails User { get { return new Emails("user@mail.xyz"); } }
        public static Emails Admin{ get { return new Emails("admin@mail.xyz"); } }
        public static Emails Root{ get { return new Emails("root@mail.xyz"); } }
	}
}

