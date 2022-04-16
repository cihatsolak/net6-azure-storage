namespace AzureStorageLibrary.Services
{
    public class QueueStorage : IQueueStorage
    {
        private readonly QueueClient _queueClient;

        public QueueStorage()
        {
            //string queueName = "vehicles-queue";
            string queueName = "watermak-queue";
            _queueClient = new QueueClient(ConnectionStrings.StorageConnectionString, queueName);
            _queueClient.CreateIfNotExists();
        }

        public async Task SendMessageAsync(string message)
        {
            //visibilitytimeout: mesaj kuyruktan işlenmek için alındıgında, bir başkası aynı mesajı almasın diye kuyrukta ne kadar süre görünmez kalacak?
            //timetolive: yaşam süresi default 7 gün.
            await _queueClient.SendMessageAsync(message, timeToLive: TimeSpan.FromDays(1));
        }

        public async Task<QueueMessage> RetrieveNextMessageAsync()
        {
            QueueProperties queueProperties = await _queueClient.GetPropertiesAsync(); //kuyrukta mesaj var mı?

            //var responsePeekedMessage = await _queueClient.PeekMessageAsync(); kuyruktan mesajı alayım ama kuyruktan da silinmesin diyorsak yani görünmezliğini kapatmamış oluyoruz.

            if (0 >= queueProperties.ApproximateMessagesCount) // kuyrukta mesaj yoksa
                return null;

            //visibilityTimeout: 1 dakika olarak belirdim. 1 dakika boyunca kuyrukta bu mesaj görünmez.
            var responseQueueMessage = await _queueClient.ReceiveMessageAsync(visibilityTimeout: TimeSpan.FromMinutes(1));
            return responseQueueMessage.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="popReceipt">kuyruktan mesajı silerken başarısız olursanız, başka client'lar o mesajı popReceipt property'si sayesinde siliyor olacaklar.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteMessageAsync(string messageId, string popReceipt)
        {
            var response = await _queueClient.DeleteMessageAsync(messageId, popReceipt);
            if (response.IsError)
                throw new Exception("");
        }
    }
}
