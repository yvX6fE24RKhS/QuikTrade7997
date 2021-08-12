using System.Diagnostics;
using System.Windows.Input;

namespace QuikTrade.Commands
{
   /// <summary>
   /// Команды модели представления.
   /// </summary>
   /// <version>1.0..* : 1.0..*</version>
   public partial class ViewModelCommands
   {
      #region Methods

      /// <summary>
      /// Открывает вкладку журнала и панель управления содержанием.
      /// </summary>
      public static void LogShow()
      {
#if DEBUG
         Debug.WriteLine("Отладка: LogShow executed.");
#endif
      }

      #endregion Methods
   }
}
