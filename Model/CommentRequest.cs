namespace Group2Comment.Model
{
    public class CommentRequest
    {
        public string Content { get; set; }
        public int Contact_Id { get; set; }
        
    }

    public class UserComment : CommentRequest
    {
        public int Id { get; set; }
        public int Photo_Id { get; set; }
    }
}