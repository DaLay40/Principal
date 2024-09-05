using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.Classes;

namespace Utilitarios.Modelo
{
    public static class DbHelper
    {

        private static DbConection Conection = new DbConection();

        public static void ExecuteQueryNoReturn(string query,Hashtable param)
        {
            Conection.ExecuteScalar(query, param);
        }

        public static List<Type> GetTable<Type>(string query, Hashtable param)
        {

            DataTable dt = Conection.GetDataTable(query, param,false);
            return Util.MontarLista<Type>(dt);
        }

        public static List<Type> Select<Type>(Expression<Func<Type, bool>> expression = null)
        {
            string query = Util.GetSelectComand<Type>();

            if (expression != null)
                query += "WHERE "+ ParseExpression(expression.Body,"");
            
            return DbHelper.GetTable<Type>(query, null);
        }

        private static string GetOperator(ExpressionType expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    return "=";
                case ExpressionType.NotEqual:
                    return "!=";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                default:
                    return expressionType.ToString();
            }
        }
        
        private static string ParseExpression(Expression expression,string str)
        {
            if (expression is BinaryExpression binaryExpression)
            {
                if (binaryExpression.NodeType == ExpressionType.AndAlso || binaryExpression.NodeType == ExpressionType.OrElse)
                {
                    str = ParseExpression(binaryExpression.Left, str);
                    str +=  binaryExpression.NodeType == ExpressionType.AndAlso ? " AND " : " OR ";
                    str = ParseExpression(binaryExpression.Right, str);
                }
                else
                {
                    var left = binaryExpression.Left as MemberExpression;
                    string propertyName = left?.Member.Name;

                    string operador = GetOperator(binaryExpression.NodeType);

                    var right = Expression.Lambda(binaryExpression.Right).Compile().DynamicInvoke();

                    str += $"{ propertyName} { operador} '{right}'";
                }
            }
            return str;
        }

    }
}
