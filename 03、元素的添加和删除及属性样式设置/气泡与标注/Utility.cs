using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Xml;
using System.Net;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
namespace WorldGIS
{
    public class Utility
    {
        public static List<string> listServerName = new List<string>();
        /// <summary>
        /// 服务器ip
        /// </summary>
        public static string serverip;
        /// <summary>
        /// 服务器端口
        /// </summary>
        public static int serverport;
        /// <summary>
        /// 投影参数
        /// </summary>
        public static string importProjectionRefFromProj4 = "";
        /// <summary>
        /// 鼠标状态的描述信息
        /// </summary>
        public static Dictionary<EnumAction3D, string> actionDescription = new Dictionary<EnumAction3D, string>{
            {EnumAction3D.ActionNull, "浏览对象"},
            {EnumAction3D.DrawPolygon, "绘制面"},
            {EnumAction3D.DrawPolyline, "绘制线"},
            {EnumAction3D.DrawWater, "绘制水面"},
            {EnumAction3D.ElevateObject, "升降对象"},
            {EnumAction3D.MeasureArea, "测量面积"},
            {EnumAction3D.MeasureDistance, "测量距离"},
            {EnumAction3D.MeasureHeight, "测量高度"},
            {EnumAction3D.MoveObject, "平移对象"},
            {EnumAction3D.RotateObject, "旋转对象"},
            {EnumAction3D.ScaleObject, "缩放对象"},
            {EnumAction3D.SelectObject, "选择对象"},
            {EnumAction3D.TrackPolygon, "填挖方分析"},
            {EnumAction3D.TrackPolyline, "剖面分析"},
            {EnumAction3D.ViewEnvelopeAnalysis, "可视包络分析"},
            {EnumAction3D.ViewshedAnalysis, "可视域分析"},
            {EnumAction3D.VisibilityAnalysis, "空间通视分析"},
        };
        /// <summary>
        /// 气泡的参数设置
        /// </summary>
        /// <param name="featureTooltip"></param>
        /// <param name="infoBalloon"></param>
        /// <param name="balloonEx"></param>
        public static void SetBallons(GSOBalloon featureTooltip, GSOBalloon infoBalloon, GSOBalloonEx balloonEx)
        {
            if (featureTooltip != null)
            {
                featureTooltip.CacheFilePath = Application.StartupPath + "/GeoScene/Globe/Temp";
                featureTooltip.SetSize(EnumSizeIndex.ROUNDED_CX, 0);
                featureTooltip.SetSize(EnumSizeIndex.ROUNDED_CY, 0);
                featureTooltip.SetSize(EnumSizeIndex.MARGIN_CX, 3);
                featureTooltip.SetSize(EnumSizeIndex.MARGIN_CY, 3);
                featureTooltip.SetSize(EnumSizeIndex.ANCHOR_HEIGHT, 0);
                featureTooltip.SetSize(EnumSizeIndex.ANCHOR_WIDTH, 0);
                featureTooltip.SetSize(EnumSizeIndex.ANCHOR_MARGIN, 0);
                featureTooltip.SetSize(EnumSizeIndex.ANCHOR_OFFSET_CX, 1);
                featureTooltip.SetSize(EnumSizeIndex.ANCHOR_OFFSET_CY, -1);
                featureTooltip.SetDirection(EnumToolTipDirection.TD_BOTTOMEDGE_LEFT);
                featureTooltip.EscapeSequencesEnabled = true;
                featureTooltip.HyperlinkEnabled = true;
                featureTooltip.Opaque = 30;
                featureTooltip.MaxWidth = 300;
                featureTooltip.SetShadow(0, 0, 50, true, 0, 0);
            }
            if (infoBalloon != null)
            {
                infoBalloon.SetColorBkType(EnumBkColorType.SILVER);
                infoBalloon.SetEffectBk(EnumBkEffect.HBUMP, 0);
                infoBalloon.SetBorder(Color.FromArgb(255, 171, 171, 171), 1, 1);
                infoBalloon.SetSize(EnumSizeIndex.ROUNDED_CX, 5);
                infoBalloon.SetSize(EnumSizeIndex.ROUNDED_CY, 5);
                infoBalloon.SetSize(EnumSizeIndex.ANCHOR_HEIGHT, 10);
                infoBalloon.SetSize(EnumSizeIndex.ANCHOR_WIDTH, 10);
                infoBalloon.SetShadow(3, 3, 50, true, 0, 0);
                infoBalloon.MaxWidth = 300;
                infoBalloon.CloseButtonVisible = true;
            }
            if (balloonEx != null)
            {
                balloonEx.SetSize(EnumSizeIndexEx.CONTENT_CX, 500);
                balloonEx.SetSize(EnumSizeIndexEx.CONTENT_CY, 300);
                balloonEx.SetSize(EnumSizeIndexEx.ANCHOR_WIDTH, 10);
                balloonEx.Opaque = 5;
                balloonEx.SetBorder(Color.White, 1, 1);
                balloonEx.SetColorBkType(EnumBkColorTypeEx.SILVER);
                balloonEx.SetEffectBk(EnumBkEffectEx.OUTRANGE, 10);
                balloonEx.CacheFilePath = Application.StartupPath + "/GeoScene/Globe/Temp";
            }
        }

        /// <summary>
        /// 获取图层中的所有feature对象，包括featureFolder下面的feature对象
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static GSOFeatures getRealFeaturesByLayer(GSOLayer layer)
        {
            GSOFeatures realFeatures = new GSOFeatures();
            if (layer != null)
            {
                for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                {
                    GSOFeature feature = layer.GetAt(i);
                    if (feature != null)
                    {
                        if (feature.Type == EnumFeatureType.FeatureFolder)
                        {
                            GSOFeatureFolder featureFolder = feature as GSOFeatureFolder;
                            getRealFeatureByFeatures(featureFolder.Features, ref realFeatures);
                        }
                        else
                        {
                            realFeatures.Add(feature);
                        }
                    }
                }
            }
            return realFeatures;
        }
        private static void getRealFeatureByFeatures(GSOFeatures features, ref GSOFeatures realFeatures)
        {
            if (features == null)
            {
                return;
            }
            for (int i = 0; i < features.Length; i++)
            {
                GSOFeature feature = features[i];
                if (feature != null)
                {
                    if (feature.Type == EnumFeatureType.FeatureFolder)
                    {
                        GSOFeatureFolder featureFolder = feature as GSOFeatureFolder;
                        getRealFeatureByFeatures(featureFolder.Features, ref realFeatures);
                    }
                    else
                    {
                        realFeatures.Add(feature);
                    }
                }
            }
        }
        /// <summary>
        /// 图层定位
        /// </summary>
        /// <param name="globeControl1"></param>
        /// <param name="latLonBounds"></param>
        public static void flyToLayerOrTerrain(GSOGlobeControl globeControl1 , GSORect2d latLonBounds)
        {
            if ((latLonBounds.Left.Equals(0.0) == false)
                                                    && (latLonBounds.Bottom.Equals(0.0) == false)
                                                    && (latLonBounds.Top.Equals(0.0) == false)
                                                    && (latLonBounds.Right.Equals(0.0) == false))
            {
                GSOPoint2d pntCenter = latLonBounds.Center;
                GSOPoint3d pntPostion = new GSOPoint3d();
                pntPostion.X = pntCenter.X;
                pntPostion.Y = pntCenter.Y;
                double dMaxGeoLen = Math.Max(latLonBounds.Width, latLonBounds.Height);
                double dSize = dMaxGeoLen * Math.PI * 6378137 / 90;
                pntPostion.Z = dSize > 20000000 ? dSize / 4 : dSize;
                globeControl1.Globe.FlyToPosition(pntPostion, EnumAltitudeMode.RelativeToGround);                
            }
        }

        /// <summary>
        /// 二维坐标转换为经纬度坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static GeoScene.Data.GSOPoint2d XYZ_2_Latlon(double x, double y)
        {
            int id = Utility.getProjectID();
            GeoScene.Data.GSOPoint2d point2d = new GeoScene.Data.GSOPoint2d(x, y);
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(point2d, id);
            return result;
        }
        public static GeoScene.Data.GSOPoint2d XYZ_2_Latlon(GSOPoint2d point2d)
        {
            int id = Utility.getProjectID();
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(point2d, id);
            return result;
        }
        public static GeoScene.Data.GSOPoint2d XYZ_2_Latlon(int projectID, GSOPoint2d point2d)
        {
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Inverse(point2d, projectID);
            return result;
        }
        /// <summary>
        /// 经纬度坐标转换为二维坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static GeoScene.Data.GSOPoint2d Latlon_2_XYZ(double lon, double lat)
        {
            int id = Utility.getProjectID();
            GeoScene.Data.GSOPoint2d point2d = new GeoScene.Data.GSOPoint2d(lon, lat);
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Forward(point2d, id);
            return result;
        }
        public static GeoScene.Data.GSOPoint2d Latlon_2_XYZ(GSOPoint3d point3d)
        {
            int id = Utility.getProjectID();
            GeoScene.Data.GSOPoint2d point2d = new GeoScene.Data.GSOPoint2d(point3d.X, point3d.Y);
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Forward(point2d, id);
            return result;
        }
        public static GeoScene.Data.GSOPoint2d Latlon_2_XYZ(int projectID,GSOPoint3d point3d)
        {
            GeoScene.Data.GSOPoint2d point2d = new GeoScene.Data.GSOPoint2d(point3d.X, point3d.Y);
            GeoScene.Data.GSOPoint2d result = GeoScene.Data.GSOProjectManager.Forward(point2d, projectID);
            return result;
        }
        private static int getProjectID()
        {
            int id = 0;
            if (Utility.importProjectionRefFromProj4 != "")
            {
                id = GeoScene.Data.GSOProjectManager.AddProject(Utility.importProjectionRefFromProj4);
            }
            return id;
        }
        public static int getProjectID(string proj4)
        {
            int id = 0;
            if (proj4 != "")
            {
                id = GeoScene.Data.GSOProjectManager.AddProject(proj4);
            }
            return id;
        }

        public static string getCaptionWithExtensionFromLayer(GSOLayer layer)
        {
            if (layer == null)
            {
                return "";
            }
            //string name = layer.Name;
            //int index = name.LastIndexOf('.');
            //return layer.Caption + name.Substring(index);
            return layer.Caption;
        }
        public static string getCaptionWithExtensionFromLayer(GSOTerrain terrain)
        {
            if (terrain == null)
            {
                return "";
            }
            //string name = terrain.Name;
            //int index = name.LastIndexOf('.');
            //return terrain.Caption + name.Substring(index);
            return terrain.Caption;
        }
        public static int getImageIndexFromLayer(GSOLayer layer)
        {
            if (layer == null)
            {
                return 17;
            }
            string name = layer.Name;
            int index = name.LastIndexOf('.');
            string extension = name.Substring(index+1);
            switch (extension.ToLower())
            { 
                case "kml":
                    return 9;
                case "lgd":
                    return 10;
                case "lrc":
                    return 11;
                case "lfp":
                    return 12;
                case "shp":
                    return 13;
                case "dwg":
                    return 14;
                case "lrp":
                    return 15;
                case "gpx":
                    return 16;
                default:
                    return 17;
            }
        }
        public static GSOLayer getLayerByName(GSOGlobeControl globeControl1,string layerName)
        {
            GSOLayer layer = null;
            if (globeControl1 != null)
            {
                layerName = layerName.Replace("\\", "/");
                for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
                {
                    GSOLayer layerItem = globeControl1.Globe.Layers[i];
                    string layerItemName = layerItem.Name.Replace("\\", "/");
                    if (layerItemName == layerName)
                    {
                        layer = layerItem;
                        break;
                    }
                }
            }
            return layer;
        }
        public static void removeLayerByName(GSOGlobeControl globeControl1, string layerName)
        {
            GSOLayer layer = null;
            if (globeControl1 != null)
            {
                layerName = layerName.Replace("\\", "/");
                for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
                {
                    GSOLayer layerItem = globeControl1.Globe.Layers[i];
                    string layerItemName = layerItem.Name.Replace("\\", "/");
                    if (layerItemName == layerName)
                    {
                        layer = layerItem;
                        layer.Dataset.DataSource.RemoveDataset(layer.Dataset);
                        globeControl1.Globe.Layers.Remove(layer);
                        break;
                    }
                }
            }            
        }

        public static void removeLayer(GSOGlobeControl globeControl1, GSOLayer layer)
        {
            if (globeControl1 != null && layer != null)
            {
                layer.Dataset.DataSource.RemoveDataset(layer.Dataset);
                globeControl1.Globe.Layers.Remove(layer);
            }
        }

        public static GSOTerrain getTerrainByName(GSOGlobeControl globeControl1, string terrainName)
        {
            GSOTerrain layer = null;
            if (globeControl1 != null)
            {
                terrainName = terrainName.Replace("\\", "/");
                for (int i = 0; i < globeControl1.Globe.Terrains.Count; i++)
                {
                    GSOTerrain layerItem = globeControl1.Globe.Terrains[i];
                    string layerItemName = layerItem.Name.Replace("\\", "/");
                    if (layerItemName == terrainName)
                    {
                        layer = layerItem;
                        break;
                    }
                }
            }
            return layer;
        }

        /// <summary>
        /// 导出指定DataGridView控件中的内容到Excel中
        /// </summary>
        /// <param name="type"></param>
        /// <param name="_dataGridView"></param>
        public static void exportDataGridViewToExcel(string title, DataGridView _dataGridView, ListBox _listBox)
        {
            if (_dataGridView.Rows.Count > 0)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel files (*.xls)|*.xls";
                dlg.FilterIndex = 0;
                dlg.RestoreDirectory = true;
                //dlg.CreatePrompt = true;
                dlg.Title = "保存为Excel文件";
                dlg.FileName = title + "-" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Stream myStream;
                    myStream = dlg.OpenFile();
                    StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                    string columnTitle = "";
                    try
                    {
                        if (_listBox != null)
                        {
                            string strList = "";
                            for (int i = 0; i < _listBox.Items.Count; i++)
                            {
                                strList += _listBox.Items[i].ToString() + @"/";
                            }
                            if (title == "")
                            {
                                sw.WriteLine("日期：" + DateTime.Now.ToString("yyyy-MM-dd") + " 结果：" + strList);
                            }
                            else
                            {
                                sw.WriteLine("内容：" + title + "  日期：" + DateTime.Now.ToString("yyyy-MM-dd") + " 结果：" + strList);
                            }
                        }
                        else
                        {
                            if (title == "")
                            {
                                sw.WriteLine("日期：" + DateTime.Now.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                sw.WriteLine("内容：" + title + "  日期：" + DateTime.Now.ToString("yyyy-MM-dd"));
                            }
                        }
                        //写入列标题   
                        for (int i = 0; i < _dataGridView.ColumnCount; i++)
                        {
                            if (i > 0)
                            {
                                columnTitle += "\t";
                            }
                            columnTitle += _dataGridView.Columns[i].HeaderText;
                        }
                        sw.WriteLine(columnTitle);

                        //写入列内容   
                        for (int j = 0; j < _dataGridView.Rows.Count; j++)
                        {
                            string columnValue = "";
                            for (int k = 0; k < _dataGridView.Columns.Count; k++)
                            {
                                if (k > 0)
                                {
                                    columnValue += "\t";
                                }
                                if (_dataGridView.Rows[j].Cells[k].Value == null)
                                {
                                    columnValue += "";
                                }
                                else
                                {
                                    columnValue += _dataGridView.Rows[j].Cells[k].Value.ToString().Trim();
                                }
                            }
                            sw.WriteLine(columnValue);
                        }
                        sw.Close();
                        myStream.Close();
                        if (MessageBox.Show("导出Excel文件成功！是否打开？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(dlg.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示");
                    }
                    finally
                    {
                        sw.Close();
                        myStream.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 导出指定DataGridView控件中的内容到Excel中
        /// </summary>
        /// <param name="type"></param>
        /// <param name="_dataGridView"></param>
        public static void exportDataGridViewToExcel(string title, DataTable _dataTable, ListBox _listBox)
        {
            if (_dataTable != null && _dataTable.Rows.Count > 0)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel files (*.xls)|*.xls";
                dlg.FilterIndex = 0;
                dlg.RestoreDirectory = true;
                //dlg.CreatePrompt = true;
                dlg.Title = "保存为Excel文件";
                dlg.FileName = title + "-" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Stream myStream;
                    myStream = dlg.OpenFile();
                    StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                    string columnTitle = "";
                    try
                    {
                        if (_listBox != null)
                        {
                            string strList = "";
                            for (int i = 0; i < _listBox.Items.Count; i++)
                            {
                                strList += _listBox.Items[i].ToString() + @"/";
                            }
                            if (title == "")
                            {
                                sw.WriteLine("日期：" + DateTime.Now.ToString("yyyy-MM-dd") + " 结果：" + strList);
                            }
                            else
                            {
                                sw.WriteLine("内容：" + title + "  日期：" + DateTime.Now.ToString("yyyy-MM-dd") + " 结果：" + strList);
                            }
                        }
                        else
                        {
                            if (title == "")
                            {
                                sw.WriteLine("日期：" + DateTime.Now.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                sw.WriteLine("内容：" + title + "  日期：" + DateTime.Now.ToString("yyyy-MM-dd"));
                            }
                        }
                        //写入列标题   
                        for (int i = 0; i < _dataTable.Columns.Count; i++)
                        {
                            if (i > 0)
                            {
                                columnTitle += "\t";
                            }
                            columnTitle += _dataTable.Columns[i].ColumnName;
                        }
                        sw.WriteLine(columnTitle);

                        //写入列内容   
                        for (int j = 0; j < _dataTable.Rows.Count; j++)
                        {
                            string columnValue = "";
                            for (int k = 0; k < _dataTable.Columns.Count; k++)
                            {
                                if (k > 0)
                                {
                                    columnValue += "\t";
                                }
                                if (_dataTable.Rows[j][k] == null)
                                {
                                    columnValue += "";
                                }
                                else
                                {
                                    columnValue += _dataTable.Rows[j][k].ToString().Trim();
                                }
                            }
                            sw.WriteLine(columnValue);
                        }
                        sw.Close();
                        myStream.Close();
                        if (MessageBox.Show("导出Excel文件成功！是否打开？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(dlg.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示");
                    }
                    finally
                    {
                        sw.Close();
                        myStream.Close();
                    }
                }
            }
        }
        public static int getLevelByHeight(double nHeight)
        {
            int nLevel = 0;
            if (nHeight >= 10123000)
            {
                nLevel = 2;
            }
            else if (nHeight >= 7123000)
            {
                nLevel = 3;
            }
            else if (nHeight >= 6321000)
            {
                nLevel = 4;
            }
            else if (nHeight >= 5522000)
            {
                nLevel = 5;
            }
            else if (nHeight >= 3436000)
            {
                nLevel = 6;
            }
            else if (nHeight >= 539000)
            {
                nLevel = 7;
            }
            else if (nHeight >= 305000)
            {
                nLevel = 8;
            }
            else if (nHeight >= 180000)
            {
                nLevel = 9;
            }
            else if (nHeight >= 133000)
            {
                nLevel = 10;
            }
            else if (nHeight >= 100000)
            {
                nLevel = 11;
            }
            else if (nHeight >= 76500)
            {
                nLevel = 12;
            }
            else if (nHeight >= 58200)
            {
                nLevel = 13;
            }
            else if (nHeight >= 23500)
            {
                nLevel = 14;
            }
            else if (nHeight >= 9600)
            {
                nLevel = 15;
            }
            else if (nHeight >= 4000)
            {
                nLevel = 16;
            }
            else if (nHeight >= 2000)
            {
                nLevel = 17;
            }
            else if (nHeight >= 1700)
            {
                nLevel = 18;
            }
            else if (nHeight >= 1500)
            {
                nLevel = 19;
            }
            else //if (nHeight >= 1000)
            {
                nLevel = 20;
            }
            return nLevel;
        }
        public static double getHeightByLevel(int nLevel)
        {
            double nHeight = 0;
            switch (nLevel)
            {
                case 2:
                    nHeight = 10123000;
                    break;
                case 3:
                    nHeight = 7123000;
                    break;
                case 4:
                    nHeight = 6321000;
                    break;
                case 5:
                    nHeight = 5522000;
                    break;
                case 6:
                    nHeight = 3436000;
                    break;
                case 7:
                    nHeight = 539000;
                    break;
                case 8:
                    nHeight = 305000;
                    break;
                case 9:
                    nHeight = 180000;
                    break;
                case 10:
                    nHeight = 133000;
                    break;
                case 11:
                    nHeight = 100000;
                    break;
                case 12:
                    nHeight = 76500;
                    break;
                case 13:
                    nHeight = 58200;
                    break;
                case 14:
                    nHeight = 23500;
                    break;
                case 15:
                    nHeight = 9600;
                    break;
                case 16:
                    nHeight = 4000;
                    break;
                case 17:
                    nHeight = 2000;
                    break;
                case 18:
                    nHeight = 1700;
                    break;
                case 19:
                    nHeight = 1500;
                    break;
                case 20:
                    nHeight = 1000;
                    break;
                default:
                    nHeight = 113444;
                    break;
            }
            return nHeight;
        }
    }    
}