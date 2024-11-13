using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyAssetManager.WPF.Common
{
    /// <summary>
    /// Interaction logic for FileSelector.xaml
    /// </summary>
    public partial class FileSelector : Button, INotifyPropertyChanged
    {
        public FileSelector()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        protected string _TargetFilePath;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual string TargetFilePath
        {
            get
            {
                return _TargetFilePath;
            }

            set
            {
                _TargetFilePath = value;
            }
        }

        public virtual string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(_TargetFilePath))
                {
                    return null;
                }

                return System.IO.Path.GetFileName(_TargetFilePath);
            }
        }

        protected override void OnClick()
        {
            base.OnClick();
            OpenFileDialog ofd = new OpenFileDialog();
            if(!string.IsNullOrEmpty(TargetFilePath))
            {
            }
            if(ofd.ShowDialog() == true)
            {
                TargetFilePath = ofd.FileName;
                PropertyChanged.Invoke(this,new PropertyChangedEventArgs(nameof(FileName)));
            }
        }
    }
}
