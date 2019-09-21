#!/bin/bash
mkdir samples
pushd samples
dotnet new manga --use-cases full -n MyFull
dotnet new manga --use-cases basic -n MyBasic
dotnet new manga --use-cases readonly -n MyReadOnly
popd