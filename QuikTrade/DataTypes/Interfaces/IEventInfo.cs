using QuikTrade.DataTypes.Enums;

namespace QuikTrade.DataTypes.Interfaces
{
   /// <summary>
   /// Интерфейс класса описания события.
   /// </summary>
   /// <version>1.0.7878.* : none</version>
   public interface IEventInfo
   {
      #region Properties

      /// <summary>
      /// Уровеньй серьёзности события.
      /// </summary>
      Severity Severity { get; set; }

      /// <summary>
      /// Инициатор события.
      /// </summary>
      Initiator Initiator { get; set; }

      /// <summary>
      /// Событие приведшее к созданию записи.
      /// </summary>
      string Event { get; set; }

      /// <summary>
      /// Строка сообщения.
      /// </summary>
      string Message { get; set; }

      #endregion Properties
   }
}
