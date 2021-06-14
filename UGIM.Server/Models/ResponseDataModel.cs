namespace UGIM.Server.Models
{
    public class ResponseDataModel<T> : ResponseModel
    {
        public T Data { get; set; }
    }
}
