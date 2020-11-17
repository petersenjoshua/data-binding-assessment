﻿using FlagData;
using System.Reflection;
using Xamarin.Forms;

namespace FlagFacts.Extensions
{
    public static class FlagExtensions
    {
        public class EmbeddedImageConverter : IValueConverter
{
    /// Optional type located in the assembly you want to get the resource
    /// from - if not supplied, the API assumes the resource is located in
    /// this assembly.
    public Type ResolvingAssemblyType { get; set; }

    public object Convert(object value, Type targetType,
                          object parameter, CultureInfo culture)
    {
        var imageUrl = (value ?? "").ToString();
        if (string.IsNullOrEmpty(imageUrl))
            return null;

        return ImageSource.FromResource(imageUrl,
            ResolvingAssemblyType?.GetTypeInfo().Assembly);
    }

    public object ConvertBack(object value, Type targetType,
                              object parameter, CultureInfo culture)
    {
        throw new NotSupportedException(
          $"{nameof(EmbeddedImageConverter)} cannot be used on two-way bindings.");
    }
}

        /// <summary>
        /// Method to retrieve the ImageSource for a flag. The
        /// flag images are stored as embedded resources in the
        /// data assembly.
        /// </summary>
        /// <param name="flag">Flag object to retrieve the image for</param>
        /// <returns>Xamarin.Forms ImageSource</returns>
        public static ImageSource GetImageSource(this Flag flag)
        {
            return ImageSource.FromResource(flag.ImageUrl, flag.GetType().GetTypeInfo().Assembly);
        }
    }
}
