using System.Linq;
using System.Threading.Tasks;
using SystemWrapper.IO;

namespace DirectoryManager.BusinessDomain
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class DirectoryBusiness : IDirectoryBusiness
    {
        /// <summary>
        /// Measure the size of all files in the directories recursivly and asyncronously. 
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
        public async Task<decimal> MeasureDirectoryAsync(IDirectoryInfoWrap directoryInfo)
        {
            // measure each inner directory via async
            var directoryMeasurements = directoryInfo.GetDirectories().Select(MeasureDirectoryAsync).ToList();

            // measure all the files in this directory
            var fileSize = MeasureFiles(directoryInfo);

            // await on return of all inner directories before summarizing their datas.
            var size = (await Task.WhenAll(directoryMeasurements)).Sum();

            return size + fileSize;
        }

        /// <summary>
        /// Measure the size of all files in the directory provided
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
        private static decimal MeasureFiles(IDirectoryInfoWrap directoryInfo)
        {
            return directoryInfo.GetFiles().Aggregate(0.0M, (current, file) => current + file.Length);
        }
    }
}
