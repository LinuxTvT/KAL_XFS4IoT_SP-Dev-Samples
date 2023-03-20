using KAL.XFS4IoTSP.Printer.Sample;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XFS4IoT;
using XFS4IoTFramework.Common;
using XFS4IoTFramework.Printer;

namespace Miraway.XFS4IoTSP.Printer.Masung
{
    public class MasungPrinter
    {

        #region Import SDK functions
        [DllImport("kernel32.dll", EntryPoint = "GetSystemDefaultLCID")]
        private static extern int GetSystemDefaultLCID();

        [DllImport("Msprintsdk.dll", EntryPoint = "SetInit", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetInit();

        [DllImport("Msprintsdk.dll", EntryPoint = "SetUsbportauto", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetUsbportauto();

        [DllImport("Msprintsdk.dll", EntryPoint = "SetClean", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetClean();

        [DllImport("Msprintsdk.dll", EntryPoint = "SetClose", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetClose();

        [DllImport("Msprintsdk.dll", EntryPoint = "SetAlignment", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetAlignment(int iAlignment);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetAlignmentLeftRight", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetAlignmentLeftRight(int iAlignment);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetBold", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetBold(int iBold);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetCommandmode", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetCommandmode(int iMode);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetLinespace", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetLinespace(int iLinespace);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetPrintport", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetPrintport(StringBuilder strPort, int iBaudrate);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintString", CharSet = CharSet.Ansi)]
        private static extern unsafe int PrintString(StringBuilder strData, int iImme);

        [DllImport("Msprintsdk.dll", EntryPoint = "GetSDKinformation", CharSet = CharSet.Ansi)]
        private static extern unsafe int GetSDKinformation(byte[] bInfodata);     

         [DllImport("Msprintsdk.dll", EntryPoint = "PrintFeedline", CharSet = CharSet.Ansi)]
        private static extern unsafe int PrintFeedline(int iLine);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintSelfcheck", CharSet = CharSet.Ansi)]
        private static extern unsafe int PrintSelfcheck();

        [DllImport("Msprintsdk.dll", EntryPoint = "GetStatus", CharSet = CharSet.Ansi)]
        private static extern unsafe int GetStatus();

        [DllImport("Msprintsdk.dll", EntryPoint = "GetStatusspecial", CharSet = CharSet.Ansi)]
        private static extern unsafe int GetStatusspecial();

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintCutpaper", CharSet = CharSet.Ansi)]
        private static extern unsafe int PrintCutpaper(int iMode);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetSizetext", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetSizetext(int iHeight, int iWidth);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetSizechinese", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetSizechinese(int iHeight, int iWidth, int iUnderline, int iChinesetype);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetItalic", CharSet = CharSet.Ansi)]
        private static extern unsafe int SetItalic(int iItalic);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintDiskbmpfile", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintDiskbmpfile(StringBuilder strData);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintDiskimgfile", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintDiskimgfile(StringBuilder strData);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintQrcode", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintQrcode(StringBuilder strData, int iLmargin, int iMside, int iRound);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintRemainQR", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintRemainQR();

        [DllImport("Msprintsdk.dll", EntryPoint = "SetLeftmargin", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetLeftmargin(int iLmargin);

        [DllImport("Msprintsdk.dll", EntryPoint = "GetProductinformation", CharSet = CharSet.Ansi)]
        public static extern unsafe int GetProductinformation(int Fstype, byte[] FIDdata, int iFidlen);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintTransmit", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintTransmit(byte[] strCmd, int iLength);

        [DllImport("Msprintsdk.dll", EntryPoint = "GetTransmit", CharSet = CharSet.Ansi)]
        public static extern unsafe int GetTransmit(byte[] strCmd, int iLength, byte[] bRecv, int iRelen);


        [DllImport("Msprintsdk.dll", EntryPoint = "PrintFeedDot", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintFeedDot(int Lnumber);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintChargeRow", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintChargeRow();

        [DllImport("Msprintsdk.dll", EntryPoint = "SetSpacechar", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetSpacechar(int iSpace);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetSizechar", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetSizechar(int iHeight, int iWidth, int iUnderline, int iAsciitype);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetRotate", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetRotate(int iRotate);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetDirection", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetDirection(int iDirection);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetWhitemodel", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetWhitemodel(int iWhite);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetUnderline", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetUnderline(int underline);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintNextHT", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintNextHT();

        [DllImport("Msprintsdk.dll", EntryPoint = "SetHTseat", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetHTseat(byte[] bHTseat, int iLength);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetCodepage", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetCodepage(int country, int CPnumber);

        [DllImport("Msprintsdk.dll", EntryPoint = "Print1Dbar", CharSet = CharSet.Ansi)]
        public static extern unsafe int Print1Dbar(int iWidth, int iHeight, int iHrisize, int iHriseat, int iCodetype, StringBuilder strData);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetPagemode", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetPagemode(int iMode, int Xrange, int Yrange);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetPagestartposition", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetPagestartposition(int Xdot, int Ydot);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetPagedirection", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetPagedirection(int iDirection);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintPagedata", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintPagedata();

        [DllImport("Msprintsdk.dll", EntryPoint = "SetReadZKmode", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetReadZKmode(int mode);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetNvbmp", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetNvbmp(int iNums, StringBuilder strPath);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintNvbmp", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintNvbmp(int iNvindex, int iMode);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetPrintIDorName", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetPrintIDorName(StringBuilder strIDorNAME);

        [DllImport("Msprintsdk.dll", EntryPoint = "GetPrintIDorName", CharSet = CharSet.Ansi)]
        public static extern unsafe int GetPrintIDorName(StringBuilder strIDorNAME);


        [DllImport("Msprintsdk.dll", EntryPoint = "PrintMarkcutpaper", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintMarkcutpaper(int iMode);

        [DllImport("Msprintsdk.dll", EntryPoint = "SetTraceLog", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetTraceLog(int iLog);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintPdf417", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintPdf417(int iDotwidth, int iDotheight, int iDatarows, int iDatacolumns, StringBuilder strData);

        //旋转模式
        [DllImport("Msprintsdk.dll", EntryPoint = "SetRotation_Intomode", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetRotation_Intomode();

        [DllImport("Msprintsdk.dll", EntryPoint = "SetRotation_Leftspace", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetRotation_Leftspace(int iLeftspace);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintRotation_Sendcode", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintRotation_Sendcode(int leftspace, int iWidth, int iHeight, int iCodetype, StringBuilder strData);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintRotation_Sendtext", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintRotation_Sendtext(StringBuilder strData, int iImme);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintRotation_Changeline", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintRotation_Changeline();

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintRotation_Data", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintRotation_Data();


        [DllImport("Msprintsdk.dll", EntryPoint = "PrintPDF_CCCB", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintPDF_CCCB(StringBuilder strData);

        [DllImport("Msprintsdk.dll", EntryPoint = "PrintDataMatrix", CharSet = CharSet.Ansi)]
        public static extern unsafe int PrintDataMatrix(StringBuilder strData, int iSize);

        #endregion

        public MasungPrinter(PrinterSample PrinterDevice , ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(MasungPrinter)} constructor. {nameof(Logger)}");
            this.Logger = Logger;
            this.PrinterDevice = PrinterDevice;

            Logger.Log("MasungPrinter", $"Createt  {nameof(MasungPrinter)}");

            byte[] sdkInfo = new byte[120];
            if (0 == GetSDKinformation(sdkInfo))
            {
                Logger.Log("MasungPrinter", $"Load Masung SDK success, version:  {System.Text.Encoding.UTF8.GetString(sdkInfo)}");
            } else
            {
                Logger.Warning("MasungPrinter", $"Load Masung SDK ERROR");
            }

            if (0 == SetUsbportauto())
            {
                Logger.Log("MasungPrinter", $"Set auto detect USB Port success");
            }
            else
            {
                Logger.Warning("MasungPrinter", $"Set auto detect USB Port ERROR");
            }

        }

        public async Task IdleProcessAsync(CancellationToken cancel)
        {
            Console.WriteLine("RunAsync  IdleProcessAsync");
            for (; ; )
            {

                //Console.WriteLine("Waiting for IDLE");
                await Task.Delay(3000);
                //Console.WriteLine("Idle processing");
                PrinterDevice.CommonStatus.Device = getDeviceStatus();
              
            }
        }

        public CommonStatusClass.DeviceEnum getDeviceStatus()
        {
            SetInit();
            int l_iStatus = GetStatus();
            int specStatus = GetStatusspecial();
            Console.WriteLine($"Masung printer status change [{Status}->{l_iStatus}]");
            if (Status != l_iStatus)
            {
                Console.WriteLine($"Masung printer status change [{Status}->{l_iStatus}]");
                Status = l_iStatus;
            }
            if (Status == 1)
            {
                return CommonStatusClass.DeviceEnum.Offline;
            } else
            {
                return CommonStatusClass.DeviceEnum.Online;
            }
        }
        public bool CutPaper()
        {
            //return (PrintCutpaper(0) == 0);
            return true;
        }

        public void printBimap(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(filePath);
            Console.WriteLine($"Print bitmap file: {sb.ToString()}");
            
            //PrintDiskbmpfile(sb);
        }
        private ILogger Logger { get; }
        private PrinterSample PrinterDevice { get; }
        private int Status { get; set; }
    }
}
