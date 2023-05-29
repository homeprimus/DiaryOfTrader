using DevExpress.XtraEditors;
using DiaryOfTrader.Properties;

namespace DiaryOfTrader.Core
{

	/// <summary>
	/// Contains some static methods to uniform messaging.
	/// </summary>
	internal static class MsgBox
	{
		public static DialogResult WarningOk(string msg,string caption)
		{
			//return MessageBox.Show(msg,caption,MessageBoxButtons.OK,MessageBoxIcon.Warning);
      return XtraMessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		public static DialogResult WarningOk(IWin32Window owner, string msg,string caption)
		{
      //return MessageBox.Show(owner, msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return XtraMessageBox.Show(owner, msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

		public static DialogResult ShowQuestionYesNo(string msg, string caption)
		{
      //return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      return XtraMessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
		public static DialogResult ShowQuestionYesNo(IWin32Window owner, string msg, string caption)
		{
      //return MessageBox.Show(owner, msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      return XtraMessageBox.Show(owner, msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
		public static DialogResult ShowQuestionYesNoCancel(string msg, string caption)
		{
      //return MessageBox.Show(msg, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
      return XtraMessageBox.Show(msg, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
    }

		public static DialogResult ShowQuestionYesNoCancel(IWin32Window owner, string msg, string caption)
		{
      //return MessageBox.Show(owner, msg, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
      return XtraMessageBox.Show(owner, msg, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
    }


    public static DialogResult ShowWarningOk(string msg, string caption)
    {
      //return MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return XtraMessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    public static DialogResult ShowWarningOk(IWin32Window owner, string msg, string caption)
    {
      //return MessageBox.Show(owner, msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return XtraMessageBox.Show(owner, msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }


//		public static DialogResult ShowStopOk(string msg, string Text)
//		{
//			return MessageBox.Show(msg,Text,MessageBoxButtons.OK,MessageBoxIcon.Stop);
//		}
		public static DialogResult ShowInformationOk(string msg, string caption)
		{
      //return MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
      return XtraMessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

		public static DialogResult ShowInformationOk(IWin32Window owner, string msg, string caption)
		{
      //return MessageBox.Show(owner, msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
      return XtraMessageBox.Show(owner, msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


		public static void ShowErrorModal(String msg, string caption)
		{
      //MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
      XtraMessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }




    public static void ShowError(String msg, string caption)
    {
      //MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
      XtraMessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void ShowError(Control ctrl, Exception ex)
    {
      ShowError(ctrl, ex, ctrl.FindForm().Text);
    }
    public static void ShowError(Control ctrl, string error)
    {
      ShowError(ctrl, error, ctrl.FindForm().Text);
    }

    public static void ShowError(Control ctrl, Exception ex, string caption)
    {
      XtraMessageBox.Show(ctrl, ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
      //MessageBox.Show(ctrl, ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

		public static void ShowError(IWin32Window owner,String msg, string caption)
		{
			//MessageBox.Show(owner, msg, caption,MessageBoxButtons.OK, MessageBoxIcon.Error);
      XtraMessageBox.Show(owner, msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }


	}
}
