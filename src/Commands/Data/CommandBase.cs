﻿using ProtoBuf;
using System.IO;

namespace CSM.Commands
{
    /// <summary>
    ///     A base protobuf command that all other commands in this mod should
    ///     extend. Provides support for serialization.
    ///
    ///     When creating new commands, you should create a new command ID (up to 255) which
    ///     represents this command when sending over the network.
    /// </summary>
    [ProtoContract]
    public abstract class CommandBase
    {
        /// <summary>
        ///     Serializes the command into a byte array for sending over the network.
        /// </summary>
        /// <returns>A byte array containing the message.</returns>
        public byte[] Serialize()
        {
            byte[] result;

            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, this);
                result = stream.ToArray();
            }

            return result;
        }
    }
}