angular.module('app')
.controller('PerfilUsuarioController', function ($scope, authService, $http, usuarioService) {

    function buscarUsuario(id){
        usuariosService.getUsuario(id)
        .then(function (response){
            $scope.usuario = response.data;
        })
    }
});