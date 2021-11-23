using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace QuikTrade.Utilities.Converters
{
   /// <summary>
   /// Конвертор реализующий сравнение целых чисел и преобразование резултата в значение перчисления <see cref="Visibility"/>.
   /// </summary>
   /// <version>1.0..* : 1.0..*</version>
   internal class IntToVisibilityConverter : IValueConverter
   {
      /// <summary>
      /// Формирует визуальное представление вкладки при переключении.
      /// </summary>
      /// <param name="value">Целое, создаваемое исходными привязками в <see cref="System.Windows.Data.MultiBinding"/>.</param>
      /// <param name="targetType">Тип целевого свойства привязки.</param>
      /// <param name="parameter">Используемый параметр преобразователя.</param>
      /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
      /// <returns>"Элемент перчисления: <c>Visibility.Visible</c>, если <c>value</c> равно <c>parameter</c>; в противном случае <c>Visibility.Hidden</c>.</returns>

      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         int _parValue;

         return value is null
            ? throw new ArgumentNullException(nameof(value))
            : parameter is null
            ? throw new ArgumentNullException(nameof(parameter))
            : int.TryParse(parameter.ToString(), out _parValue) == false
            ? throw new ArgumentException ($"Значение не иожет быть преобразовано в целое. Имя параметра: {nameof(parameter)}")
            : (_parValue == (int)value) ? Visibility.Visible : Visibility.Hidden;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="value"></param>
      /// <param name="targetType"></param>
      /// <param name="parameter"></param>
      /// <param name="culture"></param>
      /// <returns></returns>
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
   }
}
