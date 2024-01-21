﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp;
using OpenVinoSharp.Extensions.result;
using OpenVinoSharp.Extensions.model;
using OpenVinoSharp.Extensions.process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenVinoSharp.Extensions.model.Tests
{
    [TestClass()]
    public class Yolov5DetTests
    {
        public string model_xml_path = "..\\..\\..\\..\\..\\tests\\test_data\\model\\yolov5\\yolov5s.xml";
        public string image_path = "..\\..\\..\\..\\..\\tests\\test_data\\image\\demo_1.jpg";
        public string image_path1 = "..\\..\\..\\..\\..\\tests\\test_data\\image\\demo_2.jpg";
        public string image_path2 = "..\\..\\..\\..\\..\\tests\\test_data\\image\\demo_3.jpg";

        [TestMethod()]
        public void Yolov5Det_test()
        {
            Yolov5DetConfig config = new Yolov5DetConfig(model_xml_path);
            Yolov5Det yolo = new Yolov5Det(config);
        }

        [TestMethod()]
        public void predict_test()
        {
            Yolov5DetConfig config = new Yolov5DetConfig(model_xml_path);
            Yolov5Det yolo = new Yolov5Det(config);
            Mat image = Cv2.ImRead(image_path);
            DetResult result = yolo.predict(image);
            Mat im = Visualize.draw_det_result(result, image);
            Cv2.ImShow("ww", im);
            Cv2.WaitKey(0);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void predict_test1()
        {
            Yolov5DetConfig config = new Yolov5DetConfig(model_xml_path);
            Yolov5Det yolo = new Yolov5Det(config);
            List<Mat> images = new List<Mat>();
            images.Add(Cv2.ImRead(image_path));
            images.Add(Cv2.ImRead(image_path1));
            images.Add(Cv2.ImRead(image_path2));
            List<DetResult> results = yolo.predict(images);
            Mat im = Visualize.draw_det_result(results[0], images[0]);
            Cv2.ImShow("ww", im);
            Cv2.WaitKey(0);
            im = Visualize.draw_det_result(results[1], images[1]);
            Cv2.ImShow("ww", im);
            Cv2.WaitKey(0);
            im = Visualize.draw_det_result(results[2], images[2]);
            Cv2.ImShow("ww", im);
            Cv2.WaitKey(0);
            Assert.IsNotNull(results);
        }

        [TestMethod()]
        public void process_result_test()
        {

        }
    }
}