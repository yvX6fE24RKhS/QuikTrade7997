using System.Diagnostics;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Input;
using Foundation;
using QuikTrade.Commands;
using QuikTrade.Utilities;


namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Модель представления основного окна.
   /// </summary>
   /// <version>1.0.7878.* : 1.0.7871.*</version>
   [DataContract]
   public class MainViewModel : ViewModel
   {
      #region Properties

      /// <summary>
      /// Весрия сборки.
      /// </summary>
      [DataMember]
      public string AssemblyVersion
      {
         get { return Get(() => this.AssemblyVersion, DebugExtension.GetAssemblyVersion()); }
         set { Set(() => this.AssemblyVersion, DebugExtension.GetAssemblyVersion()); }
      }

      #region DockPanelChangeableProperties
      /// <summary>
      /// Ширина главной панели управления.
      /// </summary>
      [DataMember]
      public double MainControlPanelWidth
      {
         get { return Get(() => this.MainControlPanelWidth, 80); }
         set { Set(() => this.MainControlPanelWidth, value); }
      }
      #endregion DockPanelChangeableProperties

      #endregion Properties

      #region Constructors
      /// <summary>
      /// Создает экземпляр модели представления.
      /// </summary>
      public MainViewModel() : base()
      {
      }
      #endregion Constructors

      #region Methods

      /// <summary>
      /// Инициализирует модель представления даными из потока.
      /// </summary>
      /// <param name="streamingContext">Поток даннных.</param>
      [OnDeserialized]
      private void Initialize(StreamingContext streamingContext = default(StreamingContext))
      {
#if DEBUG
         string msg = "Отладка: MainViewModel.Initialize(StreamingContext streamingContext = default(StreamingContext)) executing";
         System.Diagnostics.Debug.WriteLine(msg);
#endif

         this[ApplicationCommands.Close].Executed += (sender, args) => Application.Current.Shutdown();

         this[ViewModelCommands.TestCommand].Executed += (sender, args) => App.Log.Append(
            this, 
            new EventInfo(
               init: Initiator.user,
               evnt: "TestCommand",
               msg: "Пользователь выбрал меню [_Test].[Run Test]."
            )
         );
         this[ViewModelCommands.TestCommand].Executed += (sender, args) => ViewModelCommands.RunTest();

      }



      #endregion Methods
   }
}
