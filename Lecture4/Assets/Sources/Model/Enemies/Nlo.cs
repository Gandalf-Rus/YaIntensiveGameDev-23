using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class Nlo : Enemy
    {
        private readonly float _speed;
        private Transformable _target;
        private bool _inArmy;
        private bool _inFight;

        public bool InArmy => _inArmy;
        public bool InFight => _inFight;
        public Transformable Target => _target;

        public Nlo(Transformable target, Vector2 position, float speed) : base(position, 0)
        {
            _target = target;
            _speed = speed;
        }

        public void SetArmy()
        {
            _inArmy = true;
        }

        public void SetEnemy(Nlo nlo)
        {
            if (nlo == this)
                return;
            _target = nlo;
            _inFight= true;
        }

        public override void Update(float deltaTime)
        {
            if (_target == null)
                return;
            Vector2 nextPosition = Vector2.MoveTowards(Position, _target.Position, _speed * deltaTime);
            MoveTo(nextPosition);
            LookAt(_target.Position);
        }

        private void LookAt(Vector2 point)
        {
            Rotate(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector3.up, (Position - point)));
        }
    }
}
