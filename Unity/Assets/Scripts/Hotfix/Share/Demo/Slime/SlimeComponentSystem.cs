using System.Collections.Generic;
using System.Linq;

namespace ET
{
    [FriendOf(typeof(SlimeComponent))]
    [EntitySystemOf(typeof(SlimeComponent))]
    public static partial class SlimeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SlimeComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this SlimeComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this SlimeComponent self)
        {
        }

        public static void Add(this SlimeComponent self, Slime slime)
        {
        }

        public static Slime Get(this SlimeComponent self, long id)
        {
            Slime slime = self.GetChild<Slime>(id);
            return slime;
        }

        public static void Remove(this SlimeComponent self, long id)
        {
            Slime slime = self.GetChild<Slime>(id);
            slime?.Dispose();
        }

        public static List<Slime> GetAll(this SlimeComponent self)
        {
            List<Slime> slimes = new List<Slime>();
            foreach (Entity entity in self.Children.Values.ToList())
            {
                slimes.Add(entity as Slime);
            }

            return slimes;
        }
    }
}