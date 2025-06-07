using System;
using System.Drawing;
using System.Windows.Forms;

public class ShowingOrderDetailPanel : Panel
{
    public int CornerRadius { get; set; } = 5;
    private Color originalBackColor = Color.Transparent;
    private Color hoverBackColor = Color.LightGray;

    private Label lblName;
    private Label lblCount;
    private Label lblPrice;
    private Label lblTotalPrice;

    public string ProductName
    {
        get => lblName.Text;
        set => lblName.Text = value;
    }

    public string ProductCount
    {
        get => lblCount.Text;
        set => lblCount.Text = value;
    }

    public string ProductPrice
    {
        get => lblPrice.Text;
        set => lblPrice.Text = value;
    }

    public string ProductTotalPrice
    {
        get => lblTotalPrice.Text;
        set => lblTotalPrice.Text = value;
    }

    public Action OnPanelClick { get; set; }

    public ShowingOrderDetailPanel()
    {
        // Thiết lập mặc định
        Width = 1275;
        Height = 70;
        BackColor = originalBackColor;
        DoubleBuffered = true;

        // Gắn sự kiện hover cho panel
        MouseEnter += (s, e) =>
        {
            BackColor = hoverBackColor;
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
            Width = 530,
            Height = Height,
            Location = new Point(0, 0),
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            //BackColor = Color.Pink,
        };

        // Tạo label Count
        lblCount = new Label()
        {
            Width = 130,
            Height = Height,
            Location = new Point(lblName.Width, 0),
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            //BackColor = Color.LightBlue,
        };

        // Tạo label Price
        lblPrice = new Label()
        {
            Width = 295,
            Height = Height,
            Location = new Point(lblCount.Location.X + lblCount.Width, 0),
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            //BackColor = Color.LightCyan,
        };

        // Tạo label Total Price
        lblTotalPrice = new Label()
        {
            Width = 320,
            Height = Height,
            Location = new Point(lblPrice.Location.X + lblPrice.Width, 0),
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            //BackColor = Color.Cyan,
        };

        Controls.Add(lblName);
        Controls.Add(lblCount);
        Controls.Add(lblPrice);
        Controls.Add(lblTotalPrice);

        // Gắn sự kiện hover cho từng control con (ở đây là label)
        AddHoverHandlers(lblName);
        AddHoverHandlers(lblCount);
        AddHoverHandlers(lblPrice);
        AddHoverHandlers(lblTotalPrice);

        //Gắn sự kiện MouseClick cho Panel (không nên thêm cho control con vì dễ gặp trường hợp gọi x2)
        MouseClick += HandleMouseClick;

    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
    }

    private void OnHoverEnter(object sender, EventArgs e)
    {
        this.BackColor = hoverBackColor;
        this.Invalidate();
    }

    private void OnHoverLeave(object sender, EventArgs e)
    {
        // Kiểm tra nếu đối tượng đã bị xóa --> không chạy nữa, tránh lỗi runtime
        if (this.IsDisposed || this.Parent == null || !this.Parent.Controls.Contains(this))
            return;

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