using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Wallpaper_Tools
{
    public sealed class Wallpaper
    {
        Wallpaper() { }

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public enum Style
        {
            Fill,
            Fit,
            Span,
            Stretch,
            Tile,
            Center
        }

        public static void Set(Uri uri, Style style)
        {
            var s = new WebClient().OpenRead(uri.ToString());
            if (s == null) throw new Exception("An error occured.");
            
            var img = Image.FromStream(s);
            var tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            img.Save(tempPath, ImageFormat.Bmp);

            var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            if (key == null) throw new Exception("An error occured.");
            switch (style)
            {
                case Style.Fill:
                    key.SetValue(@"WallpaperStyle", 10.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                case Style.Fit:
                    key.SetValue(@"WallpaperStyle", 6.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                case Style.Span:
                    key.SetValue(@"WallpaperStyle", 22.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                case Style.Stretch:
                    key.SetValue(@"WallpaperStyle", 2.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                case Style.Tile:
                    key.SetValue(@"WallpaperStyle", 0.ToString());
                    key.SetValue(@"TileWallpaper", 1.ToString());
                    break;
                case Style.Center:
                    key.SetValue(@"WallpaperStyle", 0.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(style), style, "That's not an option.");
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, tempPath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
    public partial class WallpaperForm : Form
    {
        private string _imagePath;
        private string _imageName;

        public WallpaperForm()
        {
            InitializeComponent();
        }

        private void SetWallpaper(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var uri = new System.Uri(_imagePath);
            switch (this.wallpaperStyle.SelectedItem)
            {
                case "Fill":
                    Wallpaper.Set(uri, Wallpaper.Style.Fill);
                    break;
                case "Fit":
                    Wallpaper.Set(uri, Wallpaper.Style.Fit);
                    break;
                case "Span":
                    Wallpaper.Set(uri, Wallpaper.Style.Span);
                    break;
                case "Stretch":
                    Wallpaper.Set(uri, Wallpaper.Style.Stretch);
                    break;
                case "Tile":
                    Wallpaper.Set(uri, Wallpaper.Style.Tile);
                    break;
                case "Center":
                    Wallpaper.Set(uri, Wallpaper.Style.Center);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(this.wallpaperStyle.SelectedItem),
                        this.wallpaperStyle.SelectedItem, "That's not an option.");
            }
            MessageBox.Show("Successfully set wallpaper!", "Success!");
            Cursor.Current = Cursors.Default;
        }

        private void OpenImageFile(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "";
            dialog.Filter = "Image Files|*.jpg;*.jpeg;";
            dialog.InitialDirectory = @"C:\";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _imagePath = dialog.FileName;
                int idx = _imagePath.LastIndexOf(@"\", StringComparison.Ordinal);
                if (idx != -1) _imageName = _imagePath[(idx + 1)..];
                fileLabel.Text = _imageName;
            }
        }
    }
}