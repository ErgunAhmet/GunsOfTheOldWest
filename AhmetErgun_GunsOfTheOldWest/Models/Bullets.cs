namespace AhmetErgun_GunsOfTheOldWest.Models
{
    public class Bullets
    {
        public int _bulletsSetId { get; set; }
        public int _bullets { get; set; } = 12;
        public Bullets(int bulletsSetId)
        {
            _bulletsSetId = bulletsSetId;
        }
        public void shoot()
        {
            _bullets--;
        }

        public int getBullets()
        {
            return _bullets;
        }

        public void addBullets(int number)
        {
            _bullets = _bullets + number;
        }
    }
}
