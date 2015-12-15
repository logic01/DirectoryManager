using System.Threading.Tasks;
using SystemWrapper.IO;

namespace DirectoryManager.BusinessDomain
{
    public interface IDirectoryBusiness
    {
        Task<decimal> MeasureDirectoryAsync(IDirectoryInfoWrap directoryInfo);
    }
}