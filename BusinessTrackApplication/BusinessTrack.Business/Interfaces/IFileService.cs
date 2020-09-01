using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessTrack.Business.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Geriye excel verisini byte dizisi olarak döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<byte[]> ExportExcel<T>(List<T> list, string workSheetName = "Worksheet1") where T : class, new();

        /// <summary>
        /// Geriye üretmiş ve upload etmiş olduğu pdf dosyasının virtual path'ini döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string ExportPdf<T>(List<T> list) where T : class, new();
    }
}
