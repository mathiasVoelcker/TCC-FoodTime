angular.module('app')
  .directive('cwiHeader', function (authService, $rootScope) {
    return {
      restrict: 'E',
      scope: {},
      templateUrl: '../home/header.directive.html',

      controller: function ($scope, usuarioService, authService, $http) {

        atualizarUsuario();

        $scope.logout = authService.logout;

        $rootScope.$on('authLoginSuccess', function () {
          atualizarUsuario();
        });

        $rootScope.$on('authLogoutSuccess', function () {
          atualizarUsuario();
        });

        function atualizarUsuario() {
          $scope.usuario = authService.getUsuario();
          console.log(authService.getUsuario())
        }

        var idUsuario = authService.getUsuario().Id;
        
          usuarioService.buscarSolicitacoesGrupo(idUsuario).then(
            function(response){
              console.log(response)
              $scope.solicitacoes = response.data
            }
          )
        
          $scope.aceitarSolicitacao = function(idGrupo){
            usuarioService.aprovarSolicitacao(idGrupo, idUsuario).then(
              function(response){
                console.log(response)
                toastr.success('Você agora faz parte deste grupo!');
              }
            )
          }

      }
    }

  });


