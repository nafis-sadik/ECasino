namespace Models.DataModels.Entities
{
    public class ResponseModel <T> where T : class
    {
        public T ObjResponse { get; set; }
        public bool IsValidResponse { get; set; }
        public string msg { get; set; }
    }
}
