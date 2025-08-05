namespace TimesTableGame.util;

public class ResultLabel : Label
{
    public ResultLabel(string name, byte x, byte y, GameForm master) : base()
    {
        Name = name;
        Text = "";
        (Location, Size) = master.GetDrawingDataForCell(x, y, 6, 2);
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

    public void Clear()
    {
        Text = "";
    }
}