

namespace StajProjesiAPI.Application.Utilities.Result
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
