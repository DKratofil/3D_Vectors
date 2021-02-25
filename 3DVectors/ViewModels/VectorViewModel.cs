using _3DVectors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VectorLibrary;

namespace _3DVectors.ViewModels
{
    public class VectorViewModel: ViewModelBase
    {
        private ICommand _CalculateDotProduct;

        #region private Members
        private double _v1x;
        private double _v2x;   
        private double _v3x;        

        private double _v1y;
        private double _v2y;
        private double _v3y;

        private double _v1z;
        private double _v2z;
        private double _v3z;
        #endregion

        #region Public Properties
        public ICommand CalculateDotProduct
        {
            get { return _CalculateDotProduct; }
            set
            {
                _CalculateDotProduct = value;
                OnPropertyChanged("CalculateDotProduct");
            }
        }
        public double V1X
        {
            get { return _v1x; }
            set
            {
                _v1x = value;
                OnPropertyChanged("V1X");
            }
        }
        public double V2X
        {
            get { return _v2x; }
            set
            {
                _v2x = value;
                OnPropertyChanged("V2X");
            }
        }
        public double V3X
        {
            get { return _v3x; }
            set
            {
                _v3x = value;
                OnPropertyChanged("V3X");
            }
        }

        public double V1Y
        {
            get { return _v1y; }
            set
            {
                _v1y = value;
                OnPropertyChanged("V1Y");
            }
        }
        public double V2Y
        {
            get { return _v2y; }
            set
            {
                _v2y = value;
                OnPropertyChanged("V2Y");
            }
        }
        public double V3Y
        {
            get { return _v3y; }
            set
            {
                _v3y = value;
                OnPropertyChanged("V3Y");
            }
        }

        public double V1Z
        {
            get { return _v1z; }
            set
            {
                _v1z = value;
                OnPropertyChanged("V1Z");
            }
        }
        public double V2Z
        {
            get { return _v2z; }
            set
            {
                _v2z = value;
                OnPropertyChanged("V2Z");
            }
        }
        public double V3Z
        {
            get { return _v3z; }
            set
            {
                _v3z = value;
                OnPropertyChanged("V3Z");
            }
        }
        #endregion

        #region Constructor
        public VectorViewModel()
        {

            CalculateDotProduct = new CommandHandler(new Action<object>(DotProduct));
           
        }
        #endregion

        #region Private Methods
        private void DotProduct(object p = null)
        {
            Vector3 v1 = new Vector3(V1X, V1Y, V1Z);
            Vector3 v2 = new Vector3(V2X, V2Y, V2Z);

            var res = v1.CrossProduct(v2);

            V3X = res.X;
            V3Y = res.Y;
            V3Z = res.Z;
        }
        #endregion
    }
}
