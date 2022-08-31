namespace ECommerce
{
    public class Names
    {
        private Names(string value) { Value = value; }

        public string Value { get; private set; }

        public static Names User { get { return new Names("User-name"); } }
        public static Names Admin{ get { return new Names("Admin-name"); } }
	}
}

