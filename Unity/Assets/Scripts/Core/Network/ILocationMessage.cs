namespace ET
{
    public interface ILocationMessage : ILocationRequest
    {
    }

    public interface ILocationRequest : IRequest
    {
    }

    public interface ILocationResponse : IResponse
    {
    }

    public interface IChatRequest : ILocationRequest
    {
    }

    public interface IChatResponse : ILocationResponse
    {
    }
}