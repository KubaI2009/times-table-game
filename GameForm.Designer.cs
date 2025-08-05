using TimesTableGame.util;

namespace TimesTableGame;

partial class GameForm
{
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
        
        //resizing the client in case something went wrong
        ClientSize = new System.Drawing.Size(FormWidth, FormHeight);
        
        AddLabelsAtTheTop();
        AddLabelsAtTheLeft();
        
        AddButtons();
        
        ResumeLayout();
    }

    private void AddLabelsAtTheTop()
    {
        for (byte i = 1; i < GridWidth; i++)
        {
            Controls.Add(new GameLabel($"lbTop{i}", i, i, 0, this));
        }
    }

    private void AddLabelsAtTheLeft()
    {
        for (byte i = 1; i < GridHeight; i++)
        {
            Controls.Add(new GameLabel($"lbLeft{i}", i, 0, i, this));
        }
    }

    private void AddButtons()
    {
        for (int i = 1; i < (GridWidth - 1) * (GridHeight); i++)
        {
            byte x = Convert.ToByte(i % GridWidth);
            byte y = Convert.ToByte(i / GridWidth + 1);
            
            Controls.Add(new GameButton($"btn{x}Times{y}", x * y, x, y, this));
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