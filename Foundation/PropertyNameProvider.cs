//source:   https://habrahabr.ru/post/208326/
//author:   poemmuse
//release:  7 января 2014
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace Foundation
{
   [DataContract]
   public class PropertyNameProvider
   {
      public static string GetPropertyName<T>(Expression<Func<T>> expression)
      {
         var memberExpression = expression.Body as MemberExpression;

         if (expression.Body is UnaryExpression unaryExpression)
            memberExpression = unaryExpression.Operand as MemberExpression;

         if (memberExpression == null || memberExpression.Member.MemberType != MemberTypes.Property)
            throw new Exception("Invalid lambda expression format.");

         return memberExpression.Member.Name;
      }
   }
}
