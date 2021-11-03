using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace QuikTrade.Utilities.Converters
{
   /// <summary>
   /// Конвертор формирующий контент вкладки.
   /// </summary>
   /// <remarks>>author: Роман Мейтес</remarks>
   /// <version>1.0..* : 1.0..*</version>
   public class TabItemConverter : DependencyObject, IMultiValueConverter
   {
      #region Fields
      /// <summary>
      /// Содержание вкладки как свойство зависимости.
      /// </summary>
      public static readonly DependencyProperty VisualContentProperty =
          DependencyProperty.Register("VisualContent", typeof(object), typeof(TabItemConverter), new PropertyMetadata(null));

      #endregion Fields

      #region Properties

      /// <summary>
      /// Содержание вкладки.
      /// </summary>
      public object VisualContent
      {
         get => GetValue(VisualContentProperty);
         set => SetValue(VisualContentProperty, value);
      }

      #endregion Properties

      #region Methods
      #region IMultiValueConverter Memebers

      /// <summary>
      /// Формирует визуальное представление вкладки при переключении.
      /// </summary>
      /// <param name="values">Массив значений, создаваемый исходными привязками в System.Windows.Data.MultiBinding.</param>
      /// <param name="targetType">Тип целевого свойства привязки.</param>
      /// <param name="parameter">Используемый параметр преобразователя.</param>
      /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
      /// <returns>Результат логического умножения над элементами массива.</returns>
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
         if (values.Length == 2 && values[0] is int selectedIndex && values[1] is TabControl tabControl)
         {
            if (tabControl.ItemContainerGenerator.ContainerFromIndex(selectedIndex) is TabItem tabItem)
            {
               object content = tabItem.GetValue(VisualContentProperty);
               if (content == null)
               {
                  content = new ContentControl
                  {
                     Content = tabItem.Content,
                     ContentTemplate = tabControl.ContentTemplate,
                     ContentTemplateSelector = tabControl.ContentTemplateSelector
                  };
                  tabItem.SetValue(VisualContentProperty, content);
               }
               return content;
            }
         }
         return null;
      }

      /// <summary>
      /// Обратное преобразование не предусмотрено.
      /// </summary>
      /// <param name="value">Значение, произведенное целевым объектом привязки.</param>
      /// <param name="targetTypes">Целевой массив байтов преобразования.</param>
      /// <param name="parameter">Используемый параметр преобразователя.</param>
      /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
      /// <returns>Вызывает исключение <see cref="NotImplementedException"/></returns>
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
      {
         throw new NotImplementedException();
      }

      #endregion IMultiValueConverter Memebers
      #endregion Methods
   }
}
