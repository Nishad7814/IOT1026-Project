using System;
using System.Collections.Generic;

namespace MinotaurLabyrinth
{
    public sealed class RoomFactory
    {
        private RoomFactory() { }
        private static readonly Lazy<RoomFactory> _lazy = new Lazy<RoomFactory>(() => new RoomFactory());

        public static RoomFactory Instance => _lazy.Value;

        private readonly Dictionary<RoomType, Func<Room>> _callbacks = new Dictionary<RoomType, Func<Room>>();

        public bool Register(RoomType type, Func<Room> createFn)
        {
            if (_callbacks.ContainsKey(type))
            {
                return false;
            }

            _callbacks.Add(type, createFn);
            return true;
        }

        public Room BuildRoom(RoomType type)
        {
            if (_callbacks.TryGetValue(type, out Func<Room> function))
            {
                return function();
            }

            var atype = Type.GetType($"MinotaurLabyrinth.{type}") ?? throw new Exception($"Could not find type {type}");
            var room = (Room)Activator.CreateInstance(atype)!;
            Register(type, () => (Room)Activator.CreateInstance(atype)!);
            return room;
        }
    }
}
