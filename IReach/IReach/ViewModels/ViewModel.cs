using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.ViewModels.Base;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace IReach
{
    public class ViewModel : BaseViewModel
    {

        DateTime time = DateTime.Now;

        DateTime dataTime = new DateTime(2015, 01, 1);

        Random random = new Random();

        private int count;

        private int wave1;

        private int wave2 = 180;

        public ObservableCollection<Model> PolarData1 { get; set; }

        public ObservableCollection<Model> PolarData2 { get; set; }

        public ObservableCollection<Model> PolarData3 { get; set; }

        public ObservableCollection<Model> AreaData { get; set; }

        public ObservableCollection<Model> AreaData1 { get; set; }

        public ObservableCollection<Model> AreaData2 { get; set; }

        public ObservableCollection<Model> AreaData3 { get; set; }

        public ObservableCollection<Model> StepAreaData1 { get; set; }

        public ObservableCollection<Model> LineData { get; set; }

        public ObservableCollection<Model> LineData1 { get; set; }

        public ObservableCollection<Model> LineData2 { get; set; }

        public ObservableCollection<Model> StepLineData1 { get; set; }

        public ObservableCollection<Model> StepLineData2 { get; set; }

        public ObservableCollection<Model> StepLineData3 { get; set; }

        public ObservableCollection<Model> ColumnData1 { get; set; }

        public ObservableCollection<Model> ColumnData2 { get; set; }

        public ObservableCollection<Model> ColumnData3 { get; set; }

        public ObservableCollection<Model> BarData1 { get; set; }

        public ObservableCollection<Model> BarData2 { get; set; }

        public ObservableCollection<Model> SplineData1 { get; set; }

        public ObservableCollection<Model> SplineData2 { get; set; }

        public ObservableCollection<Model> SplineAreaData1 { get; set; }

        public ObservableCollection<Model> SplineAreaData2 { get; set; }

        public ObservableCollection<Model> SplineAreaData3 { get; set; }

     

        public ObservableCollection<Model> PieSeriesData { get; set; }

        public ObservableCollection<Model> DoughnutSeriesData { get; set; }

        public ObservableCollection<Model> PyramidData { get; set; }

        public ObservableCollection<Model> FunnelData { get; set; }

        public ObservableCollection<Model> StackedBarData1 { get; set; }

        public ObservableCollection<Model> StackedBarData2 { get; set; }

        public ObservableCollection<Model> StackedBarData3 { get; set; }

        public ObservableCollection<Model> StackedBar100Data1 { get; set; }

        public ObservableCollection<Model> StackedBar100Data2 { get; set; }

        public ObservableCollection<Model> StackedBar100Data3 { get; set; }

        public ObservableCollection<Model> StackedBar100Data4 { get; set; }

        public ObservableCollection<Model> StackedColumnData1 { get; set; }

        public ObservableCollection<Model> StackedColumnData2 { get; set; }

        public ObservableCollection<Model> StackedColumnData3 { get; set; }

        public ObservableCollection<Model> StackedColumnData4 { get; set; }

        public ObservableCollection<Model> StackedAreaData1 { get; set; }

        public ObservableCollection<Model> StackedAreaData2 { get; set; }

        public ObservableCollection<Model> StackedAreaData3 { get; set; }

        public ObservableCollection<Model> StackedAreaData4 { get; set; }

        public ObservableCollection<Model> StackedArea100Data1 { get; set; }

        public ObservableCollection<Model> StackedArea100Data2 { get; set; }

        public ObservableCollection<Model> StackedArea100Data3 { get; set; }

        public ObservableCollection<Model> StackedArea100Data4 { get; set; }

        public ObservableCollection<Model> StepLineData { get; set; }

        public ObservableCollection<Model> CircularData { get; set; }

        public ObservableCollection<Model> MultipleAxisData { get; set; }

        public ObservableCollection<Model> SemiCircularData { get; set; }

        public ObservableCollection<Model> BubbleData { get; set; }

        public ObservableCollection<Model> ScatterData { get; set; }

        public ObservableCollection<Model> ScatterDataZoomPan
        {
            get
            {
                var items = new ObservableCollection<Model>();

                for (int i = 0; i < 300; i++)
                {
                    double x = random.NextDouble() * 100;
                    double y = random.NextDouble() * 500;
                    double randomDouble = random.NextDouble();
                    if (randomDouble >= .25 && randomDouble < .5)
                    {
                        x *= -1;
                    }
                    else if (randomDouble >= .5 && randomDouble < .75)
                    {
                        y *= -1;
                    }
                    else if (randomDouble > .75)
                    {
                        x *= -1;
                        y *= -1;
                    }
                    items.Add(new Model(300 + (x * (random.NextDouble() + 0.12)),
                                100 + (y * (random.NextDouble() + 0.12))));
                }
                return items;
            }
        }

        public ObservableCollection<Model> Data1 { get; set; }

        public ObservableCollection<Model> Data2 { get; set; }

        public ObservableCollection<Model> datas1 { get; set; }

        public ObservableCollection<Model> Data3 { get; set; }

        public ObservableCollection<Model> CategoryData { get; set; }

        public ObservableCollection<Model> LogarithmicData { get; set; }

     

        public ObservableCollection<Model> FinancialData { get; set; }

        public ObservableCollection<Model> NumericData { get; set; }

        public ObservableCollection<Model> DateTimeData { get; set; }

        public ObservableCollection<Model> SelectionData { get; set; }

        public ObservableCollection<Model> data { get; set; }

        public ObservableCollection<Model> liveData1 { get; set; }

        public ObservableCollection<Model> liveData2 { get; set; }

        public ObservableCollection<Model> verticalChart { get; set; }

        public ObservableCollection<Model> PieData { get; set; }

        public ObservableCollection<Model> StripLineData { get; set; }

        public ObservableCollection<Model> MultipleSeriesData1 { get; set; }

        public ObservableCollection<Model> MultipleSeriesData2 { get; set; }

        public ObservableCollection<Model> LineSeries1 { get; set; }

        public ObservableCollection<Model> LineSeries2 { get; set; }

        public ObservableCollection<Model> LineSeries3 { get; set; }

        public ObservableCollection<Model> TriangularData { get; set; }

        public ObservableCollection<Model> TooltipData { get; set; }

        public ObservableCollection<ChartDataPoint> DateTimeRangeData { get; set; }

        public ObservableCollection<ChartDataPoint> DateUsageData { get; set; }

        public ObservableCollection<ChartDataPoint> TechnicalIndicatorData { get; set; }

        public ViewModel()
        {
            DateTime calendar = new DateTime(2000, 1, 1);
            TechnicalIndicatorData = new ObservableCollection<ChartDataPoint>
           {
            new ChartDataPoint(calendar.AddMonths(1), 65.75, 67.27, 65.75, 65.98, 7938200),
            new ChartDataPoint(calendar.AddMonths(2), 65.98, 65.70, 65.04, 65.11, 10185300),
            new ChartDataPoint(calendar.AddMonths(3), 65.11, 65.05, 64.26, 64.97, 10835800),
            new ChartDataPoint(calendar.AddMonths(4), 64.97, 65.16, 64.09, 64.29, 9613400),
            new ChartDataPoint(calendar.AddMonths(5), 64.29, 62.73, 61.85, 62.44, 17175000),
            new ChartDataPoint(calendar.AddMonths(6), 62.44, 62.02, 61.29, 61.47, 18040600),
            new ChartDataPoint(calendar.AddMonths(7), 61.47, 62.75, 61.55, 61.59, 13456300),
            new ChartDataPoint(calendar.AddMonths(8), 61.59, 64.78, 62.22, 64.64, 8045100),
            new ChartDataPoint(calendar.AddMonths(9), 64.64, 64.50, 63.03, 63.28, 8608900),
            new ChartDataPoint(calendar.AddMonths(10), 63.28, 63.70, 62.70, 63.59, 15025500),
            new ChartDataPoint(calendar.AddMonths(11), 63.59, 64.45, 63.26, 63.61, 10065800),
            new ChartDataPoint(calendar.AddMonths(12), 63.61, 64.56, 63.81, 64.52, 6178200),
            new ChartDataPoint(calendar.AddMonths(13), 64.52, 64.84, 63.66, 63.91, 5478500),
            new ChartDataPoint(calendar.AddMonths(14), 63.91, 65.30, 64.50, 65.22, 7964300),
            new ChartDataPoint(calendar.AddMonths(15), 65.22, 65.36, 64.46, 65.06, 5679300),
            new ChartDataPoint(calendar.AddMonths(16), 65.06, 64.54, 63.56, 63.65, 10758300),
            new ChartDataPoint(calendar.AddMonths(17), 63.65, 64.03, 63.33, 63.73, 5665900),
            new ChartDataPoint(calendar.AddMonths(18), 63.73, 63.40, 62.80, 62.83, 5833000),
            new ChartDataPoint(calendar.AddMonths(19), 62.83, 63.75, 62.96, 63.60, 3500800),
            new ChartDataPoint(calendar.AddMonths(20), 63.6, 63.64, 62.51, 63.51, 5044700),
            new ChartDataPoint(calendar.AddMonths(21), 63.51, 64.03, 63.53, 63.76, 4871300),
            new ChartDataPoint(calendar.AddMonths(22), 63.76, 63.77, 63.01, 63.65, 7040400),
            new ChartDataPoint(calendar.AddMonths(23), 63.65, 63.95, 63.58, 63.79, 4727800),
            new ChartDataPoint(calendar.AddMonths(24), 63.79, 63.47, 62.92, 63.25, 6334900),
            new ChartDataPoint(calendar.AddMonths(25), 63.25, 63.96, 63.21, 63.48, 6823200),
            new ChartDataPoint(calendar.AddMonths(26), 63.48, 63.63, 62.55, 63.50, 9718400),
            new ChartDataPoint(calendar.AddMonths(27), 63.5, 63.25, 62.82, 62.90, 2827000),
            new ChartDataPoint(calendar.AddMonths(28), 62.9, 62.34, 62.05, 62.18, 4942700),
            new ChartDataPoint(calendar.AddMonths(29), 62.18, 62.86, 61.94, 62.81, 4582800),
            new ChartDataPoint(calendar.AddMonths(30), 62.81, 63.06, 62.44, 62.83, 12423900),
            new ChartDataPoint(calendar.AddMonths(31), 62.83, 63.16, 62.66, 63.09, 4940500),
            new ChartDataPoint(calendar.AddMonths(32), 63.09, 62.89, 62.43, 62.66, 6132300),
            new ChartDataPoint(calendar.AddMonths(33), 62.66, 62.39, 61.90, 62.25, 6263800),
            new ChartDataPoint(calendar.AddMonths(34), 62.25, 61.69, 60.97, 61.50, 5008300),
            new ChartDataPoint(calendar.AddMonths(35), 61.5, 61.87, 61.18, 61.79, 6662500),
            new ChartDataPoint(calendar.AddMonths(36), 61.79, 63.41, 62.72, 63.16, 5254000),
            new ChartDataPoint(calendar.AddMonths(37), 63.16, 64.40, 63.65, 63.89, 5356600),
            new ChartDataPoint(calendar.AddMonths(38), 63.89, 63.45, 61.60, 61.87, 5052600),
            new ChartDataPoint(calendar.AddMonths(39), 61.87, 62.35, 61.30, 61.54, 6266700),
            new ChartDataPoint(calendar.AddMonths(40), 61.54, 61.49, 60.33, 61.06, 6190800),
            new ChartDataPoint(calendar.AddMonths(41), 61.06, 60.78, 59.84, 60.09, 6452300),
            new ChartDataPoint(calendar.AddMonths(42), 60.09, 59.62, 58.62, 58.80, 5954000),
            new ChartDataPoint(calendar.AddMonths(43), 58.8, 59.60, 58.89, 59.53, 6250000),
            new ChartDataPoint(calendar.AddMonths(44), 59.53, 60.96, 59.42, 60.68, 5307300),
            new ChartDataPoint(calendar.AddMonths(45), 60.68, 61.12, 60.65, 60.73, 6192900),
            new ChartDataPoint(calendar.AddMonths(46), 60.73, 61.19, 60.62, 61.19, 6355600),
            new ChartDataPoint(calendar.AddMonths(47), 61.19, 61.07, 60.54, 60.97, 2946300),
            new ChartDataPoint(calendar.AddMonths(48), 60.97, 61.05, 59.65, 59.75, 2257600),
            new ChartDataPoint(calendar.AddMonths(49), 59.75, 60.58, 55.99, 59.93, 2872000),
            new ChartDataPoint(calendar.AddMonths(50), 59.93, 60.12, 59.26, 59.73, 2737500),
            new ChartDataPoint(calendar.AddMonths(51), 59.73, 60.11, 59.35, 59.57, 2589700),
            new ChartDataPoint(calendar.AddMonths(52), 59.57, 60.40, 59.60, 60.10, 7315800),
            new ChartDataPoint(calendar.AddMonths(53), 60.1, 60.31, 59.76, 60.28, 6883900),
            new ChartDataPoint(calendar.AddMonths(54), 60.28, 61.68, 60.50, 61.50, 5570700),
            new ChartDataPoint(calendar.AddMonths(55), 61.5, 62.72, 61.64, 62.26, 5976000),
            new ChartDataPoint(calendar.AddMonths(56), 62.26, 64.08, 63.10, 63.70, 3641400),
            new ChartDataPoint(calendar.AddMonths(57), 63.7, 64.60, 63.99, 64.39, 6711600),
            new ChartDataPoint(calendar.AddMonths(58), 64.39, 64.45, 63.92, 64.25, 6427000),
            new ChartDataPoint(calendar.AddMonths(59), 64.25, 65.40, 64.66, 64.70, 5863200),
            new ChartDataPoint(calendar.AddMonths(60), 64.7, 65.86, 65.32, 65.75, 4711400),
            new ChartDataPoint(calendar.AddMonths(61), 65.75, 65.22, 64.63, 64.75, 5930600),
            new ChartDataPoint(calendar.AddMonths(62), 64.75, 65.39, 64.76, 65.04, 5602700),
            new ChartDataPoint(calendar.AddMonths(63), 65.04, 65.30, 64.78, 65.18, 7487300),
            new ChartDataPoint(calendar.AddMonths(64), 65.18, 65.09, 64.42, 65.09, 9085400),
            new ChartDataPoint(calendar.AddMonths(65), 65.09, 65.64, 65.20, 65.25, 6455300),
            new ChartDataPoint(calendar.AddMonths(66), 65.25, 65.59, 64.74, 64.84, 6135500),
            new ChartDataPoint(calendar.AddMonths(67), 64.84, 65.84, 65.42, 65.82, 5846400),
            new ChartDataPoint(calendar.AddMonths(68), 65.82, 66.75, 65.85, 66.00, 6681200),
            new ChartDataPoint(calendar.AddMonths(69), 66, 67.41, 66.17, 67.41, 8780000),
            new ChartDataPoint(calendar.AddMonths(70), 67.41, 68.61, 68.06, 68.41, 10780900),
            new ChartDataPoint(calendar.AddMonths(71), 68.41, 68.91, 68.42, 68.76, 2336450),
            new ChartDataPoint(calendar.AddMonths(72), 68.76, 69.58, 68.86, 69.01, 11902000),
            new ChartDataPoint(calendar.AddMonths(73), 69.01, 69.14, 68.74, 68.94, 7513300),
            new ChartDataPoint(calendar.AddMonths(74), 68.94, 68.73, 68.06, 68.65, 12074800),
            new ChartDataPoint(calendar.AddMonths(75), 68.65, 68.79, 68.19, 68.67, 8785400),
            new ChartDataPoint(calendar.AddMonths(76), 68.67, 69.75, 68.68, 68.74, 11373200),
            new ChartDataPoint(calendar.AddMonths(77), 68.74, 68.82, 67.71, 67.76, 12378300),
            new ChartDataPoint(calendar.AddMonths(78), 67.76, 69.05, 68.43, 69.00, 8458700),
            new ChartDataPoint(calendar.AddMonths(79), 69, 68.39, 67.77, 68.02, 10779200),
            new ChartDataPoint(calendar.AddMonths(80), 68.02, 67.94, 67.22, 67.72, 9665400),
            new ChartDataPoint(calendar.AddMonths(81), 67.72, 68.15, 67.32, 67.32, 12258400),
            new ChartDataPoint(calendar.AddMonths(82), 67.32, 67.95, 67.13, 67.32, 7563600),
            new ChartDataPoint(calendar.AddMonths(83), 67.32, 68.00, 67.16, 67.96, 5509900),
            new ChartDataPoint(calendar.AddMonths(84), 67.96, 68.89, 68.34, 68.61, 12135500),
            new ChartDataPoint(calendar.AddMonths(85), 68.61, 69.47, 68.30, 68.51, 8462000),
            new ChartDataPoint(calendar.AddMonths(86), 68.51, 68.69, 68.21, 68.62, 2011950),
            new ChartDataPoint(calendar.AddMonths(87), 68.62, 68.39, 65.80, 68.37, 8536800),
            new ChartDataPoint(calendar.AddMonths(88), 68.37, 67.75, 65.00, 62.00, 7624900),
            new ChartDataPoint(calendar.AddMonths(89), 67.62, 67.04, 65.04, 67.00, 13694600),
            new ChartDataPoint(calendar.AddMonths(90), 66, 66.83, 65.02, 67.60, 8911200),
            new ChartDataPoint(calendar.AddMonths(91), 66.6, 66.98, 65.44, 66.73, 6679600),
            new ChartDataPoint(calendar.AddMonths(92), 66.73, 66.84, 65.10, 66.11, 6451900),
            new ChartDataPoint(calendar.AddMonths(93), 66.11, 66.59, 65.69, 66.38, 6739100),
            new ChartDataPoint(calendar.AddMonths(94), 66.38, 67.98, 66.51, 67.67, 2103260),
            new ChartDataPoint(calendar.AddMonths(95), 67.67, 69.21, 68.59, 68.90, 10551800),
            new ChartDataPoint(calendar.AddMonths(96), 68.9, 69.96, 69.27, 69.44, 5261100),
            new ChartDataPoint(calendar.AddMonths(97), 69.44, 69.01, 68.14, 68.18, 5905400),
            new ChartDataPoint(calendar.AddMonths(98), 68.18, 68.93, 68.08, 68.14, 10283600),
            new ChartDataPoint(calendar.AddMonths(99), 68.14, 68.60, 66.92, 67.25, 5006800),
            new ChartDataPoint(calendar.AddMonths(100), 67.25, 67.77, 67.23, 67.77, 4110000)
        };

            DateTimeRangeData = new ObservableCollection<ChartDataPoint>
            {
                new ChartDataPoint(new DateTime(2015, 01, 1), 14),
                new ChartDataPoint(new DateTime(2015, 02, 1), 54),
                new ChartDataPoint(new DateTime(2015, 03, 1), 23),
                new ChartDataPoint(new DateTime(2015, 04, 1), 53),
                new ChartDataPoint(new DateTime(2015, 05, 1), 25),
                new ChartDataPoint(new DateTime(2015, 06, 1), 32),
                new ChartDataPoint(new DateTime(2015, 07, 1), 78),
                new ChartDataPoint(new DateTime(2015, 08, 1), 100),
                new ChartDataPoint(new DateTime(2015, 09, 1), 55),
                new ChartDataPoint(new DateTime(2015, 10, 1), 38),
                new ChartDataPoint(new DateTime(2015, 11, 1), 27),
                new ChartDataPoint(new DateTime(2015, 12, 1), 56),
        new ChartDataPoint(new DateTime(2015, 12, 31), 35),
            };

            DateUsageData = new ObservableCollection<ChartDataPoint>();

            DateUsageData.Add(new ChartDataPoint(dataTime, 14));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 54));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 23));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 53));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 25));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 32));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 78));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 100));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 55));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 38));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 27));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 56));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 55));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 38));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 27));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 56));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 30));
            addWeek();
            DateUsageData.Add(new ChartDataPoint(dataTime, 45));

            PolarData1 = new ObservableCollection<Model>
            {
                new Model("N", 80),
                new Model("NE", 85),
                new Model("E", 78),
                new Model("SE", 90),
                new Model("S", 78),
                new Model("SW", 83),
                new Model("W", 79),
                new Model("NW", 88)

            };

            PolarData2 = new ObservableCollection<Model>
            {
                new Model("N", 63),
                new Model("NE", 70),
                new Model("E", 45),
                new Model("SE", 70),
                new Model("S", 47),
                new Model("SW", 65),
                new Model("W", 58),
                new Model("NW", 73)
            };

            PolarData3 = new ObservableCollection<Model>
            {
                new Model("N", 42),
                new Model("NE", 40),
                new Model("E", 25),
                new Model("SE", 40),
                new Model("S", 20),
                new Model("SW", 45),
                new Model("W", 40),
                new Model("NW", 40)
            };

            AreaData = new ObservableCollection<Model>
            {
                new Model("2010", 45),
                new Model("2011", 56),
                new Model("2012", 23),
                new Model("2013", 43),
                new Model("2014", Double.NaN),
                new Model("2015", 54),
                new Model("2016", 43),
                new Model("2017", 23),
                new Model("2018", 34)
            };

            StripLineData = new ObservableCollection<Model>
            {
                 new Model("Jan", 33),
                 new Model("Feb", 37),
                 new Model("Mar", 39),
                 new Model("Apr", 43),
                 new Model("May", 45),
                 new Model("Jun", 43),
                 new Model("Jul", 41),
                 new Model("Aug", 40),
                 new Model("Sep", 39),
                 new Model("Oct", 39),
                 new Model("Nov", 34),
                 new Model("Dec", 33)
            };

            LineData = new ObservableCollection<Model>
            {
                new Model("2005", 28),
                new Model("2006", 25),
                new Model("2007", 26),
                new Model("2008", 27),
                new Model("2009", 32),
                new Model("2010", 35),
                new Model("2011", 30)
            };

            LineData1 = new ObservableCollection<Model>
            {
                new Model("2005", 31),
                new Model("2006", 28),
                new Model("2007", 30),
                new Model("2008", 36),
                new Model("2009", 36),
                new Model("2010", 39),
                new Model("2011", 37)
            };

            LineData2 = new ObservableCollection<Model>
            {
                new Model("2005", 39),
                new Model("2006", 36),
                new Model("2007", 40),
                new Model("2008", 44),
                new Model("2009", 45),
                new Model("2010", 48),
                new Model("2011", 46)
            };

            StepLineData1 = new ObservableCollection<Model>
            {
                new Model(2006, 463),
                new Model(2007, 449),
                new Model(2008, 458),
                new Model(2009, 450),
                new Model(2010, 425),
                new Model(2011, 430),
            };
            StepLineData2 = new ObservableCollection<Model>
            {
                new Model(2006, 519),
                new Model(2007, 508),
                new Model(2008, 502),
                new Model(2009, 495),
                new Model(2010, 485),
                new Model(2011, 470),
            };
            StepLineData3 = new ObservableCollection<Model>
            {
                new Model(2006, 570),
                new Model(2007, 579),
                new Model(2008, 563),
                new Model(2009, 550),
                new Model(2010, 545),
                new Model(2011, 525),
            };

            StepAreaData1 = new ObservableCollection<Model>
            {
                new Model(2006, 400),
                new Model(2007, 480),
                new Model(2008, 460),
                new Model(2009, 520),
                new Model(2010, 450),
                new Model(2011, 450),
            };

            ColumnData1 = new ObservableCollection<Model>
            {
                new Model("USA", 50),
                new Model("China", 40),
                new Model("Japan", 70),
                new Model("Australia", 60),
                new Model("France", 50),
           };
            ColumnData2 = new ObservableCollection<Model>
            {
                 new Model("USA", 70),
                new Model("China", 60),
                new Model("Japan", 60),
                new Model("Australia", 56),
                new Model("France", 45),
            };
            ColumnData3 = new ObservableCollection<Model>
            {
                new Model("USA", 45),
                new Model("China", 55),
                new Model("Japan", 50),
                new Model("Australia", 40),
                new Model("France", 35),
            };
            BarData1 = new ObservableCollection<Model>
            {
                new Model("2006", 7.8),
                new Model("2007", 7.2),
                new Model("2008", 6.8),
                new Model("2009", 10.7),
                new Model("2010", 10.8),
                new Model("2011", 9.8)
            };
            BarData2 = new ObservableCollection<Model>
            {
                new Model("2006", 4.8),
                new Model("2007", 4.6),
                new Model("2008", 7.2),
                new Model("2009", 9.3),
                new Model("2010", 9.7),
                new Model("2011", 9)
            };
            AreaData1 = new ObservableCollection<Model>
            {
                new Model(1900, 4.0),
                new Model(1920, 3.0),
                new Model(1940, 3.8),
                new Model(1960, 3.4),
                new Model(1980, 3.2),
                new Model(2000, 3.9),
            };
            AreaData2 = new ObservableCollection<Model>
            {
                new Model(1900, 2.6),
                new Model(1920, 2.8),
                new Model(1940, 2.6),
                new Model(1960, 3.0),
                new Model(1980, 3.6),
                new Model(2000, 3.0)
            };
            AreaData3 = new ObservableCollection<Model>
            {
                new Model(1900, 2.8),
                new Model(1920, 2.5),
                new Model(1940, 2.8),
                new Model(1960, 3.0),
                new Model(1980, 2.9),
                new Model(2000, 2.0)
            };
            SplineData1 = new ObservableCollection<Model>
            {
                new Model("Jan", -1),
                new Model("Feb", -1),
                new Model("Mar", 2),
                new Model("Apr", 8),
                new Model("May", 13),
                new Model("Jun", 18),
                new Model("Jul", 21),
                new Model("Aug", 20),
                new Model("Sep", 16),
                new Model("Oct", 10),
                new Model("Nov", 4),
                new Model("Dec", 0),
            };

            SplineData2 = new ObservableCollection<Model>
            {
                new Model("Jan", 7),
                new Model("Feb", 8),
                new Model("Mar", 12),
                new Model("Apr", 19),
                new Model("May", 25),
                new Model("Jun", 29),
                new Model("Jul", 31),
                new Model("Aug", 30),
                new Model("Sep", 26),
                new Model("Oct", 20),
                new Model("Nov", 14),
                new Model("Dec", 8),
            };
            SplineAreaData1 = new ObservableCollection<Model>
            {
                new Model("2002", 2.2),
                new Model("2003", 3.4),
                new Model("2004", 2.8),
                new Model("2005", 1.6),
                new Model("2006", 2.3),
                new Model("2007", 2.5),
                new Model("2008", 2.9),
                new Model("2009", 3.8),
                new Model("2010", 1.4),
                new Model("2011", 3.1),
            };
            SplineAreaData2 = new ObservableCollection<Model>
            {
                new Model("2002", 2.0),
                new Model("2003", 1.7),
                new Model("2004", 1.8),
                new Model("2005", 2.1),
                new Model("2006", 2.3),
                new Model("2007", 1.7),
                new Model("2008", 1.5),
                new Model("2009", 2.8),
                new Model("2010", 1.5),
                new Model("2011", 2.3),
            };
            SplineAreaData3 = new ObservableCollection<Model>
            {
                new Model("2002", 0.8),
                new Model("2003", 1.3),
                new Model("2004", 1.1),
                new Model("2005", 1.6),
                new Model("2006", 2.0),
                new Model("2007", 1.7),
                new Model("2008", 2.3),
                new Model("2009", 2.7),
                new Model("2010", 1.1),
                new Model("2011", 2.3),
            };
          
            StepLineData = new ObservableCollection<Model>
            {
                new Model("2002", 36),
                new Model("2003", 40),
                new Model("2004", 34),
                new Model("2005", 40),
                new Model("2006", 44),
                new Model("2007", 38),
                new Model("2008", 30)

            };
            PieSeriesData = new ObservableCollection<Model>
            {
                new Model("Other personal", 94658),
                new Model("Medical care", 9090),
                new Model("Housing", 2577),
                new Model("Transportation", 473),
                new Model("Education", 120),
                new Model("Electronics", 70),
           };
            DoughnutSeriesData = new ObservableCollection<Model>
            {
                new Model("Labour", 28),
                new Model("Legal", 10),
                new Model("Production", 20),
                new Model("License", 15),
                new Model("Facilities", 23),
                new Model("Taxes", 17),
                new Model("Insurance", 12),
           };
            PyramidData = new ObservableCollection<Model>
            {
                new Model("India", 24),
                new Model("Japan", 25),
                new Model("Australia", 20),
                new Model("USA", 35),
                new Model("China", 23),
                new Model("Germany", 27),
                new Model("France", 22),
           };
            FunnelData = new ObservableCollection<Model>
            {
               new Model("Renewed", 18.2),
               new Model("Subscribe", 27.3),
               new Model("Support", 55.9),
               new Model("Downloaded", 76.8),
               new Model("Visited", 100),
           };
            StackedBarData1 = new ObservableCollection<Model>
            {
                new Model("Jan", 6),
                new Model("Feb", 8),
                new Model("Mar", 12),
                new Model("Apr", 15.5),
                new Model("May", 20),
                new Model("Jun", 24),
                new Model("Jul", 28),
                new Model("Aug", 32),
                new Model("Sep", 33),
                new Model("Oct", 35),
                new Model("Nov", 40),
                new Model("Dec", 42),
           };
            StackedBarData2 = new ObservableCollection<Model>
            {
                new Model("Jan", 6),
                new Model("Feb", 8),
                new Model("Mar", 12),
                new Model("Apr", 15.5),
                new Model("May", 20),
                new Model("Jun", 24),
                new Model("Jul", 28),
                new Model("Aug", 32),
                new Model("Sep", 33),
                new Model("Oct", 35),
                new Model("Nov", 40),
                new Model("Dec", 42),
            };
            StackedBarData3 = new ObservableCollection<Model>
            {
                new Model("Jan", -1),
                new Model("Feb", -1.5),
                new Model("Mar", -2),
                new Model("Apr", -2.5),
                new Model("May", -3),
                new Model("Jun", -3.5),
                new Model("Jul", -4),
                new Model("Aug", -4.5),
                new Model("Sep", -5),
                new Model("Oct", -5.5),
                new Model("Nov", -6),
                new Model("Dec", -6.5),
            };
            StackedBar100Data1 = new ObservableCollection<Model>
            {
                new Model(2007, 453),
                new Model(2008, 354),
                new Model(2009, 282),
                new Model(2010, 321),
                new Model(2011, 333),
                new Model(2012, 351),
                new Model(2013, 403),
                new Model(2014, 421),
            };
            StackedBar100Data2 = new ObservableCollection<Model>
            {
                new Model(2007, 876),
                new Model(2008, 564),
                new Model(2009, 242),
                new Model(2010, 121),
                new Model(2011, 343),
                new Model(2012, 451),
                new Model(2013, 203),
                new Model(2014, 431),
            };
            StackedBar100Data3 = new ObservableCollection<Model>
            {
                new Model(2007, 356),
                new Model(2008, 876),
                new Model(2009, 898),
                new Model(2010, 567),
                new Model(2011, 456),
                new Model(2012, 345),
                new Model(2013, 543),
                new Model(2014, 654),
            };
            StackedBar100Data4 = new ObservableCollection<Model>
            {
                new Model(2007, 122),
                new Model(2008, 444),
                new Model(2009, 222),
                new Model(2010, 231),
                new Model(2011, 122),
                new Model(2012, 333),
                new Model(2013, 354),
                new Model(2014, 100),
            };
            StackedColumnData1 = new ObservableCollection<Model>
            {
                new Model("Jan", 900),
                new Model("Feb", 820),
                new Model("Mar", 880),
                new Model("Apr", 725),
                new Model("May", 765),
                new Model("Jun", 679),
            };
            StackedColumnData2 = new ObservableCollection<Model>
            {
                new Model("Jan", 190),
                new Model("Feb", 226),
                new Model("Mar", 194),
                new Model("Apr", 250),
                new Model("May", 222),
                new Model("Jun", 181),
            };
            StackedColumnData3 = new ObservableCollection<Model>
            {
                new Model("Jan", 250),
                new Model("Feb", 145),
                new Model("Mar", 190),
                new Model("Apr", 220),
                new Model("May", 225),
                new Model("Jun", 135),
            };
            StackedColumnData4 = new ObservableCollection<Model>
            {
                new Model("Jan", 150),
                new Model("Feb", 120),
                new Model("Mar", 115),
                new Model("Apr", 125),
                new Model("May", 132),
                new Model("Jun", 137),
            };

            StackedAreaData1 = new ObservableCollection<Model>
            {
                new Model("2002", 6),
                new Model("2003", 7.5),
                new Model("2004", 6),
                new Model("2005", 6.5),
                new Model("2006", 7.4),
                new Model("2007", 7.9),
                new Model("2008", 7.5),
                new Model("2009", 8.5),
                new Model("2010", 4.8),
                new Model("2011", 9.3),
            };
            StackedAreaData2 = new ObservableCollection<Model>
            {
                new Model("2002", 3.5),
                new Model("2003", 4.9),
                new Model("2004", 3.7),
                new Model("2005", 7.5),
                new Model("2006", 4.8),
                new Model("2007", 2.6),
                new Model("2008", 4.7),
                new Model("2009", 3.7),
                new Model("2010", 3.5),
                new Model("2011", 3.6),
            };
            StackedAreaData3 = new ObservableCollection<Model>
            {
                new Model("2002", 8.1),
                new Model("2003", 8.8),
                new Model("2004", 6.7),
                new Model("2005", 6.4),
                new Model("2006", 4.0),
                new Model("2007", 4.8),
                new Model("2008", 7.4),
                new Model("2009", 3.5),
                new Model("2010", 8.3),
                new Model("2011", 4.7),
            };
            StackedAreaData4 = new ObservableCollection<Model>
            {
                new Model("2002", 2.5),
                new Model("2003", 6.1),
                new Model("2004", 6.2),
                new Model("2005", 1.8),
                new Model("2006", 4.0),
                new Model("2007", 6.5),
                new Model("2008", 6.7),
                new Model("2009", 7.2),
                new Model("2010", 8.4),
                new Model("2011", 6.9),
            };
            StackedArea100Data1 = new ObservableCollection<Model>
            {
                new Model("2006", 34),
                new Model("2007", 20),
                new Model("2008", 40),
                new Model("2009", 51),
                new Model("2010", 26),
                new Model("2011", 37),
                new Model("2012", 54),
                new Model("2013", 44),
                new Model("2014", 48),
            };
            StackedArea100Data2 = new ObservableCollection<Model>
            {
                new Model("2006", 51),
                new Model("2007", 26),
                new Model("2008", 37),
                new Model("2009", 51),
                new Model("2010", 26),
                new Model("2011", 37),
                new Model("2012", 43),
                new Model("2013", 23),
                new Model("2014", 55),
            };
            StackedArea100Data3 = new ObservableCollection<Model>
            {
                new Model("2006", 14),
                new Model("2007", 34),
                new Model("2008", 73),
                new Model("2009", 51),
                new Model("2010", 26),
                new Model("2011", 37),
                new Model("2012", 12),
                new Model("2013", 16),
                new Model("2014", 34),
            };
            StackedArea100Data4 = new ObservableCollection<Model>
            {
                new Model("2006", 37),
                new Model("2007", 16),
                new Model("2008", 53),
                new Model("2009", 51),
                new Model("2010", 26),
                new Model("2011", 37),
                new Model("2012", 54),
                new Model("2013", 44),
                new Model("2014", 23),
            };
            CircularData = new ObservableCollection<Model>
            {
                new Model("2010", 8000),
                new Model("2011", 8100),
                new Model("2012", 8250),
                new Model("2013", 8600),
                new Model("2014", 8700)
            };
            MultipleAxisData = new ObservableCollection<Model>
            {
                new Model("2010", 20),
                new Model("2011", 21),
                new Model("2012", 22.5),
                new Model("2013", 26),
                new Model("2014", 27)
            };

            SemiCircularData = new ObservableCollection<Model>
            {
                new Model("Product A", 14),
                new Model("Product B", 54),
                new Model("Product C", 23),
                new Model("Product D", 53),
            };

            BubbleData = new ObservableCollection<Model>
            {
                new Model(92.2, 7.8, 0.47),
                new Model(74, 6.5, 0.241),
                new Model(90.4, 6.0, 0.238),
                new Model(99.4, 2.2, 0.312),
                new Model(88.6, 1.3, 0.197),
                new Model(54.9, 3.7, 0.177),
                new Model(99, 0.7, 0.0818),
                new Model(72, 2.0, 0.0826),
                new Model(99.6, 3.4, 0.143),
                new Model(99, 0.2, 0.128),
                new Model(86.1, 4.0, 0.115),
                new Model(92.6, 6.6, 0.096),
                new Model(61.3, 14.5, 0.162),
                new Model(56.8, 6.1, 0.151),

            };

            ScatterData = new ObservableCollection<Model>();
            {
                for (int i = 0; i < 300; i++)
                {
                    double x = random.NextDouble() * 100;
                    double y = random.NextDouble() * 500;
                    double randomDouble = random.NextDouble();
                    if (randomDouble >= .25 && randomDouble < .5)
                    {
                        x *= -1;
                    }
                    else if (randomDouble >= .5 && randomDouble < .75)
                    {
                        y *= -1;
                    }
                    else if (randomDouble > .75)
                    {
                        x *= -1;
                        y *= -1;
                    }
                    ScatterData.Add(new Model(300 + (x * (random.NextDouble() + 0.12)),
                            100 + (y * (random.NextDouble() + 0.12))));
                }
            }

            
            FinancialData = new ObservableCollection<Model>
            {
                new Model(new DateTime(2000, 01, 17), 125, 70, 90, 115),
                new Model(new DateTime(2000, 02, 17), 150, 60, 120, 70),
                new Model(new DateTime(2000, 03, 17), 200, 140, 190, 160),
                new Model(new DateTime(2000, 04, 17), 160, 90, 110, 140),
                new Model(new DateTime(2000, 05, 17), 200, 100, 120, 180),
                new Model(new DateTime(2000, 06, 17), 100, 45, 70, 50)
            };
            Data1 = new ObservableCollection<Model>
            {
                new Model("2010", 45),
                new Model("2011", 89),
                new Model("2012", 23),
                new Model("2013", 43),
                new Model("2014", 54)
            };

            Data2 = new ObservableCollection<Model>
            {
                new Model("2010", 54),
                new Model("2011", 24),
                new Model("2012", 53),
                new Model("2013", 63),
                new Model("2014", 35)
            };

            Data3 = new ObservableCollection<Model>
            {
                new Model("2010", 14),
                new Model("2011", 54),
                new Model("2012", 23),
                new Model("2013", 53),
                new Model("2014", 25)
            };

            CategoryData = new ObservableCollection<Model>
            {
                new Model("Product A", 10),
                new Model("Product B", 30),
                new Model("Product C", 15),
                new Model("Product D", 65),
                new Model("Product E", 90),
                new Model("Product F", 85),
            };

            LogarithmicData = new ObservableCollection<Model>
            {
                new Model("1990", 80),
                new Model("1991", 200),
                new Model("1992", 400),
                new Model("1993", 600),
                new Model("1994", 900),
                new Model("1995", 1400),
                new Model("1996", 2000),
                new Model("1997", 4000),
                new Model("1998", 6000),
                new Model("1999", 8000),
                new Model("2000", 9000)
            };

            NumericData = new ObservableCollection<Model>
            {
                new Model(2001, 75),
                new Model(2002, 90),
                new Model(2003, 85),
                new Model(2004, 70),
                new Model(2005, 55),
                new Model(2006, 65),
            };

            DateTimeData = new ObservableCollection<Model>
            {
                new Model(new DateTime(2014, 02, 1), 10),
                new Model(new DateTime(2015, 03, 2), 30),
                new Model(new DateTime(2016, 04, 3), 15),
                new Model(new DateTime(2017, 05, 4), 65),
                new Model(new DateTime(2018, 06, 5), 90),
                new Model(new DateTime(2019, 07, 5), 85)
            };


            datas1 = new ObservableCollection<Model>
            {
                new Model("2010", 6),
                new Model("2011", 15),
                new Model("2012", 35),
                new Model("2013", 65),
                new Model("2014", 75)
            };

            SelectionData = new ObservableCollection<Model>
            {
                new Model("Jan", 42),
                new Model("Feb", 44),
                new Model("Mar", 53),
                new Model("Apr", 64),
                new Model("May", 75),
                new Model("Jun", 83)
            };

            MultipleSeriesData1 = new ObservableCollection<Model>();

            for (var i = 1; i <= 12; i++)
            {
                MultipleSeriesData1.Add(new Model(new DateTime(2014, i, 1), random.Next(10, 100)));
            }

            MultipleSeriesData2 = new ObservableCollection<Model>();

            for (var i = 1; i <= 12; i++)
            {
                MultipleSeriesData2.Add(new Model(new DateTime(2014, i, 1), random.Next(10, 100)));
            }

            PieData = new ObservableCollection<Model>
            {
                new Model(new DateTime(2014, 1, 1), 48),
                new Model(new DateTime(2014, 2, 1), 38),
                new Model(new DateTime(2014, 3, 1), 28),
                new Model(new DateTime(2014, 4, 1), 33),
                new Model(new DateTime(2014, 5, 1), 25),
                new Model(new DateTime(2014, 6, 1), 34)
            };

            TriangularData = new ObservableCollection<Model>
            {
                new Model("Bentley", 800),
                new Model("Audi", 810),
                new Model("BMW", 825),
                new Model("Jaguar", 860),
                new Model("Skoda", 875)
            };

            data = new ObservableCollection<Model>();

            liveData1 = new ObservableCollection<Model>();

            liveData2 = new ObservableCollection<Model>();

            verticalChart = new ObservableCollection<Model>();

            LineSeries1 = new ObservableCollection<Model>();
            LineSeries1.Add(new Model(1, 54));
            LineSeries1.Add(new Model(2, 24));
            LineSeries1.Add(new Model(3, 53));
            LineSeries1.Add(new Model(4, 63));
            LineSeries1.Add(new Model(5, 35));

            LineSeries2 = new ObservableCollection<Model>();
            LineSeries2.Add(new Model(1, 34));
            LineSeries2.Add(new Model(2, 20));
            LineSeries2.Add(new Model(3, 43));
            LineSeries2.Add(new Model(4, 53));
            LineSeries2.Add(new Model(5, 25));

            LineSeries3 = new ObservableCollection<Model>();
            LineSeries3.Add(new Model(1, 24));
            LineSeries3.Add(new Model(2, 14));
            LineSeries3.Add(new Model(3, 33));
            LineSeries3.Add(new Model(4, 43));
            LineSeries3.Add(new Model(5, 15));


            TooltipData = new ObservableCollection<Model>();
            TooltipData.Add(new Model("2007", 1.61));
            TooltipData.Add(new Model("2008", 2.34));
            TooltipData.Add(new Model("2009", 2.16));
            TooltipData.Add(new Model("2010", 2.1));
            TooltipData.Add(new Model("2011", 1.61));
            TooltipData.Add(new Model("2012", 2.05));
            TooltipData.Add(new Model("2013", 2.5));
            TooltipData.Add(new Model("2014", 2.21));
            TooltipData.Add(new Model("2015", 2.34));
        }

        public void LoadData()
        {
            for (var i = 0; i < 2; i++)
            {
                data.Add(new Model(time, random.Next(0, 100)));
                time = time.AddMilliseconds(500);
                count++;
            }
            count = data.Count;

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 500), () =>
            {
                data.Add(new Model(time, random.Next(0, 100)));
                time = time.AddMilliseconds(500);
                count++;
                return true;
            });
        }

        public async void LoadData1()
        {
            for (var i = 0; i < 180; i++)
            {
                liveData1.Add(new Model(i, Math.Sin(wave1 * (Math.PI / 180.0))));
                wave1++;
            }

            for (var i = 0; i < 180; i++)
            {
                liveData2.Add(new Model(i, Math.Sin(wave2 * (Math.PI / 180.0))));
                wave2++;
            }

            wave1 = liveData1.Count;

            await Task.Delay(200);

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 10), () =>
            {
                liveData1.RemoveAt(0);
                liveData1.Add(new Model(wave1, Math.Sin(wave1 * (Math.PI / 180.0))));
                wave1++;

                liveData2.RemoveAt(0);
                liveData2.Add(new Model(wave1, Math.Sin(wave2 * (Math.PI / 180.0))));
                wave2++;
                return true;
            });
        }

        public void LoadVerticalData()
        {
            Random rand = new Random();
            for (int j = 11; j < 50; j++)
            {
                verticalChart.Add(new Model(j, rand.Next(-3, 3)));
            }

            int index = (int)verticalChart[verticalChart.Count - 1].Value + 1;
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 10), () =>
            {
                count = count + 1;
                Random random = new Random();
                if (count > 350)
                {
                    return false;
                }
                else if (count > 300)
                {
                    verticalChart.Add(new Model(index, random.Next(0, 0)));
                }
                else if (count > 250)
                {
                    verticalChart.Add(new Model(index, random.Next(-2, 1)));
                }
                else if (count > 180)
                {
                    verticalChart.Add(new Model(index, random.Next(-3, 2)));
                }
                else if (count > 100)
                {
                    verticalChart.Add(new Model(index, random.Next(-7, 6)));
                }
                else
                {
                    verticalChart.Add(new Model(index, random.Next(-9, 9)));
                }
                index++;
                return true;
            });
        }

        private void addWeek()
        {
            dataTime = dataTime.AddDays(7);
        }
    }
}
