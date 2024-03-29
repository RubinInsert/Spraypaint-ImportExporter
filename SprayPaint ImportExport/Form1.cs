﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SprayPaint_ImportExport
{
    public partial class Form1 : Form
    {
        static DialogResult? fileDialog = null;
        static readonly string[] exportFilters = new string[]
        {
            "Graffitti File (*.dat)|*.dat",
            "PNG (*.png)|*.png",
        };
        static SprayPaint.ExportSetting exportSetting = SprayPaint.ExportSetting.ImageToGraffitti;
        public Form1()
        {
            InitializeComponent();
        }
        void CreatePreview()
        {
            if(fileImport.FileName != null)
            {
                if (previewImage.Image != null) previewImage.Image.Dispose();
                previewImage.Image = SprayPaint.CreatePreview(size256.Checked ? 256 : 512, exportSetting, fileImport.FileName);
            }
        }
        private void openFile_Click(object sender, EventArgs e)
        {
            fileDialog = fileImport.ShowDialog();
            if (fileDialog == DialogResult.OK)
            {
                string? fileType = Path.GetExtension(fileImport.FileName);
                exportSetting = fileType == ".txt" || fileType == ".dat" ? SprayPaint.ExportSetting.GraffittiToImage : SprayPaint.ExportSetting.ImageToGraffitti;


                if(exportSetting == SprayPaint.ExportSetting.ImageToGraffitti)
                {
                    fileExport.Filter = exportFilters[0];
                } else
                {
                    fileExport.Filter = exportFilters[1];
                }
                CreatePreview();
            }
        }

        private void generateImage_Click(object sender, EventArgs e)
        {
            if (fileExport.ShowDialog() == DialogResult.OK)
            {
                if (fileImport.FileName != null && fileExport.FileName != null)
                {
                    if(exportSetting == SprayPaint.ExportSetting.ImageToGraffitti)
                    {
                        SprayPaint.Img2Graffiti(size256.Checked ? 256 : 512, fileImport.FileName, fileExport.FileName);
                    } else
                    {
                        SprayPaint.Graffiti2Img(fileImport.FileName, fileExport.FileName);
                    }
                    
                }
            }
        }

        private void previewImage_Click(object sender, EventArgs e)
        {

        }

        private void size256_CheckedChanged(object sender, EventArgs e)
        {
            if(fileDialog == DialogResult.OK)
            {
                CreatePreview();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/InsertNameSUP") { UseShellExecute = true });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
