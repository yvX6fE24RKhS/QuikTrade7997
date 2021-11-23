using System.Diagnostics;
using QuikTrade.Utilities;
using System.Text.Json;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using QuikTrade.DataTypes;
using QuikTrade.Utilities.Extensions;
using System.Windows;
using System.Web.UI;

namespace QuikTrade.ViewModels.Commands
{
   /// <summary>
   /// Команды модели представления.
   /// </summary>
   /// <version>1.0.7983.* : 1.0.7881.*</version>
   public partial class ViewModelCommands
   {
      #region Methods

      /// <summary>
      /// 
      /// </summary>
      public static void RunTest1(object sender, RoutedEventArgs e)
      {
#if DEBUG
         //string msg = $"sender: {sender.ToString()}\nRoutedEventArgs: {e.ToString()}\ne.Source: {e.Source.ToString()}\n(e.OriginalSource as FrameworkElement).Name: {(e.OriginalSource as FrameworkElement).Name}\ne.RoutedEvent.Name: {e.RoutedEvent.Name}\ne.OriginalSource: {e.OriginalSource}\ne.Handled: {e.Handled}\ne.GetHashCode: {e.GetHashCode()}\ne.Source.GetType(): {e.Source.GetType()}";
         string msg = $"\ne.Source: {e.Source}\n"
                      + $"e.Source.GetType().ToString(): {e.Source.GetType()}\n"
         //+ $"((Control)e.Source).DataContext.ToString(): {((Control)e.Source).DataContext}\n"
         //+ $"((Control)e.Source).DataContext.GetType().ToString(): {((Control)e.Source).DataContext.GetType()}\n"
         //+ $"tabItem.DataContext.GetType().Name: {tabItem.DataContext.GetType().Name}\n"
         ;
         System.Diagnostics.Debug.WriteLine(msg);
         //DEBUG MessageBox.Show($"Uid: {tabItem.Uid.ToString()}\n");
#endif
      }

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
