using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RobotSpeaker.Forms.CameraAPI
{
    public class VideoOperate
    {
        #region  视频采集卡中的枚举

        public enum DISPLAYTRANSTYPE
        {
            NOT_DISPLAY = 0,
            PCI_VIEDOMEMORY = 1,
            PCI_MEMORY_VIDEOMEMORY = 2
        }

        //视频预览和视频捕捉数据流格式，目前版本只支持UUY2格式
        public enum COLORFORMAT
        {
            RGB32 = 0x0,
            RGB24 = 0x1,
            RGB16 = 0x2,
            RGB15 = 0x3,
            YUY2 = 0x4,
            BTYUV = 0x5,
            Y8 = 0x6,
            RGB8 = 0x7,
            PL422 = 0x8,
            PL411 = 0x9,
            YUV12 = 0xA,
            YUV9 = 0xB,
            RAW = 0xE
        }

        /*视频预览及视频捕获的显示属性，其中：
            BRIGHTNESS为亮度，value范围：0~255，最佳：80
            CONTRAST为对比度，value范围：-128~127，最佳：0x44
            SATURATION为饱和度，value范围：-128~127，最佳：0x40
            HUE为色度，value范围：-128~127，最佳：0x0
                只有当COLORDEVICETYPE等于COLOR_DECODER时才有效
            SHARPNESS为锐度，value范围：-8~7，最佳：0x0
                只有当COLORDEVICETYPE等于COLOR_DECODER时才有效
        */
        public enum COLORCONTROL
        {
            BRIGHTNESS = 0,
            CONTRAST = 1,
            SATURATION = 2,
            HUE = 3,
            SHARPNESS = 4
        }

        /*显示设备的显示属性，其中：
            COLOR_DECODER为解码器的显示属性，它会影响视频预览和视频捕获的显示属性
            COLOR_PREVIEW为视频预览的显示属性
            COLOR_CAPTURE为视频捕获的显示属性
        */
        public enum COLORDEVICETYPE
        {
            COLOR_DECODER = 0,
            COLOR_PREVIEW = 1,
            COLOR_CAPTURE = 2,
        }

        /*音视频捕获方式，其中：
            CAP_NULL_STREAM 捕获无效
            CAP_ORIGIN_STREAM 捕获为原始流回调
            CAP_MPEG4_STREAM 捕获为MPEG4
        */
        public enum CAPMODEL
        {
            CAP_NULL_STREAM = 0,
            CAP_ORIGIN_STREAM = 1,
            CAP_MPEG4_STREAM = 2,
        }

        /*音视频MPEG4捕获方式，只有CAPMODEL等于CAP_MPEG4_STREAM时有效，其中：
           MPEG4_AVIFILE_ONLY 存为MPEG4文件
           MPEG4_CALLBACK_ONLY MPEG数据回调
           MPEG4_AVIFILE_CALLBACK 存为MPEG文件并回调
       */
        public enum MP4MODEL
        {
            MPEG4_AVIFILE_ONLY = 0,
            MPEG4_CALLBACK_ONLY = 1,
            MPEG4_AVIFILE_CALLBACK = 2,
        }

        /*MPEG4_XVID压缩模式，其中：
           XVID_CBR_MODE 
           XVID_VBR_MODE 
       */
        public enum COMPRESSMODE
        {
            XVID_CBR_MODE = 0,
            XVID_VBR_MODE = 1,
        }

        /*视频源的输入频率，其中：
           FIELD_FREQ_50HZ 50HZ,绝对多数为PAL制式
           FIELD_FREQ_60HZ 60HZ,绝对多数为NTSC制式
           FIELD_FREQ_0HZ 无信号
       */
        public enum eFieldFrequency
        {
            FIELD_FREQ_50HZ = 0,
            FIELD_FREQ_60HZ = 1,
            FIELD_FREQ_0HZ = 2,
        }

        /*电平状态，其中：
           HIGH_VOLTAGE 高电平
           LOW_VOLTAGE 低电平
       */
        public enum eVOLTAGELEVEL
        {
            HIGH_VOLTAGE = 0,
            LOW_VOLTAGE = 1,
        }

        #endregion

        #region  视频采集卡中的API函数

        //初始化系统资源
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAInitSdk")]
        public extern static bool VCAInitSdk(IntPtr hWndMain, DISPLAYTRANSTYPE eDispTransType, bool bLnitAuDev);

        //释放系统资源
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAUnInitSdk")]
        public extern static void VCAUnInitSdk();

        //打开指定卡号的设备，分配相应系统资源
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAOpenDevice")]
        public extern static bool VCAOpenDevice(Int32 dwCard, IntPtr hPreviewWnd);

        //关闭指定卡号的设备，释放相应系统资源
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCACloseDevice")]
        public extern static bool VCACloseDevice(Int32 dwCard);

        //返回系统当中卡号数量，即为SAA7134硬件数目，为0时表示没有设备存在
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAGetDevNum")]
        public extern static int VCAGetDevNum();

        //开始视频预览
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAStartVideoPreview")]
        public extern static bool VCAStartVideoPreview(Int32 dwCard);

        //停止视频预览
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAStopVideoPreview")]
        public extern static bool VCAStopVideoPreview(Int32 dwCard);

        //更新视频预览
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAUpdateVideoPreview")]
        public extern static bool VCAUpdateVideoPreview(Int32 dwCard, IntPtr hPreviewWnd);

        //更新overlay窗口，当overlay窗口句柄改变或尺寸、位置改变时调用，overlay窗口就是包含
        //多路显示小窗口的大窗口，overlay窗口必须有一个，多路显示小窗口必须包含在其内部
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAUpdateOverlayWnd")]
        public extern static bool VCAUpdateOverlayWnd(IntPtr hOverlayWnd);

        //保存快照为JPEG文件
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASaveAsJpegFile")]
        public extern static bool VCASaveAsJpegFile(Int32 dwCard, string lpFileName, Int32 dwQuality);

        //保存快照为BMP文件
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASaveAsBmpFile")]
        public extern static bool VCASaveAsBmpFile(Int32 dwCard, string lpFileName);

        //开始视频捕获
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAStartVideoCapture")]
        public extern static bool VCAStartVideoCapture(Int32 dwCard, CAPMODEL enCapMode, MP4MODEL enMp4Mode, string lpFileName);

        //停止视频捕获
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAStopVideoCapture")]
        public extern static bool VCAStopVideoCapture(Int32 dwCard);

        //设置视频捕获尺寸，dwWidth和dwHeight最好为16的倍数，否则，动态检测为16*16的一个检测小块，检测将会不准确
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetVidCapSize")]
        public extern static bool VCASetVidCapSize(Int32 dwCard, Int32 dwWidth, Int32 dwHeight);

        //得到视频捕获尺寸
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAGetVidCapSize")]
        public extern static bool VCAGetVidCapSize(Int32 dwCard, Int32 dwWidth, Int32 dwHeight);

        //设置视频捕获频率
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetVidCapFrameRate")]
        public extern static bool VCASetVidCapFrameRate(Int32 dwCard, Int32 dwFrameRate, bool bFrameRateReduction);

        //设置MPEG压缩的位率
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetBitRate")]
        public extern static bool VCASetBitRate(Int32 dwCard, Int32 dwBitRate);

        //设置MPEG压缩的关键帧间隔，必须大于等于帧率
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetKeyFrmInterval")]
        public extern static bool VCASetKeyFrmInterval(Int32 dwCard, Int32 dwKeyFrmInterval);

        //设置MPEG4_XVID压缩的质量
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetXVIDQuality")]
        public extern static bool VCASetXVIDQuality(Int32 dwCard, Int32 dwQuantizer, Int32 dwMotionPrecision);

        //设置MPEG4_XVID压缩的模式
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetXVIDCompressMode")]
        public extern static bool VCASetXVIDCompressMode(Int32 dwCard, COMPRESSMODE enCompessMode);

        //设置视频颜色属性，它将影响视频预览和视频捕获的显示属性
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetVidDeviceColor")]
        public extern static bool VCASetVidDeviceColor(Int32 dwCard, COLORCONTROL enCtlType, Int32 dwValue);

        //得到视频源输入频率，即可得到视频源输入制式
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAGetVidFieldFrq")]
        public extern static bool VCAGetVidFieldFrq(Int32 dwCard, eFieldFrequency eVidSourceFieldRate);

        //初始化视频设备，当视频不显示，只需视频录像获音频处理时，获通过VCAInitSdk()函数已经初始化完成，可以不初始化
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAInitVidDev")]
        public extern static bool VCAInitVidDev();

        #endregion
    }
}