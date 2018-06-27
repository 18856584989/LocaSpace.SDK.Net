using System.Drawing;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace HUD
{
    public class GSOHudButtonInfo : GSOHudButton
    {
        public string toolTip = "";
        public EnumAction3D action = EnumAction3D.ActionNull;
        public string bigImagePath = "";
        public string imagePath = "";
        public GSOHudButtonInfo()
        {
            GSOTextStyle textStyle = new GSOTextStyle();
            textStyle.ForeColor = Color.White;
            textStyle.FontSize = 9;
            this.TextAlign = EnumAlign.BottomCenter;
            this.TextStyle = textStyle;
            this.TextOffset = new GSOPoint2d(0, -10);           
            this.MinOpaque = 1;
            this.MaxOpaque = 1;
            this.Align = EnumAlign.BottomCenter;           
        }

        public GSOHudButtonInfo(string name, EnumAction3D action, string imagePath, string bigImagePath, int offesetX,
            int offsetY, string toolTip)
        {
            GSOTextStyle textStyle = new GSOTextStyle();
            textStyle.ForeColor = Color.White;
            textStyle.FontSize = 9;
            this.TextAlign = EnumAlign.BottomCenter;
            this.TextStyle = textStyle;
            this.TextOffset = new GSOPoint2d(0, -10);
            this.MinOpaque = 1;
            this.MaxOpaque = 1;
            this.Align = EnumAlign.BottomCenter;

            this.Name = name;
            this.imagePath = imagePath;
            this.SetImage(Application.StartupPath + imagePath);
            this.SetOffset(offesetX, offsetY);

            this.toolTip = toolTip;
            this.action = action;
            this.bigImagePath = bigImagePath;
        }
    }
}
