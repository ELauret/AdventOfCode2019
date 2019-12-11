namespace DayTen.Model
{
    public interface ILocation
    {
        int X { get; set; }
        int Y { get; set; }

        string ToString();
        bool Equals(object obj);
        bool BelongsTo(Map map);
    }
}
