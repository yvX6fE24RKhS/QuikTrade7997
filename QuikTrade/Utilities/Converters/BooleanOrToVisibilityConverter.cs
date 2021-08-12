using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Конвертор реализующий логическое сложение и преобразование резултата в значение перчисления <see cref="Visibility"/>.
   /// </summary>
   /// <see href="https://askdev.ru/q/c-wpf-isenabled-s-ispolzovaniem-neskolkih-privyazok-76540/"/>
   /// <version>1.0..* : none</version>
   internal class BooleanOrToVisibilityConverter : IMultiValueConverter
   {
      #region Properties

      /// <summary>
      /// Состояние отображения элемента.
      /// </summary>
      public Visibility HiddenVisibility { get; set; }

      /// <summary>
      /// Определяет, нужно ли инвертировать результат преобразования.
      /// </summary>
      public bool IsInverted { get; set; }

      #endregion Properties

      #region Constructors

      /// <summary>
      /// Инициализирует новый экземпляр класса <see cref="BooleanOrToVisibilityConverter"/>
      /// </summary>
      public BooleanOrToVisibilityConverter()
      {
         this.HiddenVisibility = Visibility.Collapsed;
         this.IsInverted = false;
      }

      #endregion Constructors

      #region Methods
      #region IMultiValueConverter Memebers

      /// <summary>
      /// Выполняет логическое сложение над элементами массива.
      /// </summary>
      /// <param name="values">Массив значений, создаваемый исходными привязками в System.Windows.Data.MultiBinding.</param>
      /// <param name="targetType">Тип целевого свойства привязки.</param>
      /// <param name="parameter">Используемый параметр преобразователя.</param>
      /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
      /// <returns>Значение перчисления <see cref="Visibility"/> как результат логического сложения над элементами массива .</returns>
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
         bool flag = values.OfType<IConvertible>().Any(System.Convert.ToBoolean);
         if (this.IsInverted)
            flag = !flag;
         return flag ? Visibility.Visible : this.HiddenVisibility;
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