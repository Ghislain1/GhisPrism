$binAndObjFolder = Get-ChildItem .\ -include bin, obj -Recurse 
Write-Output $binAndObjFolder

$count = 0
$binAndObjFolder | ForEach-Object ($_) { 
    $count++;
    Start-Sleep -Second 3
    Write-Output   ""
    Write-Output " Folder Nr > '$count'"  
    remove-item $_.fullname -Force -Recurse  -verbose }

ForEach ($number in 1..10 ) {
    if ($number % 7 -eq 0) {
        Write-Output 'How to use ForEach with Number in Powershell Script'
    }
    Write-Output '---------------------------------'
}

$csprojList = Get-ChildItem .\ -Filter "*.csproj" -Recurse
$count = 0
$csprojList | ForEach-Object ($_) { 
    $count++;
    Write-Output $_.fullname
}
Write-Host -ForegroundColor Green "Number of Project in Solution is: $count"

