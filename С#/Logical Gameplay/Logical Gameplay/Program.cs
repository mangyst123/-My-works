using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_Gameplay
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class Ammo// Оружие запиши потом 
    {

    }
    class TypeDamage // Будет описывать тип урона игрока или NPC (физический по стандарту _damage, все остальное модифицированные уроны)
    {

    }
    // Я планирую сделать без классового основного игрока, может доп способности добавить, но думаю это будет лишнее
    // и так слишком масштабно получается
    class Warrior // Сделай абстрактным типом данных
    {
        // Все поля, которые будут у разных классво
        private int _health; // Определись с количеством хп, я думаю что со старта 1к хп нормально будет, в лейте ну 100к пусть будет
        private int _armor; // Будет от 1 до 350 максимум
        private string _name; // Ну просто имя перса
        private float _speed; // Скорость бега игрока (бустится артифактами )
        private float _assalt; // Скрытность, нужна ли она 
        private int _armorSkeill = 100;// модно сделать механику с процентами, как в Доте
        private int _mana; // Количество маны (а может и не буду добавлять)
        private int _damage; // Физический урон игрока
        private int _attacSpeed; // Скорость атаки, мб добавлю что-то типо кастетов, на лук точно полезно будет
        private bool _modificateAttak; // Криты
        private bool _morbetEffect; // Эфект вампиризма (будет зависить от оружия) запихни в оружие

        // Магические бонусы
        private int _magicArmor; // Нужно сделать несколько стихий или магий
        private int _magicDamage; // Основной магический урон, у посохов вместо физического будет
        private int _magicRangeCast; // Дальность каста по умолчанию
        private int _castSpeed; // Скорость сотворения заклинания (зависит от предметов)

        private void TakeDamage(Ammo ammo, int damage, TypeDamage typeDamage)
        {
            // Просто формула получения урона
        }


    }
}
