using Utils;

namespace Objects.Pawn
{
    public interface IPawn
    {
        EPawnType GetType();
        void Reset();
        void WillDespawn();
    }
}