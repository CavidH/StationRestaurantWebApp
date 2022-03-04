

namespace Data.Utilities.Interfaces
{
    public interface IDataResult<out Entity> : IResult
    {
        public Entity Data { get; }
    }
}
