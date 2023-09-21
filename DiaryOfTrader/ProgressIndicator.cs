// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using DevExpress.XtraWaitForm;

namespace DiaryOfTrader
{
  public partial class ProgressIndicator : WaitForm
  {
    public ProgressIndicator()
    {
      InitializeComponent();
      this.progressPanel1.AutoHeight = true;
    }

    #region Overrides

    public override void SetCaption(string caption)
    {
      base.SetCaption(caption);
      this.progressPanel1.Caption = caption;
    }
    public override void SetDescription(string description)
    {
      base.SetDescription(description);
      this.progressPanel1.Description = description;
    }
    public override void ProcessCommand(Enum cmd, object arg)
    {
      base.ProcessCommand(cmd, arg);
    }

    #endregion

    public enum WaitFormCommand
    {
    }
  }
}
