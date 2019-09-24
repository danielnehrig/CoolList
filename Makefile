COMPILER = mcs
DISTPATH = ./dist/
SRCPATH = ./src/
EXENAME = Program.exe
DLLNAME = CoolList.dll

dll:
	$(COMPILER) -target:library ${SRCPATH}CoolList/*.cs -out:$(DISTPATH)$(DLLNAME)

prog:
	$(COMPILER) -r:$(DISTPATH)$(DLLNAME) $(SRCPATH)*.cs -out:$(DISTPATH)$(EXENAME)

start:
	mono $(DISTPATH)$(EXENAME)

build: clean dll prog start

clean:
	rm -rf $(DISTPATH)*
