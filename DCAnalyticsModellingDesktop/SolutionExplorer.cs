using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DCAnalyticsModellingDesktop
{
    public partial class SolutionExplorer : DockContent
    {
        #region properties
        public TreeView TreeView
        {
            get
            {
                return _tvSolutionExplorer;
            }
        }
        #endregion

        public SolutionExplorer()
        {
            InitializeComponent();
        }

        internal void DisableTree()
        {
            _tvSolutionExplorer.Enabled = false;
        }

        internal void EnableTree()
        {
            _tvSolutionExplorer.Enabled = true;
        }


    }
}
