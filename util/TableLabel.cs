namespace TimesTableGame.util;

public class TableLabel : Label
{
    private GameForm _master;
    
    public TableLabel(string name, byte number, byte x, byte y, GameForm master) : base()
    {
        Name = name;
        Text = number.ToString();
        _master = master;
        (Location, Size) = _master.GetDrawingDataForCell(x, y, 1, 1);
        BackColor = Color.Gray;
        ForeColor = Color.AliceBlue;
        TextAlign = ContentAlignment.MiddleCenter;
    }
}