angular.module('app').controller('AvaliarController', function ($scope, $routeParams, toastr, usuarioService, estabService, authService, fotoService) {

  $scope.idPreferencias = []
  $scope.semFoto = false;
  $scope.adicionarPreferencias = function (idPreferencia) {
    $scope.idPreferencias.push(idPreferencia)
    console.log($scope.idPreferencias)
  }

  $scope.idEstabelecimento = parseInt($routeParams.IdEstabelecimento)

  $scope.removerPreferencias = function(idPreferencia){
    $scope.idPreferencias.splice(($scope.idPreferencias.indexOf(idPreferencia)), 1);
    console.log($scope.idPreferencias)
  }

  estabService.buscarEstabelecimentoPorId($scope.idEstabelecimento).then(
    function(response){
      $scope.estabelecimento = response.data
    }
  )
  let nomeFotoAvaliacao;
  $scope.usuarioLogado = authService.getUsuario();
  $scope.comTodasPreferencias = true;

  $scope.addFoto = function(file){
    var fd = new FormData();
    fd.append('file', file);
    nomeFotoAvaliacao = file.name;
    // $scope.adicionarPreferencias();
    fotoService.addFoto(fd).then(
      function(response){
        console.log("Foto adicionada com sucesso!");
      }, function(response){
      })

    };


    $scope.avaliacao
    $scope.avaliar = function(avaliacao){
      // debugger
      var file = document.getElementById('file').files[0];
      if(file != undefined){
        if($scope.formAvaliacao.$valid){
          console.log(authService.getUsuario())
          $scope.avaliacao.nota = parseInt($scope.avaliacao.nota)
          $scope.avaliacao.idUsuario = authService.getUsuario().Id
          $scope.avaliacao.IdEstabelecimento = $scope.idEstabelecimento
          avaliacao.FotoAvaliacao = file.name;
          $scope.addFoto(file)
          console.log(avaliacao);
          estabService.criarAvaliacao(avaliacao).then(
            function(response){
              console.log(response)
              toastr.success('Avaliação feita com sucesso!')
              if($scope.idPreferencias.length > 0){
                estabService.adicionarPreferencias($scope.idPreferencias, $scope.avaliacao.IdEstabelecimento).then(
                  function(response){
                    console.log(response)
                  }
                )
              }
            }, function(response){
              console.log(response)
            }
          )
        }
      }
      else{
        $scope.semFoto = true;
      }
    }

  });
