namespace HomeCompassApi.Services.Feed
{
    public class PostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublisedOn { get; set; }      
        public string UserId { get; set; }    
        public int CommentsCount { get; set; }
    }
}
