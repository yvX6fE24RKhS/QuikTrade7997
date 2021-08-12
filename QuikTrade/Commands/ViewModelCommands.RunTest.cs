using System.Diagnostics;
using QuikTrade.Utilities;
using QuikTrade.Models;
using System.Text.Json;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace QuikTrade.Commands
{
   /// <summary>
   /// Команды модели представления.
   /// </summary>
   /// <version>1.0.7881.* : 1.0.7871.*</version>
   public partial class ViewModelCommands
   {
      #region Methods

      /// <summary>
      /// Обработчик тестовой команды.
      /// </summary>
      public static async void RunTest()
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
         string pathJson = SerializeExtention.GetFile($"{LogPath.Name}test.log");

         using (FileStream fs = new FileStream(pathJson, FileMode.Create))
         {
            await JsonSerializer.SerializeAsync<ObservableCollection<LogEvent>>(
               fs,
               App.Log.LogEvents,
               //options: new JsonSerializerOptions {
               //   Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
               //   WriteIndented = true
               options: SerializeExtention.GetOptions()
            );
         }

         string pathXml = SerializeExtention.GetFile($"{LogPath.Name}test.log", ".xml");
         XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<LogEvent>));

         using (FileStream fs = new FileStream(pathXml, FileMode.Create))
            formatter.Serialize(fs, App.Log.LogEvents);
#endif
      }

      #endregion Methods
   }
}
