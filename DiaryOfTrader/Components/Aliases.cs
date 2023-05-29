using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab.Drawing;
using DiaryOfTrader.Core;

namespace DiaryOfTrader.Components
{
  internal static class CacheFont
  {
    private static readonly Font baseFont = new System.Drawing.Font("Tahoma", 8);

    public static Font Font
    {
      get { return baseFont; }
    }
  }

  public class CoreControl : DevExpress.XtraEditors.XtraUserControl
  {
    public static readonly AutoScaleMode ControlAutoScaleMode = AutoScaleMode.Font;

    public CoreControl()
    {
      AutoScaleMode = AutoScaleMode.Inherit;
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }

    [DefaultValue(System.Windows.Forms.AutoScaleMode.Inherit)]
    public new AutoScaleMode AutoScaleMode
    {
      get { return base.AutoScaleMode; }
      set { base.AutoScaleMode = value; }
    }
  }

  public class CoreForm : XtraForm
  {
    public CoreForm()
    {
      AutoScaleMode = CoreControl.ControlAutoScaleMode;
      Font = CacheFont.Font;
      //AutoSize = true;
      //AutoSizeMode = AutoSizeMode.GrowOnly;
    }

    [DefaultValue(System.Windows.Forms.AutoScaleMode.Font)]
    public new AutoScaleMode AutoScaleMode
    {
      get { return base.AutoScaleMode; }
      set { base.AutoScaleMode = value; }
    }

  }

  public class TabPage : DevExpress.XtraTab.XtraTabPage
  {
    private const BindingFlags bf = BindingFlags.Instance | BindingFlags.GetProperty |
                                    BindingFlags.NonPublic;

    public TabPage()
    {
      Font = CacheFont.Font;
      //BackColor = System.Drawing.Color.Transparent;
    }
        /*
    [Browsable(true)]
    public override UserLookAndFeel LookAndFeel
    {
      get { return base.LookAndFeel; }
    }
    */
    private static Rectangle Inflate(Rectangle rect, Padding padding)
    {
      rect.X -= padding.Left;
      rect.Y -= padding.Top;
      rect.Width += padding.Horizontal;
      rect.Height += padding.Vertical;
      return rect;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      var pageViewInfo = PageViewInfo;
      if (pageViewInfo != null)
      {
        using (var cache = new GraphicsCache(e))
        {
          var info = new TabDrawArgs(cache, ViewInfo, Inflate(DisplayRectangle, Padding));
          var pi = TabControl.GetType().GetProperty("Painter", bf);
          var inherited = pi == null;
          if (!inherited)
          {
            var painter = (BaseTabPainter) pi.GetValue(TabControl, null);
            inherited = painter == null;
            if (!inherited)
            {
              painter.DrawPageClientControl(info, pageViewInfo);
            }
          }
          if (inherited)
          {
            base.OnPaint(e);
            return;
          }
        }
      }
      else
      {
        using (Brush brush = new SolidBrush(BackColor))
        {
          e.Graphics.FillRectangle(brush, ClientRectangle);
        }
      }
      //if ((TabControl != null) && !TabControl.Enabled)
      //{
      //  var lookAndFeel = (View is SkinViewInfoRegistrator) ? TabControlLookAndFeel : null;
      //  BackgroundPaintHelper.PaintDisabledControl(lookAndFeel, e, ClientRectangle);
      //}
      RaisePaintEvent(this, e);
      e.Graphics.ExcludeClip(ClientRectangle);
    }
  }

  public class ComboBox : System.Windows.Forms.ComboBox, IBindingCombo
  {
    public ComboBox()
    {
      Font = CacheFont.Font;
      //BackColor = System.Drawing.Color.Transparent;
    }
  }

  public class ComboBoxEdit : DevExpress.XtraEditors.ComboBoxEdit, IBindingCombo
  {
    private const int DefaultDropDownRows = 7;
    public event EventHandler FillDataSource;
    private void Initialize()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }

    public ComboBoxEdit()
    {
      Initialize();
    }

    public ComboBoxEdit(IContainer container)
    {
      container.Add(this);
      Initialize();
    }
    public override void ShowPopup()
    {
      if (FillDataSource != null)
        FillDataSource(this, EventArgs.Empty);
      var data = DataSource;
      if (data != null)
      {
        var nCount = 0;
        if (data is IList)
        {
          nCount = (data as IList).Count;
        }
        else if (data.GetType().IsArray)
        {
          nCount = ((Array)data).Length;
        }
        Properties.DropDownRows = Math.Min(nCount, DefaultDropDownRows);
      }
      //Properties.PopupWidth = Properties.BestFit();
      base.ShowPopup();
    }
    [DefaultValue("")]
    public string DisplayMember
    {
      get { return string.Empty; }
      set {  }
    }

    [DefaultValue("")]
    public string ValueMember
    {
      get { return string.Empty; }
      set {  }
    }

    [DefaultValue("")]
    public object SelectedValue
    {
      get { return Text; }
      set { Text = (value ?? string.Empty).ToString(); }
    }
    [DefaultValue(null)]
    [AttributeProvider(typeof (IListSource)), RefreshProperties(RefreshProperties.Repaint)]
    public object DataSource
    {
      get { return Properties.Items; }
      set
      {
        Properties.BeginUpdate();
        try
        {
          var items = Properties.Items;
          items.Clear();
          if (value != null)
          {
            foreach (var item in (IEnumerable) value)
            {
              if (value is KeyValuePair<string, object>)
              {
                items.Add(((KeyValuePair<string, object>)item).Key);
              }
              else
              {
                items.Add(item);
              }
            }
          }
        }
        finally
        {
          Properties.EndUpdate();
        }
      }
    }
  }

  public class ImageComboBox : DevExpress.XtraEditors.ImageComboBoxEdit, IBindingCombo
  {
    private void Initialize()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
      Properties.Buttons.Clear();
      Properties.Buttons.Add(new EditorButton { Kind = ButtonPredefines.Combo });
    }
    public ImageComboBox()
    {
      Initialize();
    }
    public ImageComboBox(IContainer container)
    {
      container.Add(this);
      Initialize();
    }
    [DefaultValue("")]
    public string DisplayMember
    {
      get { return string.Empty; }
      set { }
    }
    [DefaultValue("")]
    public string ValueMember
    {
      get { return string.Empty; }
      set { }
    }
    [DefaultValue(null)]
    public object SelectedValue
    {
      get { return EditValue; }
      set { EditValue = value; }
    }
    [DefaultValue(null)]
    public object DataSource
    {
      get { return Properties.Items; }
      set
      {
        Properties.BeginUpdate();
        try
        {
          var items = Properties.Items;
          items.Clear();
          if (value != null)
          {
            var images = (ImageList)Properties.SmallImages;
            foreach (var item in (IEnumerable) value)
            {
              var key = item.ToString();
              var val = item is KeyValuePair<string, object> pair ? pair.Value : item;
              var comboItem = new ImageComboBoxItem
              {
                Description = key,
                Value = val, 
                ImageIndex = images == null ? -1 : images.Images.IndexOfKey(key)
              };

              items.Add(comboItem);
            }
          }
        }
        finally
        {
          Properties.EndUpdate();
        }
      }
    }
  }

  public class LookComboBox : DevExpress.XtraEditors.LookUpEdit, IBindingCombo
  {
    private const int DefaultDropDownRows = 7;
    public event EventHandler FillDataSource;

    private void Initialize()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;

      Properties.ShowHeader = false;
      Properties.NullText = "";
      Properties.ShowFooter = false;
      Properties.PopupSizeable = true;
      Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
      Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
      Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
    }

    public LookComboBox(IContainer container)
    {
      container.Add(this);
      Initialize();
    }

    public LookComboBox()
    {
      Initialize();
    }

    public override void ShowPopup()
    {
      if (FillDataSource != null)
        FillDataSource(this, EventArgs.Empty);
      var data = DataSource;
      if (data != null)
      {
        var nCount = 0;
        if (data is IList)
        {
          nCount = (data as IList).Count;
        }
        else if (data.GetType().IsArray)
        {
          nCount = ((Array) data).Length;
        }
        Properties.DropDownRows = Math.Min(nCount, DefaultDropDownRows);
      }
      Properties.PopupWidth = Properties.BestFit();
      base.ShowPopup();
    }

    protected override void OnEditValueChanged()
    {
      base.OnEditValueChanged();
      BindingUtils.SafeWriteValueOnPropertyChanged(this, BindingUtils.SelectedValue);
      BindingUtils.SafeWriteValueOnPropertyChanged(this, BindingUtils.EditValue);
    }

    [TypeConverter(
      "System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
      ), DefaultValue(""),
     Editor(
       "System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
       typeof (UITypeEditor))]
    public string DisplayMember
    {
      get { return Properties.DisplayMember; }
      set
      {
        value = value ?? string.Empty;
        if (string.Compare(Properties.DisplayMember, value, StringComparison.CurrentCultureIgnoreCase) != 0)
        {
          Properties.Columns.Clear();
          Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(value));
          Properties.DisplayMember = value;
        }
      }
    }

    [DefaultValue(""),
     Editor(
       "System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
       typeof (UITypeEditor))]
    public string ValueMember
    {
      get { return Properties.ValueMember; }
      set
      {
        value = value ?? string.Empty;
        if (string.Compare(Properties.ValueMember, value, StringComparison.CurrentCultureIgnoreCase) != 0)
        {
          Properties.ValueMember = value;
        }
      }
    }

    [Browsable(false), DefaultValue((string) null), Bindable(true),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object SelectedValue
    {
      get { return EditValue; }
      set { EditValue = value; }
    }

    [AttributeProvider(typeof (IListSource)), DefaultValue((string) null),
     RefreshProperties(RefreshProperties.Repaint)]
    public object DataSource
    {
      get { return Properties.DataSource; }
      set
      {
        Properties.DataSource = value;
      }
    }
  }

  public class CheckedListBox : DevExpress.XtraEditors.CheckedListBoxControl
  {
    public CheckedListBox()
    {
      Font = CacheFont.Font;
    }
  }


  public class ListBox : DevExpress.XtraEditors.ListBoxControl
  {
    public ListBox()
    {
      Font = CacheFont.Font;
    }
  }


  public class ImageListBox : DevExpress.XtraEditors.ImageListBoxControl
  {
    public ImageListBox()
    {
      Font = CacheFont.Font;
    }
  }

  public class RadioButton : System.Windows.Forms.RadioButton
  {
    public RadioButton()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }
  }

  public class Label : DevExpress.XtraEditors.LabelControl
  {
    public Label()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }
  }

  public class DateEdit : DevExpress.XtraEditors.DateEdit
  {
    private void Initialize()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;

      Properties.ShowClear = false;
      Properties.NullText = "";
      Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
    }

    public DateEdit()
    {
      Initialize();
    }

    public DateEdit(IContainer container)
    {
      container.Add(this);
      Initialize();
    }
  }

  public class TimeEdit : DevExpress.XtraEditors.TimeEdit
  {
    public TimeEdit()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }
  }

  //System.Windows.Forms.GroupBox
  public class GroupBox : DevExpress.XtraEditors.GroupControl
  {
    public GroupBox()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }
  }

  public class Panel : DevExpress.XtraEditors.PanelControl
  {
    public Panel()
    {
      Font = CacheFont.Font;
      BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      BackColor = System.Drawing.Color.Transparent;
    }
  }

  public class TabControl : DevExpress.XtraTab.XtraTabControl
  {
    public TabControl()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }
  }

  //System.Windows.Forms.Button
  public class Button : DevExpress.XtraEditors.SimpleButton
  {
    public Button()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }

    public bool UseVisualStyleBackColor { get; set; }
  }

  //System.Windows.Forms.CheckBox
  public class CheckBox : DevExpress.XtraEditors.CheckEdit
  {
    public CheckBox()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }
  }

  // System.Windows.Forms.TextBox
  public class TextBox : DevExpress.XtraEditors.TextEdit
  {
    public int MaxLength
    {
      get { return Properties.MaxLength; }
      set { Properties.MaxLength = value; }
    }

    public bool ReadOnly
    {
      get { return Properties.ReadOnly; }
      set { Properties.ReadOnly = value; }
    }

    public TextBox()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }
  }

  public class ButtonEdit : DevExpress.XtraEditors.ButtonEdit
  {
    public int MaxLength
    {
      get { return Properties.MaxLength; }
      set { Properties.MaxLength = value; }
    }

    public bool ReadOnly
    {
      get { return Properties.ReadOnly; }
      set { Properties.ReadOnly = value; }
    }


    public ButtonEdit(IContainer container)
    {
      container.Add(this);
    }

    public ButtonEdit()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }
  }

  public class NumEdit : DevExpress.XtraEditors.SpinEdit
  {
    public NumEdit()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }
  }

  public class ToolStrip : System.Windows.Forms.ToolStrip
  {
    public ToolStrip()
    {
      Font = CacheFont.Font;
      //BackColor = System.Drawing.Color.Transparent;     
    }
  }
/*
  public class ToolBar : System.Windows.Forms.ToolBar
  {
    public ToolBar()
    {
      Font = CacheFont.Font;
      //BackColor = System.Drawing.Color.Transparent;     
    }
  }

  public class ToolBarButton : System.Windows.Forms.ToolBarButton
  {
    public ToolBarButton()
    {
    }
  }
*/
  public class MemoEdit : DevExpress.XtraEditors.MemoEdit
  {
    public MemoEdit()
    {
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }

    [DefaultValue(0)]
    public int MaxLength
    {
      get { return Properties.MaxLength; }
      set { Properties.MaxLength = value; }
    }

    [DefaultValue(false)]
    public bool ReadOnly
    {
      get { return Properties.ReadOnly; }
      set { Properties.ReadOnly = value; }
    }

    [DefaultValue(true)]
    public bool WordWrap
    {
      get { return Properties.WordWrap; }
      set { Properties.WordWrap = value; }
    }
  }

  public class IntelliSenseTextBox : DevExpress.XtraEditors.PopupContainerEdit
  {
    private bool wordMatched;
    private string typed = string.Empty;
    private string excludeFilter = string.Empty;
    private IEnumerable includeFilter = null;
    private readonly DevExpress.XtraEditors.ListBoxControl listBoxAutoComplete;
    private readonly DevExpress.XtraEditors.PopupContainerControl popupContainerControl;

    public IntelliSenseTextBox()
    {
      AutoCompleteToken = '%';
      ShowIntelliSense = true;

      popupContainerControl = new PopupContainerControl { Font = CacheFont.Font };
      Properties.Buttons.Clear();
      Properties.CloseOnLostFocus = false;
      Properties.HideSelection = false;
      Properties.PopupControl = popupContainerControl;
      Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.FrameResize;
      Properties.ShowPopupCloseButton = false;
      Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

      listBoxAutoComplete = new DevExpress.XtraEditors.ListBoxControl { Font = CacheFont.Font };
      listBoxAutoComplete.KeyDown += ListBoxAutoCompleteKeyDown;
      listBoxAutoComplete.DoubleClick += ListBoxAutoCompleteDoubleClick;
      listBoxAutoComplete.MouseUp += ListBoxAutoCompleteMouseUp;
      listBoxAutoComplete.DrawItem += ListBoxAutoCompleteDrawItem;

      popupContainerControl.Controls.Add(listBoxAutoComplete);

      listBoxAutoComplete.Dock = System.Windows.Forms.DockStyle.Fill;

      //
      DataSource = null;
      //
      Font = CacheFont.Font;
      BackColor = System.Drawing.Color.Transparent;
    }


    [DefaultValue("%")]
    public char AutoCompleteToken
    {
      get; set;
    }

    [DefaultValue(true)]
    public bool ShowIntelliSense
    {
      get; set;
    }

    [DefaultValue(false)]
    public bool ReadOnly
    {
      get { return Properties.ReadOnly; }
      set { Properties.ReadOnly = value; }
    }

    [DefaultValue(null)]
    public IEnumerable IncludeFilter
    {
      get { return includeFilter; }
      set
      {
        includeFilter = value;
        MergeFilter();
      }
    }
    [DefaultValue("")]
    public string ExcludeFilter
    {
      get
      {
        return excludeFilter;
      }
      set
      {
        excludeFilter = value ?? string.Empty;
        MergeFilter();
      }
    }

    [AttributeProvider(typeof (IListSource)), DefaultValue((string) null),
     RefreshProperties(RefreshProperties.Repaint)]
    public object DataSource
    {
      get { return listBoxAutoComplete.Items; }
      set { IncludeFilter = (IEnumerable) value; }
    }

    private void MergeFilter()
    {
      
      var array = excludeFilter.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
      listBoxAutoComplete.BeginUpdate();
      try
      {
        listBoxAutoComplete.Items.Clear();
        if (!ReferenceEquals(includeFilter, null))
        {
          foreach (string current in includeFilter)
          {
            var sl = current.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
            if (sl.Any())
            {
              if (!array.Any(mask => sl[0].Equals(mask.Trim())))
              {
                listBoxAutoComplete.Items.Add(current);
              }
            }
          }
        }
      }
      finally
      {
        listBoxAutoComplete.EndUpdate();
      }
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      popupContainerControl.Width = Width;
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
      base.OnKeyPress(e);
      if (e.KeyChar == AutoCompleteToken && ShowIntelliSense)
      {
        typed = new string(new[] {e.KeyChar});
        var ss = SelectionStart;
        ShowPopup();
        Focus();
        SelectionStart = ss;
      }
      else if (IsPopupOpen)
      {
        var c = e.KeyChar;
        var n = (int) c;
        if (n >= 32 && n != 127)
        {
          typed += c;

          wordMatched = false;
          for (var i = 0; i < listBoxAutoComplete.Items.Count; i++)
          {
            if (listBoxAutoComplete.Items[i].ToString().StartsWith(typed))
            {
              wordMatched = true;
              listBoxAutoComplete.SelectedIndex = i;
              break;
            }
          }
        }
      }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
      if (IsPopupOpen)
      {
        switch (e.KeyCode)
        {
          case Keys.Back:
            if (!string.IsNullOrEmpty(typed))
            {
              typed = typed.Substring(0, typed.Length - 1);
            }
            if (string.IsNullOrEmpty(typed))
            {
              CloseIntelliSense();
            }
            break;
          case Keys.Return:
          case Keys.Tab:
          case Keys.Space:
            SelectItem();
            e.Handled = true;
            CloseIntelliSense();
            break;
          case Keys.F4:
            wordMatched = true;
            break;
          case Keys.Home:
            wordMatched = true;
            if (listBoxAutoComplete.Items.Count > 0)
              listBoxAutoComplete.SelectedIndex = 0;
            e.Handled = true;
            break;
          case Keys.End:
            wordMatched = true;
            if (listBoxAutoComplete.Items.Count > 0)
              listBoxAutoComplete.SelectedIndex = listBoxAutoComplete.Items.Count - 1;
            e.Handled = true;
            break;
          case Keys.Down:
            wordMatched = true;
            if (listBoxAutoComplete.SelectedIndex < listBoxAutoComplete.Items.Count - 1)
              listBoxAutoComplete.SelectedIndex++;
            e.Handled = true;
            break;
          case Keys.Up:
            wordMatched = true;
            if (listBoxAutoComplete.SelectedIndex > 0)
              listBoxAutoComplete.SelectedIndex--;
            e.Handled = true;
            break;
          case Keys.Escape:
            e.Handled = true;
            CloseIntelliSense();
            break;
          default:

            /*
            var val = (char) e.KeyData;// KeyValue;
            typed += val;

            wordMatched = false;
            for (var i = 0; i < listBoxAutoComplete.Items.Count; i++)
            {
              if (listBoxAutoComplete.Items[i].ToString().StartsWith(typed))
              {
                wordMatched = true;
                listBoxAutoComplete.SelectedIndex = i;
                break;
              }
            }
            */
            break;
        }
      }
    }

    private void SelectItem()
    {
      if (wordMatched)
      {
        var selstart = SelectionStart;
        var prefixend = selstart - typed.Length;
        var suffixstart = selstart + typed.Length;

        var text = Text;

        if (suffixstart >= text.Length)
        {
          suffixstart = text.Length;
        }

        var prefix = text.Substring(0, prefixend);
        var sl = listBoxAutoComplete.SelectedItem.ToString().Split('|');
        if (sl.Length > 0)
        {
          var fill = sl[0];
          var suffix = text.Substring(suffixstart, text.Length - suffixstart);
          Text = prefix + fill + suffix;
          SelectionStart = prefix.Length + fill.Length;
        }
      }
    }

    private void FocusToText()
    {
      var ss = SelectionStart;
      Focus();
      SelectionStart = ss;
    }

    private void CloseIntelliSense()
    {
      var ss = SelectionStart;
      ClosePopup();
      Focus();
      SelectionStart = ss;
      typed = string.Empty;
      wordMatched = false;
    }

    private void ListBoxAutoCompleteDoubleClick(object sender, EventArgs e)
    {
      OnKeyDown(new KeyEventArgs(Keys.Return));
    }

    private void ListBoxAutoCompleteKeyDown(object sender, KeyEventArgs e)
    {
      FocusToText();
      //e.Handled = true;
    }

    private void ListBoxAutoCompleteMouseUp(object sender, MouseEventArgs e)
    {
      FocusToText();
      wordMatched = true;
    }

    private void ListBoxAutoCompleteDrawItem(object sender, ListBoxDrawItemEventArgs e)
    {
      var sl = e.Item.ToString().Split('|');
      if (sl.Length > 0)
      {
        var a = e.Appearance;
        a.DrawBackground(e.Cache, e.Bounds);
        var text = sl[0].Trim();
        var w = e.Bounds.Width;

        var origFont = a.GetFont();
        var format = a.GetStringFormat();

        var font = new Font(origFont, FontStyle.Bold);
        var sz = e.Cache.Graphics.MeasureString(text, font);
        if (sz.Width < w) w = (int) sz.Width;

        var bounds = new Rectangle(e.Bounds.X, e.Bounds.Y, w, e.Bounds.Height);
        a.DrawString(e.Cache, text, bounds, font, a.GetForeBrush(e.Cache), format);

        if (sl.Length > 1)
        {
          var color =
            e.State == System.Windows.Forms.DrawItemState.Selected
              ? a.GetForeBrush(e.Cache)
              : Brushes.DarkBlue;
          text = sl[1].Trim();
          bounds = new Rectangle(w + 5, bounds.Y, e.Bounds.Width, bounds.Height);
          a.DrawString(e.Cache, text, bounds, origFont, color, format);
        }
        e.Handled = true;
      }
    }
  }
}

