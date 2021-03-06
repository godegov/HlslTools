﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace ShaderTools.CodeAnalysis.Editor.Implementation.IntelliSense
{
    internal interface ISession<TModel>
    {
        TModel InitialUnfilteredModel { get; }

        void Stop();

        TModel WaitForController();
    }
}
