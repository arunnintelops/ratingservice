using MediatR;

namespace Application.Commands.RatingService
{
    public class UpdateRatingCommand : IRequest
    {
        public int Id  { get; set; }
    
        
        public int BookID { get; set; }
        
    
        
        public int Rating { get; set; }
        
    
        
        public string Review { get; set; }
        
    
        
        public int UserID { get; set; }
        
    
    }
}
