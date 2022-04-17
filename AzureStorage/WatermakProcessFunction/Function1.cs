using AzureStorageLibrary.Entities;
using AzureStorageLibrary.Infrastructure;
using AzureStorageLibrary.Models;
using AzureStorageLibrary.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WatermakProcessFunction
{
    public class Function1
    {
        [FunctionName("Function1")]
        public async Task Run([QueueTrigger("watermak-queue", Connection = "")] ImageWatermakQueue imageWatermakQueue, ILogger log)
        {
            ConnectionStrings.StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=automotivestorageaccount;AccountKey=ueAynZX2FhrPbb3CbKDYQi6qHRQiTPtEdoNnSouo+btq0Mydd/DtrvFTeMNcJspWOTooamPS44Qqi0zn+AYH3g==;EndpointSuffix=core.windows.net";
            IBlobStorage blobStorage = new BlobStorage();
            INoSqlStorage<UserPicture> userPictureNoSqlStorage = new TableStorage<UserPicture>();

            foreach (var imageName in imageWatermakQueue.Images)
            {
                using var stream = await blobStorage.DownloadAsync(imageName, EContainerName.images);
                using var memoryStream = AddWatermak(imageWatermakQueue.WatermakText, stream);

                await blobStorage.UploadAsync(memoryStream, imageName, EContainerName.watermarks);

                log.LogInformation($"{imageName} resmine filigran eklenmiþtir.");
            }

            var userPicture = await userPictureNoSqlStorage.GetByRowAndPartitionKeyAsync(imageWatermakQueue.UserId, imageWatermakQueue.City);
            if (userPicture.Paths.Any())
            {
                imageWatermakQueue.Images.AddRange(userPicture.WatermarkPaths);
            }

            userPicture.WatermarkPaths = imageWatermakQueue.Images;
            await userPictureNoSqlStorage.UpdateAsync(userPicture);

            HttpClient httpClient = new();
            await httpClient.GetAsync($"https://localhost:7261/api/Notification/CompleteWatermakProcess/{imageWatermakQueue.ConnectionId}");

            log.LogInformation($"Client bilgilendirilmiþtir");

            httpClient.Dispose();
        }

        public MemoryStream AddWatermak(string watermarkText, Stream imageStream)
        {
            MemoryStream ms = new MemoryStream();

            using (Image image = Bitmap.FromStream(imageStream))
            {
                using (Bitmap tempBitmap = new Bitmap(image.Width, image.Height))
                {
                    using (Graphics gph = Graphics.FromImage(tempBitmap))
                    {
                        gph.DrawImage(image, 0, 0);

                        var font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);

                        var color = Color.FromArgb(255, 0, 0);

                        var brush = new SolidBrush(color);

                        var point = new Point(20, image.Height - 50);

                        gph.DrawString(watermarkText, font, brush, point);

                        tempBitmap.Save(ms, ImageFormat.Png);
                    }
                }
            }

            ms.Position = 0;

            return ms;
        }
    }
}