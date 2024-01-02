using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sybaris.IrfanView.Extensions.PhotoSort
{
    public static class PictureHelper
    {
        public static DateTime GetDateTakenFromImage(string imagePath)
        {
            using (var image = SixLabors.ImageSharp.Image.Load(imagePath))
            {
                var exifProfile = image.Metadata.ExifProfile;

                if (exifProfile != null && exifProfile.TryGetValue(ExifTag.DateTimeOriginal, out var value))
                {
                    string dateString = value.ToString();
                    if (DateTime.TryParseExact(dateString, "yyyy:MM:dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out var dateTaken))
                        return dateTaken;
                }

                return DateTime.MinValue;
            }
        }
    }
}
