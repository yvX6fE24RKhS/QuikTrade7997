namespace QuikTrade.Utilities
{
   /// <summary>
   /// Описание события.
   /// </summary>
   /// <version>1.0.7878.* : none</version>
   internal class EventInfo : IEventInfo
   {
      #region Properties
      #region IEventInfo Members

      /// <summary>
      /// Уровеньй серьёзности события.
      /// </summary>
      public Severity Severity { get; set; } = Severity.info;

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

      #endregion IEventInfo Members
      #endregion Properties

      #region Constructors

      /// <summary>
      /// Инициализирует новый экземпляр класса <see cref="EventInfo"/>.
      /// </summary>
      public EventInfo()
      {
      }

      /// <summary>
      /// Инициализирует новый экземпляр класса <see cref="EventInfo"/> с заданными значениями параметров.
      /// </summary>
      /// <param name="evnt">Строка, содержащая имя события.</param>
      /// <param name="msg">Строка сообщения описывающая событие.</param>
      /// <param name="init">Инициатор. Необязательный. Значение по умолчанию <c>Initiator.app</c>.</param>
      /// <param name="sevrt">Уровеньй серьёзности события. Необязательный. Значение по умолчанию <c>Severity.info</c>.</param>
      public EventInfo(string evnt, string msg, Initiator init = Initiator.app, Severity sevrt = Severity.info)
      {
         this.Severity = sevrt;
         this.Initiator = init;
         this.Event = evnt;
         this.Message = msg;
      }

      #endregion Constructors
   }
}
