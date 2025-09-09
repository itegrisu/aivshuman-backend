namespace HumanVSAi.Api.Data
{
    public class Image
    {
        // Veritabanındaki Id sütununa karşılık gelir
        public int Id { get; set; }

        // Veritabanındaki R2ObjectKey sütununa karşılık gelir
        public string R2ObjectKey { get; set; } = string.Empty;

        // Veritabanındaki IsAI (0 veya 1) sütununa karşılık gelir.
        // EF Core bunu otomatik olarak bool (true/false) tipine çevirir.
        public bool IsAI { get; set; }
    }
}
