@ECHO OFF

set /p addMsg=Voeg een Commit bericht toe: 
start /b cmd.exe /c git add -A
timeout 5
start /b cmd.exe /c git commit -m "%addMsg%"
timeout 5
start /b cmd.exe /c git push
pause