using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Data;


namespace QuikTrade.ViewModels
{
   [DataContract]
   //[KnownType(typeof(TabItemSampleViewModel))]
   //[KnownType(typeof(BlackPanelViewModel))]
   //[KnownType(typeof(ConnectionStringViewModel))]
   public class MainViewModel : ViewModel
   {
      MainViewModel()
      {
      }

      #region Properties

      #region DockPanelChangeableProperties
      /// <summary>
      /// Ширина главной панели управления
      /// </summary>
      [DataMember]
      public double MainControlPanelWidth
      {
         get { return Get(() => this.MainControlPanelWidth, 80); }
         set { Set(() => this.MainControlPanelWidth, value); }
      }
      #endregion DockPanelChangeableProperties

      #region ControlPanel
      //[DataMember]
      //public ViewModel MainControlPanelDataContext {
      //   get { return Get(() => MainControlPanelDataContext); }
      //   set { Set(() => MainControlPanelDataContext, value); }
      //}

      ///// <summary>
      ///// Список комманд в панели управления
      ///// </summary>
      //[DataMember]
      //public List<RoutedUICommand> MainControlPanelCommands
      //{
      //   get { return Get(() => MainControlPanelCommands); }
      //   set { Set(() => MainControlPanelCommands, value); }
      //}
      #endregion ControlPanel

      #region Workspaces
      ///// <summary>
      ///// Коллекция типов вкладок
      ///// </summary>
      //[DataMember]
      //public Dictionary<string, TabCounter> WorkspaceTypes
      //{
      //   get { return Get(() => WorkspaceTypes); }
      //   set { Set(() => WorkspaceTypes, value); }
      //}

      ///// <summary>
      ///// Коллекция открытых вкладок
      ///// </summary>
      //[DataMember]
      //public ObservableCollection<WorkspaceViewModel> Workspaces
      //{
      //   get { return Get(() => Workspaces); }
      //   set { Set(() => Workspaces, value); }
      //}

      ///// <summary>
      ///// Активная вкладка
      ///// </summary>
      //[DataMember]
      //public WorkspaceViewModel SelectedTab
      //{
      //   get { return Get(() => SelectedTab); }
      //   set { Set(() => SelectedTab, value); }
      //}
      #endregion Workspaces

      #endregion Properties

      #region Methods

//      [OnDeserialized]
//      private void Initialize(StreamingContext streamingContext = default(StreamingContext))
//      {
//#if DEBUG
//         string msg = "Отладка: MainViewModel.Initialize(StreamingContext streamingContext = default(StreamingContext)) executing";
//         System.Diagnostics.Debug.WriteLine(msg);
//#endif
//         this[ApplicationCommands.Close].Executed += (sender, args) => Application.Current.Shutdown();
//         //this[ViewModelCommands.ShowMainControlPanelCommand].Executed += (sender, args) => ShowMainControlPanel(typeof(BlackPanelViewModel)); 
//         //this[ViewModelCommands.CloseAllSameTabsCommand].Executed += (sender, args) => CloseAllSameTabs(sender, args);
//         //this[ViewModelCommands.CloseAllTabsCommand].Executed += (sender, args) => CloseAllTabs();
//         //this[ViewModelCommands.CloseOtherSameTabsCommand].Executed += (sender, args) => CloseOtherSameTabs(sender, args);
//         //this[ViewModelCommands.CloseOtherTabsCommand].Executed += (sender, args) => CloseOtherTabs(sender, args);
//         //this[ViewModelCommands.CloseTabCommand].Executed += (sender, args) => CloseTab(sender, args);
//         //this[ViewModelCommands.CreateTabSampleCommand].Executed += (sender, args) => { CreateTab(typeof(TabItemSampleViewModel)); };
//         //this[ViewModelCommands.CreateTabBlackPanelCommand].Executed += (sender, args) => { CreateTab(typeof(BlackPanelViewModel)); };
//         //this[ViewModelCommands.CreateTabConnectionStringCommand].Executed += (sender, args) => { CreateTab(typeof(ConnectionStringViewModel)); };


//         //if (WorkspaceTypes == null)
//         //{
//         //   WorkspaceTypes = new Dictionary<string, TabCounter>();
//         //}

//         //if (!WorkspaceTypes.ContainsKey(typeof(TabItemSampleViewModel).Name))
//         //{
//         //   WorkspaceTypes.Add(typeof(TabItemSampleViewModel).Name, new TabCounter());
//         //}
//         //if (!WorkspaceTypes.ContainsKey(typeof(BlackPanelViewModel).Name))
//         //{
//         //   WorkspaceTypes.Add(typeof(BlackPanelViewModel).Name, new TabCounter(TabCounter.MaxCountDefault));
//         //}
//         //if (!WorkspaceTypes.ContainsKey(typeof(ConnectionStringViewModel).Name))
//         //{
//         //   WorkspaceTypes.Add(typeof(ConnectionStringViewModel).Name, new TabCounter(1));
//         //}

//      }

      #region WorkspaceCommands

      ///// <summary>
      ///// Открывает новую вкладку
      ///// </summary>
      //private void CreateTab(Type itemType)
      //{
      //   try
      //   {
      //      //получаем имя типа
      //      string key = itemType.Name;

      //      if (itemType != null && WorkspaceTypes.ContainsKey(key))
      //      {
      //         if (WorkspaceTypes[key].Count < WorkspaceTypes[key].MaxCount)
      //         {
      //            //получаем конструктор
      //            System.Reflection.ConstructorInfo ci = itemType.GetConstructor(new Type[] { });

      //            //вызываем конструтор для создания экземпляра объекта требуемого типа 
      //            object obj = ci.Invoke(new object[] { });

      //            //увеличиваем счетчик однотипных вкладок
      //            WorkspaceTypes[key].Count += 1;

      //            //присваиваем вкладке идениификатор
      //            ((WorkspaceViewModel)obj).Uid = Guid.NewGuid();

      //            //делаем вкладку активной
      //            ((WorkspaceViewModel)obj).IsSelected = true;

      //            //добавляем вкладку в коллекцию
      //            if (Workspaces == null)
      //               Workspaces = new ObservableCollection<WorkspaceViewModel>();
      //            Workspaces.Add((WorkspaceViewModel)obj);

      //            //устанавливаем представление текущим.
      //            this.SetActiveWorkspace((WorkspaceViewModel)obj);
      //         }
      //         else
      //         {
      //            //DEBUG                  MessageBox.Show($"SelectedTab: {SelectedTab.GetType().ToString()}\n");
      //            if (SelectedTab.GetType() != itemType)
      //            {
      //               var select = Workspaces.Where(i => i.GetType() == itemType).ToList();
      //               SelectedTab = select[0];
      //               select[0].IsSelected = true;
      //            }
      //            if (WorkspaceTypes[key].MaxCount != 1)
      //            {
      //               MessageBox.Show("Открыто максимальное количество вкладок данного типа.\nЗакройте лишние.");
      //            }
      //         }
      //      }
      //   }
      //   catch (Exception exception)
      //   {
      //      MessageBox.Show(exception.Message);
      //   }
      //}

      ///// <summary>
      ///// Закрывает вкладку
      ///// </summary>
      //private void CloseTab(object sender, RoutedEventArgs e)
      //{
      //   // ищем родительскую вкладку
      //   TabItem tabItem = (e.OriginalSource is TabItem) ? (TabItem)e.OriginalSource : Utilities.ParentControl.FindParent<TabItem>((Control)e.OriginalSource);
      //   if (tabItem != null)
      //   {
      //      //DEBUG  MessageBox.Show($"Uid: {tabItem.Uid.ToString()}\n");
      //      var select = Workspaces.Where(i => i.Uid.ToString() == tabItem.Uid.ToString()).ToList();
      //      foreach (var item in select)
      //      {
      //         WorkspaceTypes[item.GetType().Name].Count -= 1;
      //         Workspaces.Remove(item);
      //      }

      //   }
      //   //DEBUG  MessageBox.Show($"this: {this.ToString()}\nsender: {sender.ToString()}\nRoutedEventArgs: {e.ToString()}\ne.Source: {e.Source.ToString()}\n(e.OriginalSource as FrameworkElement).Name: {(e.OriginalSource as FrameworkElement).Name}\ne.RoutedEvent.Name: {e.RoutedEvent.Name}\ne.OriginalSource: {e.OriginalSource}\ne.Handled: {e.Handled}\ne.GetHashCode: {e.GetHashCode()}\ne.Source.GetType(): {e.Source.GetType()}");
      //}

      ///// <summary>
      ///// Закрывает другие вкладки
      ///// </summary>
      //private void CloseOtherTabs(object sender, RoutedEventArgs e)
      //{
      //   // ищем родительскую вкладку
      //   TabItem tabItem = (e.OriginalSource is TabItem) ? (TabItem)e.OriginalSource : Utilities.ParentControl.FindParent<TabItem>((Control)e.OriginalSource);
      //   if (tabItem != null)
      //   {
      //      var select = Workspaces.Where(i => i.Uid.ToString() != tabItem.Uid.ToString()).ToList();
      //      foreach (var item in select)
      //      {
      //         WorkspaceTypes[item.GetType().Name].Count -= 1;
      //         Workspaces.Remove(item);
      //      }
      //   }
      //}

      ///// <summary>
      ///// Закрывает другие вкладки такого же типа
      ///// </summary>
      //private void CloseOtherSameTabs(object sender, RoutedEventArgs e)
      //{
      //   // ищем родительскую вкладку
      //   TabItem tabItem = (e.OriginalSource is TabItem) ? (TabItem)e.OriginalSource : Utilities.ParentControl.FindParent<TabItem>((Control)e.OriginalSource);
      //   if (tabItem != null)
      //   {
      //      var select = Workspaces.Where(i => i.Uid.ToString() != tabItem.Uid.ToString() && i.GetType().IsAssignableFrom(tabItem.DataContext.GetType())).ToList();
      //      foreach (var item in select)
      //      {
      //         WorkspaceTypes[item.GetType().Name].Count -= 1;
      //         Workspaces.Remove(item);
      //      }
      //   }
      //}

      ///// <summary>
      ///// Закрывает все вкладки такого же типа
      ///// </summary>
      //private void CloseAllSameTabs(object sender, RoutedEventArgs e)
      //{
      //   // ищем родительскую вкладку
      //   TabItem tabItem = (e.OriginalSource is TabItem) ? (TabItem)e.OriginalSource : Utilities.ParentControl.FindParent<TabItem>((Control)e.OriginalSource);
      //   if (tabItem != null)
      //   {
      //      var select = Workspaces.Where(i => i.GetType().IsAssignableFrom(tabItem.DataContext.GetType())).ToList();
      //      foreach (var item in select)
      //      {
      //         WorkspaceTypes[item.GetType().Name].Count -= 1;
      //         Workspaces.Remove(item);
      //      }
      //   }
      //}

      ///// <summary>
      ///// Закрывает все вкладки
      ///// </summary>
      //private void CloseAllTabs()
      //{
      //   if (MessageBox.Show("Закрыть все вкладки?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      //   {
      //      Workspaces.ToList().All(i => Workspaces.Remove(i));

      //      foreach (KeyValuePair<string, TabCounter> item in WorkspaceTypes)
      //      {
      //         item.Value.Count = 0;
      //      }
      //   }
      //}

      #endregion WorkspaceCommands

//      /// <summary>
//      /// Задает указанный элемент в качестве System.ComponentModel.ICollectionView.CurrentItem в представлении.
//      /// </summary>
//      /// <param name="workspace"></param>
//      void SetActiveWorkspace(WorkspaceViewModel workspace)
//      {
//         Debug.Assert(this.Workspaces.Contains(workspace));
//         bool _res = false;

//         ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
//         if (collectionView != null)
//            _res = collectionView.MoveCurrentTo(workspace);

//#if DEBUG
//         Debug.WriteLine(message: $"Отладка: {new DebugExtension().GetCallerMemberName(this)} executed. CurrentItem Type is {collectionView.CurrentItem.GetType()}. Result is {_res.ToString()}");
//#endif

//      }
//      //private void ShowMainControlPanel(Type type)
//      //{

//      //   //MainControlPanel = new BlackPanelViewModel();
//      //}
      #endregion Methods
   }
}
