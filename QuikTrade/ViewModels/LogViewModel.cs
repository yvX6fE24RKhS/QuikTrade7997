using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using QuikTrade.Models;

namespace QuikTrade.ViewModels
{
   internal class LogViewModel : ViewModel
   {
      /// <summary>
      /// Журнал текущей сессии.
      /// </summary>
      internal Log Log { get; set; }

      public LogViewModel() => this.Log = App.Log;

   }
}
