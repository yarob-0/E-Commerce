namespace ECommerce
{
    public class Passwords
    {
        private Passwords(string value) { Value = value; }

        public string Value { get; private set; }

        public static Passwords User { get { return new Passwords("Uwordpass1!"); } }
        public static Passwords Admin{ get { return new Passwords("Awordpass1!"); } }
        public static Passwords Root{ get { return new Passwords("Rwordpass1!"); } }
	}
}

