namespace TimesTableGame.util;

public class TableButton : Button
{
    private bool _state;
    private byte _messUpRange;

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

    public int Number
    {
        get;
        private set;
    }
    
    public TableButton(string name, int number, byte messUpRange, byte x, byte y, GameForm master) : base()
    {
        
        Name = name;
        Number = number;
        (Location, Size) = master.GetDrawingDataForCell(x, y, 1, 1);
        State = true;
        TextAlign = ContentAlignment.MiddleCenter;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Click += OnClick;
        
        DisplayNumber();
    }

    private void OnClick(object? sender, EventArgs? e)
    {
        Switch();
    }

    public void Switch()
    {
        State = !State;
    }

    public void DisplayNumber()
    {
        Text = Number.ToString();
    }

    //f up the number but only a little bit
    public void MessUp()
    {
        MessUp(false);
    }
    
    public void MessUp(bool display)
    {
        Random random = new Random((int) DateTime.Now.Ticks);
        byte offset = Convert.ToByte(random.Next(1, _messUpRange));
        
        offset = random.Next(1) == 0 ? Convert.ToByte(offset) : Convert.ToByte(-offset);
        
        Number += offset;

        if (display)
        {
            DisplayNumber();
        }
    }
}