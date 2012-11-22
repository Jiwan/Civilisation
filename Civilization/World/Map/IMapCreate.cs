
namespace Civilization.World.Map
{
    interface IMapCreate
    {
        #region methods
        public Map CreateMap(ISquareRandomizer randomizer);
        #endregion
    }
}
