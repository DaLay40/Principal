using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.Enumerators;
using System.Management;
using Utilitarios.Extencions;
using Utilitarios.Entidades;
using Utilitarios.Modelo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using Utilitarios.CustomAttributes;
using DevExpress.LookAndFeel;

namespace Utilitarios.Classes
{
    public static class Util
    {

        public static Computador oComputador;

        public static List<KeyValuePair<string, int>> GetDataSource(Type enumType)
        {
            if (enumType == null || !enumType.IsEnum)
                throw new MyExeption("Não foi possível obter o GetDataDource", ETipoException.Erro);

            List<KeyValuePair<string, int>> lista = new List<KeyValuePair<string, int>>();
            Array EnumValues = Enum.GetValues(enumType);

            foreach (Enum en in EnumValues)
            {
                KeyValuePair<string, int> kv = new KeyValuePair<string, int>(en.Descricao(), Convert.ToInt32(en));
                lista.Add(kv);
            }
            return lista;
        }

        public static Image GetImage(byte[] array)
        {
            MemoryStream oStreamImagem = new MemoryStream();
            oStreamImagem.Write(array, 0, array.Length);
            return System.Drawing.Image.FromStream(oStreamImagem);
        }


        public static List<Tipo> MontarLista<Tipo>(DataTable dt)
        {
            List<Tipo> list = new List<Tipo>();
            foreach (DataRow row in dt.Rows) list.Add(MapType<Tipo>(row));
            return list;
        }

        public static Tipo MapType<Tipo>(DataRow row)
        {
            Tipo resultObj = CriarInstancia<Tipo>();

            foreach (var item in resultObj.GetType().GetRuntimeProperties())
            {
                if (!row.ExistsAndIsNotNull(item.Name)) continue;

                Type tipo = item.PropertyType;
                Type tipoSubjacente = Nullable.GetUnderlyingType(tipo) ?? tipo;

                var valor = row[item.Name];
                if (Nullable.GetUnderlyingType(tipo) != null && tipo != typeof(string))
                    valor = Activator.CreateInstance(typeof(Nullable<>).MakeGenericType(tipoSubjacente), valor ?? GetDefaultValue(tipoSubjacente));

                if (tipo == typeof(string))
                    item.SetValue(resultObj, valor.ToString());
                else
                    item.SetValue(resultObj, valor);

            }
            return resultObj;
        }

        public static object GetDefaultValue(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            else
            {
                return null;
            }
        }

        public static Tipo CriarInstancia<Tipo>(params object[] parametros)
        {
            return (Tipo)Activator.CreateInstance(typeof(Tipo), parametros);
        }

        public static bool ExistsAndIsNotNull(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
                return false;

            return row[columnName] != DBNull.Value;
        }

        public static string ValueToString(this DataRow row, string columnName, string defaulValue)
        {
            string value = defaulValue;

            if (row.ExistsAndIsNotNull(columnName))
                value = row[columnName].ToString();

            return value;
        }

        public static string ValueToString(this DataRow row, string columnName)
        {
            return row.ValueToString(columnName, null);
        }

        public static int ValueToInt(this DataRow row, string columnName, int defaulValue)
        {
            int value = defaulValue;

            if (row.ExistsAndIsNotNull(columnName))
                int.TryParse(row[columnName].ToString(), out value);

            return value;
        }

        public static int ValueToInt(this DataRow row, string columnName)
        {
            return row.ValueToInt(columnName, 0);
        }

        public static float ValueToFloat(this DataRow row, string columnName, float defaulValue)
        {
            float value = defaulValue;

            if (row.ExistsAndIsNotNull(columnName))
                float.TryParse(row[columnName].ToString(), out value);

            return value;
        }

        public static float ValueToFloat(this DataRow row, string columnName)
        {
            return row.ValueToFloat(columnName, 0);
        }

        public static decimal ValueToDecimal(this DataRow row, string columnName, decimal defaulValue)
        {
            decimal value = defaulValue;

            if (row.ExistsAndIsNotNull(columnName))
                decimal.TryParse(row[columnName].ToString(), out value);

            return value;
        }

        public static decimal ValueToDecimal(this DataRow row, string columnName)
        {
            return row.ValueToDecimal(columnName, 0);
        }

        public static byte[] ValueToByteArray(this DataRow row, string columnName, byte[] defaulValue)
        {
            byte[] value = defaulValue;

            if (row.ExistsAndIsNotNull(columnName))
                value = (byte[])row[columnName];

            return value;
        }

        public static byte[] ValueToByteArray(this DataRow row, string columnName)
        {
            return row.ValueToByteArray(columnName, new byte[0]);
        }

        public static bool ValueToBool(this DataRow row, string columnName)
        {
            bool value = false;

            if (row.ExistsAndIsNotNull(columnName))
                bool.TryParse(row[columnName].ToString(), out value);

            return value;
        }

        public static DateTime ValueToDateTime(this DataRow row, string columnName)
        {
            //DateTime value = default;
            DateTime value = DateTime.MinValue;

            if (row.ExistsAndIsNotNull(columnName))
                DateTime.TryParse(row[columnName].ToString(), out value);

            return value;
        }


        public static Color GetColor(string color)
        {
            Color ColorRetorno = Color.Empty;
            if (color == "") return ColorRetorno;
            if (color.Contains(","))
            {
                string[] argb = color.Split(',');
                if (argb.Count() == 3)
                {
                    int r = Convert.ToInt32(argb[0]);
                    int g = Convert.ToInt32(argb[1]);
                    int b = Convert.ToInt32(argb[2]);
                    ColorRetorno = Color.FromArgb(r, g, b);
                }
            }
            else
            {
                ColorRetorno = Color.FromName(color);
            }
            return ColorRetorno;
        }

        public static void RegistrarComputador()
        {

            string systemDrive = Environment.GetEnvironmentVariable("SystemDrive")?.Replace("\\", "");
            string numeroSerie = "";
            if (systemDrive != null)
            {
                ManagementObjectSearcher partitionSearcher = new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" + systemDrive + "'} " +
                    "WHERE AssocClass=Win32_LogicalDiskToPartition");

                foreach (ManagementObject partition in partitionSearcher.Get())
                {
                    ManagementObjectSearcher diskSearcher = new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} " +
                        "WHERE AssocClass=Win32_DiskDriveToDiskPartition");

                    foreach (ManagementObject disk in diskSearcher.Get())
                    {
                        numeroSerie = disk["SerialNumber"].ToString();
                    }
                }
                string computerName = Environment.MachineName;

                Computador comp = new Computador() { Nome = computerName, NumeroSerie = numeroSerie,UltimoAcesso = DateTime.Now };
                List<Computador> compExists = DbHelper.Select<Computador>(x => x.NumeroSerie == comp.NumeroSerie);

                if (compExists.Count > 0)
                {
                    comp.Id = compExists[0].Id;
                    comp.Update();
                    oComputador = DbHelper.Select<Computador>(x => x.NumeroSerie == comp.NumeroSerie).Single();

                }
                else
                {
                    comp.Insert();
                    oComputador = DbHelper.Select<Computador>(x => x.NumeroSerie == comp.NumeroSerie).Single();
                }
                if(DbHelper.Select<SituacaoTitulos>(x => x.IdComputador == oComputador.Id).Count == 0)
                {
                    InsertInTableSituacoes();
                }
            }

        }

        public static (string query,Hashtable param) MontarInsert<Tipo>(Tipo obj)
        {
            string query = "INSERT INTO " + obj.GetType().Name + " ";
            string coloumns = "";
            string values = "";
            Hashtable param = new Hashtable();
            foreach (var item in obj.GetType().GetRuntimeProperties())
            {
                if (item.Name == "Id") continue;
                if (item.GetMethod.IsVirtual || item.SetMethod.IsVirtual) continue;

                if (coloumns == "") coloumns = "(" + item.Name;
                else coloumns += "," + item.Name;

                if (values == "") values = "(" + "@" + item.Name;
                else values += "," + "@" + item.Name;

                param.Add("@" + item.Name, item.GetValue(obj));
            }

            coloumns += ") ";
            values += ") ";

            query += coloumns + " VALUES " + values;

            return (query, param);

        }

        public static string GetSelectComand<Tipo>()
        {
            return $"SELECT * FROM {typeof(Tipo).Name} (NOLOCK) ";
        }

        public static (string query, Hashtable param) MontarUpdate<Tipo>(Tipo obj)
        {
            string query = "UPDATE " + obj.GetType().Name + " ";
            string values = "";
            string where = "";
            Hashtable param = new Hashtable();
            foreach (var item in obj.GetType().GetRuntimeProperties())
            {
                if (item.GetMethod.IsVirtual || item.SetMethod.IsVirtual) continue;
                param.Add("@" + item.Name, item.GetValue(obj));
                if (item.Name == "Id")
                {
                    where = $"WHERE Id = @{item.Name}";
                    continue;
                }

                if (values == "") values = $"SET {item.Name} = @{item.Name} ";
                else values += $", {item.Name} = @{item.Name} ";
            }

            query += values + where;

            return (query, param);

        }

        public static void InsertInTableSituacoes()
        {
            List<KeyValuePair<string, int>> lista = GetDataSource(typeof(ESituacaoTitulo));

            foreach(KeyValuePair<string, int> obj in lista)
            {
                SituacaoTitulos situacao = new SituacaoTitulos();
                situacao.Enumerator = obj.Value;
                situacao.Descricao = obj.Key;
                situacao.BackColor1 = GetColorSituacaoPadrao((ESituacaoTitulo)situacao.Enumerator).GetRgbStringColor();
                situacao.BackColor2 = GetColor("White").GetRgbStringColor();
                situacao.ForeColor = GetColor("Black").GetRgbStringColor();
                situacao.BorderColor = GetColor("").GetRgbStringColor();
                situacao.IdComputador = oComputador.Id.Value;
                situacao.Insert();
            }

        }

        public static AppearanceObjectEx SetFormatRuleAparence(this GridView grid, string NameFormatRule) => grid.FormatRules.Where(x => x.Name == NameFormatRule).First().RuleCast<FormatConditionRuleValue>().Appearance;

        public static void SetFormatRulesSituacoes(this GridView grid)
        {
            List<SituacaoTitulos> situacoes = DbHelper.Select<SituacaoTitulos>(x => x.IdComputador == oComputador.Id);

            foreach(SituacaoTitulos situacao in situacoes)
            {
                grid.FormatRules.AddValueRule(grid.Columns.Where(x => x.Name == "gridColumnSituacao").First(), new AppearanceDefault(GetColor("Black"), GetColor(situacao.BackColor1), GetColor(""), GetColor("White")), FormatCondition.Equal, situacao.Enumerator).ApplyToRow = true;
            }
        }

        public static Color GetColorSituacaoPadrao(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (SituacaoTituloAttibute)Attribute.GetCustomAttribute(field, typeof(SituacaoTituloAttibute));
            return GetColor(attribute.Color);
        }

        public static string GetRgbStringColor(this Color color)
        {

            if (color == Color.Empty) return "";

            string rgbString = "";

            rgbString += color.R.ToString() + ", ";
            rgbString += color.G.ToString() + ", ";
            rgbString += color.B.ToString();

            return rgbString;

        }

        public static List<string> GetThems()
        {
            List<string> lista = new List<string>();
            Type tipo = typeof(SkinStyle);

            FieldInfo[] campos = tipo.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo campo in campos)
            {
                lista.Add(campo.Name);
            }
            return lista;
        }

    }
}
