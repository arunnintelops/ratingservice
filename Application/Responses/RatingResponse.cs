namespace Application.Responses
{
    public class RatingResponse
    {    
        public int Id  { get; protected set; }
    
        
        public int BookID { get; set; }
        
    
        
        public int Rating { get; set; }
        
    
        
        public string Review { get; set; }
        
    
        
        public int UserID { get; set; }
        
    
    }
}
