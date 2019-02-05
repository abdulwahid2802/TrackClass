using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackClass.Enums;
using Xamarin.Forms;

namespace TrackClass.FileServices
{
    public class FileHelper
    {
        IFileHelper fileHelper = DependencyService.Get<IFileHelper>(); 

        public Task<bool> ExistsAsync(string filename)
        {
            return fileHelper.ExistsAsync(filename);
        }

        public Task WriteTextAsync(string filename, string text)
        {
            return fileHelper.WriteTaskAsync(filename, text);
        }

        public Task<string> ReadTextAsync(string filename)
        {
            return fileHelper.ReadTextAsync(filename);
        }

        public Task<IEnumerable<string>> GetFilesAsync()
        {
            return fileHelper.GetFilesAsync();
        }

        public Task DeleteAsync(string filename)
        {
            return fileHelper.DeleteAsync(filename);
        }

        public Task CreateDirectory(FoldersEnum folder)
        {
            return fileHelper.CreateDirectory(folder);
        }
    }
}
