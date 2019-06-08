using SwinGameSDK;
using GameFramework;
using System.Collections.Generic;

namespace GalacticAssault
{
    public abstract class Actor : Entity
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        public Actor(float x, float y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        
        public static bool CheckCollision(Actor lhs, Actor rhs)
        {
            return  lhs.X < rhs.X + rhs.Width &&
                    lhs.X + lhs.Width > rhs.X &&
                    lhs.Y < rhs.Y + rhs.Height &&
                    lhs.Y + lhs.Height > rhs.Y;
        }

        public void AddScore(int score, EntityManager entities)
        {
            List<Player> players = entities.GetEntitiesByType<Player>();
            players.ForEach(p => p.Score += score);
            entities.Add(new ScoreParticle(X + Width/2, Y + Height/2, score));
        }
        
        public abstract void Update(EntityManager entities);
        public abstract void Render();
    }
}
