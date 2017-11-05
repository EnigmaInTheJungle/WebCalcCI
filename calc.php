<?php

if (is_array($_GET) && !empty($_GET))
{
	calc($_GET['num1'],$_GET['num2'],$_GET['opr']);
}
else if(is_array($_POST) && !empty($_POST))
{
	calc($_POST['num1'],$_POST['num2'],$_POST['opr']);
}

function calc($a, $b, $op)
{
	$res = 0;
	switch($op)
	{
		case 'p': 	
			$res = $a+$b; 
			break;
		case '-': 
			$res = $a-$b; 
			break;
		case '*': 
			$res = $a*$b; 
			break;
		case '/': 
			$res = $a/$b; 
			break;
		default: 
			$res = "Unexpected error";
	}
	echo $res;
}
?>