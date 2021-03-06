using System;

namespace QuikTrade.DataTypes.Interfaces
{
   /// <summary>
   /// Интерфейс класса записи информации о событии в журнале приложения.
   /// </summary>
   /// <version>1.0.7983.* : 1.0.7878.*</version>
   public interface ILogEvent : IEventInfo
   {
      #region Properties

      /// <summary>
      /// Момент создания записи.
      /// </summary>
      DateTime Moment { get; }

      /// <summary>
      /// Объект сделавший запись.
      /// </summary>
      string Sender { get; set; }

      #endregion Properties
   }
}
