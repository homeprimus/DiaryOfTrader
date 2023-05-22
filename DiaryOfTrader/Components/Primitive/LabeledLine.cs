using System.ComponentModel;

namespace DiaryOfTrader.Components.Primitive
{
  [ToolboxItem(true)]

  public class LabeledLine : System.Windows.Forms.Label
  {
    private int space = 5;

    public LabeledLine()
    {
      Font = CacheFont.Font;
      Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      AutoSize = false;
    }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(5)]
    public int Space
    {
      get { return space; }
      set
      {
        space = value;
        Invalidate();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      PaintLine(e.Graphics);
      base.OnPaint(e);
    }

    protected void PaintLine(Graphics g)
    {
      var textSize = g.MeasureString(Text, Font);
      var x0 = 0;
      var x1 = Width;
      switch (GetHorizontalAlignment())
      {
        case HorizontalAlignment.Left:
          x0 = (int) textSize.Width + space;
          break;
        case HorizontalAlignment.Right:
          x1 = Width - (int) textSize.Width - space;
          break;
        case HorizontalAlignment.Center:
          x1 = (Width - (int) textSize.Width)/2 - space;
          break;
      }
      var y = (int) textSize.Height/2;
      switch (TextAlign)
      {
        case ContentAlignment.MiddleRight:
        case ContentAlignment.MiddleCenter:
        case ContentAlignment.MiddleLeft:
          y = Height/2;
          break;
        case ContentAlignment.BottomRight:
        case ContentAlignment.BottomCenter:
        case ContentAlignment.BottomLeft:
          y = Height - (int) (textSize.Height/2) - 2;
          break;
      }

      Draw3DLine(g, x0, y, x1, y);
      if (TextAlign == ContentAlignment.TopCenter
          || TextAlign == ContentAlignment.MiddleCenter
          || TextAlign == ContentAlignment.BottomCenter)
      {
        x0 = (Width + (int) textSize.Width)/2 + space;
        x1 = Width;
        Draw3DLine(g, x0, y, x1, y);
      }
    }

    protected HorizontalAlignment GetHorizontalAlignment()
    {
      switch (TextAlign)
      {
        case ContentAlignment.BottomLeft:
        case ContentAlignment.MiddleLeft:
        case ContentAlignment.TopLeft:
          return (RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                   ? HorizontalAlignment.Right
                   : HorizontalAlignment.Left;
        case ContentAlignment.BottomRight:
        case ContentAlignment.MiddleRight:
        case ContentAlignment.TopRight:
          return (RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                   ? HorizontalAlignment.Left
                   : HorizontalAlignment.Right;
        default:
          return HorizontalAlignment.Center;
      }
    }

    protected void Draw3DLine(Graphics g, int x1, int y1, int x2, int y2)
    {
      g.DrawLine(SystemPens.ControlDark, x1, y1, x2, y2);
      g.DrawLine(SystemPens.ControlLightLight, x1, y1 + 1, x2, y2 + 1);
    }
  }
}
