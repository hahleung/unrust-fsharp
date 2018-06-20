IF NOT EXIST paket.lock (
    START /WAIT .paket/paket.exe install
)
dotnet restore src/Pods
dotnet build src/Pods

dotnet restore tests/Pods.Tests
dotnet build tests/Pods.Tests
dotnet test tests/Pods.Tests
