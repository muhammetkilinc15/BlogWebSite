namespace Asp.net_Core_Web_Application.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string? WriterName { get; set; }
        public string? WriterAbout { get; set; }
        public string? WriterMail { get; set; }
        public string? WriterPassword { get; set; }
        
        // IFormFile Sınıfı ile bir dosyadan fotoğraf seçebiliyoruz
        public IFormFile WriterImage { get; set; }
        public bool WriterStatus { get; set; }
    }
}
