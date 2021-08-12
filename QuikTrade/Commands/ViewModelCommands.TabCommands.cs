using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuikTrade.Utilities;
using QuikTrade.ViewModels;

namespace QuikTrade.Commands
{
   /// <summary>
   /// Команды модели представления.
   /// </summary>
   /// <version>1.0..* : none</version>
   public partial class ViewModelCommands
   {
      #region Methods

      /// <summary>
      /// Открывает новую вкладку
      /// </summary>
      /// <param name="itemType">Тип вкладки (рабочего пространства).</param>
      public static void CreateTab(Type itemType)
      {
         MainViewModel viewModel = App.MainViewModel;

         string logMsg;
#if DEBUG
         //string msg = $"sender: {sender.ToString()}\nRoutedEventArgs: {e.ToString()}\ne.Source: {e.Source.ToString()}\n(e.OriginalSource as FrameworkElement).Name: {(e.OriginalSource as FrameworkElement).Name}\ne.RoutedEvent.Name: {e.RoutedEvent.Name}\ne.OriginalSource: {e.OriginalSource}\ne.Handled: {e.Handled}\ne.GetHashCode: {e.GetHashCode()}\ne.Source.GetType(): {e.Source.GetType()}";
         string msg = $"Отладка: CreateTab executed." +
         $"\n\tviewModel.ToString(): {viewModel}" +
         $"\n\tviewModel.WorkspaceTypes[key]: {viewModel.WorkspaceTypes[itemType.Name]}" +
         $"\n\titemType.Name (aka key): {itemType.Name}" +
         $"\n\tviewModel.WorkspaceTypes[key].Count: {viewModel.WorkspaceTypes[itemType.Name].Count}" +
         $"\n\tviewModel.WorkspaceTypes[key].MaxCount: {viewModel.WorkspaceTypes[itemType.Name].MaxCount}" +
         $"\n\tviewModel.WorkspaceTypes.ContainsKey(key): {viewModel.WorkspaceTypes.ContainsKey(itemType.Name)}\n";
         System.Diagnostics.Debug.WriteLine(msg);
#endif
         try
         {
            //получаем имя типа
            string key = itemType.Name;

            if (itemType != null && viewModel.WorkspaceTypes.ContainsKey(key))
            {
               if (viewModel.WorkspaceTypes[key].Count < viewModel.WorkspaceTypes[key].MaxCount)
               {
                  //получаем конструктор
                  System.Reflection.ConstructorInfo ci = itemType.GetConstructor(new Type[] { });

                  //вызываем конструтор для создания экземпляра объекта требуемого типа 
                  object obj = ci.Invoke(new object[] { });

                  //увеличиваем счетчик однотипных вкладок
                  viewModel.WorkspaceTypes[key].Count += 1;

                  //присваиваем вкладке идениификатор
                  ((WorkspaceViewModel)obj).Uid = Guid.NewGuid();

                  //делаем вкладку активной
                  ((WorkspaceViewModel)obj).IsSelected = true;

                  //добавляем вкладку в коллекцию
                  if (viewModel.Workspaces == null)
                     viewModel.Workspaces = new ObservableCollection<WorkspaceViewModel>();
                  viewModel.Workspaces.Add((WorkspaceViewModel)obj);

                  //устанавливаем представление текущим.
                  viewModel.SetActiveWorkspace((WorkspaceViewModel)obj);

                  //Запись для журнала
                  logMsg = $"Создана новая вкладка типа [{itemType.Name}] UID {((WorkspaceViewModel)obj).Uid}.";
               }
               else
               {
                  //DEBUG MessageBox.Show($"SelectedTab: {SelectedTab.GetType().ToString()}\n");
                  if (viewModel?.SelectedTab?.GetType() != itemType)
                  {
                     var select = viewModel.Workspaces.Where(i => i.GetType() == itemType).ToList();
                     viewModel.SelectedTab = select[0];
                     select[0].IsSelected = true;
                  }

                  if (viewModel.WorkspaceTypes[key].MaxCount != 1)
                  {
                     MessageBox.Show("Открыто максимальное количество вкладок данного типа.\nЗакройте лишние.");
                  }

                  //Запись для журнала
                  logMsg = $"Новая вкладка типа [{itemType.Name}] не создана. Превышено максимально допустимое количество.";
               }

               App.Log.Append(
                  viewModel,
                  new EventInfo(
                     init: Initiator.app,
                     evnt: "CreateTab",
                     msg: logMsg
                  )
               );
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(exception.Message);
         }
      }

      /// <summary>
      /// Закрывает все вкладки
      /// </summary>
      internal static void CloseAllTabs()
      {
         MainViewModel viewModel = App.MainViewModel;

         if (MessageBox.Show("Закрыть все вкладки?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
         {
            viewModel.Workspaces.ToList().All(i => viewModel.Workspaces.Remove(i));

            foreach (KeyValuePair<string, TabCounter> item in viewModel.WorkspaceTypes)
            {
               item.Value.Count = 0;
            }

            App.Log.Append(
               viewModel,
               new EventInfo(
                  init: Initiator.app,
                  evnt: "CloseTab",
                  msg: "Все вкладки закрыты."
               )
            );
         }
      }

      /// <summary>
      /// Закрывает вкладку
      /// </summary>
      /// <param name="sender">Объект, создавший событие.</param>
      /// <param name="e">Аргументы события.</param>
      internal static void CloseTab(object sender, RoutedEventArgs e)
      {
#if DEBUG
         //string msg = $"sender: {sender.ToString()}\nRoutedEventArgs: {e.ToString()}\ne.Source: {e.Source.ToString()}\n(e.OriginalSource as FrameworkElement).Name: {(e.OriginalSource as FrameworkElement).Name}\ne.RoutedEvent.Name: {e.RoutedEvent.Name}\ne.OriginalSource: {e.OriginalSource}\ne.Handled: {e.Handled}\ne.GetHashCode: {e.GetHashCode()}\ne.Source.GetType(): {e.Source.GetType()}";
         string msg = $"\ne.Source: {e.Source}\n"
                      + $"e.Source.GetType().ToString(): {e.Source.GetType()}\n"
                      + $"((Control)e.Source).DataContext.ToString(): {((Control)e.Source).DataContext}\n"
                      + $"((Control)e.Source).DataContext.GetType().ToString(): {((Control)e.Source).DataContext.GetType()}\n"
         ;
         System.Diagnostics.Debug.WriteLine(msg);
         //DEBUG MessageBox.Show($"Uid: {tabItem.Uid.ToString()}\n");
#endif

         // ищем родительскую вкладку
         TabItem tabItem = GetTabItem(e);

         if (tabItem != null)
         {
            string logMsg = $"Вкладка типа [{tabItem.DataContext.GetType().Name}] UID {tabItem.Uid} закрыта.";

            MainViewModel viewModel = (MainViewModel)(((Control)(e.Source)).DataContext);

            List<WorkspaceViewModel> workspaces = viewModel.Workspaces
               .Where(i => i.Uid.ToString() == tabItem.Uid.ToString())
               .ToList()
            ;

            CloseTabs(viewModel, workspaces);

            App.Log.Append(
               viewModel,
               new EventInfo(
                  init: Initiator.app,
                  evnt: "CloseTab",
                  msg: logMsg
               )
            );
         }
      }

      /// <summary>
      /// Возвращает родительскую вкладку элемента вызвавшего событие.
      /// </summary>
      /// <param name="e">Аргументы события.</param>
      /// <returns>Вкладка, содержащая элемент вызвавший событие.</returns>
      private static TabItem GetTabItem(RoutedEventArgs e)
      {
         return (e.OriginalSource is TabItem tabItem)
            ? tabItem
            : ControlExtension.FindParent<TabItem>((Control)e.OriginalSource)
         ;
      }

      /// <summary>
      /// Закрывает вкладки из списка.
      /// </summary>
      /// <param name="viewModel">Модель представления содержащая вкладки.</param>
      /// <param name="workspaces">Список вкладок.</param>
      private static void CloseTabs(MainViewModel viewModel, List<WorkspaceViewModel> workspaces)
      {
         foreach (WorkspaceViewModel workspace in workspaces)
         {
            viewModel.WorkspaceTypes[workspace.GetType().Name].Count -= 1;
            viewModel.Workspaces.Remove(workspace);
         }
      }

      #endregion Methods
   }
}
