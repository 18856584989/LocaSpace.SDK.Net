using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ImportCAD
{
    public static class SRIDReader
    {
        public const string filename = "Resource\\SRID.csv";//坐标系统定义文件相对地址

        //定义坐标WKT结构
        public struct WKTstring {
            //ID
            public int WKID;
            //坐标系统字符串
            public string WKT;
        }

        /// <summary>
        /// 获得SRID.csv中的坐标列表
        /// </summary>
        /// <returns>Enumerator</returns>
        public static IEnumerable<WKTstring> GetSRIDs()
        {
            using (StreamReader sr = File.OpenText(Path.Combine(Application.StartupPath, filename)))
            {
                while (!sr.EndOfStream)//逐条获取并构造WKTstring返回
                {
                    string line = sr.ReadLine();
                    int split = line.IndexOf(';');
                    if (split > -1)
                    {
                        WKTstring wkt = new WKTstring();
                        wkt.WKID = int.Parse(line.Substring(0, split));
                        wkt.WKT = line.Substring(split + 1);
                        yield return wkt;
                    }
                }
                sr.Close();
            }
        }

        /// <summary>
        /// 根据ID获取特定坐标的WKT串
        /// </summary>
        /// <param name="id">EPSG ID</param>
        /// <returns>坐标字符串或者NULL</returns>
        public static string GetCSbyID(int id)
        {
            foreach (WKTstring wkt in GetSRIDs())
            {
                if (wkt.WKID == id)
                {
                    return wkt.WKT;
                }
            }
            return null;
        }
    }
}
