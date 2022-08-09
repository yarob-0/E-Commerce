namespace ECommerce
{
    public class Roles
    {
        private Roles(string value) { Value = value; }

        public string Value { get; private set; }

        public static Roles User { get { return new Roles("User"); } }
        public static Roles Admin{ get { return new Roles("Admin"); } }
        public static Roles Root{ get { return new Roles("Root"); } }
	}
}

