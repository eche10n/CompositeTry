using System;
using System.Collections.Generic;

namespace CompositeTry
{
    class Program
    {

        class Client
        {
            /// <summary>
            /// Создание армии
            /// </summary>
            public static void Main()
            {
                Component Squad = new Composite(10);
                Component footman1 = new Primitive(10);
                Component footman2 = new Primitive(10);
                Component footman3 = new Primitive(10);
                Composite Cavalery = new Composite(50);
                Component horseman1 = new Primitive(100);
                Component horseman2 = new Primitive(100);
                Squad.Add(footman1);
                Squad.Add(footman2);
                Squad.Add(footman3);
                Cavalery.Add(horseman1);
                Cavalery.Add(horseman2);
                Squad.Add(Cavalery);
                Console.WriteLine(Squad.returnPower());
            }
        }

        /// <summary>
        /// Отвечает за общие признаки сущностей
        /// </summary>
        abstract class Component
        {
            protected int power;

            public Component(int Power)
            {
                this.power = Power;
            }

            public abstract int returnPower();
            public abstract void Add(Component c);
            public abstract void Remove(Component c);
        }


        /// <summary>
        /// Composite хранит компоненты-потомки абстрактного типа Component, 
        /// каждый из которых может быть также Composite.
        /// </summary>
        class Composite : Component
        {
            List<Component> child = new List<Component>();

            public Composite(int Power)
                 : base(Power)
            { }

            public override void Add(Component component)
            {
                child.Add(component);
            }

            public override void Remove(Component component)
            {
                child.Remove(component);
            }

            public override int returnPower()
            {
                /// <value>
                /// Значение мощи всего боевого построения
                /// </value>
                int FullPower = 0;
                FullPower += power;


                /// <remarks> Обход всех юнитов, которые пренадлежат этому отряду </remarks>
                foreach (Component component in child)
                {
                    component.returnPower();
                    FullPower += component.returnPower();
                }
                return FullPower;
            }
        }


        /// <summary>
        /// Минимальная сущность иерархии
        /// </summary>
        class Primitive : Component
        {
            public Primitive(int Power)
                : base(Power)
            { }

            public override int returnPower()
            {
                return power;
            }

            public override void Add(Component component){}

            public override void Remove(Component component){}
        }
    }
}
