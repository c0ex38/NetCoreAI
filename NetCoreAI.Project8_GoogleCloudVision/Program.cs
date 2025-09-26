using Google.Cloud.Vision.V1;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Resim yolunu giriniz: ");
        string imagePath = Console.ReadLine();

        string credentialPath = @"C:\Users\cagri\OneDrive\Desktop\vivid-pact-473312-u5-8e5a3c34339e.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);


        try
        {
            var client = ImageAnnotatorClient.Create();

            var image = Image.FromFile(imagePath);
            var response = client.DetectLabels(image);
            Console.WriteLine("Resimdeki Metin: ");
            Console.WriteLine("");
            foreach (var annotation in response)
            {
                if (!string.IsNullOrEmpty(annotation.Description))
                {
                    Console.WriteLine(annotation.Description);
                }

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu {ex.Message}");
        }
    }
}

/*
  C:\Users\cagri\OneDrive\Desktop\1.jpeg
 */