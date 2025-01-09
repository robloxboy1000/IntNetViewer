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
        private static readonly string currentVersionFormatted = "v" + Application.ProductVersion; // Replace with your current version (must be "v*.*.*")

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
                    string latestVersionString = latestRelease["tag_name"].ToString();
                    string releaseNotes = latestRelease["body"].ToString();

                    // Strip "v" from the release version if it exists
                    if (latestVersionString.StartsWith("v"))
                    {
                        latestVersionString = latestVersionString.Substring(1);
                    }

                    string currentVersionString = currentVersionFormatted; // Replace with your current app version
                    Version currentVersion = new Version(currentVersionString);
                    Version latestVersion = new Version(latestVersionString);

                    // Compare versions
                    if (currentVersion < latestVersion)
                    {
                        MessageBox.Show($"A new version {latestVersion} is available!\n\nRelease Notes:\n{releaseNotes}",
                            "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (currentVersion > latestVersion)
                    {
                        MessageBox.Show($"You are using a pre-release version ({currentVersion}).",
                            "Pre-release Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("You are using the latest version.", "Up-to-date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking for updates: {ex.Message}", "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
