﻿// This file is part of Capy64 - https://github.com/Capy64/Capy64
// Copyright 2023 Alessandro "AlexDevs" Proto
//
//    Licensed under the Apache License, Version 2.0 (the "License").
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0

using System;
using System.Runtime.Serialization;

namespace Capy64.Runtime;

public class LuaException : Exception
{
    public LuaException()
    {
    }

    public LuaException(string message) : base(message)
    {
    }

    public LuaException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected LuaException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
