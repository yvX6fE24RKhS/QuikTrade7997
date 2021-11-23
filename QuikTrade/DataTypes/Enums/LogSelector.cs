using QuikTrade.Utilities.Converters;
using System.ComponentModel;
using System.Xml.Serialization;

namespace QuikTrade.DataTypes.Enums
{
   /// <summary>
   /// Перечисление значений переключателя журналов.
   /// </summary>
   /// <version>1.0..* : 1.0..*</version>
   [TypeConverter(typeof(EnumDescriptionTypeConverter))]
   public enum LogSelector
   {
      /// <summary> Журнал текущей сессии. </summary>
      [XmlEnum(Name = "current")]
      [Description("текущая сессия")]
      current,

      /// <summary> Журнал на выбранную дату. </summary>
      [XmlEnum(Name = "dated")]
      [Description("выбрать дату")]
      dated
   }
}
