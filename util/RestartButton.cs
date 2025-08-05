namespace TimesTableGame.util;

public class RestartButton : Button
{
    public RestartButton(string name, byte x, byte y, GameForm master) : base()
    {
        Text = "Start";
        (Location, Size) = master.GetDrawingDataForCell(x, y, 4, 2);
        BackColor = Color.Gray;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 3;
        FlatAppearance.BorderColor = master.BackColor;
        Click += OnClick;
    }

    private void OnClick(object? sender, EventArgs? e)
    {
        
    }
}