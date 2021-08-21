<?php
	require_once 'config.php'; 
	include_once 'verificaLogin.php';
	require_once DBAPI; 

	include(HEADER_TEMPLATE); 
	$db = getConnection();

	if(!isset($_SESSION)) 
    { 
        session_start(); 
    } 

 //Consulta Cliente
	$sql = "SELECT COUNT(*) FROM cliente";
  	$result = $db->query($sql);

	$found = $result->fetch(PDO::FETCH_ASSOC);
	
	$clientes = implode($found);
//Consulta Produto

	$sql = "SELECT COUNT(*) FROM produto";
  	$result = $db->query($sql);

	$found = $result->fetch(PDO::FETCH_ASSOC);
	
	$produto = implode($found);


	//echo $produto;
//Consulta de Funcionario;
	$sql = "SELECT COUNT(*) FROM funcionario";
  	$result = $db->query($sql);

	$found = $result->fetch(PDO::FETCH_ASSOC);
	
	$funcionario = implode($found);
//Consulta de Orçamentos
	$sql = "SELECT COUNT(*) FROM orcamento";
  	$result = $db->query($sql);

	$found = $result->fetch(PDO::FETCH_ASSOC);
	
	$orçamentos = implode($found);
?>
<header>
	<script src="teste/Chart.js"></script>
</header>

<body>
    <div class="col-xs-12 col-sm-6">
    <canvas class="line-chart"></canvas>
    </div>

    <div class="col-xs-12 col-sm-6">
        <canvas class="bar-chart"></canvas>
    </div>

     <div class="col-xs-12 col-sm-6">
        <canvas class="pie-chart"></canvas>
    </div> 

     <div class="col-xs-12 col-sm-6">
        <canvas class="radar-chart"></canvas>
    </div> 

    <script>
    	
    	var ctx = document.getElementsByClassName("bar-chart");

        var charGraph = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: [""],
                datasets: [{
                    label: "CLIENTES  - 2019",
                    data: [<?php echo $clientes; ?>],
                    borderWidth: 2,
                    borderColor: 'rgba(0,0,255,0.85)',
                    backgroundColor: 'blue',
                },
                {
                    label: "PRODUTOS  - 2019",
                    data: [<?php echo $produto; ?>],
                    borderWidth: 2,
                    borderColor: 'rgba(77,03,01,0.85)',
                    backgroundColor: 'red ',
                },
                {
                    label: "FUNCIONARIOS  - 2019",
                    data: [<?php echo $funcionario; ?>],
                    borderWidth: 2,
                    borderColor: 'rgba(255,255,0,0.85)',
                    backgroundColor: 'yellow ',
                },
                {
                    label: "ORÇAMENTOS  - 2019",
                    data: [<?php echo $orçamentos; ?>],
                    borderWidth: 2,
                    borderColor: 'rgba(0,128,0,0.85)',
                    backgroundColor: 'green ',
                }
                ]
            },
            options:{
            	scales:{
            		yAxes:[{
            			ticks:{
            				beginAtZero: true
            			}
            		}]
            	},
                title:{
                    display: true,
                    fontSize: 20,
                    fontColor: 'rgb(255,255,255)',
                    text: "CADASTROS 2019"
                },
                
                    fontStyle: "bold",
                     legend:{display: true, position:'top',labels:{fontColor: 'rbg(255,255,255)',fontSize: 14}}
                
            }
           
        });

        var ctx = document.getElementsByClassName("line-chart");

        var charGraph = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["Jan","Fev","Mar","Abri"],
                datasets: [{
                    label: "GANHOS - 2019",
                    data: [100,320,450,800],
                    borderWidth: 6,
                    borderColor: 'rgba(75,0,130,0.85)',
                    backgroundColor: 'transparent',
                },
                {
                    label: "DESPESAS - 2019",
                    data: [500,540,320,150],
                    borderWidth: 6,
                    borderColor: 'rgba(173,255,47,0.85)',
                    backgroundColor: 'transparent ',
                }
                ]
            },
            options:{
                title:{
                    display: true,
                    fontSize: 20,
                    fontColor: 'rgb(255,255,255)',
                    text: "RELATORIO DE DESPESAS ANUAIS"
                },
                
                    fontStyle: "bold",
                    fontColor: 'rbg(255,255,255)',fontSize: 14
                
            }
           
        });

        var ctx = document.getElementsByClassName("pie-chart");

        var charGraph = new Chart(ctx, {
            type: 'horizontalBar',
            data: {
                labels: [""],
                datasets: [
                {
                    label: "PRODUTOS  - 2019",
                    data: [<?php echo $produto; ?>],
                    borderWidth: 2,
                    borderColor: 'rgba(250,128,114,0.85)',
                    backgroundColor: 'red ',
                },
                {
                    label: "FUNCIONARIOS  - 2019",
                    data: [<?php echo $funcionario; ?>],
                    borderWidth: 2,
                    borderColor: 'rgba(255,255,0,0.85)',
                    backgroundColor: 'yellow ',
                }
                ]
            },
            options:{
            	scales:{
            		xAxes:[{
            			ticks:{
            				beginAtZero: true
            			}
            		}]
            	},
                title:{
                    display: true,
                    fontSize: 20,
                    fontColor: 'rgb(255,255,255)',
                    text: "QUANTIDADE DE FUNCIONARIOS E PRODUTOS 2019"
                },
               
                fontStyle: "bold",
                legend:{display: true, position:'top',labels:{fontColor: 'rbg(255,255,255)',fontSize: 14}}
                
            }
           
        });

         var bar = document.getElementsByClassName("radar-chart");

        var charGraph = new Chart(bar, {
            type: 'doughnut',
            data: {
                labels: ["Jan","Fev","Mar","Abri"],
                datasets: [{
                    label: "RENDIMENTO - 2019",
                    backgroundColor: ['purple','Salmon','Aquamarine','orange'],
                    borderColor: ['purple','Salmon','Aquamarine','orange'],
                    data: [10,50,64,85],
                },      
                ]
            },
            options:{
                title:{
                    display: true,
                    fontSize: 20,
                    fontColor: 'rgb(255,255,255)',
                    text: "RENDIMENTO MENSAL"
                },
                fontStyle: "bold",
                legend:{display: true, position:'top',labels:{fontColor: 'rbg(255,255,255)',fontSize: 14}}
            }
           
        });
    </script>

</body>

