if not exist %systemroot%\reader_oldtstw.ini copy %systemroot%\reader.ini %systemroot%\reader_oldtstw.ini
if not exist %systemroot%\winsig_oldtstw.ini copy %systemroot%\winsig.ini %systemroot%\winsig_oldtstw.ini
if not exist %systemroot%\winros_oldtstw.ini copy %systemroot%\winros.ini %systemroot%\winros_oldtstw.ini

copy reader.ini %systemroot%
copy winsig.ini %systemroot%
copy winros.ini %systemroot%

@echo *
@echo *
@echo *
@echo ********** 安 裝 完 成 **********
@echo *
@echo *
@echo *
@echo off
pause