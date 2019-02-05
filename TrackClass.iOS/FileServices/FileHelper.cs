using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrackClass.FileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(TrackClass.iOS.FileServices.FileHelper))]

namespace TrackClass.iOS.FileServices
{
    public class FileHelper : IFileHelper
    {
        public Task DeleteAsync(string filename)
        {
            File.Delete(GetFilesPath(filename));
            return Task.FromResult(true);
        }

        public Task<bool> ExistsAsync(string filename)
        {
            string filepath = GetFilesPath(filename);
            bool exists = File.Exists(filepath);
            return Task.FromResult(exists);
        }

        public async Task<IEnumerable<string>> GetFilesAsync()
        {
            IEnumerable<string> filenames =
                from filepath in Directory.EnumerateFiles(GetDocsFolder())
                select Path.GetFileName(filepath);

            return await Task.FromResult(filenames);
        }

        public async Task<string> ReadTextAsync(string filename)
        {
            string filepath = GetFilesPath(filename);
            using (StreamReader reader = File.OpenText(filepath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task WriteTaskAsync(string filename, string text)
        {
            string filepath = GetFilesPath(filename);
            using (StreamWriter writer = File.CreateText(filepath))
            {
                await writer.WriteAsync(text);
            }
        }

        private string GetFilesPath(string filename)
        {
            return Path.Combine(GetDocsFolder(), filename);
        }
        
        private string GetDocsFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}
