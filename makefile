publish:
	rm -rf ./out
	dotnet publish PasswordRetriever/PasswordRetriever.csproj -c Release -o ./out/linux-x64 -r linux-x64 --self-contained
	rm ./out/linux-x64/PasswordRetriever.pdb
	rm ./out/linux-x64/libinfisical_c.so
	tar -czvf ./out/linux-x64.tar.gz ./out/linux-x64
	dotnet publish PasswordRetriever/PasswordRetriever.csproj -c Release -o ./out/macos-arm64 -r osx-arm64 --self-contained
	rm ./out/macos-arm64/PasswordRetriever.pdb
	rm ./out/macos-arm64/libinfisical_c.dylib
	tar -czvf ./out/macos-arm64.tar.gz ./out/macos-arm64