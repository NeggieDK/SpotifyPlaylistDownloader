using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyDownloader.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Clean(this string input)
        {
            return input.Replace("\\", "");
        }
    }
}
