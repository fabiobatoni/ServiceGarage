<?php

if(session_status()==PHP_SESSION_NONE)
{
	session_start();
}


	if (!$_SESSION['usuario'])
	{
		header('Location: http://localhost/Oficina/index.php');
		exit();
	}
?>