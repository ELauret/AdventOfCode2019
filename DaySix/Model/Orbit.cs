namespace DaySix.Model
{
    public class Orbit
    {
        public string Center { get; set; }
        public string Object { get; set; }
        public int Depth { get; set; }

        public Orbit(string orbit)
        {
            var split = orbit.Split(')');
            Center = split[0];
            Object = split[1];
        }
    }
}
