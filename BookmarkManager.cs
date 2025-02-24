using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntNetViewer
{
    public class BookmarkManager
    {
        private static string filePath = "bookmarks.json";
        private static string htmlFilePath = "./assets/bookmarks.html";

        public static List<Bookmark> LoadBookmarks()
        {
            if (!File.Exists(filePath)) return new List<Bookmark>();

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Bookmark>>(json);
        }

        public static void SaveBookmarks(List<Bookmark> bookmarks)
        {
            string json = JsonConvert.SerializeObject(bookmarks, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static void ExportBookmarksToHtml()
        {
            var bookmarks = LoadBookmarks();
            string htmlContent = GenerateHtmlContent(bookmarks);
            File.WriteAllText(htmlFilePath, htmlContent);
        }

        private static string GenerateHtmlContent(List<Bookmark> bookmarks)
        {
            string html = @"
        <!DOCTYPE html>
        <html>
        <head>
            <title>Bookmarks</title>
            <style>
                body { font-family: Arial, sans-serif; padding: 20px; }
                h2 { text-align: center; }
                ul { list-style-type: none; padding: 0; }
                li { padding: 10px; border-bottom: 1px solid #ddd; }
                a { text-decoration: none; color: #007bff; font-size: 18px; }
                a:hover { text-decoration: underline; }
            </style>
        </head>
        <body>
            <h2>My Bookmarks</h2>
            <ul>";

            foreach (var bookmark in bookmarks)
            {
                html += $"<li><a href='{bookmark.Url}' target='_blank'>{bookmark.Name}</a></li>";
            }

            html += @"
            </ul>
        </body>
        </html>";

            return html;
        }
    }
}
