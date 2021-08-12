using System;
using QuikTrade.Utilities;

namespace QuikTrade.Models
{
   /// <summary>
   /// Запись в журнале.
   /// </summary>
   /// <version>1.0.7878.* : none</version>
   [Serializable]
   public class LogEvent : ILogEvent
   {
      #region Properties 
      #region ILogEvent Memebers

      /// <summary>
      /// Момент создания записи.
      /// </summary>
      public DateTime Moment { get; set; } = DateTime.Now;

      /// <summary>
      /// Объект сделавший запись.
      /// </summary>
      public string Sender { get; set; }

      #region IEventInfo Memebers

      /// <summary>
      /// Уровеньй серьёзности события
      /// </summary>
      public Severity Severity { get; set; }

      /// <summary>
      /// Инициатор события.
      /// </summary>
      public Initiator Initiator { get; set; }

      /// <summary>
      /// Событие приведшее к созданию записи.
      /// </summary>
      public string Event { get; set; }

      /// <summary>
      /// Строка сообщения.
      /// </summary>
      public string Message { get; set; }

      #endregion IEventInfo Memebers
      #endregion ILogEvent Memebers
      #endregion Properties

      #region Overrided Methods

      /// <summary>
      /// Возвращает строку, представляющую текущий объект.
      /// </summary>
      /// <returns>Строка, представляющая текущий объект.</returns>
      public override string ToString()
      {
         return $"" +
         $"Moment: {this.Moment.ToLongTimeString()}; " +
         $"Severity: {this.Severity}; " +
         $"Initiator: {this.Initiator}; " +
         $"Sender: {this.Sender}; " +
         $"Event: {this.Event}; " +
         $"Message: {this.Message};";
      }

      #endregion Overrided Methods
   }
}
