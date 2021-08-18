using System.Runtime.Serialization;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Счетчик однотипных вкладок.
   /// </summary>
   /// <version>1.0.7898.* : none</version>
   [DataContract]
   public class TabCounter
   {
      #region Fields
      #region Constants

      /// <summary>
      /// Максималльное количество однотипных вкладок по умолчанию.
      /// </summary>
      public const int MaxCountDefault = 4;

      #endregion Constants

      private int _maxCount;

      #endregion Fields

      #region Properties

      /// <summary>
      /// Счетчик однотипных вкладок.
      /// </summary>
      [DataMember]
      internal int Count { get; set; }

      /// <summary>
      /// Максималльное количество однотипных вкладок.
      /// </summary>
      [DataMember]
      internal int MaxCount { get => _maxCount; set => _maxCount = (value > 0) ? value : 1; }

      #endregion Properties

      #region Constructors

      /// <summary>
      /// Инициализирует новый экземпляр класса <see cref="TabCounter"/> с установкой размерности по умолчанию.
      /// </summary>
      public TabCounter() : this(MaxCountDefault) { }

      /// <summary>
      /// Инициализирует новый экземпляр класса <see cref="TabCounter"/> с установкой размерности.
      /// </summary>
      /// <param name="maxCount">Максималльное количество однотипных вкладок.</param>
      public TabCounter(int maxCount) => this.MaxCount = maxCount;

      #endregion Constructors
   }
}
