#!/bin/bash
dotnet build "MyProject.Infrastructure/MyProject.Infrastructure.csproj"
#if( UI-Webapi || UI-Both )
dotnet build "MyProject.UI/MyProject.UI.csproj"
#endif