namespace TicketsOnlineBackend.Helppers
{
    public class Response
    {

        public string Message { get; set; }
        public object Data { get; set; }

        public static implicit operator Response(string v)
        {
            throw new NotImplementedException();
        }

    }
}
