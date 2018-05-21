using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class NumericSampleAverage
    {
        public int? Id { get; set; }

        public float? Average0 { get; set; }
        public float? Average1 { get; set; }
        public float? Average2 { get; set; }
        public float? Average3 { get; set; }
        public float? Average4 { get; set; }
        public float? Average5 { get; set; }
        public float? Average6 { get; set; }
        public float? Average7 { get; set; }
        public float? Average8 { get; set; }
        public float? Average9 { get; set; }
        public float? Average10 { get; set; }
        public float? Average11 { get; set; }
        public float? Average12 { get; set; }
        public float? Average13 { get; set; }
        public float? Average14 { get; set; }
        public float? Average15 { get; set; }
        public float? Average16 { get; set; }
        public float? Average17 { get; set; }
        public float? Average18 { get; set; }
        public float? Average19 { get; set; }
        public float? Average20 { get; set; }
        public float? Average21 { get; set; }
        public float? Average22 { get; set; }
        public float? Average23 { get; set; }

        public float? Minimum8Till20 { get; set; }
        public float? Maximum8Till20 { get; set; }
        public float? Minimum20Till8 { get; set; }
        public float? Maximum20Till8 { get; set; }


        public float? Sum8Till20
        {
            get
            {
                float? value = 0;
                if (Average8 != null) value += Average8;
                if (Average9 != null) value += Average9;
                if (Average10 != null) value += Average10;
                if (Average11 != null) value += Average11;
                if (Average12 != null) value += Average12;
                if (Average13 != null) value += Average13;
                if (Average14 != null) value += Average14;
                if (Average15 != null) value += Average15;
                if (Average16 != null) value += Average16;
                if (Average17 != null) value += Average17;
                if (Average18 != null) value += Average18;
                if (Average19 != null) value += Average19;

                if (value == 0)
                    return null;

                return value;
            }
        }
        public float? Sum20Till8
        {
            get
            {
                float? value = 0;
                if (Average20 != null) value += Average20;
                if (Average21 != null) value += Average21;
                if (Average22 != null) value += Average22;
                if (Average23 != null) value += Average23;
                if (Average0 != null) value += Average0;
                if (Average1 != null) value += Average1;
                if (Average2 != null) value += Average2;
                if (Average3 != null) value += Average3;
                if (Average4 != null) value += Average4;
                if (Average5 != null) value += Average5;
                if (Average6 != null) value += Average6;
                if (Average7 != null) value += Average7;

                if (value == 0)
                    return null;

                return value;
            }
        }
        public float? Average8Till20
        {
            get
            {
                float? value = 0;
                if (Average8 != null) value += 1;
                if (Average9 != null) value += 1;
                if (Average10 != null) value += 1;
                if (Average11 != null) value += 1;
                if (Average12 != null) value += 1;
                if (Average13 != null) value += 1;
                if (Average14 != null) value += 1;
                if (Average15 != null) value += 1;
                if (Average16 != null) value += 1;
                if (Average17 != null) value += 1;
                if (Average18 != null) value += 1;
                if (Average19 != null) value += 1;

                if (value == 0)
                    return null;

                return Sum8Till20 / value;
            }
        }

        public float? Average20Till8
        {
            get
            {
                float? value = 0;
                if (Average20 != null) value += 1;
                if (Average21 != null) value += 1;
                if (Average22 != null) value += 1;
                if (Average23 != null) value += 1;
                if (Average0 != null) value += 1;
                if (Average1 != null) value += 1;
                if (Average2 != null) value += 1;
                if (Average3 != null) value += 1;
                if (Average4 != null) value += 1;
                if (Average5 != null) value += 1;
                if (Average6 != null) value += 1;
                if (Average7 != null) value += 1;

                if (value == 0)
                    return null;

                return Sum20Till8 / value;
            }
        }
    }
}