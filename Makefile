COMPILER = mcs
DISTPATH = ./dist/
SRCPATH = ./src/
EXENAME = Program.exe
DLLNAME = CoolList.dll
LIBRARY = -r:$(DISTPATH)$(DLLNAME)

build: clean dll prog start

dll:
	$(COMPILER) -target:library ${SRCPATH}CoolList/*.cs -out:$(DISTPATH)$(DLLNAME)

prog:
	$(COMPILER) $(LIBRARY) $(SRCPATH)*.cs -out:$(DISTPATH)$(EXENAME)

start:
	mono $(DISTPATH)$(EXENAME)

clean:
	rm -rf $(DISTPATH)*

mono_release: clean dll prog
	mkdir release_mono
	cp ./dist/* ./release_mono/
	tar cvzf release_mono.tar.gz release_mono
	rm -rf ./release_mono

dotnet_release: clean
	dotnet build ./CoolList.sln
	mkdir release_dotnet
	cp ./dist/* ./release_dotnet/
	tar cvzf release_dotnet.tar.gz release_dotnet
	rm -rf ./release_dotnet

release: mono_release
