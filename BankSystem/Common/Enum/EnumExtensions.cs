// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtentions.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Enum
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Extension to sort collection by property name
    /// </summary>
    public static class EnumExtentions
    {
        /// <summary>
        /// Order entities by property name
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="source">Collection of entities</param>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Ordered collection</returns>
        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "OrderBy", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        /// <summary>
        /// Order entities by property name
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="source">Collection of entities</param>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Ordered collection</returns>
        public static IOrderedQueryable<TEntity> OrderByDescending<TEntity>(this IQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "OrderByDescending", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        /// <summary>
        /// Order entities by property name
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="source">Collection of entities</param>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Ordered collection</returns>
        public static IOrderedQueryable<TEntity> ThenBy<TEntity>(this IOrderedQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "ThenBy", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        /// <summary>
        /// Order entities by property name
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="source">Collection of entities</param>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Ordered collection</returns>
        public static IOrderedQueryable<TEntity> ThenByDescending<TEntity>(this IOrderedQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "ThenByDescending", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        /// <summary>
        /// Order entities by property name
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="source">Collection of entities</param>
        /// <param name="sortExpression">Sort expression</param>
        /// <returns>Ordered collection</returns>
        public static IOrderedQueryable<TEntity> OrderUsingSortExpression<TEntity>(this IQueryable<TEntity> source, string sortExpression) where TEntity : class
        {
            string[] orderFields = sortExpression.Split(',');
            IOrderedQueryable<TEntity> result = null;
            for (int currentFieldIndex = 0; currentFieldIndex < orderFields.Length; currentFieldIndex++)
            {
                string[] expressionPart = orderFields[currentFieldIndex].Trim().Split(' ');
                string sortField = expressionPart[0];
                bool sortDescending = (expressionPart.Length == 2) && expressionPart[1].Equals("DESC", StringComparison.OrdinalIgnoreCase);
                if (sortDescending)
                {
                    result = currentFieldIndex == 0 ? source.OrderByDescending(sortField) : result.ThenByDescending(sortField);
                }
                else
                {
                    result = currentFieldIndex == 0 ? source.OrderBy(sortField) : result.ThenBy(sortField);
                }
            }

            return result;
        }

        /// <summary>
        /// Use this extension method to get a DisplayName attribute's value
        /// </summary>
        /// <param name="enumValue">Enumeration item</param>
        /// <returns>Display Name's attribute value</returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            if (fi == null)
            {
                // Data corruption. int read from database is not included in enumeration
                return enumValue.ToString();
            }

            var attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Name;
            }
            else
            {
                return enumValue.ToString();
            }
        }

        /// <summary>
        /// Generate lambda expression by propertyName
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="propertyName">Property name</param>
        /// <param name="resultType">Result type</param>
        /// <returns>Lambda expression</returns>
        private static LambdaExpression GenerateSelector<TEntity>(string propertyName, out Type resultType) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "Entity");
            PropertyInfo property;
            Expression propertyAccess;
            if (propertyName.Contains('.'))
            {
                string[] childProperties = propertyName.Split('.');
                property = typeof(TEntity).GetProperty(childProperties[0], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(TEntity).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }

            resultType = property.PropertyType;
            return Expression.Lambda(propertyAccess, parameter);
        }

        /// <summary>
        /// Generates method call
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="source">Collection of entities</param>
        /// <param name="methodName">Method name</param>
        /// <param name="fieldName">Field name</param>
        /// <returns>Method call expression</returns>
        private static MethodCallExpression GenerateMethodCall<TEntity>(IQueryable<TEntity> source, string methodName, string fieldName) where TEntity : class
        {
            Type type = typeof(TEntity);
            Type selectorResultType;
            LambdaExpression selector = GenerateSelector<TEntity>(fieldName, out selectorResultType);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, selectorResultType }, source.Expression, Expression.Quote(selector));
            return resultExp;
        }
    }
}
