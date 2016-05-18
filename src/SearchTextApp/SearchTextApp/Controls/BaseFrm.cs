using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchTextApp.Controls
{
    public class BaseFrm : Form
    {
        public BaseFrm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BaseFrm";
            this.Text = "BaseFrm";
            this.ResumeLayout(false);

        }

        /// <summary>
        /// BindingSource를 추가합니다.
        /// </summary>
        /// <param name="gridName"></param>
        /// <returns>추가되면 1, 추가되지 않으면 0</returns>
        public BindingSource AddBindingSource(string gridName)
        {
            BindingSource bs = new BindingSource();
            if (this.BindingSourceList.ContainsKey(gridName))
            {
                bs = this.BindingSourceList[gridName];
            }
            else
            {
                this.BindingSourceList.Add(gridName, bs);
            }
            return bs;
        }

        /// <summary>
        /// BackgroundWorker를 추가합니다.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BackgroundWorker AddBackgroundWorker(string key)
        {
            BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
            if (this.BackgroundWorkerList.ContainsKey(key))
            {
                worker = this.BackgroundWorkerList[key];
            }
            else
            {
                worker = new System.ComponentModel.BackgroundWorker();
                worker.WorkerSupportsCancellation = true;
                worker.WorkerReportsProgress = true;

                this.BackgroundWorkerList.Add(key, worker);
            }

            return worker;
        }

        public void ClearError()
        {
            this.ErrorProvider.Clear();
        }

        public void SetError(Control ctl, string message, ErrorIconAlignment? errorIconAlignment, int? padding)
        {
            this.ErrorProvider.SetError(ctl, message);

            if (!errorIconAlignment.HasValue)
            {
                errorIconAlignment = ErrorIconAlignment.MiddleLeft;
            }

            if (!padding.HasValue)
            {
                padding = 0;
            }

            this.ErrorProvider.SetIconAlignment(ctl, errorIconAlignment.Value);
            this.ErrorProvider.SetIconPadding(ctl, padding.Value);
        }

        public void SetError(Control ctl, string message)
        {
            this.SetError(ctl, message, null, null);
        }

        /// <summary>
        /// GridName: BindingSource
        /// </summary>
        public Dictionary<string, BindingSource> BindingSourceList
        {
            get
            {
                if (this._BindingSourceList == null) { this._BindingSourceList = new Dictionary<string, BindingSource>(); }
                return this._BindingSourceList;
            }
        }

        /// <summary>
        /// BackgroundWokrers
        /// </summary>
        public Dictionary<string, BackgroundWorker> BackgroundWorkerList
        {
            get
            {
                if (this._BackgroundWorker == null)
                {
                    this._BackgroundWorker = new Dictionary<string, BackgroundWorker>();
                }
                return _BackgroundWorker;
            }
        }

        public ErrorProvider ErrorProvider
        {
            get
            {
                if(this._ErrorProvider == null) { this._ErrorProvider = new ErrorProvider();
                }
                return this._ErrorProvider;
            }
        }

        private Dictionary<string, BindingSource> _BindingSourceList = null;

        private Dictionary<string, BackgroundWorker> _BackgroundWorker = null;

        private ErrorProvider _ErrorProvider;
    }
}
