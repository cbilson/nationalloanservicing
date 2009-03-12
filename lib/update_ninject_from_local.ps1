$ninjectAssemblies = ls Ninject*
foreach ($file in $ninjectAssemblies) {
	$src = [io.Path]::Combine('..\..\ninject\bin\net-3.5\debug', $file.Name)
	cp $src . 
}
