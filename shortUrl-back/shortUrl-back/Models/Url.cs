namespace shortUrl_back.Models
{
	public class Url
	{
		public int UrlID { get; set; }

        [StringLength(maximumLength: 9999)]
        public string LongUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string ShortUrl { get; set; }

        public int EntryCount { get; set; }

        public string CreateDate { get; set; }
    }
}

