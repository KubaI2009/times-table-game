namespace TimesTableGame;

public partial class GameForm : Form
{
    public GameForm()
    {
        _messUpRange = 5;
        _messUpCount = 5;
        
        FormWidth = 500;
        FormHeight = 600;
        
        TableWidth = 500;
        TableHeight = 500;

        GridWidth = 11;
        GridHeight = 13;

        TableGridWidth = 11;
        TableGridHeight = 11;
        
        InitializeComponent();
        
        //custom controls
        AddCustomControls();
    }
}