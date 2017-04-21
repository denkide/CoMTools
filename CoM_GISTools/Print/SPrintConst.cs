using System;
using System.Collections.Generic;
using System.Text;
using CoM_GISTools.Utility;
//using MedfordToolsDAL;
using System.Data;

namespace CoM_GISTools.Print
{
    public struct SPrintConst
    {
        public static List<string> MapSize
        {
            get 
            {
                List<string> lstMapSize = new List<string>();
                lstMapSize.Add("8.5 x 11");
                lstMapSize.Add("11 x 17");
                lstMapSize.Add("17 x 22");
                lstMapSize.Add("34 x 44");
                return lstMapSize; 
            }
        }
        public enum Orientation { Landscape = 1, Portrait }

        public static Dictionary<string, string> MapScale
        {
            get 
            { 
                return CMedToolsSubs.returnConfigNode("Print", "@type='MapScale'", SConst.PrintSettingsLocation); 
            }
        }

        private static double dblNeatline_XMin;
        public static double Neatline_XMin
        {
            get { return dblNeatline_XMin; }
            set { dblNeatline_XMin = value; }
        }

        private static double dblNeatline_XMax;
        public static double Neatline_XMax
        {
            get { return dblNeatline_XMax; }
            set { dblNeatline_XMax = value; }
        }

        private static double dblNeatline_YMin;
        public static double Neatline_YMin
        {
            get { return dblNeatline_YMin; }
            set { dblNeatline_YMin = value; }
        }

        private static double dblNeatline_YMax;
        public static double Neatline_YMax
        {
            get { return dblNeatline_YMax; }
            set { dblNeatline_YMax = value; }
        }

        private static double dblMapFrame_XMin;
        public static double MapFrame_XMin
        {
            get { return dblMapFrame_XMin; }
            set { dblMapFrame_XMin = value; }
        }

        private static double dblMapFrame_XMax;
        public static double MapFrame_XMax
        {
            get { return dblMapFrame_XMax; }
            set { dblMapFrame_XMax = value; }
        }

        private static double dblMapFrame_YMin;
        public static double MapFrame_YMin
        {
            get { return dblMapFrame_YMin; }
            set { dblMapFrame_YMin = value; }
        }

        private static double dblMapFrame_YMax;
        public static double MapFrame_YMax
        {
            get { return dblMapFrame_YMax; }
            set { dblMapFrame_YMax = value; }
        }

        private static double dblLogo_Offset;
        public static double Logo_Offset
        {
            get { return dblLogo_Offset; }
            set { dblLogo_Offset = value; }
        }

        private static double dblMapScaleText_Offset;
        public static double MapScaleText_Offset
        {
            get { return dblMapScaleText_Offset; }
            set { dblMapScaleText_Offset = value; }
        }

        private static double dblNameDate_Offset;
        public static double NameDate_Offset
        {
            get { return dblNameDate_Offset; }
            set { dblNameDate_Offset = value; }
        }

        private static double dblTitle_XOffset;
        public static double Title_XOffset
        {
            get { return dblTitle_XOffset; }
            set { dblTitle_XOffset = value; }
        }

        private static double dblLegend_YMax;
        public static double Legend_YMax
        {
            get { return dblLegend_YMax; }
            set { dblLegend_YMax = value; }
        }

        private static double dblMaxLegendHeight;
        public static double MaxLengendHeight
        {
            get { return dblMaxLegendHeight; }
            set { dblMaxLegendHeight = value; }
        }

        private static double dblRightOfTitleLine_X;
        public static double RightOfTitleLine_X
        {
            get { return dblRightOfTitleLine_X; }
            set { dblRightOfTitleLine_X = value; }
        }

        private static double dblLeftLine_X;
        public static double LeftLine_X
        {
            get { return dblLeftLine_X; }
            set { dblLeftLine_X = value; }
        }

        private static double dblCenterLine_Y;
        public static double CenterLine_Y
        {
            get { return dblCenterLine_Y; }
            set { dblCenterLine_Y = value; }
        }

        private static double dblScalebar_XMin;
        public static double Scalebar_XMin
        {
            get { return dblScalebar_XMin; }
            set { dblScalebar_XMin = value; }
        }

        private static double dblScalebar_XMax;
        public static double Scalebar_XMax
        {
            get { return dblScalebar_XMax; }
            set { dblScalebar_XMax = value; }
        }

        private static double dblScalebar_YMin;
        public static double Scalebar_YMin
        {
            get { return dblScalebar_YMin; }
            set { dblScalebar_YMin = value; }
        }

        private static double dblScalebar_YMax;
        public static double Scalebar_YMax
        {
            get { return dblScalebar_YMax; }
            set { dblScalebar_YMax = value; }
        }

        public static long InchesPerMile
        {
            get { return 63360; }
        }

        private static double dblMapscaleText_XMin;
        public static double MapscaleText_XMin
        {
            get { return dblMapscaleText_XMin; }
            set { dblMapscaleText_XMin = value; }
        }

        private static double dblMapscaleText_XMax;
        public static double MapscaleText_XMax
        {
            get { return dblMapscaleText_XMax; }
            set { dblMapscaleText_XMax = value; }
        }

        private static double dblMapscaleText_YMin;
        public static double MapscaleText_YMin
        {
            get { return dblMapscaleText_YMin; }
            set { dblMapscaleText_YMin = value; }
        }

        private static double dblMedfordRectangle_YMin;
        public static double MedfordRectangle_YMin
        {
            get { return dblMedfordRectangle_YMin; }
            set { dblMedfordRectangle_YMin = value; }
        }
        
        private static double dblMedfordText_XMin;
        public static double MedfordText_XMin
        {
            get { return dblMedfordText_XMin; }
            set { dblMedfordText_XMin = value; }
        }

        private static double dblMedfordText_XMax;
        public static double MedfordText_XMax
        {
            get { return dblMedfordText_XMax; }
            set { dblMedfordText_XMax = value; }
        }

        private static double dblMedfordText_YMin;
        public static double MedfordText_YMin
        {
            get { return dblMedfordText_YMin; }
            set { dblMedfordText_YMin = value; }
        }

        private static double dblMedfordText_YMax;
        public static double MedfordText_YMax
        {
            get { return dblMedfordText_YMax; }
            set { dblMedfordText_YMax = value; }
        }

        private static double dblMedGISText_XMax;
        public static double MedGISText_XMax
        {
            get { return dblMedGISText_XMax; }
            set { dblMedGISText_XMax = value; }
        }

        private static double dblMedGISText_XMin;
        public static double MedGISText_XMin
        {
            get { return dblMedGISText_XMin; }
            set { dblMedGISText_XMin = value; }
        }

        private static double dblMedGISText_YMax;
        public static double MedGISText_YMax
        {
            get { return dblMedGISText_YMax; }
            set { dblMedGISText_YMax = value; }
        }

        private static double dblMedGISText_YMin;
        public static double MedGISText_YMin
        {
            get { return dblMedGISText_YMin; }
            set { dblMedGISText_YMin = value; }
        }

        private static double dblDisclaimer_XMin;
        public static double Disclaimer_XMin
        {
            get { return dblDisclaimer_XMin; }
            set { dblDisclaimer_XMin = value; }
        }

        private static double dblDisclaimer_XMax;
        public static double Disclaimer_XMax
        {
            get { return dblDisclaimer_XMax; }
            set { dblDisclaimer_XMax = value; }
        }

        private static double dblDisclaimer_YMin;
        public static double Disclaimer_YMin
        {
            get { return dblDisclaimer_YMin; }
            set { dblDisclaimer_YMin = value; }
        }

        private static double dblDisclaimer_YMax;
        public static double Disclaimer_YMax
        {
            get { return dblDisclaimer_YMax; }
            set { dblDisclaimer_YMax = value; }
        }

        private static double dblRecycle_YMin;
        public static double Recycle_YMin
        {
            get { return dblRecycle_YMin; }
            set { dblRecycle_YMin = value; }
        }

        private static double dblRecycle_HeightWidth;
        public static double Recycle_HeightWidth
        {
            get { return dblRecycle_HeightWidth; }
            set { dblRecycle_HeightWidth = value; }
        }


        private static string sRecycle_ImagePath;
        public static string Recycle_ImagePath
        {
            get { return sRecycle_ImagePath; }
            set { sRecycle_ImagePath = value; }
        }

        private static string sLogoImage;
        public static string Logo_Image
        {
            get { return sLogoImage; }
            set { sLogoImage = value; }
        }

        private static double dblLogo_XMin;
        public static double Logo_XMin
        {
            get { return dblLogo_XMin; }
            set { dblLogo_XMin = value; }
        }

        private static double dblLogo_YMin;
        public static double Logo_YMin
        {
            get { return dblLogo_YMin; }
            set { dblLogo_YMin = value; }
        }

        private static double dblLogo_Height;
        public static double Logo_Height
        {
            get { return dblLogo_Height; }
            set { dblLogo_Height = value; }
        }

        private static double dblLogo_Width;
        public static double Logo_Width
        {
            get { return dblLogo_Width; }
            set { dblLogo_Width = value; }
        }

        private static double dblNorthArrow_Width;
        public static double NorthArrow_Width
        {
            get { return dblNorthArrow_Width; }
            set { dblNorthArrow_Width = value; }
        }


        private static double dblNorthArrow_Height;
        public static double NorthArrow_Height
        {
            get { return dblNorthArrow_Height; }
            set { dblNorthArrow_Height = value; }
        }

        private static double dblNorthArrow_Character;
        public static double NorthArrow_Character
        {
            get { return dblNorthArrow_Character; }
            set { dblNorthArrow_Character = value; }
        }

        private static double dblNorthArrow_Size;
        public static double NorthArrow_Size
        {
            get { return dblNorthArrow_Size; }
            set { dblNorthArrow_Size = value; }
        }

        private static double dblNorthArrow_XMax;
        public static double NorthArrow_XMax
        {
            get { return dblNorthArrow_XMax; }
            set { dblNorthArrow_XMax = value; }
        }
        
        private static double dblNorthArrow_YMax;
        public static double NorthArrow_YMax
        {
            get { return dblNorthArrow_YMax; }
            set { dblNorthArrow_YMax = value; }
        }

        private static double dblNorthArrow_XMin;
        public static double NorthArrow_XMin
        {
            get { return dblNorthArrow_XMin; }
            set { dblNorthArrow_XMin = value; }
        }

        private static double dblNorthArrow_YMin;
        public static double NorthArrow_YMin
        {
            get { return dblNorthArrow_YMin; }
            set { dblNorthArrow_YMin = value; }
        }

        private static double dblTitle_XMin;
        public static double Title_XMin
        {
            get { return dblTitle_XMin; }
            set { dblTitle_XMin = value; }
        }

        private static double dblTitle_YMin;
        public static double Title_YMin
        {
            get { return dblTitle_YMin; }
            set { dblTitle_YMin = value; }
        }

        private static double dblTitle_XMax;
        public static double Title_XMax
        {
            get { return dblTitle_XMax; }
            set { dblTitle_XMax = value; }
        }

        private static double dblTitle_YMax;
        public static double Title_YMax
        {
            get { return dblTitle_YMax; }
            set { dblTitle_YMax = value; }
        }

        private static double dblSubtitle_XMin;
        public static double Subtitle_XMin
        {
            get { return dblSubtitle_XMin; }
            set { dblSubtitle_XMin = value; }
        }

        private static double dblSubtitle_YMin;
        public static double Subtitle_YMin
        {
            get { return dblSubtitle_YMin; }
            set { dblSubtitle_YMin = value; }
        }

        private static double dblSubtitle_XMax;
        public static double Subtitle_XMax
        {
            get { return dblSubtitle_XMax; }
            set { dblSubtitle_XMax = value; }
        }

        private static double dblSubtitle_YMax;
        public static double Subtitle_YMax
        {
            get { return dblSubtitle_YMax; }
            set { dblSubtitle_YMax = value; }
        }

        private static double dblLegend_XMin;
        public static double Legend_XMin
        {
            get { return dblLegend_XMin; }
            set { dblLegend_XMin = value; }
        }

        private static double dblLegend_YMin;
        public static double Legend_YMin
        {
            get { return dblLegend_YMin; }
            set { dblLegend_YMin = value; }
        }

        private static double dblLegend_Height;
        public static double Legend_Height
        {
            get { return dblLegend_Height; }
            set { dblLegend_Height = value; }
        }

        private static double dblLegend_Width;
        public static double Legend_Width
        {
            get { return dblLegend_Width; }
            set { dblLegend_Width = value; }
        }

        private static double dblName_XMin;
        public static double Name_XMin
        {
            get { return dblName_XMin; }
            set { dblName_XMin = value; }
        }

        private static double dblName_XMax;
        public static double Name_XMax
        {
            get { return dblName_XMax; }
            set { dblName_XMax = value; }
        }

        private static double dblName_YMin;
        public static double Name_YMin
        {
            get { return dblName_YMin; }
            set { dblName_YMin = value; }
        }

        private static double dblName_YMax;
        public static double Name_YMax
        {
            get { return dblName_YMax; }
            set { dblName_YMax = value; }
        }
    }
}
