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
