angular.module('app').controller('AvaliarController', function ($scope, $routeParams, toastr, estabService, authService, fotoService) {

  estabService.buscarEstabelecimentoPorId($routeParams.IdEstabelecimento).then(
    function(response){
      $scope.estabelecimento = response.data
    }
  )
  let nomeFotoAvaliacao;
  $scope.usuarioLogado = authService.getUsuario();
  $scope.comTodasPreferencias = true;

  $scope.addFoto = function(){
    var file = document.getElementById('file').files[0];
    var fd = new FormData();
    fd.append('file', file);
    nomeFotoAvaliacao = file.name;
    $scope.adicionarPreferencias();
    fotoService.addFoto(fd).then(
      function(response){
        console.log("Foto adicionada com sucesso!");
      }, function(response){
      })
    
  };  
       $scope.adicionarPreferencias = function () {
       console.log($scope.idPreferencias)
        usuarioService.adicionarPreferencias($scope.idPreferencias, usuarioLogado.Id)
      }

  $scope.avaliacao
  $scope.avaliar = function(avaliacao){
    console.log(authService.getUsuario())
    $scope.avaliacao.nota = parseInt($scope.avaliacao.nota)
    $scope.avaliacao.idUsuario = authService.getUsuario().Id
    $scope.avaliacao.IdEstabelecimento = parseInt($routeParams.IdEstabelecimento)
    avaliacao.FotoAvaliacao = nomeFotoAvaliacao;
    console.log(avaliacao);
    estabService.criarAvaliacao(avaliacao).then(
      function(response){
        console.log(response)
        toastr.success('Avaliação feita com sucesso!')
      }, function(response){
        console.log(response)
      }
    )
  }

});
