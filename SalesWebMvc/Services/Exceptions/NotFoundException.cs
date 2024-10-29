namespace SalesWebMvc.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string messege) : base(messege) 
        { 
        }
    }
}
