using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MyNavigation
{
    public abstract class MyBaseElementaryArea: MyAbstractArea
    {
        public override Vector3 CentralPoint => transform.position;

        private Collider _collider;

        public override bool ContainsPoint(Vector3 point)
        {
            if(_collider == null)
            {
                _collider = GetComponent<Collider>();
            }

            NLogFactory.GetLogger().Info($"_point = {point}");
            NLogFactory.GetLogger().Info($"_collider.bounds.Contains(point) = {_collider.bounds.Contains(point)}");
            NLogFactory.GetLogger().Info($"_collider.ClosestPoint(point) = {_collider.ClosestPoint(point)}");
            NLogFactory.GetLogger().Info($"_collider.ClosestPointOnBounds(point) = {_collider.ClosestPointOnBounds(point)}");

            return _collider.bounds.Contains(point);
            //return (_collider.ClosestPoint(point) - point).sqrMagnitude < Mathf.Epsilon * Mathf.Epsilon;
        }
    }
}
