namespace GD12_1133_A2_SreejaYathipathi
{
    public interface ICombatRoom
    {
        void OnEntered(Player player);
        void OnExited(Player player);
        void OnSearched(Player player);
    }
}