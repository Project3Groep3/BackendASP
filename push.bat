@ECHO OFF

set /p addMsg=Voeg een Commit bericht toe: 
start /b cmd.exe /c git add -A
sleep 3
start /b cmd.exe /c git commit -m "%addMsg%"
sleep 5
start /b cmd.exe /c git push


pause