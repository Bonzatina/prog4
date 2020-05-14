namespace Model
{
    public interface IBullet
    {
        int Damage { get; set; }

        void Move();
    }
}