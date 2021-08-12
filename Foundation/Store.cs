//source:   https://habrahabr.ru/post/208326/
//author:   poemmuse
//release:  7 января 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Foundation
{
   //хранилище свойств вью-модели.
   public static class Store
   {
      #region #Fields

      //словарь свойств вью-модели, которые нужно сериализовать.
      private static readonly Dictionary<Type, object> StoredItemsDictionary = new Dictionary<Type, object>();

      #endregion

      #region #Methods

      //возвращающает статический экземпляр объекта требуемого типа, по возможности десериализуя его.
      public static TItem OfType<TItem>(params object[] args) where TItem : class
      {
         var itemType = typeof(TItem);
         if (StoredItemsDictionary.ContainsKey(itemType))
            return (TItem)StoredItemsDictionary[itemType];

         var hasDataContract = Attribute.IsDefined(itemType, typeof(DataContractAttribute));
         var item = hasDataContract
               ? Serializer.DeserializeDataContract<TItem>() ?? (TItem)Activator.CreateInstance(itemType, args)
               : (TItem)Activator.CreateInstance(itemType, args);

         StoredItemsDictionary.Add(itemType, item);
         return (TItem)StoredItemsDictionary[itemType];
      }

      //делает «снимок» объектов находящихся в контейнере, сериализуя их. Вызов Snapshot в общем случае можно осуществить лишь один раз при закрытии приложения.
      public static void Snapshot()
      {
         StoredItemsDictionary
               .Where(p => Attribute.IsDefined(p.Key, typeof(DataContractAttribute)))
               .Select(p => p.Value).ToList()
               .ForEach(i => i.SerializeDataContract());
      }

      #endregion
   }
}
