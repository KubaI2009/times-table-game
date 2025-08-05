namespace TimesTableGame.util;

public class ResultLabel : Label
{
    private GameForm _master;
    
    public ResultLabel(string name, byte x, byte y, GameForm master) : base()
    {
        Name = name;
        Text = "";
        _master = master;
        (Location, Size) = _master.GetDrawingDataForCell(x, y, 6, 2);
        AutoSize = false;
        Font = new Font(FontFamily.GenericSansSerif, 21);
        BackColor = Color.DarkGray;
        ForeColor = Color.AliceBlue;
        TextAlign = ContentAlignment.MiddleCenter;
    }

    public void AnnounceResult(GameResult result)
    {
        Text = result.Message;
    }

    public void ShutUp()
    {
        Text = "";
    }
}