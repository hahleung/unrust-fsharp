if [ ! -e "paket.lock" ]
then
    exec mono .paket/paket.exe install
fi
dotnet restore src/Pods
dotnet build src/Pods

dotnet restore tests/Pods.Tests
dotnet build tests/Pods.Tests
dotnet test tests/Pods.Tests
