ConnectionStrings.StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=automotivestorageaccount;AccountKey=ueAynZX2FhrPbb3CbKDYQi6qHRQiTPtEdoNnSouo+btq0Mydd/DtrvFTeMNcJspWOTooamPS44Qqi0zn+AYH3g==;EndpointSuffix=core.windows.net";
QueueStorage _queueStorage = new();

byte[] byteMessage = Encoding.UTF8.GetBytes("Cihat Solak");
string message = Convert.ToBase64String(byteMessage);

//await _queueStorage.SendMessageAsync(message); 

var queueMessage = await _queueStorage.RetrieveNextMessageAsync();
if (queueMessage is null)
{
    Console.WriteLine("Kuyrukta bekleyen mesaj yok..");
}

string receiveMessageText = Encoding.UTF8.GetString(Convert.FromBase64String(queueMessage.Body.ToString()));
Console.WriteLine("Gelen Mesaj: {0}", receiveMessageText);

await _queueStorage.DeleteMessageAsync(queueMessage.MessageId, queueMessage.PopReceipt);

Console.ReadKey();