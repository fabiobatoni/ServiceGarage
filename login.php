<?php
	
	session_start();

	include_once './inc/database.php';

	$conn = getConnection();

	$usuario = $_POST['usuario'];
	$senha = $_POST['senha'];

	$sql = "SELECT * FROM usuario WHERE BINARY usu_usuario = :usuario AND BINARY usu_senha = md5(:senha) AND usu_status = 'ATIVO'";

	$stmt = $conn->prepare($sql);
	$stmt->bindValue(':usuario', $usuario);
	$stmt->bindValue(':senha', $senha);
	$stmt->execute();

	$row = $stmt->rowCount();

	if($row == 1)
	{
		$_SESSION['usuario'] = $usuario;
		header('location: dashboard.php');
		exit();
	}
	else
	{
		$_SESSION['nao_autenticado'] = true;
		header('location: index.php');
		exit();
	}

?>