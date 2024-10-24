namespace Kreata.Backend.Datas.Responses
{
    public class ControllerResponse : ErrorStore
    {
        public ControllerResponse() : base() { }
        public bool IsSuccess => !HasError;
    }
}
