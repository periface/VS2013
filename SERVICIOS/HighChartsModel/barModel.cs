using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.HighChartsModel //Si se exporta cambiar esta linea
{
    public class barModel
    {
        /// <summary>
        /// Helper Id
        /// </summary>
        public int id { get; set; }
        public chart chart { get; set; }
        ///Barras modelo basico
        public title title { get; set; }
        public xAxis xAxis { get; set; }
        public yAxis yAxis { get; set; }
        public tooltip tooltip { get; set; }
        public plotOptions plotOptions { get; set; }
        public legend legend { get; set; }
        public credits credits { get; set; }
        public series[] series { get; set; }
        public seriesDataObject[] seriesDo { get; set; }
        public string drillDown { get; set; }
    }
    public class barModelDataObject {
        public int id { get; set; }
        public chart chart { get; set; }
        ///Barras modelo basico
        public title title { get; set; }
        public xAxis xAxis { get; set; }
        public yAxis yAxis { get; set; }
        public tooltip tooltip { get; set; }
        public plotOptions plotOptions { get; set; }
        public legend legend { get; set; }
        public credits credits { get; set; }
        public series[] series { get; set; }
    }
    public class chart {
        public string type { get; set; }
        public string zoomType { get; set; }
    }
    public class xAxis {
        public string[] categories { get; set; }
        public title title
        {
            get;
            set;
        }
        public bool crosshair { get; set; }
        public labels labels { get; set; }
        public string type { get; set; }
    }
    public class yAxis {
        public int min { get; set; }
        public title title { get; set; }
        public labels labels { get; set; }
        

    }
    public class plotOptions
    {
        public bar bar { get; set; }
        public column column { get; set; }
    }
    public class column {
        public double pointPadding { get; set; }
        public double borderWidth { get; set; }
    }
    public class labels {
        public string overflow { get; set; }
    }
    public class title
    {
        public string text { get; set; }
        public string align { get; set; }
    }
    public class tooltip {
        string valueSuffix { get; set; }
        public string headerFormat { get; set; }
        public string pointFormat { get; set; }
        public string footerFormat { get; set; }
        public bool shared { get; set; }
        public bool useHTML { get; set; }

    }
    public class bar {
        datalabels datalabels { get; set; }
    }
    public class datalabels {
        public bool enabled { get; set; }
    }
    public class legend {
        public string layout { get; set; }
        public string align { get; set; }
        public string verticalAlign { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool floating { get; set; }
        public int borderWidth { get; set; }
        public string backgroundColor { get; set; }
        public bool shadow { get; set; }
    }
    public class credits {
        public bool enabled { get; set; }
        
    }
    public class series {
        public string name { get; set; }
        public double[] data { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public bool colorByPoint { get; set; } 
    }
    public class seriesDataObject
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool colorByPoint { get; set; }
        public data[] data { get; set; }
        
        
    }
    
    public class data {
        public string drilldown { get; set; }
        public double y { get; set; }
        public string name { get; set; }
        public string color { get; set; }
    }

}
