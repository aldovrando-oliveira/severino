#!/bin/bash
set -x
set -e

cd "$(dirname "$0")/.."

if ! [ -x "$(command -v coverlet)" ]; then
  echo 'Installing Coverlet.' >&2
  dotnet tool install --global coverlet.console

  export PATH="$PATH:/root/.dotnet/tools"
fi

dotnet build

coverlet ./test/Severino.Extensions.Exceptions.Tests/bin/Debug/net5.0/Severino.Extensions.Exceptions.Tests.dll \
    --target "dotnet" \
    --targetargs "test ./test/Severino.Extensions.Exceptions.Tests/Severino.Extensions.Exceptions.Tests.csproj --no-build" \
    --output "./coverage"
    --format "opencover"