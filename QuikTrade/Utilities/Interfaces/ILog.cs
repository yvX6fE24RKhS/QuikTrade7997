using System;
using System.Collections.ObjectModel;
using QuikTrade.Models;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Интерфейс класса журнала приложения.
   /// </summary>
   /// <version>1.0.7881.* : 1.0.7878.*</version>
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
      /// <param name="fullname">Полное имя файла.</param>
      /// <returns><c>true</c>, если файл существует; в противном случае <c>false</c>.</returns>
      bool Exists(string fullname);

      /// <summary>
      /// Чтение журнала из xml-файла.
      /// </summary>
      /// <param name="logDate">Дата журнала.</param>
      /// <returns>Журнал</returns>
      Log ReadXml(DateTime logDate);

      /// <summary>
      /// Запись журнала в xml-файл.
      /// </summary>
      void WriteXml();

      /// <summary>
      /// Чтение журнала из json-файла.
      /// </summary>
      /// <param name="logDate">Дата журнала.</param>
      /// <returns>Журнал</returns>
      Log ReadJson(DateTime logDate);

      /// <summary>
      /// Запись журнала в json-файл.
      /// </summary>
      void WriteJson();

      #endregion Methods
   }
}
