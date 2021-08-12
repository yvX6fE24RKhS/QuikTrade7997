using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Foundation;
using QuikTrade.Commands;
using QuikTrade.Utilities;


namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Модель представления основного окна.
   /// </summary>
   /// <version>1.0..* : 1.0.7878.*</version>
   [DataContract]
   [KnownType(typeof(TabItemSampleViewModel))]
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

      #region Workspaces

      /// <summary>
      /// Коллекция типов вкладок.
      /// </summary>
      [DataMember]
      public Dictionary<string, TabCounter> WorkspaceTypes
      {
         get { return Get(() => this.WorkspaceTypes); }
         set { Set(() => this.WorkspaceTypes, value); }
      }

      /// <summary>
      /// Коллекция открытых вкладок.
      /// </summary>
      [DataMember]
      public ObservableCollection<WorkspaceViewModel> Workspaces
      {
         get { return Get(() => this.Workspaces); }
         set { Set(() => this.Workspaces, value); }
      }

      /// <summary>
      /// Активная вкладка
      /// </summary>
      [DataMember]
      public WorkspaceViewModel SelectedTab
      {
         get { return Get(() => this.SelectedTab); }
         set { Set(() => this.SelectedTab, value); }
      }

      #endregion Workspaces
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
         InitializeWorkspace();

         InitialazeCommandCollection();

         App.MainViewModel = this;
      }

      /// <summary>
      /// Инициализирует элементы рабочего пространства.
      /// </summary>
      private void InitializeWorkspace()
      {
         if (this.WorkspaceTypes == null)
         {
            this.WorkspaceTypes = new Dictionary<string, TabCounter>();
         }

         if (!this.WorkspaceTypes.ContainsKey(typeof(TabItemSampleViewModel).Name))
         {
            this.WorkspaceTypes.Add(typeof(TabItemSampleViewModel).Name, new TabCounter());
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

         this[ViewModelCommands.LogShowCommand].Executed += (sender, args) => ViewModelCommands.LogShow();

         this[ViewModelCommands.CreateTabSampleCommand].Executed += (sender, args) => ViewModelCommands.CreateTab(typeof(TabItemSampleViewModel));

         this[ViewModelCommands.CloseAllTabsCommand].Executed += (sender, args) => ViewModelCommands.CloseAllTabs();

         this[ViewModelCommands.CloseTabCommand].Executed += (sender, args) => ViewModelCommands.CloseTab(sender, args);

         //this[ViewModelCommands.CloseOtherSameTabsCommand].Executed += (sender, args) => ViewModelCommands.CloseOtherSameTabs(sender, args);

         //this[ViewModelCommands.CloseAllSameTabsCommand].Executed += (sender, args) => ViewModelCommands.CloseAllSameTabs(sender, args);

         
      }

      /// <summary>
      /// Задает указанный элемент в качестве System.ComponentModel.ICollectionView.CurrentItem в представлении.
      /// </summary>
      /// <param name="workspace">Вкладка рабочего пространства, которая будет выбрана в качестве текущей.</param>
      internal void SetActiveWorkspace(WorkspaceViewModel workspace)
      {
         Debug.Assert(this.Workspaces.Contains(workspace));
         bool result = false;

         ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
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
