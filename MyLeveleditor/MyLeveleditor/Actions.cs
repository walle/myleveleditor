using System;
using System.Collections.Generic;
using System.Text;

using MapAPI;

// This file contains the class declarations for the actions the editor is capable to undo and restore

namespace MyLeveleditor
{
    class EntityAddedAction : Action
    {
        int layer;
        MapEntity entity;

        public EntityAddedAction(int layer, MapEntity entity)
        {
            this.layer = layer;
            this.entity = entity;
        }

        public override Action Restore(MapForm target)
        {
            MapEntity removed = entity;
            Action inverse = new EntityRemovedAction(layer, removed);
            target.RemoveEntity(layer, entity);
            return this;
        }

        public override string ToString()
        {
            return "Add";
        }
    }

    class EntityRemovedAction : Action
    {
        int layer;
        MapEntity removed;

        public EntityRemovedAction(int layer, MapEntity removed)
        {
            this.layer = layer;
            this.removed = removed;
        }

        public override Action Restore(MapForm target)
        {
            Action inverse = new EntityAddedAction(layer, removed);
            target.AddEntity(layer, removed);
            return this;
        }

        public override string ToString()
        {
            return "Remove";
        }
    }
}
