using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackClass.Enums;

namespace TrackClass.FileServices
{
    public interface IFileHelper
    {
        Task<bool> ExistsAsync(string filename);

        Task WriteTaskAsync(string filename, string text);

        Task<string> ReadTextAsync(string filename);

        Task<IEnumerable<string>> GetFilesAsync();

        Task DeleteAsync(string filename);


        // // // // // // // // // // // // // // // 
        Task CreateDirectory(FoldersEnum folder);

        Task<string> GetLocalFolder(FoldersEnum folder);
    }
}
