@ECHO OFF

set /p addMsg=Voeg een Commit bericht toe: 
start /b cmd.exe /c git add -A
start /b cmd.exe /c git commit -m "%addMsg%"
start /b cmd.exe /c git push
pause