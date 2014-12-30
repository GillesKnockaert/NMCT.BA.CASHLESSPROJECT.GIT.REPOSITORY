using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.uimanage.ViewModel
{
    public class StatistiekenVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Statistieken"; }
        }
    }
}
