using System.Drawing;
using System.Windows.Forms;

namespace Wallpaper_Tools
{
    partial class WallpaperForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openImage = new System.Windows.Forms.Button();
            this.setWallpaper = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.wallpaperStyle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // openImage
            // 
            this.openImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openImage.Location = new System.Drawing.Point(12, 12);
            this.openImage.Name = "openImage";
            this.openImage.Size = new System.Drawing.Size(113, 22);
            this.openImage.TabIndex = 0;
            this.openImage.Text = "Open Image File";
            this.openImage.UseVisualStyleBackColor = true;
            this.openImage.Click += new System.EventHandler(this.OpenImageFile);
            // 
            // setWallpaper
            // 
            this.setWallpaper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setWallpaper.Location = new System.Drawing.Point(285, 12);
            this.setWallpaper.Name = "setWallpaper";
            this.setWallpaper.Size = new System.Drawing.Size(90, 22);
            this.setWallpaper.TabIndex = 1;
            this.setWallpaper.Text = "Set Wallpaper";
            this.setWallpaper.UseVisualStyleBackColor = true;
            this.setWallpaper.Click += new System.EventHandler(this.SetWallpaper);
            //
            // wallpaperStyle
            //
            this.wallpaperStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wallpaperStyle.Location = new System.Drawing.Point(380, 13);
            this.wallpaperStyle.Size = new System.Drawing.Size(90, 23);
            this.wallpaperStyle.Items.Add("Fill");
            this.wallpaperStyle.Items.Add("Fit");
            this.wallpaperStyle.Items.Add("Span");
            this.wallpaperStyle.Items.Add("Stretch");
            this.wallpaperStyle.Items.Add("Tile");
            this.wallpaperStyle.Items.Add("Center");
            this.wallpaperStyle.Name = "wallpaperStyle";
            this.wallpaperStyle.TabIndex = 1;
            this.wallpaperStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            this.wallpaperStyle.SelectedItem = "Fill";
            // 
            // fileLabel
            // 
            this.fileLabel.Location = new System.Drawing.Point(131, 12);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(148, 22);
            this.fileLabel.TabIndex = 2;
            this.fileLabel.Text = "Choose a valid image file.";
            this.fileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WallpaperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 47);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.setWallpaper);
            this.Controls.Add(this.wallpaperStyle);
            this.Controls.Add(this.openImage);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(503, 86);
            this.MinimumSize = new System.Drawing.Size(503, 86);
            this.Name = "WallpaperForm";
            this.Text = "Wallpaper Tools";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button setWallpaper;
        private System.Windows.Forms.Label fileLabel;

        private System.Windows.Forms.Button openImage;
        private System.Windows.Forms.ComboBox wallpaperStyle;

        #endregion
    }
}