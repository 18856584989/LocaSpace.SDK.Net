using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoScene.Globe;

namespace 图层的添加和删除
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 添加图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            //添加图层文件
            globeControl1.Globe.Layers.Add(
                Application.StartupPath + "\\Resource\\gisdata\\tianditudata\\天地图地图.lrc");
            globeControl1.Globe.Layers.Add(
                Application.StartupPath + "\\Resource\\gisdata\\tianditudata\\天地图标注.lrc");
        }

        /// <summary>
        /// 删除图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveLayer_Click(object sender, EventArgs e)
        {
            //删除图层有三种方法
            //1.根据图层删除
            //GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption("天地图标注");
            //globeControl1.Globe.Layers.Remove(layer);
            //2.根据图层目录删除
            //globeControl1.Globe.Layers.Remove(
            //    Application.StartupPath + "\\Resource\\gisdata\\tianditudata\\天地图标注.lrc");
            //3.根据索引删除
            //globeControl1.Globe.Layers.Remove(1);
            //还有几个删除方法
            //全部删除
            globeControl1.Globe.Layers.RemoveAll();
            //根据图层ID删除
            //globeControl1.Globe.Layers.RemoveLayerByID(1);
        }

        /// <summary>
        /// 显示隐藏图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowD_Click(object sender, EventArgs e)
        {
            //根据说明查找图层，说明为文件名称（不带后缀）
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption("天地图地图");
            if (layer == null) return;
            layer.Visible = !layer.Visible;
        }

        /// <summary>
        /// 移动图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLayerMove_Click(object sender, EventArgs e)
        {
            //图层的移动是通过索引移动的
            //索引越大表示越在商城，表示后绘制
            //将索引为1的图层移动到下一层，结果为该图层的索引变为2，原来索引为2的图层变为1
            globeControl1.Globe.Layers.MoveUp(1);
            //将索引为2的图层移动到上一层，结果为该图层索引变为1，原来索引为1的变为2
            //globeControl1.Globe.Layers.MoveDown(2);
            //将索引为1的图层移动到索引为8的位置
            //globeControl1.Globe.Layers.MoveTo(1,2);
        }

        /// <summary>
        /// 添加地形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTerrain_Click(object sender, EventArgs e)
        {
            string TerrainPath = Application.StartupPath + "\\Resource\\gisdata\\googledata\\谷歌地形.lrc";
            globeControl1.Globe.Terrains.Add(TerrainPath);
        }

        /// <summary>
        /// 删除地形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveTerrain_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Terrains.RemoveAll();
        }
    }
}
