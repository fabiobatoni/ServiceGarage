<?php
session_start();
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title>Garage | Login</title>
	<meta charset="utf-8">
	<link rel="icon" type="img/jpg" href="img/car.png">	
	<link href="css/bootstrap.min.css" rel="stylesheet">
  	<link rel="stylesheet" type="text/css" href="css/login.css">
  	<script src="js/jquery-3.4.1.min.js"></script>
  	<script src="js/bootstrap.min.js"></script>
</head>
<body>
	<div class="wrapper fadeInDown">
		<div id="formContent">
	    	<div class="fadeIn first">
	    		<img src="img/car.png" id="logo" alt="User Icon"/>
	    	</div>
	    	<form name="login" method="post" action="login.php">
	    		<input type="text" id="email" class="fadeIn second" name="usuario" placeholder="Usuário" required="">
		      	<input type="password" id="senha" class="fadeIn third" name="senha" placeholder="Senha" required="">
		      	<input type="submit" class="fadeIn fourth" value="Entrar">
		      	<?php
					if(isset($_SESSION['nao_autenticado'])):
					?>
					<br>
					<div class="alert alert-danger" role="alert" align="center">
						<p>Usuário ou senha inválidos ou usuário inativo</p>
					</div>
					<?php
					endif;
					unset($_SESSION['nao_autenticado']);
				?>
		    </form>
	  	</div>
	</div>
</body>
</html>