using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using DarrenLee.Media;
using System.Threading;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureService : IWebCamCaptureService
    {

        Camera cam = new Camera();
        Image img;

        public WebCamCaptureService()
        {
            GetInfo();
            cam.OnFrameArrived += cam_OnFrameArrived;
        }

        private void cam_OnFrameArrived(object sourse, FrameArrivedEventArgs e)
        {
            img = e.GetFrame();
        }

        private void GetInfo()
        {
            var camInfo = cam.GetCameraSources();
            var camResulation = cam.GetSupportedResolutions();
        }

        public void Capture()
        {
            cam.Start();
            Console.WriteLine("Camera On");
            Thread.Sleep(3000);

            try
            {
                if (!Directory.Exists(@"C:\camTest"))
                {
                    Directory.CreateDirectory(@"C:\camTest");
                    Console.WriteLine("Directory created!");
                }

                string path = @"C:\camTest\";
                string FileName = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss-tt");

                img.Save(path + FileName + ".jpg");

                //cam.Capture(path + FileName);

                Console.WriteLine("Image Captured");


            }
            catch (Exception)
            {
                throw;
            }

            cam.Stop();
            Console.WriteLine("Camera stopped");
        }

        
    }
}
