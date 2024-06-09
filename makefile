publish:
	rm -rf ./out
	dotnet publish PasswordRetriever/PasswordRetriever.csproj -c Release -o ./out/linux-x64 -r linux-x64 --self-contained
	dotnet publish PasswordRetriever/PasswordRetriever.csproj -c Release -o ./out/macos-arm64 -r osx-arm64 --self-contained