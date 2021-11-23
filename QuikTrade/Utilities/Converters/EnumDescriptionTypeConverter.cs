using System;
using System.ComponentModel;
using System.Reflection;

namespace QuikTrade.Utilities.Converters
{
   /// <summary>
   /// Конвертор, преобразующий атрибуты описания элемента перечисления в текст связанного элемента коллекции элемента управления.
   /// </summary>
   /// <remarks>>author: Brian Logunas</remarks>
   /// <version>1.0..* : 1.0..*</version>
   public class EnumDescriptionTypeConverter : EnumConverter
   {
      #region Constructors

      /// <summary>
      /// Инициализирует новый экземпляр <see cref="EnumDescriptionTypeConverter"/> класса для заданного типа.
      /// </summary>
      /// <param name="type"> Объект System.Type представляющий тип перечисления, связываемый с этим преобразователем перечисления.</param>
      public EnumDescriptionTypeConverter(Type type)
          : base(type)
      {
      }

      #endregion Constructors

      #region Methods

      /// <summary>
      /// Преобразует указанное значение объекта в указанный тип.
      /// </summary>
      /// <param name="context">Объект <see cref="System.ComponentModel.ITypeDescriptorContext"/>, предоставляющий контекст формата.</param>
      /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
      /// <param name="value">Преобразуемый объект <see cref="System.Object"/>.</param>
      /// <param name="destinationType"><see cref="System.Type"/> Преобразуемое значение.</param>
      /// <returns>System.Object Представляющий преобразованный value.</returns>
      public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
      {
         if (destinationType == typeof(string))
         {
            if (value != null)
            {
               FieldInfo fi = value.GetType().GetField(value.ToString());
               if (fi != null)
               {
                  DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                  return ((attributes.Length > 0) && (!string.IsNullOrEmpty(attributes[0].Description))) ? attributes[0].Description : value.ToString();
               }
            }

            return string.Empty;
         }

         return base.ConvertTo(context, culture, value, destinationType);
      }

      #endregion Methods
   }
}
