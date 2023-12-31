﻿using Emgu.CV;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenVinoSharp.Extensions.model;
using OpenVinoSharp.Extensions.result;
using OpenVinoSharp.Extensions.process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenVinoSharp.Extensions.model.Tests
{
    [TestClass()]
    public class RtdetrDetTests
    {
        public string model_path = "E:\\Model\\RT-DETR\\RTDETR\\rtdetr_r50vd_6x_coco.onnx";
        public string model_path1 = "E:\\Model\\RT-DETR\\RTDETR_cropping\\rtdetr_r50vd_6x_coco.onnx";
        public string image_path = "..\\..\\..\\..\\..\\tests\\test_data\\image\\demo_1.jpg";
        public string image_path1 = "..\\..\\..\\..\\..\\tests\\test_data\\image\\demo_2.jpg";
        public string image_path2 = "..\\..\\..\\..\\..\\tests\\test_data\\image\\demo_3.jpg";
        public string image_path3 = "..\\..\\..\\..\\..\\tests\\test_data\\image\\demo_9.jpg";
        [TestMethod()]
        public void RtdetrDet_test()
        {
            Config config = new RtdetrConfig(model_path);
            RtdetrDet rtdetr = new RtdetrDet((RtdetrConfig)config);
        }

        [TestMethod()]
        public void predict_test()
        {

            Mat image = CvInvoke.Imread(image_path1);
            Config config = new RtdetrConfig(model_path);
            RtdetrDet rtdetr = new RtdetrDet((RtdetrConfig)config);
            DetResult result = rtdetr.predict(image);
            Mat im = Visualize.draw_det_result(result, image);
            CvInvoke.Imshow("ww", im);
            CvInvoke.WaitKey(0);
        }
        [TestMethod()]
        public void predict_test_1()
        {

            Mat image = CvInvoke.Imread(image_path1);
            RtdetrConfig config = new RtdetrConfig(model_path1);
            config.postprcoess = false;
            RtdetrDet rtdetr = new RtdetrDet((RtdetrConfig)config);
            DetResult result = rtdetr.predict(image);
            Mat im = Visualize.draw_det_result(result, image);
            CvInvoke.Imshow("ww", im);
            CvInvoke.WaitKey(0);
        }

        [TestMethod()]
        public void predict_test1()
        {
            List<Mat> images = new List<Mat>()
            {
                 CvInvoke.Imread(image_path),
                 CvInvoke.Imread(image_path1),
                 CvInvoke.Imread(image_path2),
                  CvInvoke.Imread(image_path3)
            };
            RtdetrConfig config = new RtdetrConfig(model_path);
            config.batch_num = 4;
            RtdetrDet rtdetr = new RtdetrDet((RtdetrConfig)config);
            List<DetResult> result = rtdetr.predict(images);
            Mat im = Visualize.draw_det_result(result[0], images[0]);
            CvInvoke.Imshow("ww", im);
            Mat im1 = Visualize.draw_det_result(result[1], images[1]);
            CvInvoke.Imshow("ww1", im1);
            Mat im2 = Visualize.draw_det_result(result[2], images[2]);
            CvInvoke.Imshow("ww2", im2);
            Mat im3 = Visualize.draw_det_result(result[3], images[3]);
            CvInvoke.Imshow("ww3", im3);
            CvInvoke.WaitKey(0);
        }
        [TestMethod()]
        public void predict_test1_1()
        {
            List<Mat> images = new List<Mat>()
            {
                CvInvoke.Imread(image_path),
                 CvInvoke.Imread(image_path1),
                 CvInvoke.Imread(image_path2),
                  CvInvoke.Imread(image_path3)
            };
            RtdetrConfig config = new RtdetrConfig(model_path1);
            config.postprcoess = false;
            config.batch_num = 4;
            RtdetrDet rtdetr = new RtdetrDet((RtdetrConfig)config);
            List<DetResult> result = rtdetr.predict(images);
            Mat im = Visualize.draw_det_result(result[0], images[0]);
            CvInvoke.Imshow("ww", im);
            Mat im1 = Visualize.draw_det_result(result[1], images[1]);
            CvInvoke.Imshow("ww1", im1);
            Mat im2 = Visualize.draw_det_result(result[2], images[2]);
            CvInvoke.Imshow("ww2", im2);
            Mat im3 = Visualize.draw_det_result(result[3], images[3]);
            CvInvoke.Imshow("ww3", im3);
            CvInvoke.WaitKey(0);
        }
    }
}