namespace Kreta.Shared.Models.Responses
{
    public class ControllerResponse : ErrorStore
    {
        public ControllerResponse() : base() { }
        public bool IsSuccess => !HasError;
    }
}
