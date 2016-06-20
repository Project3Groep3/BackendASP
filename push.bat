@ECHO OFF

set /p addMsg=Voeg een Commit bericht toe: 
start /b cmd.exe /c git add -A
timeout 3
start /b cmd.exe /c git commit -m "%addMsg%"
timeout 3
start /b cmd.exe /c git push
timeout 3
pause