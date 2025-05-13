using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class FindingProductPanel : Panel
{
    public int CornerRadius { get; set; } = 5;
    private Color originalBackColor;

    private Label lblName;
    private Label lblPrice;

    public string ProductName
    {
        get => lblName.Text;
        set => lblName.Text = value;
    }

    public string ProductPrice
    {
        get => lblPrice.Text;
        set => lblPrice.Text = value;
    }

    public Action OnPanelClick { get; set; }

    public FindingProductPanel()
    {
        // Thiết lập mặc định
        Width = 565;
        Height = 50;
        BackColor = Color.LightGray;
        originalBackColor = BackColor;
        DoubleBuffered = true;
        Margin = new Padding(5);

        // Gắn sự kiện hover cho panel
        MouseEnter += (s, e) =>
        {
            BackColor = Color.Gray;
            Invalidate();
        };

        MouseLeave += (s, e) =>
        {
            BackColor = originalBackColor;
            Invalidate();
        };

        // Tạo label Name
        lblName = new Label()
        {
            Width = 377,
            Height = 55,
            Location = new Point(0, 0),
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            //BackColor = Color.Pink,
            Padding = new Padding(5, 0, 0, 0)
        };

        // Tạo label Price
        lblPrice = new Label()
        {
            Width = 188,
            Height = 55,
            Location = new Point(Width - 188, 0), // Căn phải
            TextAlign = ContentAlignment.MiddleRight,
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            //BackColor = Color.Cyan,
            Padding = new Padding(0, 0, 5, 0)
        };

        Controls.Add(lblName);
        Controls.Add(lblPrice);

        // Gắn sự kiện hover cho từng control con (ở đây là label)
        AddHoverHandlers(lblName);
        AddHoverHandlers(lblPrice);

        //Gắn sự kiện MouseClick cho Panel (không nên thêm cho control con vì dễ gặp trường hợp gọi x2)
        MouseClick += HandleMouseClick;

    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using (GraphicsPath path = GetRoundRectangle(ClientRectangle, CornerRadius))
        {
            Region = new Region(path);
            using (Pen pen = new Pen(Color.DarkGray, 1))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        }
    }

    private GraphicsPath GetRoundRectangle(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int diameter = radius * 2;

        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }

    private void OnHoverEnter(object sender, EventArgs e)
    {
        this.BackColor = Color.Gray;
        this.Invalidate();
    }

    private void OnHoverLeave(object sender, EventArgs e)
    {
        // Kiểm tra nếu chuột đã rời toàn bộ Panel (gồm cả các control con)
        if (!this.Bounds.Contains(this.Parent.PointToClient(Cursor.Position)))
        {
            this.BackColor = originalBackColor;
            this.Invalidate();
        }
    }

    private void HandleMouseClick(object sender, MouseEventArgs e)
    {
        OnPanelClick?.Invoke(); // nếu có logic được gán thì gọi
        OnHoverLeave(sender, e); // Tắt màu sau khi bấm
    }
    
    private void AddHoverHandlers(Control ctrl)
    {
        ctrl.MouseEnter += OnHoverEnter;
        ctrl.MouseLeave += OnHoverLeave;
        ctrl.MouseClick += HandleMouseClick;
    }

}