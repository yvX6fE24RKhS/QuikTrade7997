using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using QuikTrade.DataTypes.Interfaces;
using QuikTrade.Utilities;
using QuikTrade.Utilities.Extensions;

namespace QuikTrade.DataTypes
{
   /// <summary>
   /// Журнал приложения.
   /// </summary>
   /// <version>1.0.7983.* : 1.0.7901.*</version>
   public class Log : ILog
   {
      #region Fields

      private const string XmlExtension = ".xml";
      private const string JsonExtension = ".json";
      private DateTime _date;
      private string _file;

      #endregion Fields

      #region Properties
      #region ILog Members

      /// <summary>
      /// Дата журнала.
      /// </summary>
      public DateTime LogDate
      {
         get => _date;
         set
         {
            _date = (value == DateTime.MinValue) ? DateTime.Today : value;
            _file = $"{_date:yyyyMMdd}.log";
         }
      }

      /// <summary>
      /// Содержание журнала.
      /// </summary>
      public ObservableCollection<LogEvent> LogEvents { get; set; } = new ObservableCollection<LogEvent>();

      /// <summary>
      /// Последнее событие.
      /// </summary>
      public LogEvent LastEvent { get; set; }

      #endregion ILog Members
      #endregion Properties

      #region Constructors

      /// <summary>
      ///  Инициализирует новый экземпляр класса <see cref="Log"/>.
      /// </summary>
      public Log()
      {
         _file = $"{DateTime.Today:yyyyMMdd}.log";
      }

      /// <summary>
      ///  Инициализирует новый экземпляр класса <see cref="Log"/> с заданным значением даты журнала.
      /// </summary>
      /// <param name="date">DateTime, представляющая дату журнала.</param>
      public Log(DateTime date)
      {
         this.LogDate = date;
      }

      #endregion Constructors

      #region Methods
      #region ILog Members

      /// <summary>
      /// Добавление информации о событии в журнал.
      /// </summary>
      /// <param name="logEvent">Запись о событии.</param>
      public void Append(LogEvent logEvent)
      {
         LastEvent = logEvent;
         LogEvents.Add(logEvent);
      }

      /// <summary>
      /// Добавление информации о событии в журнал.
      /// </summary>
      /// <param name="sender">Объект, создавший событие.</param>
      /// <param name="e">Данные события.</param>
      public void Append(object sender, IEventInfo e)
      {
         LogEvent logItem = new LogEvent
         {
            Severity = e.Severity,
            Initiator = e.Initiator,
            Sender = $"{sender.GetType()}",
            Event = e.Event,
            Message = e.Message
         };

         Append(logItem);
      }

      /// <summary>
      /// Проверяет, существует ли файл.
      /// </summary>
      /// <param name="fullname">Строка, содержащая полное имя и путь к файлу журнала.</param>
      /// <returns><c>true</c>, если файл существует; в противном случае <c>false</c>.</returns>
      public bool Exists(string fullname)
      {
         if (string.IsNullOrWhiteSpace(fullname))
            throw new ArgumentException("message", nameof(fullname));

         return new FileInfo(fullname).Exists;
      }

      /// <summary>
      /// Формирует полное имя xml-фалйа журнала.
      /// </summary>
      /// <param name="name">Строка, содержащая имя xml-фалйа без расширения.</param>
      /// <returns>Строка, содержащая полное имя и путь к xml-файлу журнала.</returns>
      private string GetPathXml(string name) => $"{LogPath.Name}{name}{XmlExtension}";

      /// <summary>
      /// Формирует полное имя json-фалйа журнала.
      /// </summary>
      /// <param name="name">Строка, содержащая имя json-фалйа без расширения.</param>
      /// <returns>Строка, содержащая полное имя и путь к json-файлу журнала.</returns>
      private string GetPathJson(string name) => $"{LogPath.Name}{name}{JsonExtension}";

      /// <summary>
      /// Чтение журнала из xml-файла.
      /// </summary>
      /// <param name="logDate">Дата журнала.</param>
      /// <returns>
      /// Журнал заполненный данныим из файла на дату, указанную в параметре <c>logDate</c>.
      /// Либо пустой журнал, если файл не был найден.
      /// </returns>
      public Log ReadXml(DateTime logDate)
      {
         Log log = new Log(logDate);
         string path = GetPathXml(log._file);

         if (log.Exists(path))
         {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<LogEvent>));

            using (FileStream fs = new FileStream(path, FileMode.Open))
               log.LogEvents = (ObservableCollection<LogEvent>)formatter.Deserialize(fs);
         }

         return log;
      }

      /// <summary>
      /// Запись журнала в xml-файл.
      /// </summary>
      public void WriteXml()
      {
         // Защита от перезаписи архивного журнала
         if (this.LogDate == DateTime.MinValue)
         {
            // Создать новый файл или дописать существующий

            if (!LogPath.Exists())
               LogPath.Create();
            
            Log log = ReadXml(_date);

            foreach (LogEvent logEvent in LogEvents)
               log.LogEvents.Add(logEvent);

            if (log.LogEvents != null)
            {
               string path = GetPathXml(_file);
               FileInfo fileInfo = new FileInfo(path);

               if (fileInfo.Exists)
                  fileInfo.Delete();

               XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<LogEvent>));

               using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                  formatter.Serialize(fs, log.LogEvents);
            }
         }
      }

      /// <summary>
      /// Чтение журнала из json-файла.
      /// </summary>
      /// <param name="logDate">Дата журнала.</param>
      /// <returns>
      /// Журнал заполненный данныим из файла на дату, указанную в параметре <c>logDate</c>.
      /// Либо пустой журнал, если файл не был найден.
      /// </returns>
      public Log ReadJson(DateTime logDate)
      {
         Log log = new Log(logDate);
         string path = GetPathJson(log._file);

         if (log.Exists(path))
         {
            log.LogEvents = JsonSerializer.Deserialize<ObservableCollection<LogEvent>>(
               File.ReadAllText(path),
               options: SerializeExtention.GetOptions()
            );
         }

         return log;
      }

      /// <summary>
      /// Запись журнала в json-файл.
      /// </summary>
      public async void WriteJson()
      {
         // Защита от перезаписи архивного журнала
         if (this.LogDate == DateTime.MinValue)
         {
            // Создать новый файл или дописать существующий

            if (!LogPath.Exists())
               LogPath.Create();

            Log log = ReadJson(_date);

            foreach (LogEvent logEvent in LogEvents)
               log.LogEvents.Add(logEvent);

            if (log.LogEvents != null)
            {
               string path = GetPathJson(_file);
               FileInfo fileInfo = new FileInfo(path);

               if (fileInfo.Exists)
                  fileInfo.Delete();

               using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                  await JsonSerializer.SerializeAsync<ObservableCollection<LogEvent>>(
                     fs,
                     log.LogEvents,
                     options: SerializeExtention.GetOptions()
                  );
            }
         }
      }

      #endregion ILog Members
      #endregion Methods
   }
}
