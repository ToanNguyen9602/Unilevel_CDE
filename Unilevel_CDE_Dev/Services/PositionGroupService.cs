using Unilevel_CDE_Dev.Models;

namespace Unilevel_CDE_Dev.Services
{
    public interface PositionGroupService
    {
        public bool Create(PositionGroup positionGroup);
        public dynamic FindId(int id);
        public bool Update(PositionGroup positionGroup);
        public dynamic findAll();
    }
}
