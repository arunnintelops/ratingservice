using Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Rating : EntityBase
    {
        public int Id  { get; set; }
    
        
        public int BookID { get; set; }
        
    
        
        public int Rating { get; set; }
        
    
        
        public string Review { get; set; }
        
    
        
        public int UserID { get; set; }
        
    
    }
}
