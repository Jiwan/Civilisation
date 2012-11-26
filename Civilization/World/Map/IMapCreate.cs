
namespace Civilization.World.Map
{
    public interface IMapCreate
    {
        #region methods
        Map CreateMap(ISquareRandomizer randomizer);
        #endregion
    }
}
