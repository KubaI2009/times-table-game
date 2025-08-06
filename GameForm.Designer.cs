using TimesTableGame.util;

namespace TimesTableGame;

partial class GameForm
{
    private List<int> _metaTable = new List<int>();
    private List<TableButton> _table = new List<TableButton>();

    public RestartButton GameRestartButton
    {
        get;
        private set;
    }

    public SubmitButton GameSubmitButton
    {
        get;
        private set;
    }

    public ResultLabel GameResultLabel
    {
        get;
        private set;
    }
    
    public byte MessUpRange
    {
        get;
        private set;
    }

    public int MessUpCount
    {
        get;
        private set;
    }
    
    public int FormWidth
    {
        get;
        private set;
    }

    public int FormHeight
    {
        get;
        private set;
    }

    public int TableWidth
    {
        get;
        private set;
    }

    public int TableHeight
    {
        get;
        private set;
    }

    public byte GridWidth
    {
        get;
        private set;
    }

    public byte GridHeight
    {
        get;
        private set;
    }

    public byte TableGridWidth
    {
        get;
        private set;
    }

    public byte TableGridHeight
    {
        get;
        private set;
    }

    public List<TableButton> Table
    {
        get => _table;
    }

    public int SingleCellWidth
    {
        get => FormWidth / GridWidth;
    }

    public int SingleCellHeight
    {
        get => FormHeight / GridHeight;
    }
    
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
        SuspendLayout();
        // 
        // GameForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        Text = "Times Table Game";
        ResumeLayout(false);
    }

    #endregion

    /// <summary>
    /// Method used for adding custom controls.
    /// Created in order to not interfere with the generated code.s
    /// </summary>
    private void AddCustomControls()
    {
        SuspendLayout();
        
        //customizing the form
        ClientSize = new System.Drawing.Size(FormWidth, FormHeight);
        BackColor = Color.DarkGray;
        
        AddLabelsAtTheTop();
        AddLabelsAtTheLeft();
        
        AddButtons();
        HideNumbers("");
        
        AddRestartButton();
        AddSubmitButton();
        
        GameRestartButton.Show();
        GameSubmitButton.Hide();
        
        AddResultLabel();
        
        ResumeLayout();
    }

    private void AddLabelsAtTheTop()
    {
        for (byte i = 1; i < TableGridWidth; i++)
        {
            Controls.Add(new TableLabel($"lbTop{i}", i, i, 0, this));
        }
    }

    private void AddLabelsAtTheLeft()
    {
        for (byte i = 1; i < TableGridHeight; i++)
        {
            Controls.Add(new TableLabel($"lbLeft{i}", i, 0, i, this));
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < (TableGridWidth - 1) * (TableGridHeight - 1); i++)
        {
            byte x = Convert.ToByte(i % (TableGridWidth - 1) + 1);
            byte y = Convert.ToByte(i / (TableGridHeight - 1) + 1);
            int number = x * y;

            TableButton button = new TableButton($"btn{x}Times{y}", number, MessUpRange, x, y, this);
            
            _metaTable.Add(number);
            Table.Add(button);
            Controls.Add(button);
        }

        //Console.WriteLine(Table.Count);
    }

    private void AddRestartButton()
    {
        GameRestartButton = new RestartButton("btnRestart", 7, 11, this);
        
        Controls.Add(GameRestartButton);
    }

    private void AddSubmitButton()
    {
        GameSubmitButton = new SubmitButton("btnSubmit", 7, 11, this);
        
        Controls.Add(GameSubmitButton);
    }

    private void AddResultLabel()
    {
        GameResultLabel = new ResultLabel("lbResult", 0, 11, this);
        
        Controls.Add(GameResultLabel);
    }

    public void DefaultNumbers()
    {
        for (int i = 0; i < _metaTable.Count; i++)
        {
            Table[i].SetNumber(_metaTable[i]);
        }
    }

    public void MessUpNumbers()
    {
        DefaultNumbers();
        
        List<int> excluded = new List<int>();

        for (int i = 0; i < MessUpCount; i++)
        {
            Table[RandomIndex(excluded.ToArray())].MessUp(); 
        }

        //Console.WriteLine("------------");
    }

    private int RandomIndex(int[] excluded)
    {
        Random random = new Random((int) DateTime.Now.Ticks / 3);
        int i = random.Next(Table.Count);

        while (excluded.Contains(i))
        {
            i = random.Next(Table.Count);
        }
        
        //PrintDebugDataForIndex(i);

        return i;
    }

    private void PrintDebugDataForIndex(int i)
    {
        int x = i % (TableGridWidth - 1) + 1;
        int y = i / (TableGridHeight - 1) + 1;

        Console.WriteLine($"i={i}, x={x}, y={y}");
    }

    public void RenderNumbers()
    {
        foreach (TableButton button in Table)
        {
            button.DisplayNumber();
        }
    }

    public void HideNumbers(string disguise)
    {
        foreach (TableButton button in Table)
        {
            button.Text = disguise;
        }
    }

    public void ResetStates()
    {
        foreach (TableButton button in Table)
        {
            button.SetState(true);
        }
    }

    public (bool result, int[] trueIndexes, int[] falseIndexes) NumbersMatching()
    {
        List<int> trueIndexes = new List<int>();
        List<int> falseIndexes = new List<int>();
        bool result = true;
        
        for (int i = 0; i < _metaTable.Count; i++)
        {
            if ((Table[i].Number != _metaTable[i] && Table[i].State))
            {
                falseIndexes.Add(i);
                result = false;
                continue;
            }

            if ((Table[i].Number == _metaTable[i] && !Table[i].State))
            {
                trueIndexes.Add(i);
                result = false;
            }
        }
        
        return (result, trueIndexes.ToArray(), falseIndexes.ToArray());
    }

    public void AnnounceResult(GameResult result)
    {
        GameResultLabel.AnnounceResult(result);
    }

    public void MarkBadTrue(int[] indexes)
    {
        foreach (int i in indexes)
        {
            Table[i].BackColor = Color.YellowGreen;
            Table[i].Text = Table[i].Number.ToString();
        }
    }

    public void MarkBadFalse(int[] indexes)
    {
        foreach (int i in indexes)
        {
            Table[i].BackColor = Color.Orange;
            Table[i].Text = Table[i].Number.ToString();
        }
    }
    
    /// <summary>
    /// Method used for getting a controls location within the form and it's size.
    /// </summary>
    /// <param name="column"></param>
    /// <param name="row"></param>
    /// <param name="columnSpan"></param>
    /// <param name="rowSpan"></param>
    /// <returns>Tuple containing the location and size in this order.</returns>
    public (Point, Size) GetDrawingDataForCell(byte column, byte row, byte columnSpan, byte rowSpan)
    {
        Point location = new Point(column * SingleCellWidth, row * SingleCellHeight);
        Size size = new Size(columnSpan * SingleCellWidth, rowSpan * SingleCellHeight);
        
        return (location, size);
    }
}