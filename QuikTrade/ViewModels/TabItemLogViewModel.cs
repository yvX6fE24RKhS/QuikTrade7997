using System.Runtime.Serialization;
using QuikTrade.DataTypes;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Вкладка журнала событий.
   /// </summary>
   /// <version>1.0.7983.* : 1.0.7983.*</version>
   [DataContract]
   public class TabItemLogViewModel : WorkspaceViewModel
   {
      #region Fields

      private string _header = "Журнал";

      #endregion Fields

      #region Properties
      #region Base Class Overrides

      /// <summary>
      /// Заголовок
      /// </summary>
      [DataMember]
      public override string Header { get => _header; set => _header = value; }

      #endregion Base Class Overrides

      /// <summary>
      /// Журнал.
      /// </summary>
      [IgnoreDataMember]
      public Log Log { get; set; }

      #endregion Properties

      #region Constructors

      /// <summary>
      /// Инициализирует новый экземпляр класса <see cref="TabItemLogViewModel"/> содержащий журнал текущей сессии.
      /// </summary>
      public TabItemLogViewModel() => this.Log = App.Log;

      /// <summary>
      /// Инициализирует новый экземпляр класса <see cref="TabItemLogViewModel"/> содержащий журнал из архива. 
      /// </summary>
      /// <param name="log">Журнал из архива.</param>
      public TabItemLogViewModel(Log log)
      {
         Log = log;
      }

      #endregion Constructors

      #region Methods
      /// <summary>
      /// Метод вызывается после того как объект будет десериализован. Используется вместо конструктора.
      /// </summary>
      [OnDeserialized]
      void OnDeserialized(StreamingContext context)
      {
         this.Log = App.Log;
      }

      #endregion Methods
   }
}
