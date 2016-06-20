@ECHO OFF

set /p addMsg=Voeg een Commit bericht toe: 
start /b cmd.exe /c git add -A
pause
start /b cmd.exe /c git commit -m "%addMsg%"
pause
start /b cmd.exe /c git push
pause

pause