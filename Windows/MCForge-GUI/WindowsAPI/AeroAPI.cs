﻿#region License
/*
Permission is hereby granted, free of
charge, to any person obtaining a copy of
this software and associated documentation
 files (the "Software"), to deal in the
Software without restriction, including
without limitation the rights to use, copy,
 modify, merge, publish, distribute,
sublicense, and/or sell copies of the
Software, and to permit persons to whom the
 Software is furnished to do so, subject to
the following conditions:


The above copyright notice and this
permission notice shall be included in all
 copies or substantial portions of the
Software.


THE SOFTWARE IS PROVIDED "AS IS", WITHOUT
WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 OF MERCHANTABILITY, FITNESS FOR A
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN
NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
 OTHER LIABILITY, WHETHER IN AN ACTION OF
CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR
 THE USE OR OTHER DEALINGS IN THE SOFTWARE.

 * User: Eddie
 * Date: 10/11/2012
 * Time: 3:56 PM
 * 
 */
#endregion
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Interop;
using System.Drawing;
using System.Runtime.InteropServices;
using MCForge.Gui.WindowsAPI.Utils;

namespace MCForge.Gui.WindowsAPI
{
	/// <summary>
	/// Functions for the AeroAPI.
	/// </summary>
	public class AeroAPI
	{
		public static bool CanUseAero {
			get {
				try {
					return Environment.OSVersion.Version.Major >= 6 && DwmIsCompositionEnabled();
				}
				catch {
					return false;
				}
			}
		}
		
		#region Consts

        private const int SOURCE_COPY = 0x00CC0020;
        private const int BI_RGB = 0;
        private const int DIB_RGB_COLORS = 0;

        private const int DTT_COMPOSITED = ( int ) ( 1UL << 13 );
        private const int DTT_GLOWSIZE = ( int ) ( 1UL << 11 );

        private const int DT_SINGLELINE = 0x00000020;
        private const int DT_CENTER = 0x00000001;
        private const int DT_VCENTER = 0x00000004;
        private const int DT_NOPREFIX = 0x00000800;

        public const int WM_NCHITTEST = 0x84;
        public const int WM_NCLBUTTONUP = 0x00A2;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;

        public const int HTCAPTION = 2;
        public const int HTCLIENT = 1;

        public const int S_OK = 0x0;

        public const int EP_EDITTEXT = 1;
        public const int ETS_DISABLED = 4;
        public const int ETS_NORMAL = 1;
        public const int ETS_READONLY = 6;

        public const int WM_THEMECHANGED = 0x031A;
        public const int WM_NCPAINT = 0x85;
        public const int WM_NCCALCSIZE = 0x83;

        public const int WS_EX_CLIENTEDGE = 0x200;
        public const int WVR_HREDRAW = 0x100;
        public const int WVR_VREDRAW = 0x200;
        public const int WVR_REDRAW = ( WVR_HREDRAW | WVR_VREDRAW );

        #endregion
		
        
		#region Enums/Structs
		public struct DWM_COLORIZATION_PARAMS
		{
			public long Color1;
			public long Color2;
			public long Intensity;
			public long Unknown1;
			public long Unknown2;
			public long Unknown3;
			public long Opaque;
		}
		public struct BITMAPINFOHEADER {
			public int biSize;
			public int biWidth;
			public int biHeight;
			public short biPlanes;
			public short biBitCount;
			public int biCompression;
			public int biSizeImage;
			public int biXPelsPerMeter;
			public int biYPelsPerMeter;
			public int biClrUsed;
			public int biClrImportant;
		}
		
		public struct RGBQUAD {
			public byte rgbBlue;
			public byte rgbGreen;
			public byte rgbRed;
			public byte rgbReserved;
		}

		public struct BITMAPINFO {
			public BITMAPINFOHEADER bmiHeader;
			public RGBQUAD bmiColors;
		}
		
		[StructLayout( LayoutKind.Sequential )]
		public struct DLLVersionInfo {
			public int cbSize;
			public int dwMajorVersion;
			public int dwMinorVersion;
			public int dwBuildNumber;
			public int dwPlatformID;
		}

		[StructLayout( LayoutKind.Sequential )]
		public struct NCCALCSIZE_PARAMS {
			public RECT rgrc0, rgrc1, rgrc2;
			public IntPtr lppos;
		}

        public struct POINTAPI {
            public int x;
            public int y;
        };

        public struct DTTOPTS {
            public uint dwSize;
            public uint dwFlags;
            public uint crText;
            public uint crBorder;
            public uint crShadow;
            public int iTextShadowType;
            public POINTAPI ptShadowOffset;
            public int iBorderSize;
            public int iFontPropId;
            public int iColorPropId;
            public int iStateId;
            public int fApplyOverlay;
            public int iGlowSize;
            public IntPtr pfnDrawTextCallback;
            public int lParam;
        };
        #endregion
        
        
		#region P/Invoke API Calls

		[DllImport( "dwmapi.dll", PreserveSig = false )]
		private static extern bool DwmIsCompositionEnabled();
		
		[DllImport("dwmapi.dll", EntryPoint = "#127", PreserveSig = false)]
		public static extern void DwmGetColorizationParameters(out DWM_COLORIZATION_PARAMS parameters);
		
		[DllImport("dwmapi.dll", EntryPoint = "#131", PreserveSig = false)]
		public static extern void DwmSetColorizationParameters(ref DWM_COLORIZATION_PARAMS parameters, long uUnknown);

		[DllImport( "dwmapi.dll" )]
		private static extern void DwmExtendFrameIntoClientArea( IntPtr hWnd, ref Margins margin );

		[DllImport( "gdi32.dll", ExactSpelling = true, SetLastError = true )]
		private static extern int SaveDC( IntPtr hdc );

		[DllImport( "user32.dll", ExactSpelling = true, SetLastError = true )]
		private static extern int ReleaseDC( IntPtr hdc, int state );

		[DllImport( "user32.dll", ExactSpelling = true, SetLastError = true )]
		private static extern IntPtr GetDC( IntPtr hdc );

		[DllImport( "gdi32.dll", ExactSpelling = true, SetLastError = true )]
		private static extern IntPtr CreateCompatibleDC( IntPtr hDC );

		[DllImport( "gdi32.dll", ExactSpelling = true )]
		private static extern IntPtr SelectObject( IntPtr hDC, IntPtr hObject );

		[DllImport( "gdi32.dll", ExactSpelling = true, SetLastError = true )]
		private static extern bool DeleteObject( IntPtr hObject );

		[DllImport( "gdi32.dll", ExactSpelling = true, SetLastError = true )]
		private static extern bool DeleteDC( IntPtr hdc );

		[DllImport( "gdi32.dll" )]
		private static extern bool BitBlt( IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop );

		[DllImport( "gdi32.dll", ExactSpelling = true, SetLastError = true )]
		private static extern IntPtr CreateDIBSection( IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, int ppvBits, IntPtr hSection, uint dwOffset );

		[DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = false )]
		public static extern IntPtr SendMessage( IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam );

		[DllImport( "user32.dll", SetLastError = false )]
		public static extern bool PostMessage( IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam );

		[DllImport( "UxTheme.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode )]
		private static extern int DrawThemeTextEx( IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions );

		[DllImport( "UxTheme.dll", CharSet = CharSet.Auto )]
		public static extern bool IsAppThemed();

		[DllImport( "UxTheme.dll", CharSet = CharSet.Auto )]
		public static extern bool IsThemeActive();

		[DllImport( "comctl32.dll", CharSet = CharSet.Auto )]
		public static extern int DllGetVersion( ref DLLVersionInfo version );

		[DllImport( "uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode )]
		public static extern IntPtr OpenThemeData( IntPtr hWnd, String classList );

		[DllImport( "uxtheme.dll", ExactSpelling = true )]
		public extern static Int32 CloseThemeData( IntPtr hTheme );

		[DllImport( "uxtheme", ExactSpelling = true )]
		public extern static Int32 DrawThemeBackground( IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, IntPtr pClipRect );

		[DllImport( "uxtheme", ExactSpelling = true )]
		public extern static int IsThemeBackgroundPartiallyTransparent( IntPtr hTheme, int iPartId, int iStateId );

		[DllImport( "uxtheme", ExactSpelling = true )]
		public extern static Int32 GetThemeBackgroundContentRect( IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pBoundingRect, out RECT pContentRect );

		[DllImport( "uxtheme", ExactSpelling = true )]
		public extern static Int32 DrawThemeParentBackground( IntPtr hWnd, IntPtr hdc, ref RECT pRect );

		[DllImport( "uxtheme", ExactSpelling = true )]
		public extern static Int32 DrawThemeBackground( IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, ref RECT pClipRect );

		[DllImport( "user32.dll" )]
		public static extern IntPtr GetWindowDC( IntPtr hWnd );

		[DllImport( "user32.dll" )]
		public static extern int ReleaseDC( IntPtr hWnd, IntPtr hDC );

		[DllImport( "user32.dll" )]
		public static extern bool GetWindowRect( IntPtr hWnd, out RECT lpRect );

		[DllImport( "gdi32.dll" )]
		public static extern int ExcludeClipRect( IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect );

		#endregion
		
		
		public static void SetDwmColor(Color newColor)
		{
			if (DwmIsCompositionEnabled())
			{
				DWM_COLORIZATION_PARAMS dWM_COLORIZATION_PARAMS;
				DwmGetColorizationParameters(out dWM_COLORIZATION_PARAMS);
				dWM_COLORIZATION_PARAMS.Color1 = (long)Color.FromArgb(255, (int)newColor.R, (int)newColor.G, (int)newColor.B).ToArgb();
				DwmSetColorizationParameters(ref dWM_COLORIZATION_PARAMS, 0L);
			}
		}
		public static void ExtendGlass(IntPtr handle, Rectangle bounds) {
			if (!DwmIsCompositionEnabled())
				return;
			try {
				Margins m = bounds;
				DwmExtendFrameIntoClientArea(handle, ref m);
			} catch {
				
			}
		}
		
		public static void FillBlackRegion( Graphics gph, Rectangle rgn ) {

			Margins rc = rgn;

			IntPtr destdc = gph.GetHdc();
			IntPtr Memdc = CreateCompatibleDC( destdc );
			IntPtr bitmap;
			IntPtr bitmapOld = IntPtr.Zero;

			BITMAPINFO dib = new BITMAPINFO() {
				bmiHeader = new BITMAPINFOHEADER() {
					biHeight = -( rc.Bottom - rc.Top ),
					biWidth = rc.Right - rc.Left,
					biPlanes = 1,
					biSize = Marshal.SizeOf( typeof( BITMAPINFOHEADER ) ),
					biBitCount = 32,
					biCompression = BI_RGB
				}
			};

			if ( SaveDC( Memdc ) != 0 ) {
				bitmap = CreateDIBSection( Memdc, ref dib, DIB_RGB_COLORS, 0, IntPtr.Zero, 0 );

				try {

					if ( bitmap != IntPtr.Zero ) {
						bitmapOld = SelectObject( Memdc, bitmap );
						BitBlt( destdc, rc.Left, rc.Top, rc.Right - rc.Left, rc.Bottom - rc.Top, Memdc, 0, 0, SOURCE_COPY );
					}
				}
				finally {
					SelectObject( Memdc, bitmapOld );
					DeleteObject( bitmap );
					ReleaseDC( Memdc, -1 );
					DeleteDC( Memdc );
				}
			}
			gph.ReleaseHdc();
		}
		
		public static IntPtr GetIntPtr(Form f) {
			return f.Handle;
		}
		
		public static IntPtr GetIntPtr() {
			return Process.GetCurrentProcess().MainWindowHandle;
		}
	}
}
