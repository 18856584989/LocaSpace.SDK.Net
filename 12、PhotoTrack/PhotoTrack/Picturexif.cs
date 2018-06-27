using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.IO;

namespace WorldGIS.Classes
{
    public class Picturexif
    {
        #region 构造函数
        /// <summary> 
        /// 构造函数 
        /// </summary> 
        public Picturexif()
        {
        }
        #endregion
    
        /// <summary>
        /// 获取照片的经纬度信息
        /// </summary>
        /// <param name="p_图片路径"></param>   
        public string GetGPSCoordinate(String strPath)
        {
            string GPSCoordinate = "";
            //载入图片 
            //Image objImage = Image.FromFile(strPath);
            Image objImage = new Bitmap(strPath);
            //System.Drawing.Image objImage = new System.Drawing.Bitmap(img);
           
            //取得所有的属性(以PropertyId做排序) 
            var propertyItems = objImage.PropertyItems.OrderBy(x => x.Id);
            //暂定纬度N(北纬) 
            char chrGPSLatitudeRef = 'N';
            //暂定经度为E(东经) 
            char chrGPSLongitudeRef = 'E';
            string time = "";
            foreach (PropertyItem objItem in propertyItems)
            {
                if (objItem.Id == 0x0132)
                {
                    time = System.Text.Encoding.ASCII.GetString(objItem.Value).ToString();
                }
                //只取Id范围为0x0000到0x001e
                if (objItem.Id >= 0x0000 && objItem.Id <= 0x001e)
                {
                    objItem.Id = 0x0002;
                    switch (objItem.Id)
                    {
                        case 0x0000:
                            var query = from tmpb in objItem.Value select tmpb.ToString();
                            string sreVersion = string.Join(".", query.ToArray());
                            break;
                        case 0x0001:
                            chrGPSLatitudeRef = BitConverter.ToChar(objItem.Value, 0);
                            break;
                        case 0x0002:
                            if (objItem.Value.Length == 24)
                            {
                                //degrees(将byte[0]~byte[3]转成uint, 除以byte[4]~byte[7]转成的uint) 
                                double d = BitConverter.ToUInt32(objItem.Value, 0) * 1.0d / BitConverter.ToUInt32(objItem.Value, 4);
                                //minutes(将byte[8]~byte[11]转成uint, 除以byte[12]~byte[15]转成的uint) 
                                double m = BitConverter.ToUInt32(objItem.Value, 8) * 1.0d / BitConverter.ToUInt32(objItem.Value, 12);
                                //seconds(将byte[16]~byte[19]转成uint, 除以byte[20]~byte[23]转成的uint) 
                                double s = BitConverter.ToUInt32(objItem.Value, 16) * 1.0d / BitConverter.ToUInt32(objItem.Value, 20);
                                //计算经纬度数值, 如果是南纬, 要乘上(-1) 
                                double dblGPSLatitude = (((s / 60 + m) / 60) + d) * (chrGPSLatitudeRef.Equals('N') ? 1 : -1);
                                string strLatitude = string.Format("{0:#} deg {1:#}' {2:#.00}\" {3}", d
                                , m, s, chrGPSLatitudeRef);
                                //纬度+经度
                                GPSCoordinate += dblGPSLatitude + "+";
                            }
                            break;
                        case 0x0003:
                            //透过BitConverter, 将Value转成Char('E' / 'W') 
                            //此值在后续的Longitude计算上会用到 
                            chrGPSLongitudeRef = BitConverter.ToChar(objItem.Value, 0);
                            break;
                        case 0x0004:
                            if (objItem.Value.Length == 24)
                            {
                                //degrees(将byte[0]~byte[3]转成uint, 除以byte[4]~byte[7]转成的uint) 
                                double d = BitConverter.ToUInt32(objItem.Value, 0) * 1.0d / BitConverter.ToUInt32(objItem.Value, 4);
                                //minutes(将byte[8]~byte[11]转成uint, 除以byte[12]~byte[15]转成的uint) 
                                double m = BitConverter.ToUInt32(objItem.Value, 8) * 1.0d / BitConverter.ToUInt32(objItem.Value, 12);
                                //seconds(将byte[16]~byte[19]转成uint, 除以byte[20]~byte[23]转成的uint) 
                                double s = BitConverter.ToUInt32(objItem.Value, 16) * 1.0d / BitConverter.ToUInt32(objItem.Value, 20);
                                //计算精度的数值, 如果是西经, 要乘上(-1) 
                                double dblGPSLongitude = (((s / 60 + m) / 60) + d) * (chrGPSLongitudeRef.Equals('E') ? 1 : -1);
                            }
                            break;
                        case 0x0005:
                            string strAltitude = BitConverter.ToBoolean(objItem.Value, 0) ? "0" : "1";
                            break;
                        case 0x0006:
                            if (objItem.Value.Length == 8)
                            {
                                //将byte[0]~byte[3]转成uint, 除以byte[4]~byte[7]转成的uint 
                                double dblAltitude = BitConverter.ToUInt32(objItem.Value, 0) * 1.0d / BitConverter.ToUInt32(objItem.Value, 4);
                            }
                            break;
                    }
                }
            }        
            objImage.Dispose();
            return GPSCoordinate + time;
        }      
    }
}
