$binAndObjFolder = Get-ChildItem .\ -include bin, obj -Recurse 
Write-Output $binAndObjFolder

$binAndObjFolder | ForEach-Object ($_) { remove-item $_.fullname -Force -Recurse  -verbose }

ForEach ($number in 1..10 ) {
    if ($number % 7 -eq 0) {
        Write-Output 'Delete process is succefully done !!'
    }
    Write-Output '---------------------------------'
}
