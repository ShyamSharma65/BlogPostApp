namespace BlogPost.SharedLibrary.Models
{
    public class BlogPostDto
    {
        public long Id { get; set; }
        public string BlogPostName { get; set; } = string.Empty;
        public string? BlogPostDescription { get; set; }
        public string BlogPostContent { get; set; } = string.Empty;
        public string? FeaturedImageUrl { get; set; }
        public string? Comments { get; set; }
        public bool IsPublished { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public string? CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }
}
