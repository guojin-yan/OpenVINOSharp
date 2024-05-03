using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenVinoSharp.Extensions.result
{
    /// <summary>
    /// Object detection result data.
    /// </summary>
    public class ObbData : IResultData
    {
        /// <summary>
        /// Identification result class index.
        /// </summary>
        public int index;
        /// <summary>
        /// Identification result class lable.
        /// </summary>
        public string lable;
        /// <summary>
        /// Confidence value.
        /// </summary>
        public float score;
        /// <summary>
        /// Prediction RotatedRect.
        /// </summary>
        public RotatedRect box;
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ObbData() { }
        /// <summary>
        /// Parameter construction.
        /// </summary>
        /// <param name="index">Identification result number.</param>
        /// <param name="lable">Identification result label.</param>
        /// <param name="score">Identification result score.</param>
        /// <param name="box">Identification result box.</param>
        public ObbData(int index, string lable, float score, RotatedRect box)
        {
            this.index = index;
            this.lable = lable;
            this.score = score;
            this.box = box;
        }
        /// <summary>
        /// Parameter construction.
        /// </summary>
        /// <param name="index">Identification result number.</param>
        /// <param name="score">Identification result score.</param>
        /// <param name="box">Identification result box.</param>
        public ObbData(int index, float score, RotatedRect box)
            : this(index, index.ToString(), score, box)
        { }
        /// <summary>
        /// Update lable.
        /// </summary>
        /// <param name="lables">Lable array.</param>
        /// <returns>DetData class.</returns>
        public ObbData update_lable(List<string> lables)
        {
            this.lable = lables[this.index];
            return this;
        }
        /// <summary>
        /// Update lable.
        /// </summary>
        /// <param name="lables">Lable array.</param>
        /// <returns>DetData class.</returns>
        public ObbData update_lable(string[] lables)
        {
            this.lable = lables[this.index];
            return this;
        }
        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>DetData string.</returns>
        public string to_string(string format = "0.00")
        {
            string msg = "";
            msg += ("index: " + index.ToString() + "\t");
            if (lable != null)
                msg += ("lable: " + lable.ToString() + "\t");
            msg += ("score: " + score.ToString(format) + "\t");
            msg += ("box: " + box.ToString() + "\t");
            return msg;
        }
    };

    /// <summary>
    /// Object detection result class.
    /// </summary>
    public class ObbResult : Result<ObbData>
    {
        /// <summary>
        /// Add data.
        /// </summary>
        /// <param name="index">Identification result number.</param>
        /// <param name="score">Identification result score.</param>
        /// <param name="box">Identification result box.</param>
        public override void add(int index, float score, RotatedRect box)
        {
            ObbData data = new ObbData(index, score, box);
            this.add(data);
        }
        /// <summary>
        /// Add data.
        /// </summary>
        /// <param name="index">Identification result number.</param>
        /// <param name="lable">Identification result label.</param>
        /// <param name="score">Identification result score.</param>
        /// <param name="box">Identification result box.</param>
        public override void add(int index, string lable, float score, RotatedRect box)
        {
            ObbData data = new ObbData(index, lable, score, box);
            this.add(data);
        }

        /// <summary>
        /// Update lable.
        /// </summary>
        /// <param name="lables">Lable array.</param>
        /// <returns>DetData class.</returns>
        public override void update_lable(List<string> lables)
        {
            foreach (ObbData data in this.datas)
            {
                data.update_lable(lables);
            }
        }
        /// <summary>
        /// Update lable.
        /// </summary>
        /// <param name="lables">Lable array.</param>
        /// <returns>DetData class.</returns>
        public override void update_lable(string[] lables)
        {
            foreach (ObbData data in this.datas)
            {
                data.update_lable(lables);
            }
        }
        /// <summary>
        /// Sorts the index elements in the entire inference results using the default comparer.
        /// </summary>
        /// <param name="flag"></param>
        public override void sort_by_index(bool flag = true)
        {
            if (flag)
                this.sort((x, y) => x.index.CompareTo(y.index));
            else
                this.sort((x, y) => y.index.CompareTo(x.index));
        }
        /// <summary>
        /// Sorts the score elements in the entire inference results using the default comparer.
        /// </summary>
        /// <param name="flag"></param>
        public override void sort_by_score(bool flag = true)
        {
            if (flag)
                this.sort((x, y) => x.score.CompareTo(y.score));
            else
                this.sort((x, y) => y.score.CompareTo(x.score));
        }
        /// <summary>
        /// Sorts the box elements in the entire inference results using the default comparer.
        /// </summary>
        /// <param name="flag"></param>
        public override void sort_by_bbox(bool flag)
        {
            datas.OrderBy(t => t.box.Center.X).ThenBy(t => t.box.Center.Y).ToList();

        }

        /// <summary>
        /// Print the inference results.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        public override void print(string format = "0.00")
        {
            INFO("Detection results:");
            foreach (ObbData data in this.datas)
            {
                INFO(data.to_string(format));
            }
        }
    }
}
