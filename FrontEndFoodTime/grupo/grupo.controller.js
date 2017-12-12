angular.module('app')
.controller('GrupoController', function ($scope, authService, usuarioService, grupoService, $http) {

  // $scope.mostraTabela = false
  // $scope.naoEncontrou = false
  // $scope.usuarios
  // $scope.grupo = {Nome: "", Imagem: "https://image.freepik.com/icones-gratis/grupo-de-homens_318-62649.jpg", IdUsuarios: []};
  // $scope.solicitacoes = []




    grupoService.buscarGrupoPorUsuario(authService.getUsuario().Id).then(
      function(response){
        console.log(response)
        $scope.gruposUsuario = response.data
      }
    )

  });
