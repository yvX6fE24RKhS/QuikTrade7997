using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuikTrade.Utilities;
using QuikTrade.Models;
using System.Text.Json;

namespace QuikTrade.Commands
{
   /// <summary>
   /// Команды модели представления.
   /// </summary>
   /// <version>1.0.* : 1.0.7871.*</version>
   public partial class ViewModelCommands
   {
      #region Methods

      /// <summary>
      /// Обработчик тестовой команды.
      /// </summary>
      public static void RunTest()
      {

#if DEBUG
         string msg = "Отладка: TestCommand executed.";
         Debug.WriteLine(msg);
         Debug.WriteLine(DebugExtension.GetAppName());
         Debug.WriteLine(LogPath.Name);
         Debug.WriteLine(LogPath.Exists().ToString());
         Debug.WriteLine($"App.Log.LogDate: {App.Log.LogDate.ToLongDateString()}");
         if (!LogPath.Exists())
         {
            LogPath.Create();
         }
         Debug.WriteLine("App.Log.LogEvents:");
         foreach (LogEvent item in App.Log.LogEvents)
         {
            Debug.WriteLine(item);
         }
         Debug.WriteLine("App.Log.LogEvents jsonString :");
         foreach (LogEvent item in App.Log.LogEvents)
         {
            Debug.WriteLine(JsonSerializer.Serialize(item));
         }
#endif
      }

      #endregion Methods
   }
}
