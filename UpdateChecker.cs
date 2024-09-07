using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace IntNetViewer
{
    public class UpdateChecker
    {
        private static readonly string repoOwner = "robloxboy1000";  // Replace with your repo owner
        private static readonly string repoName = "IntNetViewer";   // Replace with your repo name
        private static readonly string currentVersion = "v" + Application.ProductVersion; // Replace with your current version

        public static async Task CheckForUpdates()
        {
            string apiUrl = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases/latest";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request"); // GitHub API requires a user-agent

                try
                {
                    var response = await client.GetStringAsync(apiUrl);
                    var latestRelease = JObject.Parse(response);
                    string latestVersion = latestRelease["tag_name"].ToString();
                    string releaseNotes = latestRelease["body"].ToString();

                    // Compare versions (you might need a more sophisticated version comparison logic)
                    if (latestVersion != currentVersion)
                    {
                        // Notify the user about the new update
                        MessageBox.Show($"A new version {latestVersion} is available!\n\nRelease Notes:\n{releaseNotes}",
                            "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("You are using the latest version.", "No Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking for updates: {ex.Message}", "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
