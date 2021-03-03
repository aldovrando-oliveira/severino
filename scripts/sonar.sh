#!/bin/bash
set -x
set -e

cd "$(dirname "$0")/.."

./.sonar/scanner/dotnet-sonarscanner begin \
    /k:"aldovrando-oliveira_severino" \
    /o:"aldovrando-oliveira" \
    /d:sonar.login="59c33cf019abdbb402ffd2a46da6a53f1cfbeacd" \
    /d:sonar.host.url="https://sonarcloud.io"
    /d:sonar.cs.opencover.reportsPaths="./coverage.opencover.xml" \
    
dotnet build

./.sonar/scanner/dotnet-sonarscanner end /d:sonar.login="59c33cf019abdbb402ffd2a46da6a53f1cfbeacd"
