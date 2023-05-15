using AhmetErgun_GunsOfTheOldWest.Models;

namespace AhmetErgun_GunsOfTheOldWest.Services
{
    public class Game
    {
        Bullets bullets = new Bullets(1);
        Shooter shooter;

        public string shoot()
        {
            bullets.shoot();
            int numberOfBullets = bullets.getBullets();
            if (numberOfBullets >= 0)
            {
                Random rand = new Random();
                int chance = rand.Next(0, 10);
                if (chance <=3 )
                {
                    return "won";
                } else
                {
                    return "continue";
                }
            } else
            {
                return "lost";
            }
        }

        public int getBullets()
        {
            return bullets.getBullets();
        }

        public Shooter AddShooter(Shooter shooterValue)
        {
            shooter = new Shooter(
                shooterValue.FirstName,
                shooterValue.LastName,
                shooterValue.Email,
                shooterValue.PhoneNumber);

            return shooter;
        }

        public void AddBullets(int numberOfBulletsBought)
        {
            bullets.addBullets(numberOfBulletsBought);
        }
    }
}
