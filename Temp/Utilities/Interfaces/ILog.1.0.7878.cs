using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using QuikTrade.Models;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Интерфейс журнала приложения.
   /// </summary>
   /// <version>1.0.7878.* : none</version>
   public interface ILog
   {
      #region Properties

      /// <summary>
      /// Дата журнала.
      /// </summary>
      DateTime LogDate { get; set; }

      /// <summary>
      /// Содержание журнала.
      /// </summary>
      ObservableCollection<LogEvent> LogEvents { get; set; }

      #endregion Properties

      #region Methods

      /// <summary>
      /// Добавление информации о событии в журнал.
      /// </summary>
      /// <param name="logItem">Информация о событии.</param>
      void Append(LogEvent logItem);

      /// <summary>
      /// Добавление информации о событии в журнал.
      /// </summary>
      /// <param name="sender">Объект, создавший событие.</param>
      /// <param name="e">Данные события.</param>
      void Append(object sender, IEventInfo e);

      /// <summary>
      /// Проверка на существование файла.
      /// </summary>
      bool Exists();

      /// <summary>
      /// Чтение журнала из файла.
      /// </summary>
      Log ReadXML(DateTime logDate);

      /// <summary>
      /// Запись журнала в файл.
      /// </summary>
      void WriteXML();
      
      #endregion Methods
   }
}
