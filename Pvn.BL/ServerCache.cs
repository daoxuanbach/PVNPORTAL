using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Pvn.BL
{
   public class ServerCache
    {
        public static void Insert(string key, object value)
        {
            HttpContext.Current.Cache.Insert(key, value, null, DateTime.Now.AddDays(30), Cache.NoSlidingExpiration);
            //HttpContext.Current.Cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, TimeSpan.FromDays(1));
        }
        public static object Get(string key)
        {
            return HttpContext.Current.Cache.Get(key);
        }
        public static object Remove(string key)
        {
            return HttpContext.Current.Cache.Remove(key);
        }
        public static void RemoveAll()
        {
            IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                HttpContext.Current.Cache.Remove(enumerator.Key.ToString());
            }
        }
        public static CacheTable GetAll()
        {
            CacheTable tblCache = new CacheTable();

            IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                DataRow row = tblCache.NewRow();
                row[CacheTable.Key] = enumerator.Key.ToString();
                row[CacheTable.Type] = enumerator.GetType().FullName;

                tblCache.Rows.Add(row);
            }
            tblCache.AcceptChanges();
            return tblCache;
        }
    }
    public class CacheTable : DataTable
    {
        public const string Key = "Key";
        public const string Type = "Type";
        public const string STT = "STT";

        public CacheTable()
        {
            this.TableName = "Cache";
            this.Columns.Add(new DataColumn(Key, typeof(String)));
            this.Columns.Add(new DataColumn(Type, typeof(String)));
            this.Columns.Add(new DataColumn(STT, typeof(Int32)));
            this.Columns[STT].AutoIncrement = true;
            this.Columns[STT].AutoIncrementSeed = 1;
        }
    }
}
