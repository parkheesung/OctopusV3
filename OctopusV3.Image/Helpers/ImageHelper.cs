using OctopusV3.Core;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace OctopusV3.Image
{
    public class ImageHelper
    {
		public static ReturnValue Resize(string importPath, string exportPath, int targetX, int targetY)
		{
			var result = new ReturnValue();

			try
			{
				System.Drawing.Image originalImage = System.Drawing.Image.FromFile(importPath);


				double ratioX = targetX / (double)originalImage.Width;
				double ratioY = targetY / (double)originalImage.Height;

				double ratio = Math.Min(ratioX, ratioY);

				int newWidth = (int)(originalImage.Width * ratio);
				int newHeight = (int)(originalImage.Height * ratio);

				Bitmap newImage = new Bitmap(targetX, targetY);
				using (Graphics g = Graphics.FromImage(newImage))
				{
					g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
					g.DrawImage(originalImage, (targetX - newWidth) / 2, (targetY - newHeight) / 2, newWidth, newHeight);
				}

				newImage.Save(exportPath);
				FileInfo fi = new FileInfo(exportPath);
				if (fi.Exists)
				{
					result.Success(fi.Length, exportPath);
				}
				else
                {
					result.Error("File Save Fail.");
                }

				originalImage.Dispose();
				newImage.Dispose();
			}
			catch (Exception ex)
            {
				result.Error(ex);
            }

			return result;
		}

		public static ReturnValue Crop(string importPath, string exportPath, int targetX, int targetY)
		{
			var result = new ReturnValue();

			try
			{
				System.Drawing.Image originalImage = System.Drawing.Image.FromFile(importPath);


				double ratioX = targetX / (double)originalImage.Width;
				double ratioY = targetY / (double)originalImage.Height;

				double ratio = Math.Max(ratioX, ratioY);

				int newWidth = (int)(originalImage.Width * ratio);
				int newHeight = (int)(originalImage.Height * ratio);

				Bitmap newImage = new Bitmap(targetX, targetY);
				using (Graphics g = Graphics.FromImage(newImage))
				{
					//g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
					g.DrawImage(originalImage, (targetX - newWidth) / 2, (targetY - newHeight) / 2, newWidth, newHeight);
				}

				newImage.Save(exportPath);
				FileInfo fi = new FileInfo(exportPath);
				if (fi.Exists)
				{
					result.Success(fi.Length, exportPath);
				}
				else
				{
					result.Error("File Save Fail.");
				}

				originalImage.Dispose();
				newImage.Dispose();
			}
			catch (Exception ex)
			{
				result.Error(ex);
			}

			return result;
		}

		public static ReturnValue Resize(MemoryStream memory, string exportPath, int targetX, int targetY)
		{
			var result = new ReturnValue();

			try
			{
				System.Drawing.Image originalImage = System.Drawing.Image.FromStream(memory, false, false);


				double ratioX = targetX / (double)originalImage.Width;
				double ratioY = targetY / (double)originalImage.Height;

				double ratio = Math.Min(ratioX, ratioY);

				int newWidth = (int)(originalImage.Width * ratio);
				int newHeight = (int)(originalImage.Height * ratio);

				Bitmap newImage = new Bitmap(targetX, targetY);
				using (Graphics g = Graphics.FromImage(newImage))
				{
					g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
					g.DrawImage(originalImage, (targetX - newWidth) / 2, (targetY - newHeight) / 2, newWidth, newHeight);
				}

				newImage.Save(exportPath);
				FileInfo fi = new FileInfo(exportPath);
				if (fi.Exists)
				{
					result.Success(fi.Length, exportPath);
				}
				else
				{
					result.Error("File Save Fail.");
				}

				originalImage.Dispose();
				newImage.Dispose();
			}
			catch (Exception ex)
			{
				result.Error(ex);
			}

			return result;
		}

		public static ReturnValue Crop(MemoryStream memory, string exportPath, int targetX, int targetY)
		{
			var result = new ReturnValue();

			try
			{
				System.Drawing.Image originalImage = System.Drawing.Image.FromStream(memory, false, false);


				double ratioX = targetX / (double)originalImage.Width;
				double ratioY = targetY / (double)originalImage.Height;

				double ratio = Math.Max(ratioX, ratioY);

				int newWidth = (int)(originalImage.Width * ratio);
				int newHeight = (int)(originalImage.Height * ratio);

				Bitmap newImage = new Bitmap(targetX, targetY);
				using (Graphics g = Graphics.FromImage(newImage))
				{
					//g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
					g.DrawImage(originalImage, (targetX - newWidth) / 2, (targetY - newHeight) / 2, newWidth, newHeight);
				}

				newImage.Save(exportPath);
				FileInfo fi = new FileInfo(exportPath);
				if (fi.Exists)
				{
					result.Success(fi.Length, exportPath);
				}
				else
				{
					result.Error("File Save Fail.");
				}

				originalImage.Dispose();
				newImage.Dispose();
			}
			catch (Exception ex)
			{
				result.Error(ex);
			}

			return result;
		}

		public static Task<ReturnValue> ResizeAsync(string importPath, string exportPath, int targetX, int targetY)
        {
			return Task.Factory.StartNew(() => Resize(importPath, exportPath, targetX, targetY));
        }

		public static Task<ReturnValue> CropAsync(string importPath, string exportPath, int targetX, int targetY)
		{
			return Task.Factory.StartNew(() => Crop(importPath, exportPath, targetX, targetY));
		}

		public static Task<ReturnValue> ResizeAsync(MemoryStream memory, string exportPath, int targetX, int targetY)
		{
			return Task.Factory.StartNew(() => Resize(memory, exportPath, targetX, targetY));
		}

		public static Task<ReturnValue> CropAsync(MemoryStream memory, string exportPath, int targetX, int targetY)
		{
			return Task.Factory.StartNew(() => Crop(memory, exportPath, targetX, targetY));
		}
	}
}
