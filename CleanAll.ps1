$binAndObjFolder = Get-ChildItem .\ -include bin, obj -Recurse 
Write-Output $binAndObjFolder

$count = 0
$binAndObjFolder | ForEach-Object ($_) { 
    count++;
    Start-Sleep -Second 3
    Write-Output $count
    remove-item $_.fullname -Force -Recurse  -verbose }

ForEach ($number in 1..10 ) {
    if ($number % 7 -eq 0) {
        Write-Output 'Delete process is succefully done !!'
    }
    Write-Output '---------------------------------'
}
