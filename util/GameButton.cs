namespace TimesTableGame.util;

public class GameButton : Button
{
    private bool _state;

    public bool State
    {
        get => _state;
        private set
        {
            _state = value;

            if (_state)
            {
                BackColor = Color.ForestGreen;
                ForeColor = Color.AliceBlue;
                return;
            }
            
            BackColor = Color.OrangeRed;
            ForeColor = Color.AntiqueWhite;
        }
    }
    
    public GameButton(string name, int number, byte x, byte y, GameForm master) : base()
    {
        
        Name = name;
        Text = number.ToString();
        (Location, Size) = master.GetDrawingDataForCell(x, y, 1, 1);
        State = true;
        TextAlign = ContentAlignment.MiddleCenter;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Click += (object? sender, EventArgs? e) => Switch();
    }

    public void Switch()
    {
        State = !State;
    }
}