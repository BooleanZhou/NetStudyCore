using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace ImageToString.Models
{
    public class ImageOpreation
    {
        private static Tesseract _ocr = new Tesseract();
        //传入图片进行识别
        public static string ORC_(Bitmap img)
        {
            //""标示OCR识别调用失败
            string re = "";
            if (img == null)
                return re;
            else
            {
                Bgr drawColor = new Bgr(Color.Blue);
                try
                {
                    Image<Bgr, Byte> image = new Image<Bgr, byte>(img);
                    using (Image<Gray, byte> gray = image.Convert<Gray, Byte>())
                    {
                        _ocr.Recognize();
                        Tesseract.Character[] charactors = _ocr.GetCharacters();
                        foreach (Tesseract.Character c in charactors)
                        {
                            image.Draw(c.Region, drawColor, 1);
                        }


                        re = _ocr.GetBoxText();


                    }
                    return re;
                }
                catch (Exception ex)
                {

                    return re;
                }
            }
        }

        ////识别方法如点击按钮识别
        //private void btnXIdentification_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        _ocr = new Tesseract(@"C:\Emgu\emgucv-windows-x86-gpu 2.4.2.1777\bin\tessdata", "eng", Tesseract.OcrEngineMode.OEM_TESSERACT_CUBE_COMBINED);//方法第一个参数可为""表示通过环境变量调用字库，第二个参数表示字库的文件，第三个表示识别方式，可看文档与资料查找。
        //        _ocr.SetVariable("tessedit_char_whitelist", "0123456789X");//此方法表示只识别1234567890与x字母
        //        string result = "";
        //        Bitmap bitmap = new Bitmap(_emguImage.ToBitmap());
        //        bitmap = BrightnessP(bitmap, Convert.ToInt32(this.textBoxX3.Text));//图片加亮处理
        //        bitmap = KiContrast(bitmap, Convert.ToInt32(this.textBoxX2.Text));//调整对比对
        //        this.pictureBox3.Image = bitmap;
        //        result = ORC_(bitmap);
        //        this.textBoxX1.Text = result;
        //        _ocr.Dispose();
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //    }
        //}

        /// <summary>  
        /// 增加图像亮度  
        /// </summary>  
        /// <param name="a"></param>  

        /// <param name="v"></param>  
        /// <returns></returns>  
        public static Bitmap BrightnessP(Bitmap a, int v)
        {
            BitmapData bmpData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height),ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int bytes = a.Width * a.Height * 3;
            IntPtr ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            unsafe
            {
                byte* p = (byte*)ptr;
                int temp;
                for (int j = 0; j < a.Height; j++)
                {
                    for (int i = 0; i < a.Width * 3; i++, p++)
                    {
                        temp = p[0] + v;
                        temp = (temp > 255) ? 255 : temp < 0 ? 0 : temp;
                        p[0] = (byte)temp;
                    }
                    p += stride - a.Width * 3;
                }
            }
            a.UnlockBits(bmpData);
            return a;
        }
        ///<summary>
        ///图像对比度调整
        ///</summary>
        ///<param name="b">原始图</param>
        ///<param name="degree">对比度[-100, 100]</param>
        ///<returns></returns>
        public static Bitmap KiContrast(Bitmap b, int degree)
        {
            if (b == null)
            {
                return null;
            }
            if (degree < -100) degree = -100;
            if (degree > 100) degree = 100;
            try
            {
                double pixel = 0;
                double contrast = (100.0 + degree) / 100.0;
                contrast *= contrast;
                int width = b.Width;
                int height = b.Height;
                BitmapData data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 处理指定位置像素的对比度
                            for (int i = 0; i < 3; i++)
                            {
                             
                                pixel = ((p[0] / 255 - 0.5) * contrast + 0.5) * 255;
                                if (pixel < 0) pixel = 0;
                                if (pixel > 255) pixel = 255;
                                p[0] = (byte)pixel;
                            } // i
                            p += 3;
                        } // x
                        p += offset;
                    } // y
                }
                b.UnlockBits(data);
                return b;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}