using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using QuikTrade.Utilities;

namespace QuikTrade.Models
{
   /// <summary>
   /// Журнал приложения.
   /// </summary>
   /// <version>1.0.7878.* : none</version>
   public class Log : ILog
   {
      #region Fields
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
            _file = $"{_date.ToString("yyyyMMdd")}.log.xml";
         }
      }

      /// <summary>
      /// Содержание журнала.
      /// </summary>
      public ObservableCollection<LogEvent> LogEvents { get; set; } = new ObservableCollection<LogEvent>();

      #endregion ILog Members
      #endregion Properties

      #region Constructors

      /// <summary>
      ///  Инициализирует новый экземпляр класса <see cref="Log"/>.
      /// </summary>
      public Log()
      {
         _file = $"{DateTime.Today.ToString("yyyyMMdd")}.log.xml";
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
         this.LogEvents.Add(logEvent);
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
            Sender = $"{sender.GetType().ToString()}",
            Event = e.Event,
            Message = e.Message
         };

         this.LogEvents.Add(logItem);
      }

      /// <summary>
      /// Проверка на существование файла.
      /// </summary>
      /// <returns></returns>
      public bool Exists() => (new FileInfo(LogPath.Name + _file)).Exists;


      /// <summary>
      /// Чтение журнала из файла.
      /// </summary>
      /// <param name="logDate">Дата журнала.</param>
      /// <returns>
      /// Журнал заполненный данныим из файла на дату, указанную в параметре <c>logDate</c>.
      /// Либо пустой журнал, если файл не был найден.
      /// </returns>
      public Log ReadXML(DateTime logDate)
      {
         Log log = new Log(logDate);
         string path = LogPath.Name + log._file;

         if (log.Exists())
         {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<LogEvent>));

            using (FileStream fs = new FileStream(path, FileMode.Open))
               log.LogEvents = (ObservableCollection<LogEvent>)formatter.Deserialize(fs);
         }

         return log;
      }

      /// <summary>
      /// Запись журнала в файл.
      /// </summary>
      public void WriteXML()
      {
         // Защита от перезаписи архивного журнала
         if (this.LogDate == DateTime.MinValue)
         {
            // Создать новый файл или дописать существующий

            if (!LogPath.Exists())
               LogPath.Create();
            
            Log log = ReadXML(_date);

            foreach (LogEvent logEvent in this.LogEvents)
               log.LogEvents.Add(logEvent);

            if (log.LogEvents != null)
            {
               string path = LogPath.Name + _file;
               FileInfo fileInfo = new FileInfo(path);

               if (fileInfo.Exists)
                  fileInfo.Delete();

               XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<LogEvent>));

               using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                  formatter.Serialize(fs, log.LogEvents);
            }
         }
      }
      #endregion ILog Members
      #endregion Methods
   }
}
