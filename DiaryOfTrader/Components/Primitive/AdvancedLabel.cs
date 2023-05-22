using System.Drawing.Drawing2D;

namespace DiaryOfTrader.Components.Primitive
{
  internal class AdvancedLabel : System.Windows.Forms.Label
  {
    private Color mBcolor2 = SystemColors.Control;

    public Color BackColor2
    {
      get 
      {
        return mBcolor2;
      }
      set 
      {
        mBcolor2 = value;
      }
    }
    public AdvancedLabel()
    {
      TextAlign = ContentAlignment.MiddleLeft;
      BackColor2 = BackColor;
      Font = CacheFont.Font;
    }
	
    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
      var mBrush = new LinearGradientBrush(
        new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width, ClientRectangle.Height),
        BackColor,
        mBcolor2,
        (float)0.0);
      pevent.Graphics.FillRectangle(mBrush, pevent.ClipRectangle.Left, pevent.ClipRectangle.Top, pevent.ClipRectangle.Width, pevent.ClipRectangle.Height);
    }
  }
}
