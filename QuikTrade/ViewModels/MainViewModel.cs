using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Foundation;
using QuikTrade.ViewModels.Commands;
using QuikTrade.ViewModels.Interfaces;
using QuikTrade.DataTypes.Enums;
using QuikTrade.Utilities;
using QuikTrade.Utilities.Extensions;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Модель представления основного окна.
   /// </summary>
   /// <version>1.0.7983.* : 1.0.7898.*</version>
   [DataContract]
   [KnownType(typeof(TabItemSampleViewModel))]
   [KnownType(typeof(TabItemLogViewModel))]

   public class MainViewModel : ViewModel
   {
      #region Properties

      /// <summary>
      /// Весрия сборки.
      /// </summary>
      [DataMember]
      public string AssemblyVersion
      {
         get => Get(() => AssemblyVersion, DebugExtension.GetAssemblyVersion());
         set => Set(() => AssemblyVersion, DebugExtension.GetAssemblyVersion());
      }

      /// <summary>
      /// Последняя запись в журнале.
      /// </summary>
      public string LastEventMessage
      {
         get => Get(() => LastEventMessage, App.Log.LastEvent.Message);
         set => Set(() => LastEventMessage, value);
      }

      #region DockPanelChangeableProperties

      /// <summary>
      /// Ширина главной панели управления.
      /// </summary>
      [DataMember]
      public double MainControlPanelWidth
      {
         get => Get(() => MainControlPanelWidth, 80);
         set => Set(() => MainControlPanelWidth, value);
      }

      #endregion DockPanelChangeableProperties

      #region Workspaces

      /// <summary>
      /// Коллекция типов вкладок.
      /// </summary>
      [DataMember]
      public Dictionary<string, TabCounter> WorkspaceTypes
      {
         get => Get(() => WorkspaceTypes);
         set => Set(() => WorkspaceTypes, value);
      }

      /// <summary>
      /// Коллекция открытых вкладок.
      /// </summary>
      [DataMember]
      public ObservableCollection<IWorkspaceViewModel> Workspaces
      {
         get => Get(() => Workspaces);
         set => Set(() => Workspaces, value);
      }

      /// <summary>
      /// Активная вкладка.
      /// </summary>
      [DataMember]
      public IWorkspaceViewModel SelectedTab
      {
         get => Get(() => SelectedTab);
         set => Set(() => SelectedTab, value);
      }

      #endregion Workspaces
      #endregion Properties

      #region Constructors
      /// <summary>
      /// Создает экземпляр модели представления.
      /// </summary>
      public MainViewModel() : base()
      {
         GetLastLogedMessage();
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
         Debug.WriteLine(msg);
#endif

         InitializeWorkspace();

         InitialazeCommandCollection();
      }

      /// <summary>
      /// Инициализирует элементы рабочего пространства.
      /// </summary>
      private void InitializeWorkspace()
      {
         if (WorkspaceTypes == null)
         {
            WorkspaceTypes = new Dictionary<string, TabCounter>();
         }

         AddWorkspaceType(nameof(TabItemSampleViewModel), TabCounter.MaxCountDefault);
         AddWorkspaceType(nameof(TabItemLogViewModel), 1);

         if (Workspaces == null)
         {
            Workspaces = new ObservableCollection<IWorkspaceViewModel>();
         }

         App.MainViewModel = this;
      }

      /// <summary>
      /// Добавляет тип рабочего пространства в коллекцию типов вкладок.
      /// </summary>
      /// <param name="name">Строка с именем типа.</param>
      /// <param name="maxCount">Число, содержащее максимально допустимое количество вкладок данного типа.</param>
      private void AddWorkspaceType(string name, int maxCount)
      {
         if (!WorkspaceTypes.ContainsKey(name))
         {
            WorkspaceTypes.Add(name, new TabCounter(maxCount));
         }
      }

      /// <summary>
      /// Инициализирует коллекцию команд. Подписка на события.
      /// </summary>
      private void InitialazeCommandCollection()
      {
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

         this[ViewModelCommands.CreateTabSampleCommand].Executed += (sender, args) => ViewModelCommands.CreateTab(typeof(TabItemSampleViewModel));

         this[ViewModelCommands.LogShowCommand].Executed += (sender, args) => ViewModelCommands.CreateTab(typeof(TabItemLogViewModel));

         this[ViewModelCommands.CloseAllTabsCommand].Executed += (sender, args) => ViewModelCommands.CloseAllTabs(sender, args);

         this[ViewModelCommands.CloseTabCommand].Executed += (sender, args) => ViewModelCommands.CloseTab(sender, args);

         this[ViewModelCommands.CloseOtherSameTabsCommand].Executed += (sender, args) => ViewModelCommands.CloseOtherSameTabs(sender, args);

         this[ViewModelCommands.CloseAllSameTabsCommand].Executed += (sender, args) => ViewModelCommands.CloseAllSameTabs(sender, args);

         this[ViewModelCommands.CloseOtherTabsCommand].Executed += (sender, args) => ViewModelCommands.CloseOtherTabs(sender, args);

         App.Log.LogEvents.CollectionChanged += (sender, args) => GetLastLogedMessage();
      }

      /// <summary>
      /// Считывает последнее сообщение из журнала.
      /// </summary>
      private void GetLastLogedMessage()
      {
#if DEBUG
         Debug.WriteLine(message: $"Отладка: {DebugExtension.GetCallerMemberName(this)} executed. ");
#endif
         LastEventMessage = App.Log.LastEvent.Message;
      }

      /// <summary>
      /// Задает указанный элемент в качестве System.ComponentModel.ICollectionView.CurrentItem в представлении.
      /// </summary>
      /// <param name="workspace">Вкладка рабочего пространства, которая будет выбрана в качестве текущей.</param>
      internal void SetActiveWorkspace(WorkspaceViewModel workspace)
      {
         Debug.Assert(Workspaces.Contains(workspace));
         bool result = false;

         ICollectionView collectionView = CollectionViewSource.GetDefaultView(Workspaces);
         if (collectionView != null)
            result = collectionView.MoveCurrentTo(workspace);

#if DEBUG
         Debug.WriteLine(message: $"Отладка: {DebugExtension.GetCallerMemberName(this)} executed. "
                                  + $"\n\tCurrentItem Type is {collectionView.CurrentItem.GetType()}. "
                                  + $"\n\tworkspace.IsSelected is {workspace.IsSelected}"
                                  + $"\n\tworkspace.Uid is {workspace.Uid}"
                                  + $"\n\tResult is {result}")
         ;
#endif
      }

      #endregion Methods
   }
}
