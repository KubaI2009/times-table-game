namespace TimesTableGame.util;

public class SubmitButton : Button
{
    private static readonly GameResult[] s_results =
    {
        GameResult.Failure,
        GameResult.Success
    };
    
    private GameForm _master;
    
    public SubmitButton(string name, byte x, byte y, GameForm master) : base()
    {
        Name = name;
        Text = "Submit";
        _master = master;
        (Location, Size) = _master.GetDrawingDataForCell(x, y, 4, 2);
        BackColor = Color.Gray;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 3;
        FlatAppearance.BorderColor = master.BackColor;
        Click += OnClick;
    }

    private void OnClick(object? sender, EventArgs? e)
    {
        (bool numbersMatching, int[] trueIndexes, int[] falseIndexes) = _master.NumbersMatching();
        
        _master.HideNumbers("");
        _master.MarkBadTrue(trueIndexes);
        _master.MarkBadFalse(falseIndexes);
        _master.AnnounceResult(s_results[Convert.ToInt32(numbersMatching)]);
        
        Hide();
        _master.GameRestartButton.Show();
    }
}