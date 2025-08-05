namespace TimesTableGame;

public partial class GameForm : Form
{
    public GameForm()
    {
        FormWidth = 500;
        FormHeight = 500;

        GridWidth = 11;
        GridHeight = 11;
        
        InitializeComponent();
        
        //custom controls
        AddCustomControls();
    }
}