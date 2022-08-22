namespace Net6CqrsTemplate.Infrastructure.Services;

using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Hosting;
using Net6CqrsTemplate.Application.Contracts.Infrastructure.Services;
using Net6CqrsTemplate.Application.Dtos.Zip;

public class ZipFileService : IZipFileService
{
    private readonly IHostingEnvironment env;


    public ZipFileService(IHostingEnvironment env)
    {
        this.env = env ?? throw new ArgumentNullException(nameof(env));
    }

    public ZipResultDto DownloadZipFile(string[] filePaths)
    {
        var webRoot = env.ContentRootPath;

        var fileName = "MyZip.zip";
        var tempOutput = "/" + fileName;

        using (ZipOutputStream IzipOutputStream = new ZipOutputStream(File.Create(tempOutput)))
        {
            IzipOutputStream.SetLevel(9);
            byte[] buffer = new byte[4096];
            var fileList = new List<string>();

            foreach (var file in filePaths)
            {
                fileList.Add(file);
            }

            string directoryA = "Root/A";
            string directoryB = "Root/B";


            for (int i = 0; i < fileList.Count; i++)
            {
                ZipEntry entry = new ZipEntry("/blabla/" + Path.GetFileName(fileList[i]));
                entry.DateTime = DateTime.Now;
                entry.IsUnicodeText = true;
                IzipOutputStream.PutNextEntry(entry);

                using (FileStream oFileStream = File.OpenRead(fileList[i]))
                {
                    int sourceBytes;
                    do
                    {
                        sourceBytes = oFileStream.Read(buffer, 0, buffer.Length);
                        IzipOutputStream.Write(buffer, 0, sourceBytes);
                    } while (sourceBytes > 0);
                }
            }
            IzipOutputStream.Finish();
            IzipOutputStream.Flush();
            IzipOutputStream.Close();
        }

        byte[] finalResult = File.ReadAllBytes(tempOutput);
        if (File.Exists(tempOutput))
        {
            File.Delete(tempOutput);
        }
        if (finalResult == null || !finalResult.Any())
        {
            throw new Exception(string.Format("Nothing found"));
        }

        return new ZipResultDto
        {
            FileResult = finalResult,
            FileName = fileName
        };
    }
}
