namespace Group2Photo.Model
{
    public class PhotoRequest
    {
    public string Caption { get; set; }
    public string Url { get; set; }
    public int Contact_Id { get; set; }
    }


    public class UserPhoto : PhotoRequest 
    {
        public int Id { get; set; }
    }
}